namespace NACH.API.ControllerModel.Response
{
    public class SuccessResponse
    {
        public string Status { get; set; } = "0";
        public string? Message { get; set; } 
        public object? Response { get; set; }
    }
}
