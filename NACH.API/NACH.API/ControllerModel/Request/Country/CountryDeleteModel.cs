using System.ComponentModel.DataAnnotations;

namespace NACH.API.ControllerModel.Request.Country
{
    public class CountryDeleteModel:BaseRequestModel
    {
        [Required]
        public int TranCode { get; set; }
    }
}
