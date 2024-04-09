using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace NACH.DAL.Model
{
    [Table("DATA_IMP_TEMPLATE_HDR")]
    public class data_imp_template_hdr
    {

       
        [StringLength(6)]
        [Column("BANK_CD")]
        public string BankCode { get; set; }
        [Column("BRANCH_CD")]
        [StringLength(5)]
        public string BranchCode { get; set; }
        [Column("TRAN_CD")]
        [StringLength(20)]
        public int TranCode { get; set; }
        [Column("TRAN_DT")]

        public DateTime? TranDt { get; set; }
        [Column("DESCRIPTION")]
        [MaxLength()]
        public string? Description { get; set; }
        [Column("ECB_TABLE_NM")]
        [StringLength(100)]
        public string? EcbTableNm { get; set; }
        [Column("FILE_TYPE")]
        [StringLength(1)]
        public string? FileType { get; set; }
        [Column("FILE_PATH")]
        [MaxLength()]
        public string? FilePath { get; set; }
        [Column("ACTIVE_STATUS")]
        [StringLength(1)]
        public string? ActiveStatus { get; set; }
        [Column("REMARKS")]
        [MaxLength()]
        public string? Remarks { get; set; }
        [Column("ENTRY_BY")]
        [StringLength(16)]
        public string? EntryBy { get; set; }
        [Column("ENTRY_DT")]
        public DateTime? EntryDt { get; set; }
        [Column("MODIFY_BY")]
        [StringLength(16)]
        public string? ModifyB { get; set; }
        [Column("MODIFY_DT")]
        public DateTime? ModifyDt { get; set; }
        [Column("ENTRY_PC_NM")]
        [StringLength(25)]
        public string? EntryPcNm { get; set; }
        [Column("MODIFY_PC_NM")]
        [StringLength(25)]
        public string? ModifyPcNm { get; set; }
        [Column("DELIMITER_CD")]
        [StringLength(1)]
        public string? DelimiterCode { get; set; }
        [Column("DELIMITER_SIGN")]
        [StringLength(1)]
        public string? DelimiterSign { get; set; }
       

    }
}
