using System.ComponentModel.DataAnnotations;

namespace NACH.API.ControllerModel.Request.AcctType
{
    public class AcctTypeAddModel:BaseRequestModel
    {
        [Required]
        public string BankCode { get; set; }

        [Required]
        public string BranchCode { get; set; }

        [Required]
        public string AccountType { get; set; }

        [Required]
        public string TypeName { get; set; }

        public string CbsCode { get; set; }

        public string VerifyStatus { get; set; }
    }
}
