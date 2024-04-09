namespace NACH.API.ControllerModel.Request.AcctType
{
    public class AcctTypeModel : BaseRequestModel
    {
        public string BankCode { get; set; }
        public string BranchCode { get; set; }
        public int TranCode { get; set; }
        public string AccountType { get; set; }
        public string TypeName { get; set; }
        public string CbsCode { get; set; }

        public string VerifyStatus { get; set; }
    }
}
