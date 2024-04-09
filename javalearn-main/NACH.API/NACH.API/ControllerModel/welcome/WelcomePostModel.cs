using System.ComponentModel.DataAnnotations;

namespace NACH.API.ControllerModel.welcome
{
    public class WelcomePostModel : BaseRequestModel
    {
        [Required]
        public string MobileNumber { get; set; }

        [DataType(DataType.EmailAddress)]
        public string? EmailId { get; set; }
        public string? RefNumber { get; set; }
    }
}
