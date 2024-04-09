using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using NACH.DAL.Data;
using NACH.API.ControllerModel.Request.DataTemplate;
using NACH.API.ControllerModel.Request.NachType;
using NACH.API.ControllerModel.Response;

using NACH.API.Services;

namespace NACH.API.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class DataTemplateController : BaseController
    {
        private readonly ICommon _iCommon;
        private readonly ApplicationDbContext context;

        public DataTemplateController(
          ILogger<DataTemplateController> logger,
          IConfiguration configuration,
          ApplicationDbContext context,ICommon iCommon
         )
          : base(context: context)
        {
          
            _iCommon = iCommon;
        }

        [HttpPost]
        [Route("get-DataTemplate")]
        public IActionResult getDataTemplate([FromBody] getDataTemplate request)
        {
            if (request is null)
            {
                return BadRequest(new ErrorResponse { Message = "Invalid DataTemplate request" });
            }

            var data = _context.data_Imp_Template_Hdrs
                .Where(x => x.ActiveStatus == "Y" && x.BankCode == request.BankCode && x.BranchCode == request.BranchCode)
                .Select(x => new
                {
                    TranCode = x.TranCode,
                    Description = x.Description,
                    EcbTableNm = x.EcbTableNm,
                    DelimiterSign = x.DelimiterSign,
                    DelimiterCode = x.DelimiterCode,
                    ActiveStatus = x.ActiveStatus,
                    BranchCode = x.BranchCode,
                    BankCode = x.BankCode
                })
                .FirstOrDefault();

            

            return Ok(new SuccessResponse
            {
                Response = data
            });
        }

    }
}
