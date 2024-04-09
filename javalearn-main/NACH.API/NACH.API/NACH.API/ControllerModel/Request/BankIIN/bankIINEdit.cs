namespace NACH.API.ControllerModel.Request.BankIIN
{
    public class bankIINEdit : BaseRequestModel
    {
        public string BankIIn { get; set; }
        public string Ifsc { get; set; }
        public string Micr { get; set; }
        public string BankNm { get; set; }
        public string IinStatus { get; set; }
        public string IfscStatus { get; set; }
        public string MicrStatus { get; set; }
        public DateTime ModifyDt { get; set; }
        public string BankCode { get; set; }
        public int TranCode { get; set; }
    }
}
