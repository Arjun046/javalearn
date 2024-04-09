using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace NACH.DAL.Model
{
    [Table("NACH_RETURN_REASON_MST")]
    public class nach_return_reason_mst
    {
        [MaxLength(11)]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Column("TRAN_CD")]
        public int TranCode { get; set; }
        [Column("NACH_TYPE")]
        [StringLength(10)]
        public string NachType { get; set; }
        [Column("REASON_CD")]
        [StringLength(5)]
        public string ReasonCode { get; set; }
        [Column("REASON_DESC")]
        [StringLength(200)]
        public string? ReasonDesc { get; set; }
        
        [Column(TypeName = "decimal(12,2)")]
        public double? CHRG_AMT { get; set; } = 0.00;
        [Column("CBS_REASON_CD")]
        [StringLength(100)]
        public string? CbsReasonCode { get; set; }
    }
}
