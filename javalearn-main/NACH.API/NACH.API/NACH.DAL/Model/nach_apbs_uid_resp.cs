using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace NACH.DAL.Model
{
    [Table("NACH_APBS_UID_RESP")]
    public class nach_apbs_uid_resp
    {
        [StringLength(6)]
        [Column("ENTERED_BANK_CD")]
        public string EnteredBankCode { get; set; }
        [Column("ENTERED_BRANCH_CD")]
        [StringLength(5)]
        public string EnteredBranchCode { get; set; }
        [Column("TRAN_CD")]
        [MaxLength(20)]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int TranCode { get; set; }
        [Column("TRAN_DT")]
        public DateTime? TranDt { get; set; }
        [Column("FILE_CD")]
        [MaxLength(11)]
        public int? FileCode { get; set; }
        [Column("FILE_NM")]
        [StringLength(100)]
        public string FileNm { get; set; }
        [Column("AADHAAR_NO")]
        [StringLength(30)]
        public string AadhaarNo { get; set; }
        [Column("MAPPED_IIN")]
        [StringLength(15)]
        public string? MappedIin { get; set; }
        [Column("SCHEME")]
        [StringLength(4)]
        public string? Scheme { get;set; }
        [Column("MANDATE_CUST_DATE")]
        [StringLength(20)]
        public string? MandateCustDate { get;set; }
        [Column("MAPPING_STATUS")]
        [StringLength(10)]


        public string? MappingStatus { get;set; }
        [Column("UID_RESULT")]
        [StringLength(200)]
        public string? UidResult { get;set; }
        [Column("ACCEPTED")]
        [StringLength(5)]
        public string? Accepted { get;set; }
        [Column("UID_REASON_CODE")]
        [MaxLength(11)]
        public int? UidReasonCode { get;set; }

        [Column("MAKE_BY")]
        [StringLength(20)]
        public string? MakeBy { get; set; }
        [Column("MAKE_DT")]
        public DateTime? MakeDt { get; set; }
        [Column("MAKE_PC_NM")]
        [StringLength(30)]
        public string? MakePcNm { get; set; }
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
        public string? RejectPerson { get; set; }
        [Column("REJECT_OTHER_REASON")]
        [StringLength(100)]
        public string? RejectOtherReason { get; set; }
    }
}
