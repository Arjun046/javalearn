using System.ComponentModel.DataAnnotations;

namespace NACH.API.ControllerModel.Request.UserRole
{
    public class RoleAddModel:BaseRequestModel
    {

        [Required]
        public string BankCode { get; set; }
        [Required]
        public string RoleName { get; set; }
        public string Description { get; set; }
        [Required]
        public string RoleType { get; set; }
    }
}
