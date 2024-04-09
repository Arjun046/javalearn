using System.ComponentModel.DataAnnotations;

namespace NACH.API.ControllerModel.Request.User
{
    public class ForgotPasswordModel
    {
        [Required]
        public string UserId { get; set; }

        [Required]
        public string MobileNo { get; set; }

        public string ls_flag { get; set; }

        public string? OtpCode { get; set; }

        public string? EmailId { get; set; }

        public string UserPass { get; set; }


    }
}
