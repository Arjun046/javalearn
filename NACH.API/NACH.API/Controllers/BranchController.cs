using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using NACH.DAL.Data;
using NACH.DAL.Model;
using NACH.API.ControllerModel;
using NACH.API.ControllerModel.Request.Branch;
using NACH.API.ControllerModel.Request.NachType;
using NACH.API.ControllerModel.Request.UserPermission;
using NACH.API.ControllerModel.Response;

using NACH.API.Services;
using NACH.API.ControllerModel.Request.Branch;

namespace NACH.API.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class BranchController : BaseController
    {
        private readonly ApplicationDbContext context;
        private readonly ICommon _iCommon;
        public BranchController(
       ILogger<BranchController> logger,
       IConfiguration configuration,
       ApplicationDbContext context,
         ICommon iCommon)
       : base(context: context)
        {
            _iCommon = iCommon;

        }

        [HttpPost]
        [Route("add-branch")]
        //[UserPermission(PermissionEnum.Form.BRANCH, PermissionEnum.Rights.ADD)]
        public async Task<IActionResult> BranchAdd(BranchModel request)
        {
            if (request is null)
            {
                return BadRequest(new ErrorResponse { Message = "Invalid client request" });
            }
            var val = await _context.branch_Msts.FirstOrDefaultAsync(u => u.BankCode == request.BankCode && u.BranchCode == request.BranchCode);
            if (val != null)
                return Ok(new ErrorResponse { Message = "Branch already exists!" });

            BranchMst branch = new BranchMst
            {
                BankCode = request.BankCode,
                BranchCode = request.BranchCode,
                BranchName = request.BranchName,
                Address = request.Address,
                CityName = request.City,
                PinCode = request.PinCode,
                ContactPerson = request.ContactPerson,
                Phone = request.Phone,
                Mobile = request.Mobile,
                Email = request.Email,
                StateCode = request.StateCode,
                CountryCode = request.CountryCode,
                MicrCode = request.MicrCode,
                IfscCode = request.IfscCode,

                CreatedBy = request.UserId,
                CreatedDate = DateTime.Now,
                CreatedIp = request.IpAddress
            };

            _context.branch_Msts.Add(branch);
            await _context.SaveChangesAsync();

            return Ok(new SuccessResponse
            {
                Message = "Branch has been successfully added"
            });
        }


        [HttpPut]
        [Route("edit-Branch")]
        public async Task<IActionResult> BranchEdit(BranchEdit request)
        {
            if (request is null)
            {
                return BadRequest(new ErrorResponse { Message = "Invalid Branch request" });
            }
            var data = await _context.branch_Msts.FirstOrDefaultAsync(u => u.BankCode == request.BankCode && u.BranchCode==request.BranchCode);
            if (data == null)
                return Ok(new ErrorResponse { Message = "Branch not exists!" });

            data.BankCode = request.BankCode;
            data.BranchCode = request.BranchCode;
            data.CityName = request.City;
            data.BranchName = request.BranchName;
            data.Address= request.Address;
            data.CountryCode = request.CountryCode;
            data.MicrCode = request.MicrCode;
            data.IfscCode = request.IfscCode;
            data.Phone = request.Phone;
            data.Mobile = request.Mobile;
            data.Email = request.Email;
            data.StateCode = request.StateCode;
            data.CountryCode= request.CountryCode;
            data.ContactPerson = request.ContactPerson;

            _context.branch_Msts.Update(data);  
            await _context.SaveChangesAsync();

            return Ok(new SuccessResponse
            {
                Message = "Branch has been successfully update"
            });
        }




        [HttpPost]
        [Route("branch-list")]
        public IActionResult BranchView([FromBody] BranchView request)
        {
            if (request is null)
            {
                return BadRequest(new ErrorResponse { Message = "Invalid Branch request" });
            }

            var data = _context.branch_Msts
                .Where(x => x.BankCode == request.BankCode)
                .Select(x => new
                {
                    BankCode = x.BankCode,
                    BranchCode = x.BranchCode,
                    Address = x.Address,
                    
                    CityName = x.CityName,
                    PinCode = x.PinCode,
                    StateCode = x.StateCode,
                    CountryCode = x.CountryCode,
                    ContactPerson = x.ContactPerson,
                    Phone = x.Phone,
                    Mobile = x.Mobile,
                    Email = x.Email,
                    MicrCode = x.MicrCode,
                    IfscCode = x.IfscCode,
                    BranchName = x.BranchName
                });

            return Ok(new SuccessResponse
            {
                Response = data
            });
        }

        [HttpPost]
        [Route("Get-branch")]
        public IActionResult BranchGet([FromBody] BranchGet request)
        {
            if (request is null)
            {
                return BadRequest(new ErrorResponse { Message = "Invalid Branch request" });
            }

            var data = _context.branch_Msts
                .Where(x => x.BankCode == request.BankCode)
                .OrderBy(x => x.BranchCode)
                .Select(x => new
                {
                    BankCode = x.BankCode,
                    BranchCode = x.BranchCode,
                    MicrCode = x.MicrCode,
                    IfscCode = x.IfscCode,
                    BranchName = x.BranchName
                }); 

           

            return Ok(new SuccessResponse
            {
                Response = data,
            });
        }


        [HttpPost]
        [Route("Get-BranchUserWise")]
        public IActionResult GetBranchUserWise([FromBody] GetBranchUserWise request)
        {
            if (request is null)
                return BadRequest(new ErrorResponse { Message = "Invalid Branch request" });

            var userId = request.UserId;

            var data = (from branch in _context.branch_Msts
                        join permission in _context.user_Permission_Dtls on new { branch.BankCode, branch.BranchCode } equals new { permission.BankCode, permission.BranchCode }
                        where permission.UserId == userId
                        select new { branch.BankCode, branch.BranchCode, branch.BranchName, branch.IfscCode });
            return Ok(new SuccessResponse
            {
                Message = "Success",
                Response = data
            });
        }

        [HttpPost]
        [Route("branch-permission")]
        public IActionResult BranchPermissionGet([FromBody] branchpermissionGet request)
        {
            if (request is null)
            {
                return BadRequest(new ErrorResponse { Message = "Invalid Branch Permission request" });
            }

            var data = _context.branch_Msts
                .Select(x => new
                {
                    B_BranchCode = x.BranchCode,
                    BranchNm = x.BranchName,
                    BankCode = _context.user_Permission_Dtls
                                        .Where(a => a.BranchCode == x.BranchCode && a.UserId == request.UserId)
                                        .Select(a => a.BankCode)
                                        .FirstOrDefault(),

                    BranchCode = _context.user_Permission_Dtls
                                        .Where(a => a.BranchCode == x.BranchCode && a.UserId == request.UserId)
                                        .Select(a => a.BranchCode)
                                        .FirstOrDefault(),

                    UserId = _context.user_Permission_Dtls
                                        .Where(a => a.BranchCode == x.BranchCode && a.UserId == request.UserId)
                                        .Select(a => a.UserId)
                                        .FirstOrDefault(),

                    DefaultSelection = _context.user_Permission_Dtls
                                            .Where(a => a.BranchCode == x.BranchCode && a.UserId == request.UserId)
                                            .Select(a => a.DefaultSelection ?? "N")
                                            .FirstOrDefault(),
                }); 


            return Ok(new SuccessResponse
            {
                Response = data
            });
        }






    }

}
