namespace NACH.API.ControllerModel.Request.Company
{
    public class CompMstModel:BaseRequestModel
    {
        public string SellerId { get; set; }

        public string BankCode { get; set; }

        public string UserId { get; set; }

        public string Password {  get; set; }

        public string? CompNm { get; set; }

        public string? MobileNo1 { get; set; }

        public string? MobileNo2 { get; set; }

        public string? EmailId { get; set; }

        public string? Address1 { get; set; }
    }
}
