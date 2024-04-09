using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace NACH.DAL.Model
{
    [Table("COUNTRY_MST")]
    public class country_mst : EntityBase
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [MaxLength()]
        [Unicode(false)]
        [Column("TRAN_CD")]
        public int TranCode { get; set; }

        [StringLength(100)]
        [Unicode(false)]
        [Column("COUNTRY_NM")]
        public string CountryName { get; set; }

        [StringLength(5)]
        [Unicode(false)]
        [Column("SORT_NM")]
        public string? SortName { get; set; }

        [StringLength(5)]
        [Unicode(false)]
        [Column("PHONE_CODE")]
        public string? PhoneCode { get; set; }
    }
}
