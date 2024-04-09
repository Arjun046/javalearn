using System.ComponentModel.DataAnnotations;

namespace NACH.API.ControllerModel.Request.Branch
{
    public class BranchEdit : BaseRequestModel
    {

        public string BankCode {  get; set; }

        public string BranchCode {  get; set; } 
        [Required]
        [StringLength(50, ErrorMessage = "{0} length must be between {2} and {1}.", MinimumLength = 4)]
        public string BranchName { get; set; }

        [StringLength(100, ErrorMessage = "{0} length must be between {2} and {1}.", MinimumLength = 4)]
        public string Address { get; set; }

        [StringLength(25, ErrorMessage = "{0} length must be between {2} and {1}.", MinimumLength = 4)]
        public string? City { get; set; }
        public string? PinCode { get; set; }
        public int StateCode { get; set; }
        public int CountryCode { get; set; }
        public string? ContactPerson { get; set; }
        [Phone]
        public string? Phone { get; set; }
        [Phone]
        public string? Mobile { get; set; }
        [EmailAddress]
        public string? Email { get; set; }
        public string? MicrCode { get; set; }

        [RegularExpression(@"^[A-Z]{4}0[A-Z0-9]{6}$")]
        public string? IfscCode { get; set; }
        public string? Fax { get; set; }
        public string? CbsCode { get; set; }
    }
}
