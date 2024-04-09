using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace NACH.DAL.Model
{
    [Table("NACH_ACCOUNT_MST")]
    public class nach_account_mst
    {
        [StringLength(6)]
        [Column("ENTERED_BANK_CD")]
        public string EnteredBankCode { get; set; }
        [Column("ENTERED_BRANCH_CD")]
        [StringLength(5)]
        public string EnteredBranchCode { get; set; }
        [Column("TRAN_DT")]
        public DateTime TranDt { get; set; }
        [Column("ACCT_NO")]
        [StringLength(50)]
        public string AcctNo { get; set; }
        [Column("BRANCH_CD")]
        [StringLength(4)]
        public string? BranchCode { get; set; }
        [Column("CUSTOMER_NO")]
        [StringLength(20)]
        public string? CustomerNo { get; set; }
        [Column("PROD_TYPE")]
        [StringLength(4)]
        public string? ProdType { get; set; }
        [Column("INT_TYPE")]
        [StringLength(4)]
        public string? IntType { get; set; }
        [Column("ACCT_NM")]
        [StringLength(100)]
        public string? AcctNm { get; set; }
        [Column("TYPE_ID")]
        [StringLength(4)]
        public string? TypeId { get; set; }
        [Column("AADHAAR_NO")]
        [StringLength(30)]
        public string? AadhaarNo { get; set; }
        [Column("PAN_NO")]
        [StringLength(10)]
        public string? PanNo { get; set; }
        [Column("SEC_ACCT_NM")]
        [StringLength(100)]

        public string? SecAcctNm { get; set; }
        [Column("SEC_PAN_NO")]
        [StringLength(10)]
        public string? SecPanNo { get; set; }
        [Column("MOBILE_NO")]
        [StringLength(15)]
        public string? MobileNo { get; set; }
        [Column("STATUS")]
        [StringLength(10)]
        public string? Status { get; set; }
        [Column("ENTRY_BY")]
        [StringLength(20)]

        public string? EntryBy { get; set; }
        [Column("ENTRY_DT")]
        public DateTime? EntryDt { get; set; }

        [Column("ENTRY_PC_NM")]
        [StringLength(30)]
        public string? EntryPcNm { get; set; }
        [Column("MODIFY_BY")]
        [StringLength(20)]
        public string? ModifyBy { get; set; }
        [Column("MODIFY_DT")]
        public DateTime? ModifyDt { get; set; }
        [Column("MODIFY_PC_NM")]
        [StringLength(30)]
        public string? ModifyPcNm { get; set; }
        [Column("BR_MICR_CD")]
        [StringLength(15)]
        public string? BrMicrCode { get; set; }
        [Column("OLD_ACCT_TYPE")]
        [StringLength(5)]
        public string? OldAcctType { get; set; }
        [Column("OLD_ACCT_NO")]
        [StringLength(20)]
        public string? OldAcctNo { get; set; }
        [Column("ACCT_NO2")]
        [StringLength(20)]
        public string? AcctNo2 { get; set; }


        
    }
}
