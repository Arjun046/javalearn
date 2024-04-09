using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace NACH.DAL.Model
{
    [Table("ROLE_MST")]
    public class role_mst
    {
        [StringLength(6)]
        [Column("BANK_CD")]
        public string BankCode { get; set; }
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Column("TRAN_CD")]
        [MaxLength(11)]
        public int TranCode { get; set; }
        [Column("ROLE_NM")]
        [StringLength(45)]
        public string RoleNm { get; set; }
        [Column("ROLE_TYPE")]
        [StringLength(1)]
        public string RoleType { get; set; } = "U";
        [Column("DESCRIPTION")]
        [MaxLength()]
        public string? Description  { get; set; }    
    }
}
