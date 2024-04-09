using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using NACH.DAL.Data;
using NACH.DAL.Model;
using NACH.API.ControllerModel.Request.BankIIN;
using NACH.API.ControllerModel.Request.UserRole;
using NACH.API.ControllerModel.Response;
//using SmartNachApi.Data;
//using SmartNachApi.Model;

namespace NACH.API.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class BankIInMstController : BaseController
    {
        private readonly ApplicationDbContext context;
        public BankIInMstController(
       ILogger<AcctTypeController> logger,
       IConfiguration configuration,
       ApplicationDbContext context
      )
       : base(context:context)
        {

        }

        [HttpPost]
        [Route("add-bankIIN")]
        public async Task<IActionResult> bankIINAdd(BankIINAdd request)
        {
            if (request is null)
            {
                return BadRequest(new ErrorResponse { Message = "Invalid Bank IIN request" });
            }

            var data = await _context.bank_Iin_Msts.FirstOrDefaultAsync(u => u.BankCode == request.BankCode);
            if (data != null)
                return Ok(new ErrorResponse { Message = " Bank IIN  already exists!" });

            bank_iin_mst model = new bank_iin_mst
            {
                BankCode = request.BankCode,
                BranchCode = request.BranchCode,
                BankNm = request.BankNm,
                Ifsc = request.Ifsc,
                Micr=request.Micr,
                EntryBy=request.EntryBy,
                IinStatus = request.IinStatus,
                IfscStatus=request.IfscStatus,
                MicrStatus=request.MicrStatus,
                BankIIn = request.BankIIn,
                EntryDt = request.EntryDt,

            };

            _context.bank_Iin_Msts.Add(model);
            await _context.SaveChangesAsync();

            return Ok(new SuccessResponse
            {
                Message = "Bank IIN has been successfully add"
            });
        }

        [HttpPut]
        [Route("edit-bankIIN")]
        public async Task<IActionResult> bankIINEdit(bankIINEdit request)
        {
            if (request is null)
            {
                return BadRequest(new ErrorResponse { Message = "Invalid Bank IIN request" });
            }

            var data = await _context.bank_Iin_Msts
                .FirstOrDefaultAsync(u => u.BankCode == request.BankCode && u.TranCode == request.TranCode);

            if (data == null)
            {
                return Ok(new ErrorResponse { Message = "Bank IIN not exists!" });
            }

            // Update properties in the retrieved data
            data.TranCode = request.TranCode;
            data.BankCode = request.BankCode;
            data.Ifsc = request.Ifsc;
            data.Micr = request.Micr;
            data.IinStatus = request.IinStatus;
            data.IfscStatus = request.IfscStatus;
            data.MicrStatus = request.MicrStatus;
            data.ModifyDt = DateTime.Now;
            data.BankIIn = request.BankIIn;
            data.BankNm = request.BankNm;

            // Update the entity in the database
            _context.bank_Iin_Msts.Update(data);
            await _context.SaveChangesAsync();

            return Ok(new SuccessResponse
            {
                Message = "Bank IIN has been successfully modified"
            });
        }


        [HttpPost]
        [Route("list-bankIIN")]
        public async Task<IActionResult> bankIINView([FromBody] BankIINView request)
        {
            if (request is null)
            {
                return BadRequest(new ErrorResponse { Message = "Invalid Bank IIN request" });
            }

            var data = _context.bank_Iin_Msts
                .Where(x => x.BankCode == request.BankCode && x.BranchCode==request.BranchCode)
                .OrderByDescending(x => x.TranCode)
                .Select(x => new
                {
                    BankCode = x.BankCode,
                    TranCode = x.TranCode,
                    BankIIn = x.BankIIn,
                    Ifsc = x.Ifsc,
                    Micr = x.Micr,
                    BankNm = x.BankNm
                })
                .FirstOrDefault();


            return Ok(new SuccessResponse
            {
                Response = data,
                Message = "Successfully"
            });
        }




        [HttpPost]
        [Route("get-bankIIN")]
        public async Task<IActionResult> BankIINGet([FromBody] bankIINGet request)
        {
            if (request is null)
            {
                return BadRequest(new ErrorResponse { Message = "Invalid Bank IIN request" });
            }


            var data = await _context.bank_Iin_Msts
                .FirstOrDefaultAsync(x => x.BankCode == request.BankCode && x.BranchCode == request.BranchCode && !string.IsNullOrEmpty(x.BankIIn));

            if (data == null)
            {
                return Ok(new ErrorResponse { Message = "Bank IIN not exists!" });
            }


            var responseData = await _context.bank_Iin_Msts
                .Where(x => x.BranchCode == request.BranchCode)
                .OrderBy(x => x.BranchCode)
                .Select(x => new
                {
                    x.BankCode,
                    x.TranCode,
                    x.BankIIn,
                    x.BankNm,
                    x.BranchCode,
                    x.TypeOfBank
                })
                .ToListAsync();

            return Ok(new SuccessResponse
            {
                Response = responseData,
                Message = "success"
            });
        }
        [HttpPost]
        [Route("get-bankiinifsc")]
        public async Task<IActionResult> getbankiinifscmicrGet([FromBody] bankIINifscGet request)
        {
            if (request is null)
            {
                return BadRequest(new ErrorResponse { Message = "Invalid Bank IIN request" });
            }

            var data = _context.bank_Iin_Msts
                .Where(x => x.BankCode == request.BankCode && x.BranchCode == request.BranchCode)
                .OrderBy(x => x.BranchCode)
                .Select(x => new
                {
                    BankCode = x.BankCode,
                    TranCode = x.TranCode,
                    BankIIn = x.BankIIn,
                    BankNm = x.BankNm,
                    BranchCode = x.BranchCode,
                    TypeOfBank = x.TypeOfBank,
                    Ifsc = x.Ifsc,
                    Micr = x.Micr
                })
                .FirstOrDefault();

            return Ok(new SuccessResponse
            {
                Response = data,
                Message = "success"
            });
        }







    }
}
