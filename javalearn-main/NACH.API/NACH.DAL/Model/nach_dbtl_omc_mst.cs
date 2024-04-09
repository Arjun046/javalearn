using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace NACH.DAL.Model
{
    [Table("NACH_DBTL_OMC_MST")]
    public class nach_dbtl_omc_mst
    {
        [MaxLength(11)]
        [Column("TRAN_CD")]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int TranCode { get; set; }
        [Column("BANK_CD")]
        [StringLength(6)]
        public string BankCode { get; set; }
        [Column("CODE")]
        [StringLength(20)]
        public string Code { get; set; }
        [Column("OMC_NM")]
        [StringLength(100)]
        public string? OmcNm { get; set; }
        [Column("LPG_ID")]
        [StringLength(20)]
        public string? LpgId { get; set; }
    }
}
