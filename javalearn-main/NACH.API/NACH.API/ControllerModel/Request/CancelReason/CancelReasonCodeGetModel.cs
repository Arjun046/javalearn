namespace NACH.API.ControllerModel.Request.CancelReason
{
    public class CancelReasonCodeGetModel:BaseRequestModel
    {

        public string BankCode { get; set; }

        public int TranCode { get; set; }

       // public string ReasonCode { get; set; }
    }
}
