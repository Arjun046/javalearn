//using MessagePack;
using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace NACH.DAL.Model
{
    [Table("USER_TIME_LOG")]
    public class user_time_log
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [MaxLength()]
        [Unicode(false)]
        [Column("TRAN_CD")]
        public int TranCode { get; set; }

        [StringLength(15)]
        [Unicode(false)]
        [Column("USER_ID")]
        public string UserId { get; set; }

        [StringLength(5)]
        [Unicode(false)]
        [Column("BANK_CD")]
        public string? BankCode { get; set; }

        [StringLength(5)]
        [Unicode(false)]
        [Column("BRANCH_CD")]
        public string? BranchCode { get; set; }

        [MaxLength()]
        [Unicode(false)]
        [Column("CLOCKINTIME")]
        public DateTime ClockIntime { get; set; }

        [MaxLength()]
        [Unicode(false)]
        [Column("CLOCKOUTTIME")]
        public DateTime? ClockOuttime { get; set; }

        [MaxLength()]
        [Unicode(false)]
        [Column("WORKHOURS")]
        public int? WorkHours { get; set; }

        [MaxLength()]
        [Unicode(false)]
        [Column("WORKMINUTES")]
        public int? WorkMinutes { get; set; }

        [StringLength(25)]
        [Unicode(false)]
        [Column("IN_LONGITUDE")]
        public string InLongitude { get; set; }

        [StringLength(25)]
        [Unicode(false)]
        [Column("IN_LATITUDE")]
        public string InLatitde { get; set; }

        [StringLength(25)]
        [Unicode(false)]
        [Column("OUT_LONGITUDE")]
        public string? OutLongitude { get; set; }

        [StringLength(25)]
        [Unicode(false)]
        [Column("OUT_LATITUDE")]
        public string? OutLatitde { get; set; }

        [StringLength(25)]
        [Unicode(false)]
        [Column("REMARKS")]
        public string? Remarks { get; set; }

    }
}
