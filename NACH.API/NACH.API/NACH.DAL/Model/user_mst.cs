using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace NACH.DAL.Model
{
    [Table("USER_MST")]
    public class user_mst
    {
        [MaxLength(11)]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Column("TRAN_CD")]
        public int TranCode { get; set; }
        [Column("SELLER_ID")]
        [StringLength(8)]
        public string SellerId { get; set; }
        [Column("USER_ID")]
        [StringLength(10)]
        
        public string UserId { get; set; }
        [Column("BANK_CD")]
        [StringLength(6)]
        public string BankCode { get; set; }
        [Column("BRANCH_CD")]
        [StringLength(5)]
        public string? BranchCode { get; set; }
        [Column("TRAN_DT")]
        public DateTime? TranDt { get; set; } = DateTime.Now;
        [StringLength(100)]
        [Column("PASSWORD")]
        public string Password { get; set; }
        [Column("PERSON_NAME")]
        [StringLength(100)]
        public string PersonName { get; set; }
        [Unicode(false)]
        [Column("PASS_HASH")]
        public string PasswordHash { get; set; }
        [Column("LAST_LOGIN")]
        public DateTime? LastLogin { get; set; }
        [Column("USER_TYPE")]
        [StringLength(1)]
        public string UserType { get; set; } = "U";
        [Column("MOBILE_NO1")]
        [StringLength(15)]
        public string? MobileNo1 { get; set; }
        [Column("MOBILE_NO2")]
        [StringLength(15)]
        public string? MobileNo2 { get; set; }
        [Column("EMAIL_ID")]
        [StringLength(100)]
        public string? EmailId { get; set; }
        [Column("STATUS")]
        [StringLength(1)]
        public string Status { get; set; } = "Y";
        [Column("ADDRESS1")]
        [StringLength(200)]
        public string? Address1 { get; set; }
        [Column("ADDRESS2")]
        [StringLength(200)]
        public string? Address2 { get; set; }
        [Column("CITY_CD")]
        [StringLength(20)]
        public string? CityCode { get; set; }
        [Column("STATE_CD")]
        [StringLength(20)]
        public string? StateCode { get; set; }
        [Column("COUNTRY_CD")]
        [StringLength(20)]
        public string? CountryCode { get; set; }
        [Column("PIN_CODE")]
        [StringLength(6)]
        public string? PinCode { get; set; }

        [Column("2F_AUTH")]
        [StringLength(1)]
        public string? TF_AUTH { get; set; } = "N";
    }
}
