using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace NACH.DAL.Model
{
    [Table("OW_MNDT_RESPONSE_MST")]
    public class ow_mndt_response_mst
    {
        [StringLength(6)]
        [Column("BANK_CD")]
        public string BankCode { get; set; }
        [Column("BRANCH_CD")]
        [StringLength(5)]
        public string BranchCode { get; set; }
        [Column("TRAN_CD")]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [MaxLength(11)]
        public int TranCode { get; set; }
        [Column("TRAN_DT")]

        public DateTime? TranDt { get; set; }
        [Column("MNDT_FILE_NM")]
        [StringLength(100)]
        public string? MndtFileNm { get; set; }
        [Column("MSG_ID")]
        [StringLength(35)]
        public string? MsgId { get; set; }
        [Column("CRE_DT_TM")]
        [StringLength(30)]
        public string? CreDtTm { get; set; }
        [Column("UMRN")]
        [StringLength(35)]
        public string? Umrn {  get; set; }
        [Column("SPN_BANK_NM")]
        [StringLength(50)]
        public string? SpnBankNm { get; set; }
        [Column("DEST_BANK_NM")]
        [StringLength(50)]
        public string? DestBankNm { get; set; }
        [Column("MNDT_IW_XML")]
        [MaxLength()]
        public byte[] MndtIwXml { get; set; }
        [Column("STATUS")]
        [StringLength(6)]
        public string? Status { get; set; } = "FALSE";
        [Column("REASON_CD")]
        [StringLength(10)]
        public string? ReasonCode { get; set; }
        
    }
}
