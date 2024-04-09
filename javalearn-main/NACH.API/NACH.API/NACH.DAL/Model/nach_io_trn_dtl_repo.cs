using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace NACH.DAL.Model
{
    [Table("NACH_IO_TRN_DTL_REPO")]
    public class nach_io_trn_dtl_repo
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
        [Column("SR_CD")]
        [MaxLength(20)]
        public int SrCode { get; set; }
        [Column("ACCT_NO")]
        [StringLength(50)]
        public string? AcctNo { get; set; }
        [Column("AADHAAR_NO")]
        [StringLength(30)]
        public string? AadhaarNo { get; set; }
        [Column("CBS_ACCT_OP_DT")]

        public DateTime? CbsAcctOpDt { get; set; }
        [Column("CBS_ACCT_NO")]
        [StringLength(20)]
        public string? CbsAcctNo { get; set; }
        [Column("CBS_BRANCH_CD")]
        [StringLength(6)]
        public string? CbsBranchCode { get; set; }
        [Column("CBS_PROD_TYPE")]
        [StringLength(4)]
        public string? CbsProdType { get; set; }
        [Column("CBS_CUSTOMER_NO")]
        [StringLength(20)]
        public string? CbsCustomerNo { get; set; }
        [Column("CBS_INT_TYPE")]
        [StringLength(4)]
        public string? CbsIntType { get; set; }
        [Column("CBS_ACCT_NM")]
        [StringLength(100)]
        public string? CbsAcctNm { get; set; }
        [Column("CBS_AADHAAR_NO")]
        [StringLength(30)]
        public string? CbsAadhaarNo { get; set; }
        [Column("CBS_MOBILE_NO")]
        [StringLength(15)]
        public string? CbsMobileNo { get; set; }
        [Column("CBS_ACCT_STATUS")]
        [StringLength(10)]
        public string? CbsAcctStatus { get; set; }

        [Column(TypeName ="decimal(14,2)")]
        public decimal? AMOUNT { get; set; }
        [Column("FILE_STATUS")]
        [StringLength(2)]

        public string? FileStatus { get; set; }
        [Column("ACCT_STATUS")]
        [StringLength(2)]
        public string? AcctStatus { get; set; }
        [Column("RETURN_REASON_CD")]
        [StringLength(5)]
        public string? ReturnReasonCode { get; set; }
        [Column("TRN_TYPE")]
        [StringLength(5)]
        public string? TrnType { get; set; }
        [Column("UMR_NO")]
        [StringLength(35)]
        public string? UmrNo { get; set; }
    }
}
