using System.ComponentModel.DataAnnotations;

namespace NACH.API.ControllerModel.Request.Bank
{
    public class BankEdit : BaseRequestModel
    {
        [Required]
        public string BankCode { get; set; }
        [Required]
        public string? BankName { get; set; }
        public string? BankCategory { get; set; }
        [DataType(DataType.Date)]
        public DateTime? RegestrationDate { get; set; }
        public string? BsrCode { get; set; }
        public string? UniqueFiuld { get; set; }
        public string? ContactPerson { get; set; }
        public string? Designation { get; set; }
        public string? Address { get; set; }
        public string? CityName { get; set; }
        public int? StateCode { get; set; }
        public int? CountryCode { get; set; }
        public string? PinCode { get; set; }
        public string? Mobile { get; set; }
        public string? Phone { get; set; }
        public string? Email { get; set; }
        public string? Fax { get; set; }
        public string? UtilityVersion { get; set; }
        public string? DataStructureVersion { get; set; }

    }
}
