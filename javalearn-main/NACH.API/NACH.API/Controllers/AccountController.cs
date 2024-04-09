using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using NACH.DAL.Data;
using NACH.DAL.Model;
using NACH.API.ControllerModel.Request.NachAccount;
using NACH.API.ControllerModel.Request.NachType;
using NACH.API.ControllerModel.Response;
//using SmartNachApi.Data;
//using SmartNachApi.Model;
using NACH.API.Services;

namespace NACH.API.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class AccountController : BaseController
    {
        private readonly ICommon _iCommon;
        private readonly ApplicationDbContext context;
        string REQEUST_TYPE = "";

        public AccountController(
           ILogger<AccountController> logger,
           IConfiguration configuration,
           ApplicationDbContext context,ICommon iCommon
          )
           : base(context: context)
        {
            
           _iCommon = iCommon;

        }

        [HttpPost]
        [Route("add-account")]
        public async Task<IActionResult> NachAccountAdd(NachAccountAdd request)
        {
            if (request is null)
            {
                return BadRequest(new ErrorResponse { Message = "Invalid Account request" });
            }

            var data = await _context.nach_Account_Msts.FirstOrDefaultAsync(x=>x.EnteredBankCode==request.EnteredBankCode);
            if (data != null)
                return Ok(new ErrorResponse { Message = " Account already exists!" });

            nach_account_mst model = new nach_account_mst
            {
                EnteredBankCode=request.EnteredBankCode,
                EnteredBranchCode=request.EnteredBranchCode,
                BranchCode=request.BranchCode,  
                AcctNo=request.AcctNo,
                CustomerNo=request.CustomerNo,
                AcctNm=request.AcctNm,  
                AadhaarNo=request.AadhaarNo,    
                MobileNo=request.MobileNo,
                PanNo=request.PanNo,
                Status=request.Status,
                TranDt=DateTime.Now,
                EntryDt=DateTime.Now,
                EntryBy=request.EntryBy,
                SecAcctNm=request.SecAcctNm,
                SecPanNo=request.SecPanNo
            };

            _context.nach_Account_Msts.Add(model);
            await _context.SaveChangesAsync();

            return Ok(new SuccessResponse
            {
                Message = "Account has been successfully add"
            });
        }


        [HttpPut]
        [Route("edit-account")]
        public async Task<IActionResult> NachAccountEdit(NachAccountEdit request)
        {
            if (request is null)
            {
                return BadRequest(new ErrorResponse { Message = "Invalid Account request" });
            }
            var data = await _context.nach_Account_Msts.FirstOrDefaultAsync(u => u.EnteredBankCode == request.EnteredBankCode && u.AcctNo==request.AcctNo);
            if (data == null)
                return Ok(new ErrorResponse { Message = "Account not exists!" });

            data.BranchCode = request.BranchCode;
            data.CustomerNo = request.CustomerNo;
            data.AcctNm = request.AcctNm;
            data.SecAcctNm = request.SecAcctNm;
            data.SecPanNo = request.SecPanNo; 
            data.AadhaarNo = request.AadhaarNo;
            data.MobileNo = request.MobileNo;
            data.Status = request.Status;
            data.ModifyDt = DateTime.Now;
            data.ModifyBy = request.ModifyBy;
            data.AcctNo = request.AcctNo;
            data.EnteredBankCode = request.EnteredBankCode;
            data.AcctNo=request.AcctNo;

            _context.nach_Account_Msts.Update(data);
            await _context.SaveChangesAsync();

            return Ok(new SuccessResponse
            {
                Message = "Account has been successfully update"
            });
        }




        [HttpPost]
        [Route("account-list")]
        public async Task<IActionResult> NachaccountView([FromBody] NachaccountView request)
        {
            if (request is null)
            {
                return BadRequest(new ErrorResponse { Message = "Invalid Account request" });
            }

            var data = _context.nach_Account_Msts
                .Where(x => x.EnteredBankCode == request.EnteredBankCode && x.EnteredBranchCode == request.EnteredBranchCode)
                .Select(x => new
                {
                    EnteredBranchCode = x.EnteredBranchCode,
                    EnteredBankCode = x.EnteredBankCode,
                    BranchCode = x.BranchCode,
                    TranDt = x.TranDt,
                    AcctNo = x.AcctNo,
                    CustomerNo = x.CustomerNo,
                    Status = x.Status,
                    AADHAAR_NO = x.AadhaarNo.Length > 8 ? x.AadhaarNo.Substring(8, Math.Min(12, x.AadhaarNo.Length - 8)).PadRight(12, 'X') : "",
                    MobileNo = x.MobileNo,
                    PanNo = x.PanNo,
                    SecAcctNm = x.SecAcctNm,
                    SecPanNo = x.SecPanNo,
                    StatusName = x.Status == "O" ?
                        "Account Active" :
                        (from R in _context.nach_Return_Reason_Msts
                         where R.CbsReasonCode != "" && (R.NachType == "ACHC" || R.NachType == "ACHD") && R.ReasonCode == x.Status
                         select R.ReasonCode).FirstOrDefault()
                });

            if (data == null)
            {
                return NotFound(new ErrorResponse { Message = "account not exists" });
            }

            return Ok(new SuccessResponse
            {
                Response = data,
                Message = "Successfully"
            });
        }



        [HttpPost]
        [Route("get-AccountRecord")]
        public IActionResult NachaccountRecordGet([FromBody] NachaccountGet request)
        {
            if (request is null)
            {
                return BadRequest(new ErrorResponse { Message = "Invalid Account request" });
            }

            var data = _context.nach_Account_Msts
                .Where(x => x.EnteredBankCode == request.EnteredBankCode &&
                            x.EnteredBranchCode == request.EnteredBranchCode &&
                            x.Status == "O")
                .Select(x => new {
                    AcctNo = x.AcctNo,
                    AcctNm = x.AcctNm,
                    CustomerNo = x.CustomerNo,
                    AadhaarNo = x.AadhaarNo,
                    SecAcctNm = x.SecAcctNm,
                    PanNo = x.PanNo,
                    SecPanNo = x.SecPanNo,
                    EnteredBranchCode = x.EnteredBranchCode,
                    EnteredBankCode = x.EnteredBankCode,
                    Status = x.Status
                }); 

            if (data == null)
            {
                return NotFound(new ErrorResponse { Message = " Account not exists " });
            }

            return Ok(new SuccessResponse
            {
                Response = data
            });
        }



        [HttpPost]
        [Route("get-AccountByNo")]
        public IActionResult getAccountByNo([FromBody] NachaccountGet request)
        {
            if (request is null)
            {
                return BadRequest(new ErrorResponse { Message = "Invalid Account request" });
            }

            var data = _context.nach_Account_Msts
                .Where(x => x.EnteredBankCode == request.EnteredBankCode &&
                            x.EnteredBranchCode == request.EnteredBranchCode &&
                            x.Status == "O")
                .Select(x => new
                {
                    AcctNo = x.AcctNo,
                    AcctNm = x.AcctNm,
                    CustomerNo = x.CustomerNo,
                    AadhaarNo = x.AadhaarNo,
                    SecAcctNm = x.SecAcctNm,
                    PanNo = x.PanNo,
                    SecPanNo = x.SecPanNo,
                    EnteredBranchCode = x.EnteredBranchCode,
                    EnteredBankCode = x.EnteredBankCode,
                    Status = x.Status
                });

            if (data == null)
            {
                return NotFound(new ErrorResponse { Message = "Account not exists" });
            }

            return Ok(new SuccessResponse
            {
                Response = data
            });
        }


        [HttpPost]
        [Route("get-data")]
        public IActionResult getdata([FromBody] Nachgetdata request)
        {

            if (request is null)
            {
                return BadRequest(new ErrorResponse { Message = "Invalid  Account Request" });
            }

            if (request.REQEUST_TYPE == "GET_ACCT_NAME")
            {
                var data1 = _context.nach_Account_Msts
                    .Where(x => x.EnteredBankCode == request.EnteredBankCode &&
                                x.EnteredBranchCode == request.EnteredBranchCode &&
                                x.AcctNo == request.AcctNo)
                    .Select(x => new
                    {
                        AcctNo = x.AcctNo,
                        AcctNm = x.AcctNm,
                        CustomerNo = x.CustomerNo,
                        AadhaarNo = x.AadhaarNo,
                        SecAcctNm = x.SecAcctNm,
                        PanNo = x.PanNo,
                        SecPanNo = x.SecPanNo,
                        EnteredBranchCode = x.EnteredBranchCode,
                        EnteredBankCode = x.EnteredBankCode,
                    });

               

                return Ok(new SuccessResponse
                {
                    Message = "Record Found",
                    Response = data1
                });
            }

            else if (request.REQEUST_TYPE == "GET_CBS_FILE_CONFIG")
            {
                var data2 = _context.nach_File_Config_Msts
                    .Where(x => x.NachType == "CBSC" || x.NachType == "CBSD")

                    .Select(x => new
                    {
                        BankCode = x.BankCode,
                        TranCode = x.TranCode,
                        NachType = x.NachType,
                        ConfigNm = x.ConfigNm,
                        ConfigType = x.ConfigType,
                        DelimiterCode = x.DelimiterCode,
                        DelimiterSign = x.DelimiterSign,
                        FileFormat = x.FileFormat,
                        FileNm = x.FileNm,
                        SkipRowFlag = x.SkipRowFlag,
                        TrnType = x.TrnType,
                        TrnBranchCode = x.TrnBranchCode,
                        TrnProdType = x.TrnProdType,
                        TrnAcctNo = x.TrnAcctNo,
                        ChrgFlag = x.ChrgFlag,
                        ChrgBranchCode = x.ChrgBranchCode,
                        ChrgProdType = x.ChrgProdType,
                        ChrgAcctNo = x.ChrgAcctNo,
                        RetTrnType = x.RetTrnType,
                        RetChrgFlag = x.RetChrgFlag,
                        EntryBy = x.EntryBy,
                        EntryDt = x.EntryDt,
                        EntryPcNm = x.EntryPcNm,
                        ModifyBy = x.ModifyBy,
                        ModifyDt = x.ModifyDt,
                        ModifyPcNm = x.ModifyPcNm,
                        CbsConfigCode = x.CbsConfigCode,
                        RetConfigCode = x.RetConfigCode
                    });

                

                return Ok(new SuccessResponse
                {
                    Message = "Record Found",
                    Response = data2
                });
            }
            else if (request.REQEUST_TYPE == "GET_RET_CBS_FILE_CONFIG")
            {
                var data3 = _context.nach_File_Config_Msts
                    .Where(x => x.ConfigType == "R")
                    .Select(x => new
                    {
                        BankCode = x.BankCode,
                        TranCode = x.TranCode,
                        NachType = x.NachType,
                        ConfigNm = x.ConfigNm,
                        ConfigType = x.ConfigType,
                        DelimiterCode = x.DelimiterCode,
                        DelimiterSign = x.DelimiterSign,
                        FileFormat = x.FileFormat,
                        FileNm = x.FileNm,
                        SkipRowFlag = x.SkipRowFlag,
                        TrnType = x.TrnType,
                        TrnBranchCode = x.TrnBranchCode,
                        TrnProdType = x.TrnProdType,
                        TrnAcctNo = x.TrnAcctNo,
                        ChrgFlag = x.ChrgFlag,
                        ChrgBranchCode = x.ChrgBranchCode,
                        ChrgProdType = x.ChrgProdType,
                        ChrgAcctNo = x.ChrgAcctNo,
                        RetTrnType = x.RetTrnType,
                        RetChrgFlag = x.RetChrgFlag,
                        EntryBy = x.EntryBy,
                        EntryDt = x.EntryDt,
                        EntryPcNm = x.EntryPcNm,
                        ModifyBy = x.ModifyBy,
                        ModifyDt = x.ModifyDt,
                        ModifyPcNm = x.ModifyPcNm,
                        CbsConfigCode = x.CbsConfigCode,
                        RetConfigCode = x.RetConfigCode
                    });

              

                return Ok(new SuccessResponse
                {
                    Message = "Record Found",
                    Response = data3
                });
            }
            else if (request.REQEUST_TYPE == "GET_PAGE_NOTES")
            {
                var data4 = _context.page_Notes_Msts
                    .Where(x => x.PageCode == request.PageCode)
                    .Select(x => new
                    {
                        Data = x.Data,
                        PageCode = x.PageCode,
                    });

                if (data4 == null)
                {
                    return NotFound(new ErrorResponse { Message = "Page not exists" });
                }

                return Ok(new SuccessResponse
                {
                    Message = "Record Found",
                    Response = data4
                });
            }
            return BadRequest(new ErrorResponse { Message = "Invalid Request" });


        }
        
    

    }
}
