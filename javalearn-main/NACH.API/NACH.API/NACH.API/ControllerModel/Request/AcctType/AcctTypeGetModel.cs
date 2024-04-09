using System.ComponentModel.DataAnnotations;

namespace NACH.API.ControllerModel.Request.AcctType
{
    public class AcctTypeGetModel:BaseRequestModel
    {
        [Required]
        public string BankCode { get; set; }
        /* [Required]
         public int TranCode { get; set; }*/
        [Required]
        public string BranchCode { get; set; }

        [Required]
        public int TranCode { get; set; }


    }
}
