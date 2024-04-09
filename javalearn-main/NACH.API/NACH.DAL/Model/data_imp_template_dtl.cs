using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace NACH.DAL.Model
{
    [Table("DATA_IMP_TEMPLATE_DTL")]
    public class data_imp_template_dtl
    {
        [StringLength(6)]
        [Column("BANK_CD")]
        public string BankCode { get; set; }
        [Column("BRANCH_CD")]
        [StringLength(5)]

        public string BranchCode { get; set; }
        [Column("TRAN_CD")]
        [MaxLength(20)]
        public int TranCode { get; set; }
        [Column("SR_CD")]
        [MaxLength(6)]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]

        public int SrCode { get; set; }
        [Column("DB_COLUMN_NM")]
        [StringLength(20)]
        public string? DbColumnNm { get; set; }
        [Column("COL_PK_FLAG")]
        [StringLength(2)]
        public string? ColPkFlag { get; set; }
        [Column("DATA_TYPE")]
        [StringLength(20)]
        public string DataType { get; set; }
        [Column("NUM_SCALE")]
        [MaxLength(4)]
        public int NumScale { get; set; } = '2';
        [Column("VALIDATION_SQL")]
        [MaxLength()]
        public string? ValidationSql { get; set; }
        [Column("COL_SEQ_NO")]
        [MaxLength(6)]
        public int ColSeqNo { get; set; }
        [Column("COL_SIZE")]
        [MaxLength(20)]
        public int ColSize { get; set; }
        [Column("FROM_VAL")]
        [MaxLength(20)]
        public int? FromVal { get; set; }
        [Column("TO_VAL")]
        [MaxLength(20)]
        public int? ToVal { get; set; }
        [Column("DEFAULT_VAL")]
        [MaxLength()]
        public string? DefaultVal { get; set; }
        [Column("COL_DESC")]

        [MaxLength()]
        public string? ColDesc { get; set; }
        [Column("COL_FORMAT")]
        [StringLength(50)]
        public string? ColFormat { get; set; }
        
    }
}
