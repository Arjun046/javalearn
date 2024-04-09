using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace NACH.DAL.Model
{
    [Table("NACH_OW_TRN_DTL")]
    public class nach_ow_trn_dtl
    {
        [StringLength(6)]
        [Column("ENTERED_BANK_CD")]
        public string EntreredBankCode { get; set; }
        [Column("ENTERED_BRANCH_CD")]
        [StringLength(5)]
        public string EntreredBranchCode { get; set; }
        [Column("TRAN_CD")]
        [MaxLength(20)]
        public int TranCode { get; set; }
        [Column("SR_CD")]
        [MaxLength(20)]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]   

        public int SrCode { get; set; }
        [Column("NACH_ID")]
        [StringLength(6)]
        public string? NachId { get; set; }
        [Column("NACH_SEQ_NO")]
        [StringLength(15)]
        public string? NachSeqNo { get; set; }
        [Column("TRN_REF_NO")]
        [StringLength(50)]
        public string? TrnRefNo { get; set; }
        [Column("BRANCH_CD")]
        [StringLength(6)]
        public string? BranchCode { get; set; }
        [Column("PROD_TYPE")]
        [StringLength(4)]
        public string? ProdType { get; set; }
        [Column("ACCT_NO")]
        [StringLength(50)]
        public string? AcctNo { get; set; }
        [Column("DEST_ACCT_NO")]
        [StringLength(50)]
        public string? DestAcctNo { get; set; }
        [Column("DEST_BANK_IIN")]
        [StringLength(15)]
        public string? DestBankIin { get; set; }
        [Column("DEST_IFSC_MICR")]
        [StringLength(30)]
        public string? DestIfscMicr { get; set; }
        [Column("DEST_ACCT_TYPE")]
        [StringLength(6)]
        public string? DestAcctType { get; set; }
        [Column("DEST_ACCT_NM")]
        [StringLength(50)]
        public string? DestAcctNm { get; set; }
        [Column("SPON_BANK_IIN")]
        [StringLength(15)]
        public string? SponBankIin { get; set; }
        [Column("LF_NO")]
        [StringLength(15)]

        public string? LfNo { get; set; }
        [Column("UMRN")]
        [StringLength(30)]
        public string? Umrn { get; set; }
        [Column("AADHAAR_NO")]
        [StringLength(30)]
        public string? AadhaarNo { get; set; }
        [Column("USER_NO")]
        [StringLength(20)]
        public string? UserNo { get; set; }
        [Column("USER_NM")]
        [StringLength(20)]

        public string? UserNm { get; set; }

        [Column(TypeName ="decimal(14,2)")]
        public double? AMOUNT { get; set; } = 0.00;
        [Column("CHECKSUM")]
        [StringLength(15)]
        public string? CheckSum { get; set; }
        [Column("CONFIRMED")]
        [StringLength(1)]
        public string? Confirmed { get; set; } = "N";
        [Column("STATUS")]
        [StringLength(2)]
        public string? Status { get; set; }
        [Column("RETURN_REASON_CD")]
        [StringLength(5)]
        public string? ReturnReasonCode { get; set; }
    }
}
