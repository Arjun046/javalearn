using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace NACH.DAL.Model
{
    [Table("VERIFY_REJECT_REASON")]
    public class verify_reject_reason
    {
        [MaxLength(11)]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Column("TRAN_CD")]
        public int TranCode { get; set; }
        [StringLength(5)]
        [Column("REASON_CD")]
        public string ReasonCode { get; set; }
        [StringLength(100)]
        [Column("REASON_DESC")]
        public string? ReasonDesc { get; set; }
    }
}
