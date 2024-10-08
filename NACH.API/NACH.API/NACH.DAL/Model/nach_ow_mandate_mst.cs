﻿using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace NACH.DAL.Model
{
    [Table("NACH_OW_MANDATE_MST")]
    public class nach_ow_mandate_mst
    {
        [StringLength(6)]
        [Column("ENTERED_BANK_CD")]
        public string EnteredBankCode { get; set; }
        [Column("ENTERED_BRANCH_CD")]
        [StringLength(5)]
        public string EnteredBranchCode { get; set; }
        [Column("TRAN_CD")]
        [MaxLength(20)]
        public int TranCode { get; set; }
        [Column("AMEND_CD")]
        [MaxLength(20)]
        public int AmendCode { get; set; }
        [Column("MANDATE_TYPE")]
        [StringLength(5)]
        public string? MandateType { get; set; }
        [Column("NACH_TRN_TYPE")]
        [StringLength(10)]
        public string NachTrnType { get; set; } = "ACHD";
        [Column("TRAN_DT")]
        public DateTime TranDt { get; set; }
        [Column("BRANCH_CD")]
        [StringLength(5)]
        public string? BranchCode { get; set; }
        [Column("PROD_TYPE")]
        [StringLength(4)]
        public string? ProdType { get; set; }
        [Column("ACCT_NO")]
        [StringLength(50)]
        public string AcctNo { get; set; }
        [Column("DEST_BANK_IIN")]
        [StringLength(20)]
        public string DestBankIin { get; set; }
        [Column("DEST_ACCT_TYPE")]
        [StringLength(20)]
        public string? DestAcctType { get; set; }
        [Column("DEST_ACCT_NO")]
        [StringLength(50)]
        public string DestAcctNo { get; set; }
        [Column("DEST_ACCT_NM")]
        [StringLength(100)]
        public string DestAcctNm { get; set; }
        [Column("CONTACT_1")]
        [StringLength(35)]
        public string? Contact1 { get; set; }
        [Column("CONTACT_2")]
        [StringLength(35)]
        public string? Contact2 { get; set; }
        [Column("EMAIL_ID")]
        [StringLength(35)]
        public string? EmailId { get; set; }
        [Column("OTHER_DTL")]
        [StringLength(35)]
        public string? OtherDtl { get; set; }
        [Column("SCHEME_TYPE")]
        [StringLength(35)]
        public string? SchemeType { get; set; }
        [Column("DEF_TRAN_CD")]
        [MaxLength(20)]
        public int? DefTranCode { get; set; }
        [Column("CHEQUE_NO")]
        [MaxLength(20)]
        public int? ChequeNo { get; set; }
        [Column(TypeName ="decimal(14,2)")]
        public decimal AMOUNT { get; set; }
        [Column(TypeName = "decimal(14,2)")]
        public decimal? COMM_AMT { get; set; }
        [Column(TypeName = "decimal(14,2)")]

        public decimal? SER_CHRG_AMT { get; set; }
        [Column("START_DT")]
        public DateTime StartDt { get; set; }
        [Column("VALID_UPTO_CNCL")]
        [StringLength(1)]

        public string? ValidUptoCncl { get; set; } = "N";
        [Column("VALID_UPTO")]
        public DateTime? ValidUpto { get; set; }
        [Column("EXEC_TYPE")]
        [StringLength(4)]
        public string ExecType { get; set; } = "R";
        [Column("FEQ_TYPE")]
        [StringLength(4)]
        public string FeqType { get; set; } = "M";
        [Column("REMARKS")]
        [StringLength(100)]
        public string? Remarks { get; set; }
        [Column("STATUS")]
        [StringLength(1)]
        public string? Status { get; set; } = "A";
        [Column("DEACTIVE_DT")]
        public DateTime? DeactiveDt { get; set; }
        [Column("MNDT_JPG_IMG")]
        [MaxLength()]
        public string? MndtJpgImg { get; set; }
        [Column("MNDT_TIF_IMG")]
        [MaxLength()]
        public string? MndtTifImg { get; set; }
        [Column("DEST_CNTRY_CD")]
        [StringLength(10)]
        public string? DestCntryCode { get; set; } = "91";
        [Column("DEST_AREA_PHNO")]
        [StringLength(10)]
        public string? DestAreaPhNo { get; set; }
        [Column("CATEGORY_CD")]
        [StringLength(5)]
        public string? CategoryCode { get; set; }
        [Column("UMRN")]
        [StringLength(30)]
        public string? Umrn { get; set; }
        [Column("MSG_ID")]
        [StringLength(30)]
        public string? MsgId { get; set; }
        [Column("FILE_NM")]
        [StringLength(200)]
        public string? FileNm { get; set; }
        [Column("ACCEPTED")]
        [StringLength(5)]
        public string? Accepted { get; set; }
        [Column("REASON_CD")]
        [StringLength(5)]
        public string? ReasonCode { get; set; }
        [Column("AMEND")]
        [StringLength(1)]
        public string? Amend { get; set; } = "N";
        [Column("AMEND_DT")]
        public DateTime? AmendDt { get; set; }
        [Column("AMEND_REASON_CD")]
        [StringLength(5)]
        public string? AmendReasonCode { get; set; }
        [Column("AMEND_FILE_NM")]
        [StringLength(200)]
        public string? AmendFileNm { get; set; }
        [Column("CANCEL_REASON_CD")]
        [StringLength(5)]
        public string? CancelReasonCode { get; set; }
        [Column("CANCEL_FILE_NM")]
        [StringLength(200)]
        public string? CancelFileNm { get; set; }
        [Column("REF_NO")]
        [MaxLength()]
        public string? RefNo { get; set; }
        [Column("REQ_EXP_DATE")]
        public DateTime? ReqExpDate { get; set; }
        [Column("REQ_STATUS")]
        [StringLength(1)]
        public string? ReqStatus { get; set; } = "P";
        [Column("RESP_XML")]
        [MaxLength()]
        public string? RespXml { get; set; }
        [Column("RESP_DT")]

        public DateTime? RespDt { get; set; }
        [Column("REQ_XML")]
        [MaxLength()]
        public string? ReqXml { get; set; }
        [Column("EXPORT_STATUS")]
        [StringLength(1)]
        public string? ExportStatus { get; set; } = "N";
        [Column("MAKE_BY")]
        [StringLength(30)]
        public string? MakeBy { get; set; }
        [Column("MAKE_DT")]
        public DateTime? MakeDt { get; set; }
        [Column("MAKE_PC_NM")]
        [StringLength(30)]
        public string? MakePcNm { get; set; }
        [Column("VERIFY_BY")]
        [StringLength(30)]
        public string? VerifyBy { get; set; }
        [Column("VERIFY_DT")]

        public DateTime? VerifyDt { get; set; }
        [Column("VERIFY_PC_NM")]
        [StringLength(30)]
        public string? VerifyPcNm { get; set; }
        [Column("VERIFY_STATUS")]
        [StringLength(1)]
        public string? VerifyStatus { get; set; } = "P";
        [Column("REJECT_REASON")]
        [StringLength(5)]
        public string? RejectReason { get; set; }
        [Column("REJECT_OTHER_REASON")]
        [StringLength(100)]
        public string? RejectOtherReason { get; set; } 
        
    }
}
