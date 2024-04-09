using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace NACH.DAL.Model
{
    [Table("MNDT_DTL")]
    public class mndt_dtl
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
        [Column("UMR_NO")]
        [StringLength(35)]
        public string UmrNo { get; set; }
        [Column("ACCT_CD")]
        [StringLength(25)]
        public string AcctCode { get; set; }
        [Column("MNDT_STATUS")]
        [StringLength(1)]
        public string? MndtStatus { get; set; }
        [Column("CANCEL_REASON_CD")]
        [StringLength(10)]
        public string? CancelReasonCode { get; set; }
        [Column("OTHR_REASON")]
        [StringLength(200)]
        public string? OtherReason { get; set; }
        [Column("MNDT_REASON_CD")]
        [StringLength(10)]
        public string? MndtReasonCode { get; set; }
        [Column("MNDT_RESPONSE")]
        [StringLength(200)]
        public string? MndtResponse { get; set; }
        [Column("ENTER_DT")]
        public DateTime? EntryDt { get; set; }
        [Column("ENTER_BY")]
        [StringLength(30)]
        public string? EntryBy { get; set; }
        [Column("RESPONSE_DT")]
        public DateTime? ResponseDt { get; set; }
        [Column("RESPONSE_BY")]
        [StringLength(30)]
        public string? ResponseBy { get; set; }
        [Column("IP_ADDRESS")]
        [StringLength(45)]
        public string? IpAddress { get; set; }
        [Column("SMS_SEND")]
        [StringLength(1)]
        public string? SmsSend { get; set; } = "P";
        [Column("MNDT_ACCEPT")]
        [StringLength(1)]
        public string? MndtAccept { get; set; } = "P";
        [Column("ACCEPT")]
        [StringLength(1)]
        public string? Accept { get; set; } = "P";
        [Column("CHENNAL")]
        [StringLength(4)]
        public string? Chennal { get; set; } 

    }
}
