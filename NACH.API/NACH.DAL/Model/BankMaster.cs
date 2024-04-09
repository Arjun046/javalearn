    using Microsoft.EntityFrameworkCore;

using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace NACH.DAL.Model
{
    [Table("BANK_MASTER")]
    public class BankMaster : EntityBase
    {
        [Key]
        [StringLength(6)]
        [Unicode(false)]
        [Column("BANK_CD")]
        public string BankCode { get; set; }

        [StringLength(15)]
        [Column("BANK_IIN")]

        public string BankIIN {  get; set; }

        [StringLength(100)]
        [Unicode(false)]
        [Column("BANK_NM")]
        public string? BankName { get; set; }

        [StringLength(20)]
        [Unicode(false)]
        [Column("BANK_CATEGORY")]
        public string? BankCategory { get; set; }

        [StringLength(250)]
        [Unicode(false)]
        [Column("ADDRESS")]
        public string? Address { get; set; }

        [StringLength(100)]
        [Unicode(false)]
        [Column("CITY_NM")]
        public string? CityName { get; set; }

        [MaxLength()]
        [Unicode(false)]
        [Column("REG_DT")]
        public DateTime? RegestrationDate { get; set; }

        [StringLength(50)]
        [Unicode(false)]
        [Column("BSR_CODE")]
        public string? BsrCode { get; set; }

        [StringLength(50)]
        [Unicode(false)]
        [Column("UNIQUE_FIULD")]
        public string? UniqueFiuld { get; set; }

        [StringLength(100)]
        [Unicode(false)]
        [Column("CONTACT_PERSON")]
        public string? ContactPerson { get; set; }

        [StringLength(300)]
        [Unicode(false)]
        [Column("DESIGNATION")]
        public string? Designation { get; set; }

        [StringLength(10)]
        [Unicode(false)]
        [Column("PIN_CODE")]
        public string? PinCode { get; set; }

        [StringLength(2)]
        [Unicode(false)]
        [Column("STATE_CD")]
        public int? StateCode { get; set; }

        [StringLength(2)]
        [Unicode(false)]
        [Column("COUNTRY_CD")]
        public int? CountryCode { get; set; }

        [StringLength(15)]
        [Unicode(false)]
        [Column("PHONE")]
        public string? Phone { get; set; }

        [StringLength(15)]
        [Unicode(false)]
        [Column("MOBILE")]
        public string? Mobile { get; set; }

        [StringLength(50)]
        [Unicode(false)]
        [Column("EMAIL", TypeName = "varchar(50)")]
        public string? Email { get; set; }

        [StringLength(45)]
        [Unicode(false)]
        [Column("FAX", TypeName = "varchar(45)")]
        public string? Fax { get; set; }

        [StringLength(10)]
        [Unicode(false)]
        [Column("UTILITY_VERSION")]
        public string? UtilityVersion { get; set; }

        [StringLength(10)]
        [Unicode(false)]
        [Column("DATA_STARUCTURE_VERSION")]
        public string? DataStructureVersion { get; set; }

        [MaxLength()]
        [Unicode(false)]
        [Column("CTR_COUNT")]
        public int? CtrCount { get; set; }

        [MaxLength()]
        [Unicode(false)]
        [Column("NTR_COUNT")]
        public int? NtrCount { get; set; }

        [MaxLength()]
        [Unicode(false)]
        [Column("STR_COUNT")]
        public int? StrConnt { get; set; }

        [MaxLength()]
        [Unicode(false)]
        [Column("CCR_COUNT")]
        public int? CcrCount { get; set; }
    }
}
