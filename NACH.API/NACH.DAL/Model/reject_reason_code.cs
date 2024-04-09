using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace NACH.DAL.Model
{
    [Table("REJECT_REASON_CODE")]
    public class reject_reason_code
    {
        [StringLength(6)]
        [Column("BANK_CD")]
        public string BankCode { get; set; }
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Column("TRAN_CD")]
        [MaxLength(11)]
        public int TranCode { get; set; }
        [Column("FILE_STATUS")]
        [StringLength(4)]
        public string FileStatus { get; set; }
        [Column("FILE_STATUS_DESC_REJECT")]
        [StringLength(100)]
        public string FileStatusDescReject { get; set; }
        [Column("REASON_CD")]
        [StringLength(4)]
        public string ReasonCode { get; set; }
        [Column("DESCRIPTION")]
        [StringLength(300)]
        public string? Description { get; set; }
    }
}
