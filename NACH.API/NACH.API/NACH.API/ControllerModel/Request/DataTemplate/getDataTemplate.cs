namespace NACH.API.ControllerModel.Request.DataTemplate
{
    public class getDataTemplate : BaseRequestModel
    {
        public string BankCode { get; set; }
        public string BranchCode { get; set; }
        public string? ActiveStatus { get; set; }
    }
}
