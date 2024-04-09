using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace NACH.DAL.Model
{
    [Table("USER_PERMISSION")]
    public class user_permission
    {
        [StringLength(15)]
        [Column("USER_ID")]
        public string UserId { get; set; }
        [StringLength(100)]
        [Column("FORM_NM")]
        public string FormNm { get; set; }
        [Column("FORM_CAPTION")]
        [StringLength(100)]
        public string formCaption { get; set; }
        [Column("SEQ_NO")]
        [MaxLength(11)]
        public int? SeqNo { get; set; } = '0';
        [Column("TYPE")]
        [StringLength(1)]
        public string? Type { get; set; } = "S";
        [Column("MAIN_FORM")]
        [StringLength(100)]
        public string? MainForm { get; set; } = "M";
        [Column("BTN_SAVE")]
        [StringLength(1)]
        public string? BtnSave { get; set; } = "N";
        [Column("BTN_UPDATE")]
        [StringLength(1)]
        public string? BtnUpdate { get; set; } = "N";
        [Column("BTN_DELETE")]

        [StringLength(1)]
        public string? BtnDelete { get; set; } = "N";
        [Column("BTN_SHOW")]

        [StringLength(1)]
        public string? BtnShow { get; set; } = "N";
        [Column("FORM_OPEN")]

        [StringLength(1)]
        public string? FormOpen { get; set; } = "N";
        [Column("FORM_AUTO_AUTH")]

        [StringLength(1)]
        public string? FormAutoAuth { get; set; } = "N";

    }
}
