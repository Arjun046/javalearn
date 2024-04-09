using System.ComponentModel.DataAnnotations.Schema;

namespace NACH.API.ControllerModel.Request.NachAccount
{
    public class NachAccountAdd : BaseRequestModel
    {

        public string EnteredBankCode { get; set; }

        public string EnteredBranchCode { get; set; }

        public string? BranchCode { get; set; }

        public string AcctNo { get; set; }

        public string? CustomerNo { get; set; }

        public string? AcctNm { get; set; }

        public string? AadhaarNo { get; set; }
        public string? MobileNo { get; set; }
        public string? PanNo { get; set; }

        public string? Status { get; set; }

       
        public DateTime TranDt { get; set; }
        public string? EntryBy { get; set; }

       
        public DateTime? EntryDt { get; set; }
        public string? SecAcctNm { get; set; }

        public string? SecPanNo { get; set; }
    }
}
