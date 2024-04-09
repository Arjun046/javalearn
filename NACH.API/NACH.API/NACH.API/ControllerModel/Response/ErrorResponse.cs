namespace NACH.API.ControllerModel.Response
{
    public class ErrorResponse
    {
        public string Status { get; set; } = "99";
        public string? Message { get; set; } = null;
        public object? Response { get; set; }
    }
}
