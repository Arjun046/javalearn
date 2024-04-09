using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace NACH.API.ControllerModel
{
    public class UserActivity
    {
        [Key]
        [StringLength(10)]
        [Unicode(false)]
        [Column("BANK_CD")]
        public string BankCode { get; set; }


        [StringLength(15)]
        [Unicode(false)]
        [Column("USER_ID")]
        public string UserId { get; set; }


        [StringLength(15)]
        [Unicode(false)]
        [Column("AUDIT_ID")]
        public string AuditId { get; set; }


        [MaxLength()]
        [Unicode(false)]
        [Column("AUD_TIMESTAMP")]
        public DateTime AudTimeStamp { get; set; }


        [StringLength(500)]
        [Unicode(false)]
        [Column("LAST_ACTIVITY_DATA")]
        public string LastActivityData { get; set; }
    }
}
