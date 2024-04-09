using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace NACH.DAL.Model
{
    [Table("USER_BRANCH_PERMISSION")]
    public class user_branch_permission
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [MaxLength(11)]
        [Column("TRAN_CD")]
        public int tranCode { get; set; }
        [Column("BANK_CD")]
        [StringLength(6)]
        public string BankCode { get; set; }
        [Column("BRANCH_CD")]
        [StringLength (5)]
        public string BranchCode { get; set; }
        [Column("USER_NM")]
        [StringLength (10)]
        public string UserNm { get; set; }
        [Column("DEFAULT_SELECTION")]
        [StringLength (1)]
        public string DefaultSelection { get; set; } = "Y";
    }
}
