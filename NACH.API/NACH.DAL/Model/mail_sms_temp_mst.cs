using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace NACH.DAL.Model
{
    [Table("MAIL_SMS_TEMP_MST")]
    public class mail_sms_temp_mst
    {
        [MaxLength(20)]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Column("TRAN_CD")]
        public int TranCode { get; set; }
        [StringLength(1)]
        [Column("TYPE")]

        public string Type { get; set; } = "M";
        [Column("NACH_TYPE")]
        [StringLength(20)]
        public string NachType { get; set; }
        [Column("TEMP_ID")]
        [StringLength(8)]
        public string? TempId { get; set; }
        [Column("TEMP_NM")]
        [StringLength(100)]
        public string TempNm { get; set; }
        [Column("SUBJECT")]
        [StringLength(100)]
        public string? Subject { get; set; }
        [Column("MESSAGE")]
        [MaxLength()]
        public string? Message { get; set; }
        [Column("SMS_TEMP_ID")]
        [StringLength(30)]
        public string? SmsTempId { get; set; }
        [Column("STATUS")]
        [StringLength(1)]
        public string? Status { get; set; }
        [Column("INT_CUST_STATUS")]
        [StringLength(1)]
        public string? IntCustStatus { get; set; } = "I";
        [Column("DEFAULT_1")]
        [StringLength(100)]
        public string? Default1 { get; set; }
        [Column("DEFAULT_2")]
        [StringLength(100)]
        public string? Default2 { get; set; }
        [Column("DEFAULT_3")]
        [StringLength(100)]
        public string? Default3 { get; set; }
        [Column("ENTRY_BY")]
        [StringLength(30)]
        public string? EntryBy { get; set; }
        [Column("ENTRY_DT")]
        public DateTime? EntryDt { get; set; }
        [Column("MODIFY_BY")]
        [StringLength(30)]
        public string? ModifyBy { get; set; }
        [Column("MODIFY_DT")]
        public DateTime? ModifyDt { get; set; } 
    }
}
