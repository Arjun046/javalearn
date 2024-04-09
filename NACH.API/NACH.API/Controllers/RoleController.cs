using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using NACH.DAL.Data;
using NACH.DAL.Model;
using NACH.API.ControllerModel.Request.UserRole;
using NACH.API.ControllerModel.Response;

using NACH.API.Services;

namespace NACH.API.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class RoleController : BaseController
    {
        private readonly ICommon _icommon;
        private readonly ApplicationDbContext context;

        public RoleController(
          ILogger<AcctTypeController> logger,
          IConfiguration configuration,
          ApplicationDbContext context,ICommon iCommon
         )
          : base(context: context)
        {
            _icommon = iCommon;
        }

        [HttpPost]
        [Route("add-role")]
        public async Task<IActionResult> UserRoleAdd(UserRoleAdd request)
        {
            if (request is null)
            {
                return BadRequest(new ErrorResponse { Message = "Invalid User role request" });
            }

            var data = await _context.role_Msts.FirstOrDefaultAsync(u => u.BankCode == request.BankCode);
            if (data != null)
                return Ok(new ErrorResponse { Message = "User role already exists!" });

            role_mst model = new role_mst
            {
                BankCode = request.BankCode,
                RoleNm = request.RoleNm,
                Description = request.Description,
                RoleType = request.RoleType
                
            };

            _context.role_Msts.Add(model);
            await _context.SaveChangesAsync();

            return Ok(new SuccessResponse
            {
                Message = "User Role has been successfully added"
            });
        }



        [HttpPut]
        [Route("edit-role")]
        public async Task<IActionResult> RoleEdit(UserRoleEdit request)
        {
            if (request is null)
            {
                return BadRequest(new ErrorResponse { Message = "Invalid User role request" });
            }

            var data = await _context.role_Msts.FirstOrDefaultAsync(u => u.BankCode == request.BankCode && u.TranCode == request.TranCode);
            if (data == null)
                return Ok(new ErrorResponse { Message = "User role not exists!" });

            
            data.BankCode = request.BankCode;
            data.Description = request.Description;
            data.RoleType = request.RoleType;
            data.RoleNm = request.RoleName;

            

            try
            {
                await _context.SaveChangesAsync();

                return Ok(new SuccessResponse
                {
                    Message = "User Role has been successfully updated"
                });
            }
            catch (Exception ex)
            {
                // Handle exceptions appropriately
                return StatusCode(500, new ErrorResponse { Message = "An error occurred while updating the user role" });
            }
        }


        [HttpPost]
        [Route("get-role")]
        public IActionResult RoleGet([FromBody] UserRoleGet request)
        {
            if (request is null)
            {
                return BadRequest(new ErrorResponse { Message = "Invalid User role request" });
            }

            var data = _context.role_Msts
                .Where(x => x.BankCode == request.BankCode)
                .Select(x => new
                {
                    BankCode = x.BankCode,
                    TranCode = x.TranCode,
                    RoleNm = x.RoleNm,
                    Description = x.Description,
                    RoleType = x.RoleType
                })
                .OrderByDescending(x => x.TranCode); 

           

            return Ok(new SuccessResponse
            {
                Response = data
            });
        }

        [HttpPost]
        [Route("get-Role")]
        public IActionResult getUserRole([FromBody] UserRoleGet request)
        {
            if (request is null)
            {
                return BadRequest(new ErrorResponse { Message = "Invalid User role request" });
            }

            var data = _context.role_Msts
                .Where(x => x.BankCode == request.BankCode)
                .Select(x => new
                {
                    TranCode = x.TranCode,
                    RoleNm = x.RoleNm,
                    BankCode = x.BankCode
                });

            
            return Ok(new SuccessResponse
            {
                Response = data
            });
        }



    }
}
