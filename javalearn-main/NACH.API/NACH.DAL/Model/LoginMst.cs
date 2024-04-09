using Microsoft.EntityFrameworkCore;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace NACH.DAL.Model
{
    [Table("LOGIN_MST")]
    public class LoginMst : EntityBase
    {
        [StringLength(10)]
        [Column("BANK_CD")]
        public string? BankCode { get; set; }

        [Key]
        [StringLength(15)]
        [Column("USER_ID")]
        public string UserId { get; set; }

        [Column("USER_PASS")]
        public string UserPass { get; set; }

        [Column("PASS_SALT")]
        public string PasswordSalt { get; set; }

        [StringLength(5)]
        [Column("BRANCH_CD")]
        public string BranchCode { get; set; }

        [StringLength(50)]
        [Column("USER_NM")]
        public string UserName { get; set; }

        [Column("CREATE_DATE")]
        public DateTime CreateDate { get; set; }

        [StringLength(1)]
        [Column("ACTIVE_STATUS")]
        public string ActiveStatus { get; set; } = "1";

        //[StringLength(15)]
        //[Column("USER_LEVEL")]
        //public string UserLevel { get; set; }

        [Column("ROLE_CD")]
        public int RoleId { get; set; }

        [StringLength(100)]
        [Unicode(false)]
        [Column("REMARKS")]
        public string? Remarks { get; set; }

        [StringLength(50)]
        [Column("TOKEN_ID")]
        public string? TokenId { get; set; }

        [MaxLength()]
        [Column("LAST_ACTIVITY")]
        public DateTime? LastActivity { get; set; }

        [StringLength(500)]
        [Column("LAST_ACTIVITY_TYPE")]
        public string? LastActivityType { get; set; }

        [StringLength(80)]
        [Column("OFFICER_NM")]
        public string? OfficerName { get; set; }

        [StringLength(80)]
        [Column("DESIGNATION")]
        public string? Designation { get; set; }

        [StringLength(255)]
        [Column("ADDRESS")]
        public string? Address { get; set; }

        [StringLength(50)]
        [Column("CITY_NM")]
        public string? CityName { get; set; }

        [StringLength(10)]
        [Column("PINCODE")]
        public string? PinCode { get; set; }

        [StringLength(2)]
        [Column("STATE_CD")]
        public string? StateCode { get; set; }

        [StringLength(2)]
        [Column("COUNTRY_CD")]
        public string? CountryCode { get; set; }

        [StringLength(30)]
        [Column("PHONE")]
        public string? Phone { get; set; }

        [StringLength(30)]
        [Column("MOBILE_NO")]
        public string? MobileNumber { get; set; }

        [StringLength(30)]
        [Column("FAX")]
        public string? Fax { get; set; }

        [StringLength(50)]
        [Column("EMAIL_ID")]
        public string? EmailId { get; set; }

        [StringLength(6)]
        [Column("OTP_CD")]
        public string? OTPCode { get; set; }

        [StringLength(1)]
        [Column("OTP_STATUS")]
        public string? OTPStatus { get; set; }

        [MaxLength()]
        [Column("LAST_LOGIN_DT")]
        public DateTime? LastLoginDate { get; set; }

        //[StringLength(1)]
        //[Column("USER_TYPE")]
        //public string? UserType { get; set; }

        [StringLength(15)]
        [Column("CUST_USER_NM")]
        public string? CustUserName { get; set; }

        [StringLength(1)]
        [Column("RESET_FLAG")]
        public string? ResetFlag { get; set; } = "N";

        [StringLength(30)]
        [Column("NPCI_USER")]
        public string? NPCIUser { get; set; }

        [Column("LOCK_OUT_END")]
        public DateTime? LockoutEnd { get; set; }

        [DefaultValue(true)]
        [Column("LOCK_OUT_ENABLED")]
        public bool LockoutEnabled { get; set; } = true;

        [DefaultValue(0)]
        [Column("ACCESS_FAILED_COUNT")]
        public int AccessFailedCount { get; set; }

        [StringLength(100)]
        [Column("REFRESH_TOKEN")]
        public string? RefreshToken { get; set; }

        [Column("REFRESH_TOKEN_EXPIRY_TIME")]
        public DateTime? RefreshTokenExpiryTime { get; set; }

        [StringLength(100)]
        [Column("SESSION_ID")]
        public string? SessionId { get; set; }

    }
}
