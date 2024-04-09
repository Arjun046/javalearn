using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace NACH.DAL.Model
{
    [Table("NACH_IO_TRN_MST")]
    public class nach_io_trn_mst
    {
        [StringLength(6)]
        [Column("ENTERED_BANK_CD")]
        public string EnteredBankCode { get; set; }
        [
        Column("ENTERED_BRANCH_CD")]
        [StringLength(5)]
        public string EnteredBranchCode { get; set; }

        [Column("TRAN_CD")]
        [MaxLength(20)]
        public int TranCode { get; set; }

        [Column("NACH_TYPE")]
        [StringLength(10)]
        public string? NachType { get; set; }

        [Column("TRAN_DT")]
        public DateTime TranDate { get; set; } = DateTime.Now;

        [Column("CONFIG_CD")]
        [MaxLength(20)]
        public int? ConfigCode { get; set; }

        [Column("RET_CONFIG_CD")]
        [MaxLength(20)]
        public int? RetConfigCode { get; set; }

        [Column("FILE_NM")]
        [StringLength(200)]
        public string? FileName { get; set; }

        [Column("NACH_ID")]
        [StringLength(6)]
        public string? NachId { get; set; }

        [Column("BANK_IIN")]
        [StringLength(15)]
        public string? BankIIN { get; set; }

        [Column("TOTAL_TRN")]
        [MaxLength(20)]
        public int? TotalTRN { get; set; }

        [Column("TOTAL_TRN_AMT")]
       // [Column(TypeName = "decimal(14,2)")]
        public double? TotalTrnAmt { get; set; }

        [Column("ST_DATE")]
        [StringLength(10)]
        public string? StDate { get; set; }

        [Column("ST_CYCLE")]
        [StringLength(10)]
        public string? StCycle { get; set; }

        [Column("USER_NM")]
        [StringLength(20)]
        public string? UserName { get; set; }

        [Column("USER_NO")]
        [StringLength(20)]
        public string? UserNo { get; set; }

        [Column("TRN_REF_NO")]
        [StringLength(50)]
        public string? TrnRefNo { get; set; }

        [Column("TRN_TYPE")]
        [StringLength(1)]
        public string? TrnType { get; set; }

        [Column("GL_BRANCH_CD")]
        [StringLength(4)]
        public string? GLBranchCode { get; set; }

        [Column("GL_PROD_TYPE")]
        [StringLength(4)]
        public string? GLProdType { get; set; }

        [Column("GL_ACCT_NO")]
        [StringLength(50)]
        public string? GLAcctNo { get; set; }

        [Column("ENTRY_BY")]
        [StringLength(20)]
        public string? EntryBy { get; set; }

        [Column("ENTRY_DT")]
        public DateTime? EntryDate { get; set; } = DateTime.Now;

        [Column("ENTRY_PC_NM")]
        [StringLength(30)]
        public string? EntryPCDate { get; set; }

        [Column("MODIFY_BY")]
        [StringLength(20)]
        public string? ModifyBy { get; set; }

        [Column("MODIFY_DT")]
        public DateTime? ModifyDate { get; set; }

        [Column("MODIFY_PC_NM")]
        [StringLength(30)]
        public string? ModifyPCName { get; set; }

        [Column("CBS_CONFIG_CD")]
        [MaxLength(20)]
        public int? CBSConfigCode { get; set; }

        [Column("VERIFY_BY")]
        [StringLength(20)]
        public string? VerifyBy { get; set; }

        [Column("VERIFY_DT")]
        public DateTime? VerifyDate { get; set; }

        [Column("VERIFY_PC_NM")]
        [StringLength(30)]
        public string? VerifyPCName { get; set; }

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