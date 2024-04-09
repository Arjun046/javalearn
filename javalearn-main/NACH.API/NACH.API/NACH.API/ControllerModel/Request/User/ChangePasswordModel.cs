using System.ComponentModel.DataAnnotations;

namespace NACH.API.ControllerModel.Request.User
{
    public class ChangePasswordModel:BaseRequestModel
    {
        [Required(ErrorMessage = "Password is required")]
        [DataType(DataType.Password)]
        public string CurrentPassword { get; set; }

        [Required(ErrorMessage = "Password is required")]
        [DataType(DataType.Password)]
        public string Password { get; set; }
    }
}
