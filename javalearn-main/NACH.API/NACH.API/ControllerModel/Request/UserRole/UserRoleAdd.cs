    using System.ComponentModel.DataAnnotations.Schema;
    using System.ComponentModel.DataAnnotations;
using NACH.DAL;

namespace NACH.API.ControllerModel.Request.UserRole
    {
        public class UserRoleAdd : EntityBase
        {
            public string BankCode { get; set; }
            public string RoleNm { get; set; }
            public string RoleType { get; set; }
            public string? Description { get; set; }
        }
    }
