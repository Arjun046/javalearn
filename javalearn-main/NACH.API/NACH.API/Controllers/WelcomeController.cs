using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using NACH.DAL.Data;
using NACH.API.ControllerModel.Request.User;
using NACH.API.ControllerModel.Response;
using NACH.API.ControllerModel.welcome;

using NACH.API.Services;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;

namespace NACH.API.Controllers
{
    [ApiController]
    public class WelcomeController : BaseController
    {
        private readonly ICommon _iCommon;
        public readonly IEmailSender _emailSender;
        public readonly ISMSSender _smsSender;
        private readonly ILogger _logger;
        public WelcomeController(
            ApplicationDbContext context,
            IConfiguration configuration,
            //IWebHostEnvironment iHostingEnvironment,
            ICommon iCommon,
           IEmailSender emailSender,
           ISMSSender smsSender,
            ILogger<WelcomeController> logger)
            : base(configuration, context)
        {
            _iCommon = iCommon;
            this._emailSender = emailSender;
            this._smsSender = smsSender;
            _logger = logger;
        }

        [HttpGet]
        [Route("get-init")]
        [AllowAnonymous]
        public IActionResult WelcomeInit()
        {
            try
            {
                bool EmailMandatory = _context.parameter_Msts.FirstOrDefault(u => u.ParaCode == "415")?.ParaValue == "Y";
                bool ScreenRecording = _context.parameter_Msts.FirstOrDefault(u => u.ParaCode == "422")?.ParaValue == "Y";
                return Ok(new SuccessResponse
                {
                    Message = "",
                    Response = new { EmailIdMandatory = EmailMandatory, ReqType = "N", FullScreenRecording = ScreenRecording }
                });
            }
            catch (Exception ex)
            {
                return BadRequest(new ErrorResponse { Message = ex.Message });
            }
        }



        [HttpPost]
        [Route("otp-verify")]
        [AllowAnonymous]
        public async Task<IActionResult> VerifyOTP([FromBody] VerifyOTPModel request)
        {
            try
            {
                string ls_message = string.Empty;
                bool EmailMandatory = _context.parameter_Msts.FirstOrDefault(u => u.ParaCode == "415")?.ParaValue == "Y";

                if (string.IsNullOrEmpty(request.LoginMobileNo))
                {
                    return Ok(new ErrorResponse
                    {
                        Message = "Invalid Mobile Number",
                    });
                }
                if (EmailMandatory && string.IsNullOrEmpty(request.LoginEmailId))
                {
                    return Ok(new ErrorResponse
                    {
                        Message = "Invalid Email id",
                    });
                }

#pragma warning disable CS8602 // Dereference of a possibly null reference.
                var _OTPHistory = _context.otp_Msts.Where(x => x.OtpVerify == "P"
                    && x.MobileNumber.Substring(x.MobileNumber.Length - 10, 10) == request.LoginMobileNo.Substring(request.LoginMobileNo.Length - 10, 10)).OrderByDescending(x => x.TranDate).Take(1).SingleOrDefault();
#pragma warning restore CS8602 // Dereference of a possibly null reference.

#pragma warning disable CS8602 // Dereference of a possibly null reference.
                if (_OTPHistory.OtpAttemp >= 3)
                {
                    if (_OTPHistory == null)
                    {
                        return Ok(new ErrorResponse
                        {
                            Message = "Multiple invalid otp attempts",
                        });
                    }
                }
                else
                {
                    bool mobileValid = false;
                    bool emailValid = false;

                    var smsOTP = await _context.otp_Msts.Where(x => x.OtpVerify == "P"
                    && x.MobileNumber.Substring(x.MobileNumber.Length - 10, 10) == request.LoginMobileNo.Substring(request.LoginMobileNo.Length - 10, 10)).OrderByDescending(x => x.TranDate).Take(1).SingleOrDefaultAsync();

                    if (smsOTP.OtpCode == request.SMSOTP)
                    {
                        mobileValid = true;
                    }
                    else
                    {
                        smsOTP.OtpAttemp += 1;
                        _context.otp_Msts.Update(smsOTP);
                        await _context.SaveChangesAsync();
                    }

                    if (EmailMandatory)
                    {
                        var emailOTP = await _context.otp_Msts.Where(x => x.MailOtpVerify == "P" && x.EmailId == request.LoginEmailId).OrderByDescending(x => x.TranDate).Take(1).SingleOrDefaultAsync();
                        if (emailOTP.MailOtp == request.EmailOTP)
                        {
                            emailValid = true;
                        }
                    }
                    else
                    {
                        emailValid = true;
                    }

                    if (emailValid && mobileValid)
                    {
                        smsOTP.OtpVerify = "Y";
                        smsOTP.MailOtpVerify = "Y";
                        _context.otp_Msts.Update(smsOTP).State = EntityState.Modified;

                        if (EmailMandatory)
                        {
                            var emailOTP = await _context.otp_Msts.Where(x => x.MailOtpVerify == "P" && x.EmailId == request.LoginEmailId).OrderByDescending(x => x.TranDate).Take(1).SingleOrDefaultAsync();
                            emailOTP.OtpVerify = "Y";
                            emailOTP.MailOtpVerify = "Y";
                            _context.otp_Msts.Update(emailOTP);
                        }
                        await _context.SaveChangesAsync();

                        var authClaims = new List<Claim>
                        {
                            new Claim(ClaimTypes.MobilePhone, request.LoginMobileNo),
                            new Claim(ClaimTypes.Email, request.LoginEmailId),
                            new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString()),
                        };

                        var token = CreateToken(authClaims);
                        return Ok(new SuccessResponse
                        {
                            Response = new
                            {
                                AccessToken = new JwtSecurityTokenHandler().WriteToken(token),
                                Expiration = token.ValidTo
                            }
                        });
                    }
                    else
                    {
                        if (!emailValid && !mobileValid)
                        {
                            ls_message = "Email Id and Mobile OTP Invalid";
                        }
                        else if (!emailValid)
                        {
                            ls_message = "Email Id OTP Invalid";
                        }
                        else if (!mobileValid)
                        {
                            ls_message = "Mobile No OTP Invalid";
                        }
                    }
                }
#pragma warning restore CS8602 // Dereference of a possibly null reference.
                return Ok(new ErrorResponse
                {
                    Message = ls_message,
                });
            }
            catch (Exception ex)
            {
                return BadRequest(new ErrorResponse { Message = ex.Message });
            }
        }

      

      
    }
}