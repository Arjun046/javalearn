using System.ComponentModel.DataAnnotations;

namespace NACH.API.ControllerModel.Request.NachAccount
{
    public class NachaccountView : BaseRequestModel
    {
        public string EnteredBankCode { get; set; }

        public string EnteredBranchCode { get; set; }

       
    }
}
