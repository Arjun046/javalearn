using System.ComponentModel.DataAnnotations;

namespace NACH.API.ControllerModel.Request.Country
{
    public class CountryEditModel:CountryAddModel
    {
        [Required]
        public int TranCode { get; set; }
    }
}
