using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Security;

namespace NACH.DAL.Model
{
    [Table("NACH_IW_MANDATE_MST")]
    public class nach_iw_mandate_mst
    {
        [StringLength(6)]
        [Column("ENTERED_BANK_CD")]
        public string EnterdBankCode { get; set; }

        [StringLength(5)]
        [Column("ENTERED_BRANCH_CD")]
        public string EnterdBranchCode { get; set; }

        [MaxLength(20)]
        [Column("TRAN_CD")]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int TranCode { get; set; }

        [Column("TRAN_DT")]
        public DateTime TranDate { get; set; }

        [StringLength(20)]
        [Column("REF_NO")]
        public string RefNo { get; set; }

        [StringLength(100)]
        [Column("FILE_NM")]
        public string? FileName { get; set; }

        [StringLength(100)]
        [Column("MNDT_FILE_NM")]
        public string? MNDTFileName { get; set; }

        [StringLength(35)]
        [Column("MSG_ID")]
        public string MsgId { get; set; }

        [StringLength(30)]
        [Column("CRE_DT_TM")]
        public string CreDateTime { get; set; }

        [StringLength(35)]
        [Column("SPN_BANK_CORP_ID")]
        public string? SPNBankCorpId { get; set; }

        [StringLength(11)]
        [Column("SPN_BANK_IFSC")]
        public string SPNBankIfsc { get; set; }

        [StringLength(50)]
        [Column("SPN_BANK_NM")]
        public string? SPNBankName { get; set; }

        [StringLength(11)]
        [Column("DEST_BANK_IFSC")]
        public string DESTBankIfsc { get; set; }

        [StringLength(50)]
        [Column("DEST_BANK_NM")]
        public string? DESTBankName { get; set; }

        [StringLength(35)]
        [Column("MNDT_REQ_ID")]
        public string MNDTReqId { get; set; }

        [StringLength(35)]
        [Column("UMR_NO")]
        public string UmrNo { get; set; }

        [StringLength(4)]
        [Column("MNDT_CATEGORY")]
        public string MndtCategory { get; set; }

        [StringLength(35)]
        [Column("MNDT_TYPE")]
        public string? MndtType { get; set; }

        [StringLength(4)]
        [Column("SEQ_TYPE")]
        public string? SeqType { get; set; }

        [StringLength(4)]
        [Column("FRQCY")]
        public string? frqcy { get; set; }

        [StringLength(20)]
        [Column("FRST_COLLTN_DT")]
        public string? frstColltnDate { get; set; }

        [StringLength(20)]
        [Column("FNL_COLLTN_DT")]
        public string? FnlColltnDate { get; set; }

        [StringLength(13)]
        [Column("COLLTN_AMT")]
        public string? ColltnAmt { get; set; }

        [StringLength(140)]
        [Column("CR_NM")]
        public string? CrName { get; set; }

        [StringLength(50)]
        [Column("CR_ACCT_NO")]
        public string? CrAcctNo { get; set; }

        [StringLength(11)]
        [Column("CR_AGT_IFSC")]
        public string? CrAgtIfsc { get; set; }

        [StringLength(100)]
        [Column("CR_AGT_NM")]
        public string? CrAgtName { get; set; }

        [StringLength(100)]
        [Column("DR_NM")]
        public string? DrName { get; set; }

        [StringLength(35)]
        [Column("DR_REF_NO")]
        public string? DrRefNo { get; set; }

        [StringLength(35)]
        [Column("DR_SCHEME")]
        public string? DrScheme { get; set; }

        [StringLength(35)]
        [Column("DR_PHNO")]
        public string? DrPhoneNo { get; set; }

        [StringLength(35)]
        [Column("DR_MOBNO")]
        public string? DrMobNo { get; set; }

        [StringLength(50)]
        [Column("DR_EMAIL")]
        public string? DrEmail { get; set; }

        [StringLength(35)]
        [Column("DR_OTHER")]
        public string? DrOther { get; set; }

        [StringLength(50)]
        [Column("DR_ACCT_NO")]
        public string? DrAcctNo { get; set; }

        [StringLength(35)]
        [Column("DR_ACCT_TYPE")]
        public string? DrAcctType { get; set; }

        [StringLength(11)]
        [Column("DR_AGT_IFSC")]
        public string? DrAgtIfsc { get; set; }

        [StringLength(100)]
        [Column("DR_AGT_NM")]
        public string? DrAgtName { get; set; }

        [MaxLength()]
        [Column("MNDT_IW_XML")]
        public string? MndtIwXML { get; set; }

        [MaxLength()]
        [Column("MNDT_F_IMG")]
        public string? MndtFImage { get; set; }

        [MaxLength()]
        [Column("MNDT_D_IMG")]
        public string? MndtDImage { get; set; }

        [StringLength(1)]
        [Column("STATUS")]
        public string? Status { get; set; } = "P";

        [StringLength(10)]
        [Column("REASON_CD")]
        public string? ReasonCode { get; set; }

        [StringLength(20)]
        [Column("ACCT_NO")]
        public string? AcctNo { get; set; }

        [StringLength(20)]
        [Column("ENTRY_BY")]
        public string? EntryBy { get; set; }

        [Column("ENTRY_DT")]
        public DateTime? EntryDate { get; set; }

        [StringLength(30)]
        [Column("ENTRY_PC_NM")]
        public string? EntryPcName { get; set; }

        [StringLength(20)]
        [Column("MODIFY_BY")]
        public string? ModifyBy { get; set; }

        [Column("MODIFY_DT")]
        public DateTime? ModifyDate { get; set; }

        [StringLength(30)]
        [Column("MODIFY_PC_NM")]
        public string? ModifyPcName { get; set; }

        [StringLength(20)]
        [Column("VERIFY_BY")]
        public string? VerifyBy { get; set; }

        [Column("VERIFY_DT")]
        public DateTime? VerifyDate { get; set; }

        [StringLength(30)]
        [Column("VERIFY_PC_NM")]
        public string? VerifyPcName { get; set; }

        [StringLength(1)]
        [Column("VERIFY_STATUS")]
        public string? VerifyStatus { get; set; } = "P";

        [StringLength(5)]
        [Column("REJECT_REASON")]
        public string? RejectReason { get; set; }

        [StringLength(100)]
        [Column("REJECT_OTHER_REASON")]
        public string? RejectOtherReason { get; set; }

        [StringLength(30)]
        [Column("DATE_OF_MANDATE")]
        public string? DateOfMandate { get; set; }
    }
}
