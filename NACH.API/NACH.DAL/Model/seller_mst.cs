using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace NACH.DAL.Model
{
    [Table("SELLER_MST")]
    public class seller_mst
    {
        [MaxLength(11)]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Column("TRAN_CD")]
        public int TranCode { get; set; }
        [Column("SELLER_ID")]
        [StringLength(8)]
        public string SellerId { get; set; }
        [Column("TRAN_DT")]

        public DateTime TranDt { get; set; }= DateTime.Now;
        [Column("COMP_NM")]
        [StringLength(100)]
        public string CompNm { get; set; }
        [Column("CONTACT_PERSON_NM")]
        [StringLength (100)]
        public string ContactPersonNm { get; set; }
        [Column("CONTACT1")]
        [StringLength(13)]
        public string? Contact1 { get; set; }
        [Column("CONTACT2")]
        [StringLength(13)]

        public string? Contact2 { get; set; }
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
        [Column("DOMAIN_NM")]
        [StringLength(50)]
        public string? DomainNm { get; set; }
        [Column("LOGO_ID")]
        [MaxLength()]
        public string? LogoId { get; set; }
        [Column("COMP_INFO")]
        [MaxLength()]
        public string? CompInfo { get; set; }
        [Column("WEB_SITE")]
        [StringLength(300)]
        public string? WebSite { get; set; }
        [Column("PLAY_STORE")]
        [MaxLength()]

        public string? PlayStore { get; set; }
        [Column("PASSWORD")]
        [StringLength(100)]
        public string Password { get; set; }
        [Column("STATUS")]
        [StringLength(1)]
        public string Status { get; set; } = "Y";
        [Column("IP_ADDRESS")]
        [StringLength(20)]
        public string Ipaddress { get; set; }
    }
}
