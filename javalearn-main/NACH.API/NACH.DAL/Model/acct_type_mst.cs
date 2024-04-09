using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
//using SmartNachApi;

namespace NACH.DAL.Model
{
    [Table("ACCT_TYPE_MST")]
    public class acct_type_mst : EntityBase
    {
        [MaxLength(4)]
        [Unicode(false)]
        [Column("BANK_CD")]
        public string BankCode { get; set; }

        [StringLength(4)]
        [Unicode(false)]
        [Column("BRANCH_CD")]
        public string BranchCode { get; set; }

        [Key]
        [Column("TRAN_CD")]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int TranCode { get; set; }


        [StringLength(4)]
        [Unicode(false)]
        [Column("ACCT_TYPE")]
        public string AccountType { get; set; }


        [Unicode(false)]
        [StringLength(50)]
        [Column("TYPE_NM")]
        public string TypeName { get; set; }


        [Unicode(false)]
        [StringLength(20)]
        [Column("CBS_CD")]
        public string? CbsCode { get; set; }

        [StringLength(1)]
        [Unicode(false)]
        [Column("VERIFY_STATUS")]
        public string VerifyStatus { get; set; }

    }
}
