namespace NACH.API.ControllerModel.Request.Branch
{
    public class GetBranchUserWise : BaseRequestModel
    {

        public string BranchCode { get; set; }

        public string BankCode { get; set; }

        public string UserId { get; set; }
    }
}
