using System.ComponentModel.DataAnnotations;

namespace NACH.API.Filter {
    public class FromDtToDtPaginationModel : PaginationFilter {

        [Required]
        public string BankCode { get; set; }

        [DataType(DataType.Date)]
        public DateTime FromDate { get; set; }

        [DataType(DataType.Date)]
        public DateTime ToDate { get; set; }
    }
}
