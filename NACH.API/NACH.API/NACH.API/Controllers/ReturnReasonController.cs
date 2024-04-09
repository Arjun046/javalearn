using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using NACH.DAL.Data;
using NACH.DAL.Model;
using NACH.API.ControllerModel.Request.City;
using NACH.API.ControllerModel.Request.NachType;
using NACH.API.ControllerModel.Request.NachTypeReason;
using NACH.API.ControllerModel.Response;

using NACH.API.Services;
using static System.Runtime.CompilerServices.RuntimeHelpers;

namespace NACH.API.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class ReturnReasonController : BaseController
    {

        private readonly ICommon _iCommon;
        private readonly ApplicationDbContext context;

        public ReturnReasonController(
            ILogger<ReturnReasonController> logger,
            IConfiguration configuration,
            ApplicationDbContext context,ICommon iCommon
           )
            : base(context: context)
        {
           _iCommon = iCommon;

        }

        [HttpPost]
        [Route("add-returnreason")]
        public async Task<IActionResult> NachReturnReasonAdd([FromBody] NachReasonAdd request)
        {
            if (request is null)
            {
                return BadRequest(new ErrorResponse { Message = "Invalid Nach Return Reason request" });
            }

            var val = await _context.nach_Return_Reason_Msts.FirstOrDefaultAsync(u => u.TranCode == request.TranCode);
            if (val != null)
                return Ok(new ErrorResponse { Message = " Nach Return Reason already exists!" });

            nach_return_reason_mst category = new nach_return_reason_mst
            {
                TranCode=request.TranCode,
                ReasonCode= request.ReasonCode,
                NachType = request.NachType,
                ReasonDesc=request.ReasonDesc,
                CHRG_AMT=request.CHRG_AMT,
                CbsReasonCode = request.CbsReasonCode
            };

            _context.nach_Return_Reason_Msts.Add(category);
            await _context.SaveChangesAsync();

            return Ok(new SuccessResponse
            {
                Message = "NACH RETURN REASON has been successfully add"
            });
        }


        [HttpPut]
        [Route("edit-returnreason")]
        public async Task<IActionResult> NachReturnReasonEdit(NachReasonAdd request)
        {
            if (request is null)
            {
                return BadRequest(new ErrorResponse { Message = "Invalid Nach Return Reason request" });
            }
            var data = await _context.nach_Return_Reason_Msts.FirstOrDefaultAsync(u => u.TranCode == request.TranCode);
            if (data == null)
                return Ok(new ErrorResponse { Message = "Nach Return Reason already exists!" });

            data.TranCode = request.TranCode;
            data.ReasonCode=request.ReasonCode;
            data.NachType = request.NachType;
            data.ReasonDesc = request.ReasonDesc;
            data.CHRG_AMT = request.CHRG_AMT;
            data.CbsReasonCode = request.CbsReasonCode;


            _context.nach_Return_Reason_Msts.Update(data);
            await _context.SaveChangesAsync();

            return Ok(new SuccessResponse
            {
                Message = "Nach Type has been successfully update"
            });
        }

        [HttpPost]
        [Route("get-returnreason")]
        public IActionResult NachReturnReasonGet([FromBody] NachReasonGet request)
        {
            if (request is null)
            {
                return BadRequest(new ErrorResponse { Message = "Invalid Nach Return Reason request" });
            }

            var data = _context.nach_Return_Reason_Msts
                .Where(x => x.TranCode == request.TranCode)
                .Select(x => new
                {
                    TranCode = x.TranCode,
                    NachType = x.NachType,
                    ReasonCode = x.ReasonCode,
                    ReasonDesc = x.ReasonDesc,
                    CHRG_AMT = x.CHRG_AMT,
                    CbsReasonCode = x.CbsReasonCode
                })
                .OrderBy(x => x.TranCode);

            if (data == null)
            {
                return NotFound(new ErrorResponse { Message = "Nach Return Reason not found" });
            }

            return Ok(new SuccessResponse
            {
                Response = data,
                Message = "Successfully"
            });
        }



        [HttpPost]
        [Route("get-NACHReason")]
        public IActionResult getNACHReason([FromBody] ReasonGet request)
        {
            if (request is null)
            {
                return BadRequest(new ErrorResponse { Message = "Invalid Nach Return Reason request" });
            }

            var data = _context.nach_Return_Reason_Msts
                .Where(x => x.NachType == request.NachType)
                .Select(x => new
                {
                    NachType = x.NachType,
                    ReasonCode = x.ReasonCode,
                    ReasonDesc = x.ReasonDesc,
                    CHRG_AMT = x.CHRG_AMT,
                    //CbsReasonCode = x.CbsReasonCode
                })
                .OrderBy(x => x.ReasonCode);

            if (data == null)
            {
                return NotFound(new ErrorResponse { Message = "NACH Return Reason not exists" });
            }

            return Ok(new SuccessResponse
            {
                Response = data,
                Message = "Success"
            });
        }


        [HttpPost]
        [Route("get-NachRtnRsnAcct")]
        public IActionResult getNachRtnRsnAcct([FromBody] NachRtnRsnAcctGet request)
        {
            if (request == null)
            {
                return BadRequest(new ErrorResponse { Message = "Invalid Nach Return Reason request" });
            }

            var data = _context.nach_Return_Reason_Msts
                .Where(x => (x.NachType == "ACHC" || x.NachType == "ACHD"));

            if (!string.IsNullOrEmpty(request.CbsReasonCode))
            {
                data = data.Where(x => x.CbsReasonCode == request.CbsReasonCode);
            }

            var filteredData = data
                .Select(x => new
                {
                    NachType = x.NachType,
                    ReasonCode = x.ReasonCode,
                    ReasonDesc = x.ReasonDesc,
                    CbsReasonCode = x.CbsReasonCode
                })
                .OrderBy(x => x.ReasonCode)
                .ToList(); // Materialize the query

            var result = filteredData
                .GroupBy(x => x.ReasonCode)
                .ToList();

            if (result.Count == 0)
            {
                return NotFound(new ErrorResponse { Message = "Nach Return Reason not exists" });
            }

            return Ok(new SuccessResponse
            {
                Response = result,
                Message = "Success"
            });
        }



        [HttpPost]
        [Route("get-DBTLIwReason")]
        public IActionResult getDBTLIwReason([FromBody] getDBTLIwReasonGet request)
        {
            if (request is null)
            {
                return BadRequest(new ErrorResponse { Message = "Invalid Nach Return Reason request" });
            }

            var data = _context.nach_Return_Reason_Msts
                .Where(x => x.NachType == "DBTL")
                .Select(x => new
                {
                    NachType = x.NachType,
                    ReasonCode = x.ReasonCode,
                    ReasonDesc = x.ReasonDesc,
                    CHRG_AMT = x.CHRG_AMT,
                    CbsReasonCode = x.CbsReasonCode
                })
                .OrderBy(x => x.ReasonCode);

            if (data == null)
            {
                return NotFound(new ErrorResponse { Message = "Nach Return Reason for DBTL not exists" });
            }

            return Ok(new SuccessResponse
            {
                Response = data,
                Message = "Success"
            });
        }



        [HttpPost]
        [Route("get-OACReason")]
        public IActionResult getOACReason([FromBody] getOACReasonGet request)
        {
            if (request is null)
            {
                return BadRequest(new ErrorResponse { Message = "Invalid Nach Return Reason request" });
            }

            var data = _context.nach_Return_Reason_Msts
                .Where(x => x.NachType == "OAC")
                .Select(x => new
                {
                    NachType = x.NachType,
                    ReasonCode = x.ReasonCode,
                    ReasonDesc = x.ReasonDesc,
                    CHRG_AMT = x.CHRG_AMT
                })
                .OrderBy(x => x.ReasonCode);

            if (data == null)
            {
                return NotFound(new ErrorResponse { Message = "Nach Return Reason for NachType 'OAC' not exists" });
            }

            return Ok(new SuccessResponse
            {
                Response = data,
                Message = "Success"
            });
        }







    }
}
