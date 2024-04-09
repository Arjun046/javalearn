using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace NACH.DAL.Model
{
    [Table("NACH_DBTL_AV_DTL")]
    public class nach_dbtl_av_dtl
    {
        [StringLength(6)]
        [Column("ENTERED_BANK_CD")]
        public string EnteredBankCode { get; set; }
        [Column("ENTERED_BRANCH_CD")]
        [StringLength(5)]
        public int EnteredBranchCode { get; set; }
        [Column("TRAN_CD")]
        [MaxLength(20)]
        public int TranCode { get; set; }
        [Column("SR_CD")]
        [MaxLength(20)]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int SrCode { get; set; }
        [Column("RECORD_ID")]
        [StringLength(2)]
        public string? RecordId { get; set; }
        [Column("RECORD_REF_NO")]
        [StringLength(15)]

        public string? RecordRefNo { get; set; }
        [Column("BEN_IFSC_CD")]
        [StringLength(11)]
        public string? BenIfscCode { get; set; }
        [Column("BEN_ACCT_NO")]
        [StringLength(35)]
        public string? BenAcctNo { get; set; }
        [Column("BEN_ACCT_NM")]
        [StringLength(100)]
        public string? BenAcctNm { get; set; }
        [Column("LPG_CONS_ID")]
        [StringLength(17)]
        public string? LpgConsId { get; set; }
        [Column("VALID_FLAG")]
        [StringLength(2)]
        public string? ValidFlag { get; set; } = "P";
        [Column("BEN_NM_FLAG")]
        [StringLength(2)]
        public string? BenNmFlag { get; set; }
        [Column("RSP_BEN_NM")]
        [StringLength(100)]

        public string? RspBenNm { get; set; }
        [Column("AADHAAR_NO")]
        [StringLength(30)]
        public string? AadhaarNo { get; set; }
        [Column("BRANCH_CD")]
        [StringLength(4)]
        public string? BranchCode { get; set; }
        [Column("PROD_TYPE")]
        [StringLength(4)]
        public string? ProdType { get; set; }
        [Column("ACCT_NO")]
        [StringLength(50)]
        public string? AcctNo { get; set; }
        [Column("JOINT_ACCT_FLAG")]
        [StringLength(2)]
        public string? JointAcctFlag { get; set; }
        [Column("PRIMARY_PAN_NO")]
        [StringLength(10)]
        public string?  PrimaryPanNo { get; set; }
        [Column("SECONDARY_PAN_NO")]
        [StringLength(10)]
        public string? SecondaryPanNo  { get; set; }
        [Column("PRIMARY_ACCT_NAME")]
        [StringLength(50)]
        public string? PrimaryAcctName { get; set; }
        [Column("SECONDARY_ACCT_NAME")]
        [StringLength(50)]
        public string? SecondaryAcctName { get; set; }
        [Column("ACCT_TYPE")]
        [StringLength(2)]
        public string? AcctType { get; set; }
        
    }
}
