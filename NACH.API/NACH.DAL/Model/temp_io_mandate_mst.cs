using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace NACH.DAL.Model
{
    [Table("TEMP_IO_MANDATE_MST")]
    public class temp_io_mandate_mst
    {
        [StringLength(6)]
        [Column("BANK_CD")]
        public string BankCode { get; set; }
        [Column("BRANCH_CD")]
        [StringLength(6)]
        public string BranchCode { get; set; }
        [Column("TRAN_CD")]
        [MaxLength(20)]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]   
        public int TranCode { get; set; }
        [Column("TRAN_DT")]
        public DateTime TranDt { get; set; }
        [Column("FILE_TYPE")]
        [StringLength (10)]
        public string? FileType { get; set; }
        [Column("FOLDER_NM")]
        [StringLength(300)]
        public string? FolderNm { get; set; }
        [Column("FILE_NM")]
        [StringLength(300)]
        public string? FileNm { get; set; }
        [Column("XML_DATA")]
        [MaxLength()]
        public byte[]? XmlData { get; set; }
        [Column("MNDT_F_IMG")]
        [MaxLength()]
        public string? MndtFImg { get; set; }
        [Column("MNDT_D_IMG")]
        [MaxLength()]
        public string? MndtDImg { get; set; }
        [Column("PROCESS")]
        [StringLength(1)]
        public string? Process { get; set; } = "P";
        [Column("PROCESS_DT")]
        public DateTime? ProcessDt { get; set; }
        [Column("IMP_TYPE")]
        [StringLength(10)]
        public string? ImpType { get; set; } = "INW";
        [Column("REF_NO")]
        [StringLength(30)]
        public string RefNo { get; set; }
        [Column("ENTRY_BY")]
        [StringLength(20)]
        public string? EntryBy { get; set; }
        [Column("ENTRY_DT")]
        public DateTime? EntryDt { get; set; }
        [Column("ENTRY_PC_NM")]
        [StringLength(30)]
        public string? EntryPcNm { get; set; }
        [Column("ROLE_ID")]
        [MaxLength(11)]
        public int? RoleId { get; set; }
        
    }
}
