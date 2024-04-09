namespace NACH.API.ControllerModel.Request.MmsReason
{
    public class mmsreasonedit : BaseRequestModel
    {
        public int TranCode { get; set; }
        public string ReasonCode { get; set; }

        public string ReasonType { get; set; }

        public string? ReasonDesc { get; set; }
    }
}
