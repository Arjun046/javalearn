namespace NACH.API.ControllerModel.Request.BankIIN
{
    public class BankIINView : BaseRequestModel
    { 
        public string BankCode { get; set; }
        public string BranchCode { get; set; }
    }
}
