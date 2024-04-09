namespace NACH.API.ControllerModel.Request.CancelReason
{
    public class CancelReasonCodeEditModel:BaseRequestModel
    {
        public string BankCode { get; set; }

        public int TranCode { get; set; }

        public string ReasonCode { get; set; }

        public string Description { get; set; }

        public string? AssignBy { get; set; } = "B";
    }
}
