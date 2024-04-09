using System.ComponentModel.DataAnnotations;

namespace NACH.API.ControllerModel.Request.City
{
    public class CityEditModel:CityAddModel
    {
        [Required]
        public int TranCode { get; set; }
    }
}
