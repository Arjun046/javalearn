using NACH.API.ControllerModel.Response;

namespace NACH.API.Models.Response
{
    public class PagedResponse : SuccessResponse
    {
        public int PageNumber { get; set; }
        public int PageSize { get; set; }
        public int TotalPages { get; set; }
        public int TotalRecords { get; set; }
        public int FilterRecords { get; set; }
    }
}
