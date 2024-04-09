using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace NACH.DAL.Model
{
    [Table("NPCI_RESPONSE_DTL")]
    public class npci_response_dtl
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [MaxLength(11)]
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
        [Column("TRANSACTION_CD")]
        [StringLength(20)]
        public string TransactionCode { get; set; }
        [Column("ACCT_CD")]
        [StringLength(20)]
        public string AcctCode { get; set; }
        [Column("SAN")]
        [StringLength(10)]
        public string San { get; set; }
        [Column("CHEQUE_NO")]
        [StringLength(6)]
        public string ChequeNo { get; set; }
        [Column("CHEQUE_DT")]
        public DateTime? CHEQUE_DT { get; set; }
        [Column(TypeName ="decimal(14,2)")]
        public Decimal? CHEQUE_AMT { get; set; }
        [Column("PAYEE_NM")]
        [StringLength(100)]
        public string? PayeeNm { get; set; }
        [Column("DRAWEE_BRANCH_NM")]
        [StringLength(100)]
        public string? DraweeBranchNm { get; set; }
        [Column("DRAWEE_BRANCH_CD")]
        [StringLength(15)]
        public string? DraweeBranchCode { get; set; }
        [Column("OPTIONAL1")]
        [MaxLength()]
        public string? Optional1 { get; set; }
        [Column("OPTIONAL2")]
        [MaxLength()]
        public string? Optional2 { get; set; }
        [Column("OPTIONAL3")]
        [MaxLength()]
        public string? Optional3 { get; set; }
        [Column("REJECT_REASON")]
        [StringLength(4)]
        public string? RejectReason { get; set; }
        [Column("IP_ADDRESS")]
        [StringLength(45)]
        public string? IpAddress { get; set; }
    }
}
