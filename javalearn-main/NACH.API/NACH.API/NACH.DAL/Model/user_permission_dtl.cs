using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace NACH.DAL.Model
{
    [Table("USER_PERMISSION_DTL")]
    public class user_permission_dtl
    {
        [StringLength(6)]
        [Column("BANK_CD")]
        public string BankCode { get; set; }
        [Column("BRANCH_CD")]
        [StringLength(6)]
        public string BranchCode { get; set; }
        [Column("USER_ID")]
        [StringLength(15)]
        public string UserId { get; set; }
        [Column("DEFAULT_SELECTION")]
        [StringLength(1)]
        public string? DefaultSelection { get; set; } = "N";
    }
}
