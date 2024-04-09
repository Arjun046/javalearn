using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace NACH.DAL.Model
{
    [Table("NACH_TYPE_MST")]
    public class nach_type_mst
    {
        [MaxLength(11)]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Column("TRAN_CD")]
        public int TranCode { get; set; }
        [Column("NACH_TYPE")]
        [StringLength(10)]
        public string NachType { get; set; }
        [Column("DESCRIPTION")]
        [StringLength(50)]
        public string? Description { get; set; }
        [Column("STATUS")]
        [StringLength(1)]
        public string? Status { get; set; } = "Y";
    }
}
