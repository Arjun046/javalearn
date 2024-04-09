using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace NACH.DAL.Model
{
    [Table("NACH_CONFIG_COLUMN")]
    public class nach_config_column
    {
        [StringLength(6)]
        [Column("BANK_CD")]
        public string BankCode { get; set; }
        [Column("PARA_CD")]
        [StringLength(50)]
        public string ParaCode { get; set; }
        [Column("DESCRIPTION")]
        [MaxLength()]
        public string? Description { get; set; }
        [Column("PARA_VALUE")]
        [StringLength(100)]
        public string? Paravalue { get; set; }
        [Column("PARA_TYPE")]
        [StringLength(1)]

        public string? ParaType { get; set; } = "U";
        [Column("COL_FLAG")]
        [StringLength(1)]
       
        public string? ColFlag { get; set; }
    }
}
