using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace NACH.API.ControllerModel
{
    public class UserAddModel : BaseRequestModel
    {
        public string BankCode { get; set; }
        public string BranchCode { get; set; }

        [Required(ErrorMessage = "Username is required")]
        [StringLength(15, ErrorMessage = "{0} length must be between {2} and {1}.", MinimumLength = 2)]
        public string Username { get; set; }
        [Required(ErrorMessage = "Name is required")]
        public string Name { get; set; }

        [DataType(DataType.Password)]
        [Required(ErrorMessage = "Password is required")]
        public string Password { get; set; }
        [Required]
        public int RoleId { get; set; }
        [Required]
        public string MobileNo1 { get; set; }
        public string? MobileNo2 { get; set; }

        [EmailAddress]
        [Required(ErrorMessage = "Email is required")]
        public string Email { get; set; }
        public string? Remarks { get; set; }

    }
}
