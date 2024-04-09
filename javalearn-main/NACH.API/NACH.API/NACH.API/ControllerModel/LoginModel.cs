using System.ComponentModel.DataAnnotations;

namespace NACH.API.ControllerModel
{
    public class LoginModel 
    {
        [Required(ErrorMessage = "User id is required")]
        [StringLength(15, ErrorMessage = "{0} length must be between {2} and {1}.", MinimumLength = 2)]
        public string UserId { get; set; }

        [Required(ErrorMessage = "Password is required")]
        [DataType(DataType.Password)]
        public string Password { get; set; }
        public string? Latitude { get; set; }
        public string? Longitude { get; set; }

    }
}
