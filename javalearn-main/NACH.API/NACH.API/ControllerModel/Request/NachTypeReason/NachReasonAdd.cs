namespace NACH.API.ControllerModel.Request.NachTypeReason
{
    public class NachReasonAdd
    {
        public int TranCode { get; set; }
        public string NachType { get; set; }

        public string ReasonCode { get; set; }
        public string? ReasonDesc { get; set; }

        public double? CHRG_AMT { get; set; }
        public string? CbsReasonCode { get; set; }
    }
}
