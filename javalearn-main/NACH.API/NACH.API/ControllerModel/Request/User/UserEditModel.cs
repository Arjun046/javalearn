using System.ComponentModel.DataAnnotations;

namespace NACH.API.ControllerModel.Request.User
{
    public class UserEditModel : BaseRequestModel
    {

        public string Name { get; set; }
        [Required(ErrorMessage = "EditUserId is required")]
        public string EditUserId { get; set; }
        [Required]  
        public string ActiveStatus { get; set; }
        [Required]
        public int RoleId { get; set; }
        [Required]
        public string MobileNo1 { get; set; }
        public string? MobileNo2 { get; set; }

        //[Required(ErrorMessage = "Custom Username is required")]
        //[StringLength(15, ErrorMessage = "{0} length must be between {2} and {1}.", MinimumLength = 2)]
        //public string? CustUserName { get; set; }

        [EmailAddress]
       // [Required(ErrorMessage = "Email is required")]
        public string Email { get; set; }
        public string? Remarks { get; set; }

    }
}
