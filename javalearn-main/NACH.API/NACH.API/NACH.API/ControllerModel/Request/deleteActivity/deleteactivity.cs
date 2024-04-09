namespace NACH.API.ControllerModel.Request.deleteActivity
{
    public class deleteactivity : BaseRequestModel
    {
        public int TranCode { get; set; }
        public string? BankCode { get; set; }

        public string ls_req_type { get; set; }

        public string BranchCode { get; set; }

        public string UserId { get; set; }

        public string EnteredBankCode { get; set; }
        public string AcctNo { get; set; }
        public string Code { get; set; }

        public string EnteredBranchCode { get; set; }

        public string? NachType { get; set; }

    }
}
