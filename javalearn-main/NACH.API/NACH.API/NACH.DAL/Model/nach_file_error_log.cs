using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace NACH.DAL.Model
{
    [Table("NACH_FILE_ERROR_LOG")]
    public class nach_file_error_log
    {
        [StringLength(6)]
        [Column("ENTERED_BANK_CD")]
        public string EnteredBankCode { get; set; }
        [Column("ENTERED_BRANCH_CD")]
        [StringLength(6)]
        public string EnteredBranchCode { get; set; }
        [Column("TRAN_CD")]
        [MaxLength(20)]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]   
        public int TranCode { get; set; }
        [Column("PROCESS_TYPE")]
        [StringLength(20)]
        public string ProcessType { get; set; }
        [Column("FILE_NM")]
        [StringLength(100)]
        public string? FileNm { get; set; }
        [Column("DESCRIPTION")]
        [StringLength(200)]
        public string? Description { get; set; }

    }
}
