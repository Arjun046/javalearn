using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace NACH.DAL.Model
{
    [Table("NACH_OW_TRN_MST")]
    public class nach_ow_trn_mst
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
        [Column("NACH_TYPE")]
        [StringLength(10)]
        public string? NachType { get; set; }
        [Column("TRAN_DT")]
        public DateTime TranDt { get; set; }=DateTime.Now;
        [Column("CONFIG_CD")]
        [MaxLength(20)]
        public int? ConfigCode { get; set; }
        [Column("RET_CONFIG_CD")]
        [MaxLength(20)]
        public int? RetConfigCode { get; set; }
        [Column("FILE_NM")]
        [StringLength(200)]
        public string? FileNm { get; set; }
        [Column("NACH_ID")]
        [StringLength(6)]
        public string? NachId { get; set; }
        [Column("BANK_IIN")]
        [StringLength(15)]

        public string? BankIin { get; set; }
        [Column("TOTAL_TRN")]
        [MaxLength(20)]
        public int? TotalTrn { get; set; }

        [Column(TypeName = "decimal(14,2)")]
        public double TOTAL_TRN_AMT { get; set; } = 0.00;
        [Column("ST_DATE")]
        [StringLength(10)]

        public string? StDate { get; set; }
        [Column("ST_CYCLE")]
        [StringLength(10)]
        public string? StCycle { get; set; }
        [Column("USER_NM")]
        [StringLength(20)]
        public string? UserNm { get; set; }
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

        public string? GlBranchCode { get; set; }
        [Column("GL_PROD_TYPE")]
        [StringLength(4)]
        public string? GLProdType { get; set; }
        [Column("GL_ACCT_NO")]
        [StringLength(50)]
        public string? GlAcctNo { get; set; }
        [Column("ENTRY_BY")]
        [StringLength(20)]
        public string? EntryBy { get; set; }
        [Column("ENTRY_DT")]
        public DateTime? EntryDt { get; set; }=DateTime.Now;
        [Column("ENTRY_PC_NM")]
        [StringLength(30)]

        public string? EntryPcNm { get; set; }
        [Column("MODIFY_BY")]
        [StringLength(20)]
        public string? ModifyBy { get; set; }
        [Column("MODIFY_DT")]
        public DateTime? ModifyDt { get; set; }
        [Column("MODIFY_PC_NM")]
        [StringLength(30)]
        public string? ModifyPcNm { get; set; }
    }
}
