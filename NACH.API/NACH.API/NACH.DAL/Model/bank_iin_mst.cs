using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace NACH.DAL.Model
{
    [Table("BANK_IIN_MST")]
    public class bank_iin_mst
    {
        
        [StringLength(5)]
        [Column("BRANCH_CD")]
        public string BranchCode { get; set; }
        [MaxLength(11)]
        [Column("TRAN_CD")]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int TranCode { get; set; }
        [StringLength(100)]
        [Column("BANK_NM")]
        public string BankNm { get; set; }
        [StringLength(1)]
        [Column("IIN_STATUS")]
        public string? IinStatus { get; set; } = "N";
        [StringLength(15)]
        [Column("BANK_IIN")]
        public string? BankIIn { get; set; }
        [StringLength(20)]
        [Column("ENTRY_BY")]
        public string? EntryBy { get; set; }
        [Column("ENTRY_DT")]
        public DateTime? EntryDt { get; set; }
        [StringLength(30)]
        [Column("ENTRY_PC_NM")]
        public string? EntryPcNm { get; set; }
        [StringLength(20)]
        [Column("MODIFY_BY")]
        public string? ModifyBy { get; set; }
        [Column("MODIFY_DT")]
        public DateTime? ModifyDt { get; set; }
        [StringLength(30)]
        [Column("MODIFY_PC_NM")]
        public string? ModifyPcNm { get; set; }
        [StringLength(6)]
        [Column("BANK_CODE")]

        public string? BankCode { get; set; }
        [StringLength(10)]
        [Column("TYPE_OF_BANK")]
        public string? TypeOfBank { get; set; }
        [StringLength(1)]
        [Column("IFSC_STATUS")]
        public string? IfscStatus { get; set; } = "N";
        [StringLength(11)]
        [Column("IFSC")]
        public string? Ifsc { get; set; }
        [StringLength(1)]
        [Column("MICR_STATUS")]
        public string? MicrStatus { get; set; } = "N";
        [StringLength(9)]
        [Column("MICR")]
        public string? Micr { get; set; }
        [StringLength(1)]
        [Column("APBS_FLAG")]
        public string? ApbsFlag { get; set; }
        [StringLength(1)]
        [Column("ACHCR_FLAG")]
        public string? AcharFlag { get; set; }
        [StringLength(1)]
        [Column("ACHDR_FLAG")]
        public string? AchdrFlag { get; set; }



    }
}
