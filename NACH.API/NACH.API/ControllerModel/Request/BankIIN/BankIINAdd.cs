namespace NACH.API.ControllerModel.Request.BankIIN
{
    public class BankIINAdd : BaseRequestModel
    {
        public string? BankCode { get; set; }

        public string BranchCode { get; set; }
        public string BankNm { get; set; }

        public string? BankIIn { get; set; }

        public string? Ifsc { get; set; }

        public string? Micr { get; set; }

        public string? EntryBy { get; set; }

        public DateTime? EntryDt { get; set; }

        public string? IinStatus { get; set; }

        public string? IfscStatus { get; set; }

        public string? MicrStatus { get; set; }


    }
}
