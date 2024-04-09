namespace NACH.API.ControllerModel.Request.NachAccount
{
    public class NachAccountEdit : BaseRequestModel
    {
        public string EnteredBankCode { get; set; }

      

        public string? BranchCode { get; set; }

  

        public string? CustomerNo { get; set; }

        public string? AcctNm { get; set; }

        public string? AadhaarNo { get; set; }
        public string? MobileNo { get; set; }
        public string? PanNo { get; set; }

        public string? ModifyBy { get; set; }
        public DateTime? ModifyDt { get; set; }

        public string AcctNo { get; set; }
        public string? Status { get; set; }

        public string? SecAcctNm { get; set; }

        public string? SecPanNo { get; set; }
    }
}

