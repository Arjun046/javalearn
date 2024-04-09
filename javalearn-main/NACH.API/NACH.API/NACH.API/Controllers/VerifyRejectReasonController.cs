using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using NACH.DAL.Data;
using NACH.API.ControllerModel.Request.AcctType;
using NACH.API.ControllerModel.Request.VerifyReason;
using NACH.API.ControllerModel.Response;

using NACH.API.Services;
using NACH.API.Controllers;

namespace SmartNachApi.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class VerifyRejectReasonController : BaseController
    {

        private readonly ICommon _icommon;
        private readonly ApplicationDbContext _context;
        public VerifyRejectReasonController(ApplicationDbContext context,ICommon iCommon) 
        {
            _icommon = iCommon;
            _context = context;
        }

        [HttpPost]
        [Route("get-verifyreason")]
        public async Task<IActionResult> VerifyReasonGet([FromBody] verifyReasonGet model)
        {
            if (model is null || model.TranCode == 0)
            {
                return BadRequest(new ErrorResponse { Message = "Invalid verification reason request" });
            }

            var Verify = _context.verify_Reject_Reasons
                .Where(x => x.TranCode == model.TranCode)
                .Select(x => new
                {
                    ReasonCode = x.ReasonCode,
                    TranCode = x.TranCode,
                    ReasonDesc = x.ReasonDesc ?? "", // Use empty string if ReasonDesc is null
                })
                .ToList(); // Execute the query to avoid deferred execution issues

            return Ok(new SuccessResponse
            {
                Message = "Success",
                Response = Verify
            });
        }


    }
}
