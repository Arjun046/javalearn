using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace NACH.DAL.Model
{
    [Table("STATE_MST")]
    public class StateMst
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Column("TRAN_CD")]
        public int TranCode { get; set; }

        [Column("STATE_NM")]
        [StringLength(100)]
        public string StateNm { get; set; }

        [Unicode(false)]
        [Column("COUNTRY_CD")]
        public int CountryCode { get; set; }
    }
}
