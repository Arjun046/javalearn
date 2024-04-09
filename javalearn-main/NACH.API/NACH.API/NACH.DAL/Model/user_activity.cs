using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace NACH.DAL.Model
{
    [Table("USER_ACTIVITY")]
    public class user_activity
    {
        [MaxLength(11)]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Column("TRAN_CD")]
        public int TranCode { get; set; }
        [Column("BANK_CD")]
        [StringLength(10)]
        public string BankCode { get; set; }
        [Column("USER_ID")]
        [StringLength(15)]
        public string UserId { get; set; }
        [Column("AUDIT_ID")]
        [StringLength(30)]
        public string AuditId { get; set; }
        [Column("AUD_TIMESTAMP")]
        public DateTime AudTimeStamp { get; set; }
        [Column("LAST_ACTIVITY_DATA")]
        [StringLength(500)]
        public string LastActivityData { get; set; }
    }
}
