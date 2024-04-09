using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace NACH.DAL.Model
{
    [Table("CITY_MST")]
    public class city_mst:EntityBase
    {
        [Key]
        [MaxLength(11)]
        [Column("TRAN_CD")]
        public int TranCode { get; set; }
        [Column("CITY_NM")]
        [StringLength(45)]
        public string? CityNm { get; set; }
        [Column("STATE_CD")]
        [MaxLength(11)]
        public int? StateCode { get; set; }
        [StringLength(1)]
        [Unicode(false)]
        [Column("STATUS")]
        public string Status { get; set; } = "N";
    }
}
