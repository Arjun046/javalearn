using Microsoft.EntityFrameworkCore;

using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace NACH.DAL.Model
{
    [Table("BRANCH_MST")]
    public class BranchMst : EntityBase
    {
        [Key]
        [StringLength(6)]
        [Unicode(false)]
        [Column("BANK_CD")]
        public string BankCode { get; set; }

        [StringLength(6)]
        [Unicode(false)]
        [Column("BRANCH_CD")]
        public string BranchCode { get; set; }

        [StringLength(100)]
        [Unicode(false)]
        [Column("BRANCH_NM")]
        public string BranchName { get; set; }

        [StringLength(200)]
        [Unicode(false)]
        [Column("ADDRESS")]
        public string? Address { get; set; }

        [StringLength(100)]
        [Unicode(false)]
        [Column("CITY_NM")]
        public string? CityName { get; set; }

        [StringLength(10)]
        [Column("PINCODE")]
        public string? PinCode { get; set; }

        [StringLength(2)]
        [Column("STATE_CD")]
        public int? StateCode { get; set; }

        [Column("COUNTRY_CD")]
        public int? CountryCode { get; set; }


        [StringLength(100)]
        [Unicode(false)]
        [Column("CONTACT_PERSON")]
        public string? ContactPerson { get; set; }


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
        [Column("EMAIL")]
        public string? Email { get; set; }

        [StringLength(12)]
        [Unicode(false)]
        [Column("MICR_CD")]
        public string? MicrCode { get; set; }

        [StringLength(11)]
        [Unicode(false)]
        [Column("IFSC_CD")]
        public string? IfscCode { get; set; }

        [StringLength(1)]
        [Unicode(false)]
        [Column("BASE_MICR_BR")]
        public string? BaseMicrBr { get; set; }

        [StringLength(45)]
        [Unicode(false)]
        [Column("FAX")]
        public string? Fax { get; set; }

        [StringLength(20)]
        [Unicode(false)]
        [Column("CBS_CD")]
        public string? CbsCode { get; set; }

    }
}
