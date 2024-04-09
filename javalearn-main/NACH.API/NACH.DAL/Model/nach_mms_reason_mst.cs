using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace NACH.DAL.Model
{
    [Table("NACH_MMS_REASON_MST")]
    public class nach_mms_reason_mst
    {
        [MaxLength(11)]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Column("TRAN_CD")]
        public int TranCode { get; set; }
        [Column("REASON_CD")]
        [StringLength(5)]
        public string ReasonCode { get; set; }
        [Column("REASON_TYPE")]
        [StringLength(1)]
        public string ReasonType { get; set; }
        [Column("REASON_DESC")]
        [StringLength(50)]
        public string? ReasonDesc { get; set; }
    }
}
