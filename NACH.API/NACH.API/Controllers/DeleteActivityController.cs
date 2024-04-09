using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using NACH.DAL.Data;
using NACH.API.ControllerModel.Request.deleteActivity;
using NACH.API.ControllerModel.Request.Parameter;
using NACH.API.ControllerModel.Response;

using NACH.API.Services;
using System.Linq;

namespace NACH.API.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class DeleteActivityController : BaseController
    {
        private readonly ICommon _iCommon;
        private readonly ApplicationDbContext context;
        string ls_req_type = null;

        public DeleteActivityController(
         ILogger<DeleteActivityController> logger,
         IConfiguration configuration,
         ApplicationDbContext context,ICommon iCommon
        )
         : base(context: context)
        {
            _iCommon = iCommon;

        }

        [HttpPost]
        [Route("delete-activity")]
        public IActionResult deleteactivity([FromBody] deleteactivity request)
        {


            if (request.ls_req_type == "DELETE_BANK_IIN")
            {
                var recorddelete = _context.bank_Iin_Msts.FirstOrDefault(b => b.BankCode == request.BankCode && b.TranCode == request.TranCode);
                if (recorddelete != null)
                {
                    _context.bank_Iin_Msts.Remove(recorddelete);
                    _context.SaveChanges();
                }
                return Ok(new SuccessResponse
                {
                    Message = "Bank IIN record has been successfully delete"
                });
            }
            else if (request.ls_req_type == "DELETE_BRANCH_MASTER")
            {

                var recorddelete1 = _context.branch_Msts.FirstOrDefault(b => b.BankCode == request.BankCode && b.BranchCode == request.BranchCode);
                if (recorddelete1 != null)
                {
                    _context.branch_Msts.Remove(recorddelete1);
                    _context.SaveChanges();

                    return Ok(new SuccessResponse
                    {
                        Message = "Branch has been successfully delete"
                    });
                }
            }
            else if (request.ls_req_type == "DELETE_USER_MST")
            {

                var recorddelete2 = _context.LoginMst.FirstOrDefault(b => b.UserId == request.UserId);
                if (recorddelete2 != null)
                {
                    _context.LoginMst.Remove(recorddelete2);
                    _context.SaveChanges();

                    return Ok(new SuccessResponse
                    {
                        Message = "User has been successfully delete"
                    });
                }
            }
            else if (request.ls_req_type == "DELETE_USER_ROLE_MASTER")
            {

                var recorddelete3 = _context.role_Msts.FirstOrDefault(x => x.BankCode == request.BankCode && x.TranCode == request.TranCode);
                if (recorddelete3 != null)
                {
                    _context.role_Msts.Remove(recorddelete3);
                    _context.SaveChanges();

                    return Ok(new SuccessResponse
                    {
                        Message = "User has been successfully delete"
                    });
                }
            }

            else if (request.ls_req_type == "DELETE_ACCOUNT")
            {

                var recorddelete4 = _context.nach_Account_Msts.FirstOrDefault(x => x.EnteredBankCode == request.EnteredBankCode && x.AcctNo == request.AcctNo);
                if (recorddelete4 != null)
                {
                    _context.nach_Account_Msts.Remove(recorddelete4);
                    _context.SaveChanges();

                    return Ok(new SuccessResponse
                    {
                        Message = "Account has been successfully delete"
                    });
                }
            }
            else if (request.ls_req_type == "DELETE_NACH_TYPE")
            {
                var recorddelete5 = _context.nach_Type_Msts.FirstOrDefault(x => x.TranCode == request.TranCode);
                if (recorddelete5 != null)
                {
                    _context.nach_Type_Msts.Remove(recorddelete5);
                    _context.SaveChanges();

                    return Ok(new SuccessResponse
                    {
                        Message = "NACH Type has been successfully delete"
                    });
                }
            }
            else if (request.ls_req_type == "DELETE_NACH_RETURN_REASON")
            {

                var recorddelete6 = _context.nach_Return_Reason_Msts.FirstOrDefault(x => x.TranCode == request.TranCode);
                if (recorddelete6 != null)
                {
                    _context.nach_Return_Reason_Msts.Remove(recorddelete6);
                    _context.SaveChanges();

                    return Ok(new SuccessResponse
                    {
                        Message = "NACH Return Reason has been successfully delete"
                    });
                }
            }

            else if (request.ls_req_type == "DELETE_NACH_MMS_CATEGORY")
            {

                var recorddelete7 = _context.Nach_Mms_Category_Msts.FirstOrDefault(x => x.TranCode == request.TranCode);
                if (recorddelete7 != null)
                {
                    _context.Nach_Mms_Category_Msts.Remove(recorddelete7);
                    _context.SaveChanges();

                    return Ok(new SuccessResponse
                    {
                        Message = "NACH MMS Category been successfully delete"
                    });
                }
            }

            else if (request.ls_req_type == "DELETE_OMC_LPG_COMP")
            {
                var recorddelete8 = _context.nach_Dbtl_Omc_Msts.FirstOrDefault(x => x.BankCode == request.BankCode && x.Code == request.Code);
                if (recorddelete8 != null)
                {
                    _context.nach_Dbtl_Omc_Msts.Remove(recorddelete8);
                    _context.SaveChanges();

                    return Ok(new SuccessResponse
                    {
                        Message = "OMC LPG Company been successfully delete"
                    });
                }
            }

            else if (request.ls_req_type == "DELETE_NACH_FILE_CONFIG")
            {
                var recorddelete9 = _context.nach_File_Config_Msts.FirstOrDefault(x => x.BankCode == request.BankCode && x.TranCode == request.TranCode);
                if (recorddelete9 != null)
                {
                    _context.nach_File_Config_Msts.Remove(recorddelete9);
                    _context.SaveChanges();

                    return Ok(new SuccessResponse
                    {
                        Message = "Nach File Config been successfully delete"
                    });
                }
            }
            else if (request.ls_req_type == "DELETE_ACH_DEBIT_MANDATE")
            {
                var recorddelete10 = _context.nach_Iw_Mandate_Msts.FirstOrDefault(x => x.EnterdBankCode == request.EnteredBankCode && x.TranCode == request.TranCode);
                if (recorddelete10 != null)
                {
                    _context.nach_Iw_Mandate_Msts.Remove(recorddelete10);
                    _context.SaveChanges();

                    return Ok(new SuccessResponse
                    {
                        Message = "ACH Debit Mandate been successfully delete"
                    });
                }
            }

            else if (request.ls_req_type == "DELETE_ACH_INWARD_PROCESS")
            {

                var recorddelete11 = _context.nach_Io_Trn_Msts.FirstOrDefault(x => x.EnteredBankCode == request.EnteredBankCode && x.TranCode == request.TranCode);
                if (recorddelete11 != null)
                {
                    _context.nach_Io_Trn_Msts.Remove(recorddelete11);
                    _context.SaveChanges();

                    return Ok(new SuccessResponse
                    {
                        Message = "ACH Debit Mandate been successfully delete"
                    });
                }
            }

            else if (request.ls_req_type == "DELETE_ECS_RECORD")
            {
                var recorddelete12 = _context.nach_Io_Trn_Msts.FirstOrDefault(x => x.EnteredBankCode == request.EnteredBankCode && x.TranCode == request.TranCode);
                if (recorddelete12 != null)
                {
                    _context.nach_Io_Trn_Msts.Remove(recorddelete12);
                    _context.SaveChanges();

                    return Ok(new SuccessResponse
                    {
                        Message = "ECS record has been successfully delete"
                    });
                }
            }
            else if (request.ls_req_type == "DELETE_DBTL_AC_REGISTER")
            {
                var recorddelete13 = _context.nach_Dbtl_Reg_Msts.FirstOrDefault(x => x.EnteredBankCode == request.EnteredBankCode && x.TranCode == request.TranCode);
                if (recorddelete13 != null)
                {
                    _context.nach_Dbtl_Reg_Msts.Remove(recorddelete13);
                    _context.SaveChanges();

                    return Ok(new SuccessResponse
                    {
                        Message = "DBTL A/c register been successfully delete"
                    });
                }
            }

            else if (request.ls_req_type == "DELETE_DBTL_INWARD_AV")
            {
                var recorddelete14 = _context.nach_Dbtl_Av_Msts.FirstOrDefault(x => x.EnteredBankCode == request.EnteredBankCode && x.TranCode == request.TranCode);
                if (recorddelete14 != null)
                {
                    _context.nach_Dbtl_Av_Msts.Remove(recorddelete14);
                    _context.SaveChanges();

                    return Ok(new SuccessResponse
                    {
                        Message = "Confirmation detail has been successfully delete"
                    });
                }
            }
            else if (request.ls_req_type == "DELETE_DBTL_UPLOAD_OW_AV_RESP")
            {
                var recorddelete15 = _context.nach_Dbtl_Av_Msts.FirstOrDefault(x => x.EnteredBankCode == request.EnteredBankCode && x.TranCode == request.TranCode);
                if (recorddelete15 != null)
                {
                    _context.nach_Dbtl_Av_Msts.Remove(recorddelete15);
                    _context.SaveChanges();

                    return Ok(new SuccessResponse
                    {
                        Message = "DBTL Upload O/W AV Response File has been successfully delete"
                    });
                }
            }

            else if (request.ls_req_type == "DELETE_APBS_REGISTRATION")
            {
                var recorddelete16 = _context.Nach_Apbs_Reg_Msts.FirstOrDefault(x => x.EnteredBankCode == request.EnteredBankCode && x.EnteredBranchCode == request.EnteredBranchCode);
                if (recorddelete16 != null)
                {
                    _context.Nach_Apbs_Reg_Msts.Remove(recorddelete16);
                    _context.SaveChanges();

                    return Ok(new SuccessResponse
                    {
                        Message = "APBS Registration record has been successfully delete"
                    });
                }
            }

            else if (request.ls_req_type == "DELETE_CBDT_AV")
            {
                var recorddelete17 = _context.nach_Dbtl_Av_Msts.FirstOrDefault(x => x.EnteredBankCode == request.EnteredBankCode && x.TranCode == request.TranCode && x.NachType == "CBDT");
                if (recorddelete17 != null)
                {
                    _context.nach_Dbtl_Av_Msts.Remove(recorddelete17);
                    _context.SaveChanges();

                    return Ok(new SuccessResponse
                    {
                        Message = "DBTL Inward AV File has been successfully delete"
                    });
                }
            }


            else if (request.ls_req_type == "DELETE_OAC_FILE")
            {
                var recorddelete18 = _context.nach_Oac_Msts.FirstOrDefault(x => x.EnteredBankCode == request.EnteredBankCode && x.TranCode == request.TranCode);
                if (recorddelete18 != null)
                {
                    _context.nach_Oac_Msts.Remove(recorddelete18);
                    _context.SaveChanges();

                    return Ok(new SuccessResponse
                    {
                        Message = "OAC File has been successfully delete"
                    });
                }
            }

            else if (request.ls_req_type == "DELETE_MAIL_SMS_TEMP")
            {
                var recorddelete19 = _context.mail_Sms_Temp_Msts.FirstOrDefault(x => x.TranCode == request.TranCode);
                if (recorddelete19 != null)
                {
                    _context.mail_Sms_Temp_Msts.Remove(recorddelete19);
                    _context.SaveChanges();

                    return Ok(new SuccessResponse
                    {
                        Message = "Mail/SMS template has been successfully delete"
                    });
                }
            }

            else if (request.ls_req_type == "DELETE_MAIL_SMS_TEMP")
            {
                var recorddelete20 = _context.mail_Sms_Temp_Msts.FirstOrDefault(x => x.TranCode == request.TranCode);
                if (recorddelete20 != null)
                {
                    _context.mail_Sms_Temp_Msts.Remove(recorddelete20);
                    _context.SaveChanges();


                    return Ok(new SuccessResponse
                    {
                        Message = "Mail/SMS template has been successfully delete"
                    });

                }
            }

            return Ok(new SuccessResponse
            {
                Message = "",
            });


        }

    }
                                                                                
}


       

                                                                                
                                                                            


