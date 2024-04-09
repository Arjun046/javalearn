using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace NACH.DAL.Model
{
    [Table("NACH_OAC_DTL")]
    public class nach_oac_dtl
    {
        [StringLength(6)]
        [Column("ENTERED_BANK_CD")]
        public string EnteredBankCode { get; set; }
        [Column("ENTERED_BRANCH_CD")]
        [StringLength(6)]
        public string EnteredBranchCode { get; set; }
        [Column("TRAN_CD")]
        [MaxLength(6)]
        public int TranCode { get; set; }
        [Column("SR_CD")]
        [MaxLength(6)]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int SrCode { get; set; }
        [Column("NACH_ID")]
        [StringLength(2)]

        public string? NachId { get; set; }
        [Column("RECORD_REF_NO")]
        [StringLength(15)]

        public string? RecordRefNo { get; set; }
        [Column("IFSC_CD")]
        [StringLength(11)]
        public string? IfscCode { get; set; }
        [Column("OLD_ACCT_TYPE")]
        [StringLength(2)]
        public string? OldAcctType { get; set; }
        [Column("OLD_ACCT_NO")]
        [StringLength(20)]

        public string? OldAcctNo { get; set; }
        [Column("OLD_ACCT_NM")]
        [StringLength(100)]
        public string? OldAcctNm { get; set; }
        [Column("USER_NO")]
        [StringLength(10)]
        public string? UserNo { get; set; }
        [Column("USER_NM")]
        [StringLength(20)]
        public string? UserNm { get; set; }
        [Column("TRN_REF_NO")]
        [StringLength(15)]
        public string? TrnRefNo { get; set; }
        [Column("VALID_FLAG")]
        [StringLength(2)]
        public string? ValidFlag { get; set; } = "N";
        [Column("REASON_CD")]
        [StringLength(5)]
        public string? ReasonCode { get; set; }
        [Column("ACCT_NO")]
        [StringLength(20)]
        public string? AcctNo { get; set; }

    }
}
