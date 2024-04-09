namespace NACH.API.ControllerModel.Request.BankIIN
{
    public class bankIINGet : BaseRequestModel
    {
        public string? BankIIn { get; set; }
        public string? BranchCode { get; set; }
        public string? BankCode { get; set; }
    }
}
