using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace NACH.DAL.Model
{
    [Table("USER_ACTIVITY_LOG")]
    public class user_activity_log
    {
        [StringLength(10)]
        [Column("BANK_CD")]
        public string BankCode { get; set; }
        [Column("USER_ID")]
        [StringLength(15)]
        public string UserId { get; set; }
        [Column("LAST_ACTIVITY")]

        public DateTime LastActivity { get; set; }
        [Column("LAST_ACTIVITY_TYPE")]
        [StringLength(500)]

        public string LastActivityType { get; set; }
    }
}
