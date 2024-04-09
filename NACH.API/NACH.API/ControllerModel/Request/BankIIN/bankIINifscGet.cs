namespace NACH.API.ControllerModel.Request.BankIIN
{
    public class bankIINifscGet : BaseRequestModel
    {

        public string? BranchCode { get; set; }
        public string? BankCode { get; set; }
    }
}
