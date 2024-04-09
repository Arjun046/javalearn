using System.ComponentModel.DataAnnotations;

namespace NACH.API.ControllerModel.Request.User
{
    public class VerifyOTPModel
    {

        public string LoginMobileNo { get; set; }
        public string LoginEmailId { get; set; }

        [Required(ErrorMessage = "SMS OTP is required")]
        [StringLength(6, ErrorMessage = "{0} length must be between {2} and {1}.", MinimumLength = 4)]
        public string SMSOTP { get; set; }
        public string? EmailOTP { get; set; }
    }
}
