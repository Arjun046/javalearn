using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace NACH.DAL.Model
{
    [Table("NACH_MMS_CATEGORY_MST")]
    public class nach_mms_category_mst
    {
        [MaxLength(11)]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Column("TRAN_CD")]
        public int TranCode { get; set; }
        [Column("CATEGORY_CD")]
        [StringLength(5)]
        public string CategoryCode { get; set; }
        [Column("ACH_TYPE")]
        [StringLength(2)]
        public string? AchType { get; set; }
        [Column("CATEGORY_DESC")]
        [StringLength(50)]
        public string? CategoryDesc { get; set; }
    }
}
