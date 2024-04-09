using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace NACH.DAL.Model
{
    [Table("PAGE_NOTES_MST")]
    public class page_notes_mst
    {
        [StringLength(100)]
        [Column("PAGE_CD")]
        public string PageCode { get; set; }
        [Column("PAGE_NM")]
        [StringLength(100)]
        public string? PageNm { get; set; }
        [Column("DATA")]
        [MaxLength()]
        public string? Data { get; set; }
    }
}
