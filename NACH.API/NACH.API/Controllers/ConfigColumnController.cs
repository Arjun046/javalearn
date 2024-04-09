using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using NACH.DAL.Data;
using NACH.API.ControllerModel.Request.NachConfigColumn;
using NACH.API.ControllerModel.Request.NachTypeReason;
using NACH.API.ControllerModel.Response;

using NACH.API.Services;

namespace NACH.API.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class ConfigColumnController : BaseController
    {
        private readonly ICommon _iCommon;
        private readonly ApplicationDbContext context;
        public ConfigColumnController(
          ILogger<ConfigColumnController> logger,
          IConfiguration configuration,
          ApplicationDbContext context,ICommon iCommon
         )
          : base(context: context)
        {
           
            _iCommon= iCommon;
        }

        [HttpPost]
        [Route("get-ConfigColumn")]
        public IActionResult getConfigColumn([FromBody] getConfigColumn request)
        {
            if (request is null)
            {
                return BadRequest(new ErrorResponse { Message = "Invalid Nach Config Column request" });
            }

            var data = _context.nach_Config_Columns
                .Where(x => x.BankCode == request.BankCode && x.ColFlag == request.ColFlag)
                .Select(x => new
                {
                    BankCode = x.BankCode,
                    ParaCode = x.ParaCode,
                    Description = x.Description,
                    Paravalue = x.Paravalue,
                    ParaType = x.ParaType,
                    ColFlag = x.ColFlag
                });

            if (data == null)
            {
                return NotFound(new ErrorResponse { Message = "Nach Config Column not exists" });
            }

            return Ok(new SuccessResponse
            {
                Response = data,
                Message = "Success"
            });
        }

    }
}
