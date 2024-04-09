using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace NACH.DAL
{
    public class EntityBase
    {
        [Column("CREATED_DT")]
        public DateTime CreatedDate { get; set; }

        [Column("MODIFIED_DT")]
        public DateTime? ModifiedDate { get; set; }

        [StringLength(15)]
        [Column("CREATED_BY")]
        public string CreatedBy { get; set; }

        [StringLength(15)]
        [Column("MODIFIED_BY")]
        public string? ModifiedBy { get; set; }

        [StringLength(20)]
        [Column("CREATED_IP")]
        public string? CreatedIp { get; set; }

        [StringLength(20)]
        [Column("MODIFIED_IP")]
        public string? ModifiedIp { get; set; }
    }
}
