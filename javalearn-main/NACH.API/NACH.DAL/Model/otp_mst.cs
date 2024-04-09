using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace NACH.DAL.Model
{
    [Table("OTP_MST")]
    public class otp_mst
    {
        [Key]
        [MaxLength()]
        [Unicode(false)]
        [Column("OTP_ID", TypeName = "int")]
        public int OtpId { get; set; }

        [MaxLength()]
        [Unicode(false)]
        [Column("TRAN_DT", TypeName = "datetime")]
        public DateTime TranDate { get; set; }

        [StringLength(13)]
        [Unicode(false)]
        [Column("MOBILE_NO", TypeName = "varchar(13)")]
        public string? MobileNumber { get; set; }

        [StringLength(6)]
        [Unicode(false)]
        [Column("OTP_CD", TypeName = "varchar(6)")]
        public string? OtpCode { get; set; }

        [StringLength(1)]
        [Unicode(false)]
        [Column("OTP_SEND", TypeName = "char(1)")]
        public string? OtpSend { get; set; }

        [StringLength(1)]
        [Unicode(false)]
        [Column("OTP_VERIFY", TypeName = "char(1)")]
        public string? OtpVerify { get; set; }

        [StringLength(100)]
        [Unicode(false)]
        [Column("EMAIL_ID", TypeName = "varchar(100)")]
        public string? EmailId { get; set; }

        [StringLength(6)]
        [Unicode(false)]
        [Column("MAIL_OTP", TypeName = "varchar(6)")]
        public string? MailOtp { get; set; }

        [StringLength(1)]
        [Unicode(false)]
        [Column("MAIL_SEND", TypeName = "char(1)")]
        public string? MailSend { get; set; }

        [StringLength(1)]
        [Unicode(false)]
        [Column("MAIL_OTP_VERIFY", TypeName = "char(1)")]
        public string? MailOtpVerify { get; set; }

        [StringLength(2)]
        [Unicode(false)]
        [Column("OTP_TYPE", TypeName = "varchar(2)")]
        public string? OtpType { get; set; }

        [StringLength(45)]
        [Unicode(false)]
        [Column("LATITUDE", TypeName = "varchar(45)")]
        public string? Latitude { get; set; }

        [StringLength(45)]
        [Unicode(false)]
        [Column("LONGITUDE", TypeName = "varchar(45)")]
        public string? Longitude { get; set; }

        [StringLength(45)]
        [Unicode(false)]
        [Column("IP_ADDRESS", TypeName = "varchar(45)")]
        public string? IpAddress { get; set; }

        [MaxLength()]
        [Unicode(false)]
        [Column("OTP_ATTEMP", TypeName = "int")]
        public int? OtpAttemp { get; set; }
    }
}
