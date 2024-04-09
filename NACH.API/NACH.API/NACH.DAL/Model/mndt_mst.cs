using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace NACH.DAL.Model
{
    [Table("MNDT_MST")]
    public class mndt_mst
    {
        [StringLength(6)]
        [Column("BANK_CD")]
        public string BankCode { get; set; }
        [Column("BRANCH_CD")]
        [StringLength(5)]
        public string BranchCode { get; set; }
        [Column("TRAN_CD")]
        [MaxLength(11)]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int TranCode { get; set; }
        [Column("CUSTOMER_ID")]
        [StringLength(25)]
        public string? CustomerId { get; set; }
        [Column("UMR_NO")]
        [StringLength(25)]
        public string UmrNo { get; set; }
        [Column("MNDT_CREDT_TE")]
        [StringLength(25)]
        public string? MndtCreditTe { get; set; }
        [Column("SPNSR_BANK_NM")]
        [StringLength(100)]
        public string? SpnsrBankNm { get; set; }
        [Column("SPNSR_IFSC_CD")]
        [StringLength(11)]
        public string? SpnsrIfscCode { get; set; }
        [Column("MNDT_NM")]
        [StringLength(100)]

        public string? MndtNm { get; set; }
        [Column("ACCT_CD")]
        [StringLength(25)]
        public string AcctCode { get; set; }

        [Column(TypeName ="decimal(14,2)")]
        public decimal? MNDT_AMT { get; set; }
        [Column("MNDT_REMARKS")]
        [StringLength(200)]
        public string? MndtRemarks { get; set; }
        [Column("MNDT_FREQUENCY")]
        [StringLength(1)]
        public string? MndtFrequency { get; set; }
        [Column("ENTER_DT")]
        public DateTime? EntryDt { get; set; }
        [Column("ENTER_BY")]
        [StringLength(10)]
        public string EntryBy { get; set; }
        [Column("RESPONSE_DT")]
        public DateTime? ResponseDt { get; set; }
        [Column("RESPONSE_BY")]
        [StringLength(10)]
        public string? ResponseBy { get; set; }
        [Column("IP_ADDRESS")]
        [StringLength(45)]
        public string? IpAddress { get; set; }
        
    }
}
