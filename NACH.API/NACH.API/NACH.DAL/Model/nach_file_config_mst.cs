using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace NACH.DAL.Model
{
    [Table("NACH_FILE_CONFIG_MST")]
    public class nach_file_config_mst
    {
        [StringLength(6)]
        [Column("BANK_CD")]
        public string BankCode { get; set; }
        [Column("TRAN_CD")]
        [MaxLength(20)]
        public int TranCode { get; set; }
        [Column("NACH_TYPE")]
        [MaxLength(10)]
        public string NachType { get; set; }
        [Column("CONFIG_NM")]
        [StringLength(100)]

        public string ConfigNm { get; set; }
        [Column("CONFIG_TYPE")]
        [StringLength(1)]
        public string ConfigType { get; set; }
        [Column("DELIMITER_CD")]
        [StringLength(1)]
        public string? DelimiterCode { get; set; }
        [Column("DELIMITER_SIGN")]
        [StringLength(1)]
        public string? DelimiterSign { get; set; }
        [Column("FILE_FORMAT")]
        [StringLength(10)]

        public string? FileFormat { get; set; }
        [Column("FILE_NM")]
        [StringLength(100)]
        public string? FileNm { get; set; }
        [Column("SKIP_ROW_FLAG")]
        [StringLength(5)]
        public string? SkipRowFlag { get; set; } = "N";
        [Column("TRN_TYPE")]
        [StringLength(1)]

        public string? TrnType { get; set; } = "C";
        [Column("TRN_BRANCH_CD")]
        [StringLength(4)]
        public string? TrnBranchCode { get; set; }
        [Column("TRN_PROD_TYPE")]
        [StringLength(4)]
        public string? TrnProdType { get; set; }
        [Column("TRN_ACCT_NO")]
        [StringLength(20)]
        public string? TrnAcctNo { get; set; }
        [Column("CHRG_FLAG")]
        [StringLength(1)]
        public string? ChrgFlag { get; set; } = "N";
        [Column("CHRG_BRANCH_CD")]
        [StringLength(4)]
        public string? ChrgBranchCode { get; set; }
        [Column("CHRG_PROD_TYPE")]
        [StringLength(4)]
        public string? ChrgProdType { get; set; }
        [Column("CHRG_ACCT_NO")]
        [StringLength(20)]
        public string? ChrgAcctNo { get; set; }
        [Column("RET_TRN_TYPE")]
        [StringLength(1)]
        public string? RetTrnType { get; set; } = "N";
        [Column("RET_CHRG_FLAG")]
        [StringLength(1)]
        public string? RetChrgFlag { get; set; }="N";
        [Column("ENTRY_BY")]
        [StringLength(20)]
        public string? EntryBy { get; set; }
        [Column("ENTRY_DT")]

        public DateTime? EntryDt { get; set; }
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
        [Column("CBS_CONFIG_CD")]
        [StringLength(3)]
        public string? CbsConfigCode { get; set; }
        [Column("RET_CONFIG_CD")]
        [StringLength(3)]
        public string? RetConfigCode { get; set; }
    }
}
