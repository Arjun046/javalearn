using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace NACH.DAL.Model
{
    [Table("CANCEL_REASON_CODE")]
    public class cancel_reason_code : EntityBase
    {
        [StringLength(6)]
        [Column("BANK_CD")]
        public string BankCode { get; set; }
        [Column("TRAN_CD")]
        [MaxLength(11)]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int TranCode { get; set; }
        [Column("REASON_CD")]
        [StringLength(4)]
        public string ReasonCode { get; set; }
        [Column("DESCRIPTION")]
        [StringLength(300)]
        public string Description { get; set; }
        [Column("ASSIGN_BY")]
        [StringLength(1)]
        public string? AssignBy { get; set; } = "B";
    }
}
