using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace NACH.DAL.Model
{
    [Table("NACH_OW_RESPONSE_MST")]
    public class nach_ow_response_mst
    {
        [StringLength(6)]
        [Column("ENTERED_BANK_CD")]
        public string EnteredBankCode { get; set; }
        [Column("ENTERED_BRANCH_CD")]
        [StringLength(5)]
        public string EnteredBranchCode { get; set; }
        [Column("TRAN_CD")]
        [MaxLength(20)]
        public int TranCode { get; set; }
        [Column("TRAN_DT")]
        public DateTime TranDt { get; set; }
        [Column("MNDT_FILE_NM")]
        [StringLength(200)]
        public string? MndtFileNm { get; set; }
        [Column("MSG_ID")]
        [StringLength(35)]
        public string? MsgId { get; set; }
        [Column("CRE_DT_TM")]
        [StringLength(35)]
        public string? CreDtTm { get; set; }
        [Column("UMRN")]
        [StringLength(35)]
        public string? Umrn { get; set; }
        [Column("SPN_BANK_NM")]
        [StringLength(50)]
        public string? SpnBankNm { get; set; }
        [Column("DEST_BANK_NM")]
        [StringLength(50)]
        public string? DestBankNm { get; set; }
        [Column("MNDT_IW_XML")]
        [MaxLength()]
        public string? MndtIwXml { get; set; }
        [Column("STATUS")]
        [StringLength(6)]
        public string? Status { get; set; } = "FALSE";
        [Column("REASON_CD")]
        [StringLength(10)]
        public string? ReasonCode { get; set; }
        [Column("ENTRY_BY")]
        [StringLength(30)]
        public string? EntryBy { get; set; }
        [Column("MODIFY_BY")]
        [StringLength(30)]
        public string? ModifyBy { get; set; }
        [Column("ENTRY_DT")]
        public DateTime? EntryDt { get; set; }
        [Column("MODIFY_DT")]
        public DateTime? ModifyDt { get; set; }
        [Column("ENTRY_PC_NM")]
        [StringLength(30)]
        public string? EntryPcNm { get; set; }
        [Column("MODIFY_PC_NM")]
        [StringLength(30)]
        public string? ModifyPcNm { get; set; }
    }
}
