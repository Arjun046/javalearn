using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace NACH.DAL.Model
{
    [Table("INW_CLR_CHQ_DTL")]
    public class inw_clr_chq_dtl
    {
        [MaxLength(11)]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Column("TRAN_CD")]
        public int TranCode { get; set; }
        [Column("TRAN_DT")]
        public DateTime? TranDt { get; set; }=DateTime.Now;
        [Column("BANK_CD")]
        [StringLength(6)]
        public string BankCode { get; set; }
        [Column("BRANCH_CD")]
        [StringLength(5)]
        public string BranchCode { get; set; }
        [Column("ACCT_TYPE")]
        [StringLength(4)]
        public string AcctType { get; set; }
        [Column("ACCT_CD")]
        [StringLength(50)]
        public string AcctCode { get; set; }
        [Column("CUSTOMER_ID")]
        [StringLength(25)]
        public string? CustomerId { get; set; }
        [Column("CHEQUE_NO")]
        [StringLength(6)]
        public string ChequeNo { get; set; }
        [Column("CHQ_DT")]

        public DateTime? ChqDt { get; set; }
        [Column("BENF_NM")]
        [StringLength(100)]
        public string? BenfNm { get; set; }

        [Column(TypeName ="decimal(14,2)")]
        public decimal? CHQ_AMT { get; set; }
        [Column("REMARKS")]
        [StringLength(200)]
        public string? Remarks { get; set; }
        [Column("CHQ_IMG")]
        [MaxLength()]
        public string? ChqImg { get; set; }
        [Column("REASON_CD")]
        [StringLength(4)]
        public string? ReasonCode { get; set; }
        [Column("EXP_DATE")]
        public DateTime? ExpDate { get; set; }
        [Column("EXP_STATUS")]
        [StringLength(1)]
        public string? ExpStatus { get; set; } = "N";
        [Column("IP_ADDRESS")]
        [StringLength(45)]
        public string? IpAddress { get; set; }
        [Column("SHORT_ACCT")]
        [StringLength(7)]
        public string? ShortAcct { get; set; } 
    }
}
