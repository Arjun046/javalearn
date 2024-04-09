using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace NACH.DAL.Model
{
    [Table("NACH_APBS_REG_MST")]
    public class nach_apbs_reg_mst
    {
        [StringLength(6)]
        [Column("ENTERED_BANK_CD")]
        public string EnteredBankCode { get; set; }
        [Column("ENTERED_BRANCH_CD")]
        [StringLength(5)]
        public string EnteredBranchCode { get; set; }
        [Column("TRAN_CD")]
        [MaxLength(20)]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int TranCode { get; set; }
        [Column("TRAN_DT")]
        public DateTime? TranDt { get; set; }
        [Column("AADHAAR_NO")]
        [StringLength(30)]
        public string AadhaarNo { get; set; }
        [Column("BRANCH_CD")]
        [StringLength(4)]
        public string? BranchCode { get; set; }
        [Column("PROD_TYPE")]
        [StringLength(4)]
        public string? ProdType { get; set; }
        [Column("ACCT_NO")]
        [StringLength(50)]
        public string AcctNo { get; set; }
        [Column("STATUS")]
        [StringLength(1)]
        public string? Status { get; set; } = "A";
        [Column("DEACTIVE_DT")]
        public DateTime? Deactivedt { get; set; }
        [Column("UPLOAD")]
        [StringLength(1)]
        public string? Upload { get; set; } = "N";
        [Column("UPLOAD_DT")]
        public DateTime? UploadDt { get; set; }
        [Column("UPLOAD_FILE_NM")]
        [StringLength(100)]


        public string? UploadFileNm { get; set; }
        [Column("PREVIOUS_BANK_FLAG")]
        [StringLength(1)]
        public string? PreviousBankFlag { get; set; } = "N";
        [Column("PREVIOUS_BANK_IIN")]
        [StringLength(15)]
        public string? PreviousBankIin { get; set; }
        [Column("MAKE_BY")]
        [StringLength(20)]
        public string? MakeBy { get; set; }
        [Column("MAKE_DT")]
        public DateTime? MakeDt { get; set; }
        [Column("MAKE_PC_NM")]
        [StringLength(30)]
        public string? MakePcNm { get; set; }
        [Column("VERIFY_BY")]
        [StringLength(20)]
        public string? VerifyBy { get; set; }
        [Column("VERIFY_DT")]
        public DateTime? VerifyDt { get; set; }
        [Column("VERIFY_PC_NM")]
        [StringLength(30)]
        public string? VerifyPcNm { get; set; }
        [Column("VERIFY_STATUS")]
        [StringLength(1)]
        public string? VerifyStatus { get; set; } = "P";
        [Column("REJECT_REASON")]
        [StringLength(5)]
        public string? RejectPerson { get; set; }
        [Column("REJECT_OTHER_REASON")]
        [StringLength(100)]
        public string? RejectOtherPerson { get; set; } 
      
        
    }
}
