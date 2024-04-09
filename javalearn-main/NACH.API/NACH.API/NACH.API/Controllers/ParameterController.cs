using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using NACH.DAL.Data;
using NACH.API.ControllerModel.Request.NachType;
using NACH.API.ControllerModel.Request.Parameter;
using NACH.API.ControllerModel.Response;

using NACH.API.Services;

namespace NACH.API.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class ParameterController : BaseController
    {
        private readonly ICommon _iCommon;
        private readonly ApplicationDbContext context;
        string ls_flag = "";
        public ParameterController(
           ILogger<ParameterController> logger,
           IConfiguration configuration,
           ApplicationDbContext context,
           ICommon iCommon
          )
           : base(context: context)
        {
          _iCommon = iCommon;

        }

        [HttpPost]
        [Route("get-Parameter")]
        public IActionResult getParameter([FromBody] ParameterGet request)
        {
            if (request is null)
            {
                return BadRequest(new ErrorResponse { Message = "Invalid Parameter request" });
            }

            var data = _context.parameter_Msts
                .Where(x => x.BankCode == request.BankCode && x.BranchCode == request.BranchCode)
                .Select(x => new
                {
                    BankCode = x.BankCode,
                    BranchCode = x.BranchCode,
                    ParaCode = x.ParaCode,
                    ParaDesc = x.ParaDesc,
                    ParaValue = x.ParaValue
                });

            if (data == null)
            {
                return NotFound(new ErrorResponse { Message = "Parameter not exists" });
            }

            return Ok(new SuccessResponse
            {
                Response = data
            });
        }


        [HttpPost]
        [Route("edit-delete-parameter")]    
        public IActionResult Parameter([FromBody] ParameterRequest request)
        {

            if (request.ls_flag == "EDIT")
            {
                var parameterEntity=_context.parameter_Msts.FirstOrDefault(x=>x.BankCode == request.BankCode && x.ParaCode==request.ParaCode);
                if (parameterEntity != null)
                {
                    parameterEntity.ParaValue = request.ParaValue;
                    parameterEntity.ParaDesc = request.ParaDesc;
                    parameterEntity.BankCode = request.BankCode;
                    parameterEntity.ParaCode = request.ParaCode;
                    _context.SaveChanges();
                }
                return Ok(new SuccessResponse
                {
                    Message= "Parameter has been successfully modify"
                });

            }
            else if (request.ls_flag == "DELETE")
            {
                var dataToDelete = _context.parameter_Msts
                    .Where(x => x.BankCode == request.BankCode && x.ParaCode == request.ParaCode);

                _context.parameter_Msts.RemoveRange(dataToDelete);
                _context.SaveChanges();

                return Ok(new SuccessResponse
                {
                    Message = "Parameter has been successfully deleted"
                });
            }
            return Ok(new ErrorResponse
            {
                Message = "Invalid ls_flag value"
            });

        }


    }
}
