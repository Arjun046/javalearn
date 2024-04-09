using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace NACH.DAL.Model
{
    [Table("MANDATE_MST")]
    public class mandate_mst
    {
        [StringLength(6)]
        [Column("BANK_CD")]
        public string BankCode { get; set; }
        [Column("BRANCH_CD")]
        [StringLength(6)]
        public string BranchCode { get; set; }
        [Column("TRAN_CD")]
        [MaxLength(11)]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int TranCode { get; set; }
        [Column("TRAN_DT")]
        public DateTime? TranDt { get; set; }
        [Column("REF_NO")]
        [StringLength(20)]
        public string? RefNo { get; set; }
        [Column("MNDT_FILE_NM")]
        [StringLength(100)]
        public string? MndtFileNm { get; set; }
        [Column("MSG_ID")]
        [StringLength(35)]
        public string? MsgId { get; set; }
        [Column("CRE_DT_TM")]
        [StringLength(30)]
        public string? CredtTm { get; set; }
        [Column("SPN_BANK_CORP_ID")]
        [StringLength(35)]
        public string? SpnBankCorpId { get; set; }
        [Column("SPN_BANK_IFSC")]
        [StringLength(11)]
        public string? SpnBankIfsc { get; set; }
        [Column("SPN_BANK_NM")]
        [StringLength(50)]

        public string? SpnBankNm { get; set; }
        [Column("DEST_BANK_IFSC")]
        [StringLength(11)]
        public string? DestBankIfsc { get; set; }
        [Column("DEST_BANK_NM")]
        [StringLength(50)]
        public string? DestBankNm { get; set; }
        [Column("MNDT_REQ_ID")]
        [StringLength(35)]
        public string? MndtReqId { get; set; }
        [Column("UMR_NO")]
        [StringLength(45)]
        public string? UmrNo { get; set; }
        [Column("MNDT_CATEGORY")]
        [StringLength(5)]
        public string? MndtCategory { get; set; }
        [Column("MNDT_TYPE")]
        [StringLength(35)]
        public string? MndtType { get; set; }
        [Column("SEQ_TYPE")]
        [StringLength(4)]
        public string? SeqType { get; set; }
        [Column("FRQCY")]
        [StringLength(4)]
        public string? Frqcy { get; set; }
        [Column("FRST_COLLTN_DT")]
        [StringLength(20)]
        public string? FrstColltnDt { get; set; }
        [Column("FNL_COLLTN_DT")]
        [StringLength(20)]
        public string? FnlColltnDt { get; set; }
        [Column("COLLTN_AMT")]
        [StringLength(15)]
        public string? ColltnAmt { get; set; }
        [Column("CR_NM")]
        [StringLength(100)]
        public string? CrNm { get; set; }
        [Column("CR_ACCT_NO")]
        [StringLength(35)]
        public string? CrAcctNo { get; set; }
        [Column("CR_AGT_IFSC")]
        [StringLength(11)]
        public string? CrAgtIfsc { get; set; }
        [Column("CR_AGT_NM")]
        [StringLength(100)]
        public string? CrAgtNm { get; set; }
        [Column("DR_NM")]
        [StringLength(100)]
        public string? DrNm { get; set; }
        [Column("DR_REF_NO")]
        [StringLength(35)]
        public string? DrRefNo { get; set; }
        [Column("DR_SCHEME")]
        [StringLength(35)]
        public string? DrScheme { get; set; }
        [Column("DR_PHNO")]
        [StringLength(35)]
        public string? DrPhNo { get; set; }
        [Column("DR_MOBNO")]
        [StringLength(35)]
        public string? DrMobNo { get; set; }
        [Column("DR_EMAIL")]
        [StringLength(50)]
        public string? DrEmail { get; set; }
        [Column("DR_OTHER")]
        [StringLength(35)]
        public string? DrOther { get; set; }
        [Column("DR_ACCT_NO")]
        [StringLength(35)]
        public string? DrAcctNo { get; set; }
        [Column("DR_ACCT_TYPE")]
        [StringLength(35)]
        public string? DrAcctType { get; set; }
        [Column("DR_AGT_IFSC")]
        [StringLength(11)]
        public string? DrAgtIfsc { get; set; }
        [Column("DR_AGT_NM")]
        [StringLength(100)]
        public string? DrAgtNm { get; set; }
        [Column("MNDT_F_IMG")]
        [MaxLength()]
        public byte[]? MndtFImg { get; set; }
        [Column("MNDT_D_IMG")]
        [MaxLength()]
        public byte[]? MndtDImg { get; set; }
        [Column("FILE_NM")]
        [StringLength(100)]
        public string? FileNm { get; set; }
        [StringLength(1)]
        [Column("STATUS")]
        public string? Status { get; set; } = "P";
    }
}
