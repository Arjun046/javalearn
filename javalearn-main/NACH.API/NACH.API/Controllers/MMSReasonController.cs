using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using NACH.DAL.Data;
using NACH.DAL.Model;
using NACH.API.ControllerModel.Request.MmsReason;
using NACH.API.ControllerModel.Request.NachType;
using NACH.API.ControllerModel.Response;

using NACH.API.Services;

namespace NACH.API.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class MMSReasonController : BaseController
    {
        private readonly ICommon _iCommon;
        private readonly ApplicationDbContext context;

        public MMSReasonController(
          ILogger<MMSReasonController> logger,
          IConfiguration configuration,
          ApplicationDbContext context,ICommon iCommon
         )
          : base(context: context)
        {

            _iCommon = iCommon;
        }



        [HttpPost]
        [Route("add-mmsreason")]
        public async Task<IActionResult> mmsreasonadd(mmsreasonadd request)
        {
            if (request is null)
            {
                return BadRequest(new ErrorResponse { Message = "Invalid  MMS Reason request" });
            }

            var data = await _context.Nach_Mms_Reason_Msts.FirstOrDefaultAsync(x=>x.TranCode==request.TranCode);
            if (data != null)
                return Ok(new ErrorResponse { Message = " MMS Reason  already exists!" });

            nach_mms_reason_mst model = new nach_mms_reason_mst
            {
                ReasonCode = request.ReasonCode,
                ReasonType = request.ReasonType,
                ReasonDesc = request.ReasonDesc

            };

            _context.Nach_Mms_Reason_Msts.Add(model);
            await _context.SaveChangesAsync();

            return Ok(new SuccessResponse
            {
                Message = "MMS has been successfully add"
            });
        }


        [HttpPut]
        [Route("edit-mmsreason")]
        public async Task<IActionResult> mmsreasonedit(mmsreasonedit request)
        {
            if (request is null)
            {
                return BadRequest(new ErrorResponse { Message = "Invalid  MMS Reason request" });
            }
            var data = await _context.Nach_Mms_Reason_Msts.FirstOrDefaultAsync(u => u.TranCode == request.TranCode);
            if (data == null)
                return Ok(new ErrorResponse { Message = "MMS Reason not exists!" });

            data.TranCode = request.TranCode;
            data.ReasonDesc = request.ReasonDesc;
            data.ReasonCode = request.ReasonCode;
            data.ReasonType=request.ReasonType;

            _context.Nach_Mms_Reason_Msts.Update(data);
            await _context.SaveChangesAsync();

            return Ok(new SuccessResponse
            {
                Message = "MMS has been successfully update"
            });
        }




        [HttpPost]
        [Route("list-mmsreason")]
        public IActionResult MMSReasonView([FromBody] mmsreasonview request)
        {
            if (request is null)
            {
                return BadRequest(new ErrorResponse { Message = "Invalid MMS Reason request" });
            }

            var data = _context.Nach_Mms_Reason_Msts
                .Where(x => x.TranCode == request.TranCode)
                .Select(x => new
                {
                    TranCode = x.TranCode,
                    ReasonCode = x.ReasonCode,
                    ReasonType = x.ReasonType,
                    ReasonTypeNm = x.ReasonType == "A" ? "Accept" :
                                   x.ReasonType == "C" ? "Cancel" :
                                   x.ReasonType == "R" ? "Reject" :
                                   x.ReasonType == "M" ? "Amendment" : "",
                    ReasonDesc = x.ReasonDesc
                })
                .OrderByDescending(x => x.TranCode);

            

            return Ok(new SuccessResponse
            {
                Response = data,
                Message = "Successfully"
            });
        }


        [HttpPost]
        [Route("get-MMSReason")]
        public IActionResult NachMmsReasonGet([FromBody] MmsReasonGet request)
        {
            if (request is null)
            {
                return BadRequest(new ErrorResponse { Message = "Invalid Nach Mms Reason  request" });
            }

            var data = _context.Nach_Mms_Reason_Msts
                .Where(x => x.ReasonType == request.ReasonType)
                .Select(x => new
                {
                    ReasonCode = x.ReasonCode,
                    ReasonDesc = x.ReasonDesc,
                    ReasonType = x.ReasonType
                });

            

            return Ok(new SuccessResponse
            {
                Response = data
            });
        }

    }
}

