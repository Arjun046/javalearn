using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace NACH.DAL.Model
{
    [Table("DUMMY")]
    public class dummy
    {
        [MaxLength(1)]
        [Key]
        [Column("row_no")]
        public int RowNo { get; set; }
    }
}
