    using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace NACH.DAL.Model
{
    [Table("FORM_MST")]
    public class form_mst
    {
        [StringLength(100)]
        [Key]
        [Column("FORM_NM")]
        public string FormNm { get; set; }
        [Column("FORM_CAPTION")]
        [StringLength(100)]
        public string? FormCaption { get; set; }
        [Column("SEQ_NO")]
        [MaxLength(11)]
        public int? SeqNo { get; set; } = 0;
        [Column("TYPE")]
        [StringLength(1)]
        public string? Type { get; set; } = "S";
        [Column("MAIN_FORM")]
        [StringLength(100)]
        public string? MainForm { get; set; } = "M";
        [Column("FORM_SAVE")]
        [StringLength(1)]
        public string? FormSave { get; set; } = "N";
        [Column("FORM_UPDATE")]
        [StringLength(1)]
        public string? FormUpdate { get; set; } = "N";
        [Column("FORM_DELETE")]
        [StringLength(1)]
        public string? FormDelete { get; set; } = "N";
        [Column("FORM_SHOW")]
        [StringLength(1)]
        public string? FormShow { get; set; } = "N";
        [Column("FORM_VIEW")]
        [StringLength(1)]
        public string? FormView { get; set; } = "N";
        [Column("FORM_AUTO_AUTH")]
        [StringLength(1)]
        public string? FormAutoAuth { get; set; } = "N";
    }
}
