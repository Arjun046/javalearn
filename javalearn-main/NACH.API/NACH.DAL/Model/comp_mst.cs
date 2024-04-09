using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace NACH.DAL.Model
{
    [Table("COMP_MST")]
    public class comp_mst:  EntityBase
    {
        [StringLength(8)]
        [Column("SELLER_ID")]
        public string SellerId { get; set; }
        [Column("BANK_CD")]
        [StringLength(6)]
        public string BankCode { get; set; }
        [Column("USER_ID")]
        [StringLength(10)]
        public string UserId { get; set; }
        [Column("TRAN_DT")]
        public DateTime? TranDt { get; set; } = DateTime.Now;
        [Column("PASSWORD")]

        [StringLength(100)]
        public string Password { get; set; }
        [Column("COMP_NM")]
        [StringLength(100)]
        public string? CompNm { get; set; }
        [Column("MOBILE_NO1")]
        [StringLength(15)]

        public string? MobileNo1 { get; set; }
        [Column("MOBILE_NO2")]
        [StringLength(15)]
        public string? MobileNo2 { get; set; }
        [Column("EMAIL_ID")]
        [StringLength(100)]
        public string? EmailId { get; set; }
        [Column("ADDRESS1")]
        [StringLength(200)]
        public string? Address1 { get; set; }
        [Column("ADDRESS2")]
        [StringLength(200)]

        public string? Address2 { get; set; }
        [Column("CITY_CD")]
        [StringLength(100)]
        public string? CityCode { get; set; }
        [Column("STATE_CD")]
        [StringLength(100)]
        public string? StateCode { get; set; }
        [Column("COUNTRY_CD")]
        [StringLength(100)]
        public string? CountryCode { get; set; }
        [Column("PIN_CODE")]
        [StringLength(6)]
        public string? PinCode { get; set; }
        [Column("REGISTRATION_DT")]
        public DateTime? RegistrationDt { get; set; }
        [Column("LICENCE_DT")]
        public DateTime? LicenceDt { get; set; }
        [Column("LICENCE_NUMERIC")]
        [StringLength(20)]
        public string? LicenceNumeric{ get; set; }
        [Column("STATUS")]
        [StringLength(1)]
        public string? Status { get; set; } = "Y";
       
    }
}
