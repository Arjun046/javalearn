using System.ComponentModel.DataAnnotations;

namespace NACH.API.ControllerModel.Request.User
{
    public class UserGetModel:BaseRequestModel
    {
        [Required]
        public string ForUserId { get; set; }
    }
}
