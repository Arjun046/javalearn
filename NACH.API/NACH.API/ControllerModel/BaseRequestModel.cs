using System.ComponentModel.DataAnnotations;

namespace NACH.API.ControllerModel
{
    public class BaseRequestModel
    {
        [Required]
        public string UserId { get; set; }
        public string? Latitude { get; set; }
        public string? Longitude { get; set; }
        public string? IpAddress { get; set; }
    }
}
