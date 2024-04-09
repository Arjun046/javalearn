using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using NACH.DAL.Data;
using NACH.DAL.Model;
using NACH.API.ControllerModel;
using NACH.API.ControllerModel.Request.User;
using NACH.API.ControllerModel.Response;

using NACH.API.Filter;

using NACH.API.Models.Response;
using NACH.API.Services;
using NACH.API.Utility;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using NACH.API.Controllers;



namespace SmartNachApi.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class UserController : BaseController
    {
        private readonly ICommon _iCommon;
        private readonly ILogger _logger;
        public readonly IEmailSender _emailSender;
        public readonly ISMSSender _smsSender;
        private readonly string key = "3J5vNgaRa#gNZX+uPBYUVKSJJ3RatV%T";
        
        string ls_flag = "";
        string ls_status = "";

        public UserController(
            ILogger<UserController> logger,
            IConfiguration configuration,
            ApplicationDbContext _context,
            ICommon iCommon,
             IEmailSender emailSender,
           ISMSSender smsSender
           )
            : base(configuration, _context)
        {
            _logger = logger;
            _iCommon = iCommon;
            _emailSender = emailSender;
            _smsSender = smsSender;

        }

        [HttpPost]
        //[ValidateSession]
        [Route("add-user")]
        public async Task<IActionResult> userAdd(UserAddModel userAddModel)
        {
            if (userAddModel is null)
            {
                return BadRequest(new ErrorResponse { Message = "Invalid client request" });
            }
            try
            {
                var loginUser = await _context.LoginMst.FirstOrDefaultAsync(u => (u.UserId == userAddModel.Username || u.CustUserName == userAddModel.Username));
                if (loginUser != null)
                    return Ok(new ErrorResponse { Message = "User already exists!" });

                var hash = _iCommon.HashPasword(userAddModel.Password, out var salt);

                LoginMst user = new()
                {
                    BankCode = userAddModel.BankCode,
                    BranchCode = userAddModel.BranchCode,
                    UserId = userAddModel.Username.ToLower(),
                    UserName = userAddModel.Name,
                    UserPass = hash,
                    PasswordSalt = salt,
                    ActiveStatus = "1",
                    //UserLevel = userAddModel.Level,
                    RoleId = userAddModel.RoleId,
                    MobileNumber = userAddModel.MobileNo1,
                    Phone = userAddModel.MobileNo2,
                    EmailId = userAddModel.Email,
                    Remarks = userAddModel.Remarks,
                    CreateDate = DateTime.Now,
                    CustUserName = userAddModel.Username.ToUpper(),

                    CreatedBy = userAddModel.UserId,
                    CreatedDate = DateTime.Now,
                    CreatedIp = userAddModel.IpAddress
                };

                await _context.LoginMst.AddAsync(user);
                await _context.SaveChangesAsync();
                _logger.LogInformation("User created a new account with password.");
                await _iCommon.UpdateActivity("Add user : " + user.UserName, userAddModel.UserId, "INSERT");

                return Ok(new SuccessResponse
                {
                    Message = "User has been successfully added"
                });
            }
            catch (Exception ex)
            {
                return Ok(new ErrorResponse { Message = "Failed to create user!" });
            }
        }

        [HttpPut]
        // [ValidateSession]
        [Route("edit-user")]
        public async Task<IActionResult> userEdit(UserEditModel userEditModel)
        {
            if (userEditModel is null)
            {
                return BadRequest(new ErrorResponse { Message = "Invalid client request" });
            }
            try
            {
                var loginUser = await _context.LoginMst.FirstOrDefaultAsync(u => u.UserId == userEditModel.EditUserId);
                if (loginUser == null)
                    return Ok(new ErrorResponse { Message = "User not exists!" });

                var val = await _context.LoginMst.FirstOrDefaultAsync(u => u.UserId != userEditModel.EditUserId);
                if (val != null)
                    return Ok(new ErrorResponse { Message = "Custom User Already Taken by another user!" });

                loginUser.UserName = userEditModel.Name;
                loginUser.ActiveStatus = userEditModel.ActiveStatus;
                //loginUser.UserLevel = userEditModel.Level;
                loginUser.MobileNumber = userEditModel.MobileNo1;
                loginUser.Phone = userEditModel.MobileNo2;
                loginUser.EmailId = userEditModel.Email;
                loginUser.Remarks = userEditModel.Remarks;
                loginUser.RoleId = userEditModel.RoleId;
                //loginUser.CustUserName = userEditModel.CustUserName;

                loginUser.ModifiedBy = userEditModel.UserId;
                loginUser.ModifiedDate = DateTime.Now;
                loginUser.ModifiedIp = userEditModel.IpAddress;

                _context.LoginMst.Update(loginUser);
                await _context.SaveChangesAsync();
                await _iCommon.UpdateActivity("Edit user : " + loginUser.UserName, userEditModel.UserId, "UPDATE");

                return Ok(new SuccessResponse
                {
                    Message = "User has been successfully modify"
                });
            }
            catch (Exception ex)
            {
                return Ok(new ErrorResponse { Message = ex.Message });
            }
        }

        [HttpPost]
        //[ValidateSession]
        [Route("get-user-list")]
        public async Task<IActionResult> userGetList(PaginationFilter request)
        {
            if (request is null)
            {
                return BadRequest(new ErrorResponse { Message = "Invalid client request" });
            }

            var validFilter = new PaginationFilter(request.PageNumber, request.PageSize);

#pragma warning disable CS8601 // Possible null reference assignment.
            var users = await _context.LoginMst
                .OrderBy(x => x.UserId)
                .Select(u => new {
                    UserId = u.UserId,
                    CustUserName = u.CustUserName,
                    Name = u.UserName,
                    MobileNo1 = u.MobileNumber,
                    MobileNo2 = u.Phone,
                    Email = u.EmailId,
                    Remarks = u.Remarks,
                    RoleId = u.RoleId,
                    RoleName = _context.role_Msts.FirstOrDefault(x => x.BankCode == u.BankCode && x.TranCode == u.RoleId).RoleNm,
                    //UserLevel = u.UserLevel,
                    ActiveStatus = u.ActiveStatus == "1" ? "Active" : "InActive",
                    LockStatus = (u.LockoutEnd.HasValue && u.LockoutEnd.Value > DateTime.Now) ? "Y" : "N",
                    CreatedBy = u.CreatedBy,
                    CreatedDate = u.CreatedDate,
                    CreatedIp = u.CreatedIp,
                    ModifiedBy = u.ModifiedBy,
                    ModifiedDate = u.ModifiedDate,
                    ModifiedIp = u.ModifiedIp,
                }).ToListAsync();
#pragma warning restore CS8601 // Possible null reference assignment.

            var totalRecords = await _context.LoginMst.CountAsync();

            var filter = users.Filter(request.FilterContain);
            var result = filter.Skip((validFilter.PageNumber - 1) * validFilter.PageSize)
              .Take(validFilter.PageSize);

            var totalPages = (int)Math.Ceiling((double)filter.Count() / validFilter.PageSize);

            return Ok(new PagedResponse
            {
                PageSize = validFilter.PageSize,
                PageNumber = validFilter.PageNumber,
                TotalRecords = totalRecords,
                FilterRecords = string.IsNullOrEmpty(request.FilterContain) ? 0 : filter.Count(),
                TotalPages = totalPages,
                Message = "",
                Response = result
            });
        }

        [HttpPost]
        //[ValidateSession]
        [Route("get-user")]
        public async Task<IActionResult> userGet(UserGetModel user)
        {
            if (user is null)
            {
                return BadRequest(new ErrorResponse { Message = "Invalid client request" });
            }
#pragma warning disable CS8601 // Possible null reference assignment.
            var model = await _context.LoginMst
                .Where(u => u.UserId == user.ForUserId)
                .Select(u => new {
                    UserId = u.UserId,
                    Name = u.UserName,
                    CustUserName = u.CustUserName,
                    MobileNo1 = u.MobileNumber,
                    MobileNo2 = u.Phone,
                    Email = u.EmailId,
                    Remarks = u.Remarks,
                    RoleId = u.RoleId,
                    RoleName = _context.role_Msts.FirstOrDefault(x => x.BankCode == u.BankCode && x.TranCode == u.RoleId).RoleNm,
                    ActiveStatus = u.ActiveStatus,
                    LockStatus = (u.LockoutEnd.HasValue && u.LockoutEnd.Value > DateTime.Now) ? "Y" : "N",

                    CreatedBy = u.CreatedBy,
                    CreatedDate = u.CreatedDate,
                    CreatedIp = u.CreatedIp,
                    ModifiedBy = u.ModifiedBy,
                    ModifiedDate = u.ModifiedDate,
                    ModifiedIp = u.ModifiedIp,
                }).FirstOrDefaultAsync();
#pragma warning restore CS8601 // Possible null reference assignment.

            return Ok(new SuccessResponse
            {
                Response = model
            });
        }
        [HttpPost]
        [Route("login")]
        [AllowAnonymous]
        public async Task<IActionResult> Login(LoginModel loginModel)
        {
            if (loginModel is null)
            {
                return BadRequest(new ErrorResponse { Message = "Invalid client request!" });
            }

            loginModel.Password = _iCommon.Decrypt(loginModel.Password, key);

            _ = int.TryParse(_configuration["IdentityDefaultOptions:LockoutMaxFailedAccessAttempts"], out int lockoutMaxFailedAccessAttempts);
            _ = int.TryParse(_configuration["IdentityDefaultOptions:LockoutDefaultLockoutTimeSpanInMinutes"], out int lockoutDefaultLockoutTimeSpanInMinutes);

            var user = await _context.LoginMst.FirstOrDefaultAsync(x => (x.UserId == loginModel.UserId || x.CustUserName == loginModel.UserId));
            if (user is null)
            {
                _logger.LogWarning("Invalid username!");
                await InserLoginHistory(true, false, loginModel);
                return Ok(new ErrorResponse { Message = "Invalid username!" });
            }

            if (user.LockoutEnd.HasValue && user.LockoutEnd.Value > DateTime.Now)
            {

                TimeSpan ts = (user.LockoutEnd.Value - DateTime.Now);
                string msg = string.Format("Your account has been locked due to multiple failed login attempts.! ({0} minutes left to unlock)", (int)ts.TotalMinutes);
                _logger.LogWarning(msg);
                return Ok(new ErrorResponse { Message = msg });

            }
            else if (user.ActiveStatus != "1")
            {
                _logger.LogWarning("User InActive.");
                return Ok(new ErrorResponse { Message = "User is In-Active Please contact system administrator.!" });
            }
            else if (_iCommon.VerifyPassword(loginModel.Password, user.UserPass, user.PasswordSalt))
            {
                await InserLoginHistory(true, true, loginModel);

                _logger.LogInformation("User logged in.");
                string sessionId = GetUniqueKey(20);

                var authClaims = new List<Claim>
                {
                    new Claim(ClaimTypes.Name, loginModel.UserId.ToLower()),
                    new Claim(ClaimTypes.Thumbprint, sessionId),
                    new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString()),
                };

                var token = CreateToken(authClaims);
                var newRefreshToken = GenerateRefreshToken();

                _ = int.TryParse(_configuration["JwtAuth:RefreshTokenValidityInMinutes"], out int refreshTokenValidityInMinutes);

                user.SessionId = sessionId;
                user.AccessFailedCount = 0;
                user.LockoutEnd = null;
                user.RefreshToken = newRefreshToken;
                user.RefreshTokenExpiryTime = DateTime.Now.AddMinutes(refreshTokenValidityInMinutes);
                _context.LoginMst.Update(user);
                await _context.SaveChangesAsync();

                return Ok(new SuccessResponse
                {
                    Response = new
                    {
                        UserId = user.UserId.ToLower(),
                        UserName = user.UserName,
                        ShortUserName = user.UserName.Length > 15 ? user.UserName.Substring(0, 15) : user.UserName,
                        BankCode = user.BankCode,
                        BranchCode = user.BranchCode,
                        //UserLevel = user.UserLevel,
                        RoleId = user.RoleId,
                        RoleName = _context.role_Msts.FirstOrDefault(x => x.BankCode == user.BankCode && x.TranCode == user.RoleId)?.RoleNm,
                        RoleType = _context.role_Msts.FirstOrDefault(x => x.BankCode == user.BankCode && x.TranCode == user.RoleId)?.RoleType,
                        LastLoginDate = user.LastLoginDate.HasValue ? user.LastLoginDate.Value.ToString() : null,
                        ResetFlag = user.ResetFlag ?? "N",
                        Token = new
                        {
                            AccessToken = new JwtSecurityTokenHandler().WriteToken(token),
                            RefreshToken = newRefreshToken,
                            Expiration = token.ValidTo,
                            RefreshTokenExpiryTime = user.RefreshTokenExpiryTime
                        },
                    }
                });
            }
            else if (user.LockoutEnabled && user.AccessFailedCount < lockoutMaxFailedAccessAttempts)
            {
                user.AccessFailedCount += 1;
                user.LockoutEnd = user.AccessFailedCount >= lockoutMaxFailedAccessAttempts ? DateTime.Now.AddMinutes(lockoutDefaultLockoutTimeSpanInMinutes) : null;
                _context.LoginMst.Update(user);
                await _context.SaveChangesAsync();
                await InserLoginHistory(true, false, loginModel);

                TimeSpan? ts;
                string msg = string.Empty;
                if (lockoutMaxFailedAccessAttempts < user.AccessFailedCount)
                {
                    ts = user.LockoutEnd.HasValue ? (user.LockoutEnd.Value - DateTime.Now) : null;
                    msg = string.Format(" ({0} minutes left to unlock)", ts.Value.TotalMinutes);
                }
                string msg2 = lockoutMaxFailedAccessAttempts > user.AccessFailedCount ? string.Format("Invalid credentials, {0} login attempts remaining", (lockoutMaxFailedAccessAttempts - user.AccessFailedCount)) : ("Your account has been locked due to multiple failed login attempts." + msg);
                _logger.LogWarning(msg2);
                return Ok(new ErrorResponse { Message = msg2 });
            }
            else
            {
                _logger.LogWarning("Invalid user id or password!");
                return Ok(new ErrorResponse { Message = "Invalid user id or password!" });
            }
        }


        private async Task InserLoginHistory(bool IsLoginAction, bool _IsSuccess, LoginModel _LoginViewModel)
        {
            var _Headers = HttpContext.Request.Headers["User-Agent"];

            user_time_log vm = new user_time_log { };

            if (IsLoginAction)
            {
                vm.UserId = _LoginViewModel.UserId;
                vm.ClockIntime = DateTime.Now;
                vm.WorkHours = 0;
                vm.WorkMinutes = 0;
                vm.InLatitde = _LoginViewModel.Latitude;
                vm.InLongitude = _LoginViewModel.Longitude;
                vm.WorkMinutes = 0;
                vm.Remarks = "Login";
                _iCommon.UpdateLoginActivity(_LoginViewModel).Wait();
            }
            else
            {
                var _LoginHistory = _context.user_Time_Logs.Where(x => x.UserId == _LoginViewModel.UserId && x.Remarks == "Login").OrderByDescending(x => x.ClockIntime).Take(1).SingleOrDefault();
                if (_LoginHistory != null)
                {
                    vm.TranCode = _LoginHistory.TranCode;
                    vm.UserId = _LoginHistory.UserId;
                    vm.InLatitde = _LoginHistory.InLatitde;
                    vm.InLongitude = _LoginHistory.InLongitude;

                    vm.OutLatitde = _LoginViewModel.Latitude;
                    vm.OutLongitude = _LoginViewModel.Longitude;
                    vm.ClockIntime = _LoginHistory.ClockIntime; //Bug null
                    vm.WorkHours = (int)(DateTime.Now - _LoginHistory.ClockIntime).TotalHours;
                    vm.WorkMinutes = (int)(DateTime.Now - _LoginHistory.ClockIntime).TotalMinutes;
                }
                vm.ClockOuttime = DateTime.Now;
                vm.Remarks = "Manually Logout";
            }
            _iCommon.InsertLoginHistory(vm);
        }



        [HttpPost]
        //[ValidateSession]
        [Route("logout")]
        public async Task<IActionResult> Logout(BaseRequestModel request)
        {

            LoginModel _LoginModel = new LoginModel()
            {
                UserId = request.UserId,
                Latitude = request.Latitude,
                Longitude = request.Longitude,
            };
            await InserLoginHistory(false, true, _LoginModel);
            _logger.LogInformation("User logged out.");
            return Ok(new SuccessResponse { Message = "successfully logout" });
        }


        [HttpPost]
        [Route("change-password")]
        public async Task<IActionResult> ChangePassword(ChangePasswordModel request)
        {
            if (request is null)
            {
                return BadRequest(new ErrorResponse { Message = "Invalid client request!" });
            }

            var user = await _context.LoginMst.FirstOrDefaultAsync(x => (x.UserId == request.UserId || x.CustUserName == request.UserId));
            if (user != null)
            {

                request.CurrentPassword = _iCommon.Decrypt(request.CurrentPassword, key);

                if (_iCommon.VerifyPassword(request.CurrentPassword, user.UserPass, user.PasswordSalt))
                {

                    request.Password = _iCommon.Decrypt(request.Password, key);

                    var hash = _iCommon.HashPasword(request.Password, out var salt);
                    user.UserPass = hash;
                    user.PasswordSalt = salt;
                    user.ResetFlag = "N";

                    await _context.SaveChangesAsync();
                    await _iCommon.UpdateActivity(string.Format("CHANGE PASSWORD : {0}", request.UserId), request.UserId, "UPDATE");

                    _logger.LogWarning("Password has been successfully changed.!");
                    return Ok(new SuccessResponse { Message = "Password has been successfully changed.!" });
                }
                else
                {
                    _logger.LogWarning("Current password is incorrect!");
                    return Ok(new ErrorResponse { Message = "Current password is incorrect!" });
                }
            }
            else
            {
                _logger.LogWarning("Invalid user id or password!");
                return Ok(new ErrorResponse { Message = "Invalid user id or password!" });
            }
        }



        [HttpPost]
        [AllowAnonymous]
        [Route("verify-otp")]
        public async Task<IActionResult> VerifyOTP(VerifyOTPModel1 request)
        {
            if (request is null)
            {
                return BadRequest(new ErrorResponse { Message = "Invalid client request!" });
            }

            request.Password = _iCommon.Decrypt(request.Password, key);
            request.ConfirmPassword = _iCommon.Decrypt(request.ConfirmPassword, key);

            if (request.Password == request.ConfirmPassword)
            {
                var user = await _context.LoginMst.Where(u => (u.UserId == request.UserId || u.CustUserName == request.UserId)
                && u.MobileNumber == request.MobileNo
                && u.OTPCode == request.OTP
                && u.OTPStatus == "P"
                && u.ActiveStatus == "1").ToListAsync();

                if (user.Count == 1)
                {
                    user.ForEach(u => {
                        var hash = _iCommon.HashPasword(request.Password, out var salt);

                        u.UserPass = hash;
                        u.PasswordSalt = salt;

                        u.OTPStatus = "Y";
                        u.LastActivity = DateTime.Now;
                    });
                    await _context.SaveChangesAsync();
                    await _iCommon.UpdateActivity(string.Format("VERIFY PASSWORD : {0}", request.UserId), request.UserId, "UPDATE");

                    _logger.LogWarning("Password has been successfully changed.!");
                    return Ok(new SuccessResponse { Message = "Password has been successfully changed.!" });

                }
                else
                {
                    _logger.LogWarning("Invalid OTP code!");
                    return Ok(new ErrorResponse { Message = "Invalid OTP code!" });
                }
            }
            else
            {
                _logger.LogWarning("Your password or confirm password not match.!");
                return Ok(new ErrorResponse { Message = "Your password or confirm password not match.!" });
            }
        }
    }
}