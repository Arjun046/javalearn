namespace NACH.API.ControllerModel.Request.NachMmsCategory
{
    public class NachMmsCategoryAdd
    {

        public int TranCode { get; set; }
        public string CategoryCode { get; set; }

        public string? AchType { get; set; }

        public string? CategoryDesc { get; set; }
    }
}
