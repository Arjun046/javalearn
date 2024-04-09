using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace NACH.DAL.Model
{
    [Table("PARAMETER_MST")]
    public class parameter_mst
    {
        [StringLength(6)]
        [Column("BANK_CD")]
        public string BankCode { get; set; }
        [Column("BRANCH_CD")]
        [StringLength(6)]
        public string BranchCode { get; set; }
        [Column("PARA_CD")]
        [StringLength(10)]
        public string ParaCode { get; set; }
        [Column("PARA_DESC")]
        [StringLength(100)]
        public string ParaDesc { get; set; }
        [Column("PARA_VALUE")]
        [StringLength(200)]
        public string ParaValue { get; set; }
    }
}
