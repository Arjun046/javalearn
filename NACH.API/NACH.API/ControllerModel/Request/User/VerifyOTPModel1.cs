using System.ComponentModel.DataAnnotations;

namespace NACH.API.ControllerModel.Request.User
{
    public class VerifyOTPModel1
    {
        [Required]
        public string UserId { get; set; }

        [Required]
        public string MobileNo { get; set; }

        [Required]
        public string OTP { get; set; }

        [Required(ErrorMessage = "Password is required")]
        [DataType(DataType.Password)]
        public string Password { get; set; }

        [Required(ErrorMessage = "ConfirmPassword is required")]
        [DataType(DataType.Password)]
        public string ConfirmPassword { get; set; }
    }
}
