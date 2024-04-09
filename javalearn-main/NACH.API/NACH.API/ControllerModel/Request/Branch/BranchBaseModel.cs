using System.ComponentModel.DataAnnotations;

namespace NACH.API.ControllerModel.Request.Branch
{
    public class BranchBaseModel:BaseRequestModel
    {
        [Required]
        public string BankCode { get; set; }
        [Required]
        public string BranchCode { get; set; }
    }
}
