using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace NACH.DAL.Model
{
    [Table("FILE_TYPE_MST")]
    public class file_type_mst
    {
        [StringLength(3)]
        [Column("FILE_TYPE_CD")]
        public string FileTypeCode { get; set; }
        [Column("FILE_TYPE")]
        [StringLength(50)]
        public string? FileType { get; set; }
        [Column("FILE_FORMAT")]
        [StringLength(100)]
        public string? FileFormat { get; set; } = "ALL";
    }
}
