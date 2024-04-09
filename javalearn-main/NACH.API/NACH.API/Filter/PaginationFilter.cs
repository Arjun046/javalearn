using NACH.API.ControllerModel;
using System.ComponentModel;


namespace NACH.API.Filter {
    public class PaginationFilter : BaseRequestModel {
        [DefaultValue(1)]
        public int PageNumber { get; set; }

        [DefaultValue(10)]
        public int PageSize { get; set; }

        public PaginationFilter() {
            this.PageNumber = 1;
            this.PageSize = 10;
        }
        public PaginationFilter(int pageNumber, int pageSize) {
            this.PageNumber = pageNumber < 1 ? 1 : pageNumber;
            this.PageSize = pageSize < 10 ? 10 : pageSize;
        }

        public bool IsPaginationEnabled { get; set; } = true;
        public string FilterContain { get; set; } = string.Empty;
    }
}
