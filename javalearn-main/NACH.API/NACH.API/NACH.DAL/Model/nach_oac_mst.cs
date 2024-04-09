using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace NACH.DAL.Model
{
    [Table("NACH_OAC_MST")]
    public class nach_oac_mst
    {
        [StringLength(6)]
        [Column("ENTERED_BANK_CD")]
        public string EnteredBankCode { get; set; }
        [Column("ENTERED_BRANCH_CD")]
        [StringLength(6)]
        public string EnteredBranchCode { get; set; }
        [Column("TRAN_CD")]
        [MaxLength(20)]
        public int TranCode { get; set; }
        [Column("TRAN_DT")]
        public DateTime? TranDt { get; set; }=DateTime.Now;
        [Column("CONFIG_CD")]
        [MaxLength(20)]
        public int? ConfigCode { get; set; }
        [Column("FILE_NM")]
        [StringLength(200)]

        public string? FileNm { get; set; }
        [Column("NACH_ID")]
        [StringLength(2)]
        public string? NachId { get; set; }
        [Column("ORG_CD")]
        [StringLength(11)]
        public string? OrgCode { get; set; }
        [Column("RSP_CD")]
        [StringLength(11)]
        public string? RspCode { get; set; }
        [Column("FILE_UPDT")]
        [StringLength(10)]
        public string? FileUpdt { get; set; }
        [Column("FILE_REF_NO")]
        [StringLength(10)]
        public string? FileRefNo { get; set; }
        [Column("TOTAL_TRN")]
        [MaxLength(11)]
        public int? TotalTrn { get; set; }
        [Column("RET_CONFIG_CD")]
        [MaxLength(20)]
        public int? RetConfigCode { get; set; }
        [Column("ENTRY_BY")]
        [StringLength(20)]
        public string? EntryBy { get; set; }
        [Column("ENTRY_DT")]
        public DateTime? EntryDt { get; set; } =DateTime.Now;
        [Column("ENTRY_PC_NM")]
        [StringLength(30)]
        public string? EntryPcNm { get; set; }
        [Column("VERIFY_BY")]
        [StringLength(20)]

        public string? VerifyBy { get; set; }
        [Column("VERIFY_DT")]
        public DateTime? VerifyDt { get; set; }
        [Column("VERIFY_PC_NM")]
        [StringLength(30)]
        public string? VerifyPcNm { get; set; }
        [Column("VERIFY_STATUS")]
        [StringLength(1)]
        public string? VerifyStatus { get; set; } = "P";
        [Column("REJECT_REASON")]
        [StringLength(5)]
        public string? RejectReason { get; set; }
        [Column("REJECT_OTHER_REASON")]
        [StringLength(100)]
        public string? RejectOtherReason { get; set; }
    }
}
