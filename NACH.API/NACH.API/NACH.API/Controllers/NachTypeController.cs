using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using NACH.DAL.Data;
using NACH.DAL.Model;
using NACH.API.ControllerModel.Request.BankIIN;
using NACH.API.ControllerModel.Request.NachType;
using NACH.API.ControllerModel.Request.UserRole;
using NACH.API.ControllerModel.Response;

using NACH.API.Services;

namespace NACH.API.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class NachTypeController : BaseController
    {
        private readonly ICommon _iCommon;
        private readonly ApplicationDbContext context;
        public NachTypeController(
                ILogger<NachTypeController> logger,
                IConfiguration configuration,
                ApplicationDbContext context,ICommon iCommon
               )
                : base(context: context)
                    {
                   _iCommon = iCommon;
                    }

        [HttpPost]
        [Route("add-nachtype")]
        public async Task<IActionResult> NachTypeAdd(NachTypeAdd request)
        {
            if (request is null)
            {
                return BadRequest(new ErrorResponse { Message = "Invalid NACH Type request" });
            }

            var data = await _context.nach_Type_Msts.FirstOrDefaultAsync(u => u.TranCode == request.TranCode);
            if (data != null)
                return Ok(new ErrorResponse { Message = " NACH Type  already exists!" });

            nach_type_mst model = new nach_type_mst
            {
                TranCode = request.TranCode,
                NachType = request.NachType,
                Description = request.Description
            };

            _context.nach_Type_Msts.Add(model);
            await _context.SaveChangesAsync();

            return Ok(new SuccessResponse
            {
                Message = "NACH Type has been successfully add"
            });
        }


        [HttpPut]
        [Route("edit-nachtype")]
        public async Task<IActionResult> NachTypeEdit(NachTypeAdd request)
        {
            if (request is null)
            {
                return BadRequest(new ErrorResponse { Message = "Invalid Nach Type request" });
            }
            var data = await _context.nach_Type_Msts.FirstOrDefaultAsync(u => u.TranCode == request.TranCode);
            if (data == null)
                return Ok(new ErrorResponse { Message = "Nach Type not exists!" });

            data.TranCode = request.TranCode;
            data.Description = request.Description;
            data.NachType = request.NachType;

            _context.nach_Type_Msts.Update(data);
            await _context.SaveChangesAsync();

            return Ok(new SuccessResponse
            {
                Message = "Nach Type has been successfully update"
            });
        }




        [HttpPost]
        [Route("list-NachType")]
        public IActionResult NachTypeView([FromBody] NachTypeView request)
        {
            if (request is null)
            {
                return BadRequest(new ErrorResponse { Message = "Invalid Nach Type request" });
            }

            var data = _context.nach_Type_Msts
                .Where(x => x.Status == "Y")
                .Select(x => new
                {
                    TranCode = x.TranCode,
                    NachType = x.NachType,
                    Description = x.Description,
                    Status = x.Status
                })
                .OrderByDescending(x => x.TranCode);

            if (data == null)
            {
                return NotFound(new ErrorResponse { Message = "Nach Types not exists" });
            }

            return Ok(new SuccessResponse
            {
                Response = data,
                Message = "Successfully"
            });
        }


        [HttpPost]
        [Route("get-nachtype")]
        public IActionResult NachTypeGet([FromBody] NachTypeGet request)
        {
            if (request is null)
            {
                return BadRequest(new ErrorResponse { Message = "Invalid Nach Type request" });
            }

            var data = _context.nach_Type_Msts
                .Where(x => x.Status == "Y")
                .Select(x => new
                {
                    NachType = x.NachType,
                    Description = x.Description,
                    Status = x.Status
                });

            if (data == null)
            {
                return NotFound(new ErrorResponse { Message = "Nach Type not exists" });
            }

            return Ok(new SuccessResponse
            {
                Response = data
            });
        }


        [HttpPost]
        [Route("Get-NachTypeOfMailSms")]
        public IActionResult GetNachTypeOfMailSms([FromBody] NachTypeGet request)
        {
            if (request is null)
            {
                return BadRequest(new ErrorResponse { Message = "Invalid Nach Type request" });
            }

            var data = _context.nach_Type_Msts
                .Select(x => new
                {
                    TranCode = x.TranCode,
                    NachType = x.NachType,
                    Description = x.Description
                });

            if (data == null)
            {
                return NotFound(new ErrorResponse { Message = "Nach Types not exists" });
            }

            return Ok(new SuccessResponse
            {
                Response = data,
                Message = "Successfully"
            });
        }



    }
}
