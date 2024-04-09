namespace NACH.API.ControllerModel.Request.User
{
    public class getUser: BaseRequestModel
    {
        public string UserId { get; set; }
        public string BranchCode {  get; set; }
        public string BankCode {  get; set; }
    }
}
