using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace NACH.DAL.Model
{
    [Table("NACH_FILE_CONFIG_DTL")]
    public class nach_file_config_dtl
    {
        [StringLength(6)]
        [Column("BANK_CD")]
        public string BankCode { get; set; }
        [Column("TRAN_CD")]
        [MaxLength(20)]
        public int TranCode { get; set; }
        [Column("SR_CD")]
        [MaxLength(11)]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int SrCode { get; set; }
        [Column("CONFIG_FLAG")]
        [StringLength(1)]
        public string ConfigFlag { get; set; }
        [Column("COLUMN_SEQ")]
        [MaxLength(11)]
        public int ColumnSeq { get; set; }
        [Column("VALUE_DESC")]
        [StringLength(100)]
        public string? ValueDesc { get; set; }
        [Column("START")]
        [MaxLength(11)]
        public int Start { get; set; }= 0;
        [Column("COL_SIZE")]
        [MaxLength(11)]
        public int ColSize { get; set; }
        [Column("END")]
        [MaxLength(11)]
        public int End { get; set; } = 0;
        [Column("ALIGNMENT")]
        [StringLength(1)]
        public string? Alignment { get; set; }
        [Column("VALUE_TYPE")]
        [StringLength(50)]
        public string? ValueType { get; set; }
        [Column("DEFAULT_VALUE")]
        [StringLength(100)]
        public string? DefaultValue { get; set; }

        [Column("FILL_BY")]
        [StringLength(1)]
        public string? FillBy { get; set; }
        [Column("FILL_BY_VALUE")]
        [StringLength(100)]
        public string? FillByValue { get; set; }
        [Column("VALUE_FORMAT")]
        [StringLength(50)]
        public string? ValueFormat { get; set; }
        [Column("MODIFY_BY")]
        [StringLength(20)]
        public string? ModifyBy { get; set; }
        [Column("MODIFY_DT")]

        public DateTime? ModifyDt { get; set; }
    }
}
