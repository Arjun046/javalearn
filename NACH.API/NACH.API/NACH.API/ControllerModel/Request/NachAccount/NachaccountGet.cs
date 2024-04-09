namespace NACH.API.ControllerModel.Request.NachAccount
{
    public class NachaccountGet : BaseRequestModel
    {

        public string EnteredBankCode { get; set; }

        public string EnteredBranchCode { get; set; }

       
        public string? Status { get; set; }


        
    }
}
