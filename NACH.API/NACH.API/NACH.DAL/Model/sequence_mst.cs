using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace NACH.DAL.Model
{
    [Table("SEQUENCE_MST")]
    public class sequence_mst
    {
        [Column("SEQUENCE_NM")]
        [StringLength(50)]
        [Key]
        public string SequenceNm { get; set; }

        [Column("TranCd")]
        [MaxLength(20)]
        public int TranCode { get; set; }
    }
}
