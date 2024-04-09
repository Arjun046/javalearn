using System.ComponentModel.DataAnnotations;

namespace NACH.API.ControllerModel.Request.Country
{
    public class CountryAddModel: BaseRequestModel
    {
        [Required]
        public string CountryName { get; set; }
        [Required]
        public string SortName { get; set; }
        [Required]
        public string PhoneCode { get; set; }
    }
}
