using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace NACH.DAL.Model
{
    [Table("NACH_OW_SCHDL_DTL")]
    public class nach_ow_schdl_dtl
    {
        [StringLength(6)]
        [Column("ENTERED_BANK_CD")]
        public string EnteredBankCode { get; set; }
        [Column("ENTERED_BRANCH_CD")]
        [StringLength(5)]
        public string EnteredBranchCode { get; set; }
        [Column("TRAN_CD")]
        [MaxLength(11)]
        public int TranCode { get; set; }
        [Column("SR_CD")]
        [MaxLength(11)]
        public int SrCode { get; set; }
        [Column("SCHDL_DT")]
        public DateTime SchdlDt { get; set; }
        [Column("AMOUNT")]
        [MaxLength(11)]
        public int Amount { get; set; }
        [Column("STATUS")]
        [StringLength(1)]
        public string? Status { get; set; }
        [Column("TRN_REF_NO")]
        [StringLength(50)]
        public string? TrnRefNo { get; set; }
        [Column("UPLOAD_FILE_NM")]
        [StringLength(200)]
        public string? UploadFileNm { get; set; }
        [Column("UPLOAD")]
        [StringLength(1)]
        public string? Upload { get; set; } = "N";
        [Column("UPLOAD_DT")]

        public DateTime? UploadDt { get; set; }
        [Column("EXPORT_CNT")]
        [MaxLength(11)]
        public int? ExportCnt { get; set; } = 0;
    }
}
