using Microsoft.EntityFrameworkCore;
using NACH.DAL.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NACH.DAL.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);



            modelBuilder.Entity<acct_type_mst>().HasKey(x => new { x.BankCode, x.BranchCode, x.TranCode });
            modelBuilder.Entity<bank_iin_mst>().HasKey(x => new { x.BankCode, x.BranchCode, x.TranCode });
            modelBuilder.Entity<cancel_reason_code>().HasKey(x => new { x.BankCode, x.TranCode, x.ReasonCode });
            modelBuilder.Entity<cancel_reason_code>().HasIndex(u => u.TranCode).IsUnique();
            modelBuilder.Entity<comp_mst>().HasKey(x => new { x.SellerId, x.BankCode, x.UserId });
            modelBuilder.Entity<BranchMst>().HasKey(x => new { x.BankCode, x.BranchCode });
            modelBuilder.Entity<data_imp_template_dtl>().HasKey(x => new { x.BankCode, x.BranchCode, x.TranCode, x.SrCode });
            modelBuilder.Entity<data_imp_template_hdr>().HasKey(x => new { x.BankCode, x.BranchCode, x.TranCode });
            modelBuilder.Entity<file_type_mst>().HasKey(x => new { x.FileTypeCode });
            modelBuilder.Entity<file_type_mst>().HasIndex(u => u.FileTypeCode).IsUnique();
            modelBuilder.Entity<inw_clr_chq_dtl>().HasKey(x => new { x.TranCode, x.AcctCode, x.ChequeNo });
            modelBuilder.Entity<inw_clr_chq_dtl>().HasIndex(u => u.TranCode).IsUnique();
            modelBuilder.Entity<inw_clr_chq_dtl>().HasIndex(u => u.ChequeNo).IsUnique();
            modelBuilder.Entity<mail_sms_temp_mst>().HasKey(x => new { x.Type, x.NachType, x.TempNm });
            modelBuilder.Entity<mandate_mst>().HasKey(x => new { x.BankCode, x.BranchCode, x.TranCode });
            modelBuilder.Entity<mndt_dtl>().HasKey(x => new { x.TranCode, x.BankCode, x.BranchCode, x.UmrNo, x.AcctCode });
            modelBuilder.Entity<mndt_mst>().HasKey(x => new { x.TranCode, x.UmrNo, x.AcctCode });
            modelBuilder.Entity<mndt_mst>().HasIndex(u => u.TranCode).IsUnique();
            modelBuilder.Entity<mndt_mst>().HasIndex(u => u.UmrNo).IsUnique();
            modelBuilder.Entity<verify_reject_reason>().HasKey(x => new { x.TranCode, x.ReasonCode });
            modelBuilder.Entity<verify_reject_reason>().HasIndex(u => u.TranCode).IsUnique();
            modelBuilder.Entity<user_time_log>().HasKey(x => new { x.TranCode, x.UserId });
            //modelBuilder.Entity<user_time_log>().HasIndex(u => u.TranCode).IsUnique();
            modelBuilder.Entity<user_permission_dtl>().HasKey(x => new { x.BankCode, x.BranchCode, x.UserId });
            modelBuilder.Entity<user_permission>().HasKey(x => new { x.UserId });
            modelBuilder.Entity<user_mst>().HasKey(x => new { x.TranCode, x.SellerId, x.UserId, x.BranchCode });
            modelBuilder.Entity<user_mst>().HasIndex(u => u.UserId).IsUnique();
            modelBuilder.Entity<user_branch_permission>().HasKey(x => new { x.BankCode, x.BranchCode, x.UserNm });
            modelBuilder.Entity<user_branch_permission>().HasIndex(u => u.tranCode).IsUnique();
            modelBuilder.Entity<user_activity_log>().HasKey(x => new { x.BankCode, x.UserId, x.LastActivity, x.LastActivityType });
            modelBuilder.Entity<user_activity>().HasKey(x => new { x.TranCode, x.BankCode, x.UserId });
            modelBuilder.Entity<user_activity>().HasIndex(u => u.TranCode).IsUnique();
            modelBuilder.Entity<temp_io_mandate_mst>().HasKey(x => new { x.BankCode, x.BranchCode, x.TranCode, });
            modelBuilder.Entity<temp_io_mandate_mst>().HasIndex(u => u.TranCode).IsUnique();
            modelBuilder.Entity<StateMst>().HasKey(x => new { x.TranCode });
            modelBuilder.Entity<StateMst>().HasIndex(u => u.TranCode).IsUnique();
            modelBuilder.Entity<seller_mst>().HasKey(x => new { x.TranCode, x.SellerId });
            modelBuilder.Entity<seller_mst>().HasIndex(u => u.SellerId).IsUnique();
            modelBuilder.Entity<role_mst>().HasKey(x => new { x.BankCode });

            modelBuilder.Entity<reject_reason_code>().HasKey(x => new { x.BankCode, x.FileStatus, x.FileStatusDescReject, x.ReasonCode });
            modelBuilder.Entity<reject_reason_code>().HasIndex(u => u.TranCode).IsUnique();
            modelBuilder.Entity<parameter_mst>().HasKey(x => new { x.BankCode, x.BranchCode, x.ParaCode });
            modelBuilder.Entity<page_notes_mst>().HasKey(x => new { x.PageCode });
            modelBuilder.Entity<page_notes_mst>().HasIndex(u => u.PageCode).IsUnique();
            modelBuilder.Entity<ow_mndt_response_mst>().HasKey(x => new { x.BankCode, x.BranchCode, x.TranCode });
            modelBuilder.Entity<otp_mst>().HasKey(x => new { x.OtpId });
            modelBuilder.Entity<npci_response_dtl>().HasKey(x => new { x.TranCode, x.AcctCode, x.ChequeNo });
            modelBuilder.Entity<npci_response_dtl>().HasIndex(u => u.TranCode).IsUnique();
            modelBuilder.Entity<npci_response_dtl>().HasIndex(u => u.ChequeNo).IsUnique();
            modelBuilder.Entity<nach_file_error_log>().HasKey(x => new { x.EnteredBankCode, x.EnteredBranchCode, x.TranCode, x.ProcessType });
            modelBuilder.Entity<nach_file_error_log>().HasIndex(u => u.ProcessType).IsUnique();
            modelBuilder.Entity<nach_type_mst>().HasKey(x => new { x.TranCode, x.NachType });
            modelBuilder.Entity<nach_type_mst>().HasIndex(u => u.TranCode).IsUnique();
            modelBuilder.Entity<nach_return_reason_mst>().HasKey(x => new { x.TranCode, x.NachType });
            modelBuilder.Entity<nach_return_reason_mst>().HasIndex(u => u.TranCode).IsUnique();
            modelBuilder.Entity<nach_ow_trn_mst>().HasKey(x => new { x.EnteredBankCode, x.EnteredBranchCode, x.TranCode });
            modelBuilder.Entity<nach_ow_trn_dtl>().HasKey(x => new { x.SrCode });
            modelBuilder.Entity<nach_ow_trn_dtl>().HasIndex(u => u.SrCode).IsUnique();
            modelBuilder.Entity<nach_ow_schdl_dtl>().HasKey(x => new { x.EnteredBankCode, x.EnteredBranchCode, x.TranCode, x.SrCode });
            modelBuilder.Entity<nach_ow_response_mst>().HasKey(x => new { x.EnteredBankCode, x.EnteredBranchCode, x.TranCode });
            modelBuilder.Entity<nach_ow_mandate_mst>().HasKey(x => new { x.EnteredBankCode, x.EnteredBranchCode, x.TranCode, x.AmendCode });
            modelBuilder.Entity<nach_oac_mst>().HasKey(x => new { x.EnteredBankCode, x.EnteredBranchCode, x.TranCode });
            modelBuilder.Entity<nach_oac_dtl>().HasKey(x => new { x.EnteredBankCode, x.EnteredBranchCode, x.TranCode, x.SrCode });
            modelBuilder.Entity<nach_oac_dtl>().HasIndex(u => u.SrCode).IsUnique();
            modelBuilder.Entity<nach_mms_reason_mst>().HasKey(x => new { x.TranCode });
            // modelBuilder.Entity<nach_mms_reason_mst>().HasIndex(u => u.TranCode).IsUnique();
            modelBuilder.Entity<nach_mms_ow_repository>().HasKey(x => new { x.EnteredBankCode, x.EnteredBranchCode, x.TranCode, x.SrCode });
            modelBuilder.Entity<nach_mms_ow_repository>().HasIndex(u => u.SrCode).IsUnique();
            modelBuilder.Entity<nach_mms_category_mst>().HasKey(x => new { x.TranCode, x.CategoryCode, });
            modelBuilder.Entity<nach_mms_category_mst>().HasIndex(u => u.TranCode).IsUnique();
            modelBuilder.Entity<nach_account_mst>().HasKey(x => new { x.EnteredBankCode, x.EnteredBranchCode, x.AcctNo });
            modelBuilder.Entity<nach_apbs_reg_mst>().HasKey(x => new { x.EnteredBankCode, x.EnteredBranchCode, x.TranCode });
            modelBuilder.Entity<nach_apbs_reg_mst>().HasIndex(u => u.AadhaarNo).IsUnique();
            modelBuilder.Entity<nach_apbs_uid_resp>().HasKey(x => new { x.EnteredBankCode, x.EnteredBranchCode, x.TranCode, x.TranDt, x.FileNm, x.AadhaarNo });
            modelBuilder.Entity<nach_config_column>().HasKey(x => new { x.BankCode, x.ParaCode, x.ParaType });
            modelBuilder.Entity<nach_dbtl_av_dtl>().HasKey(x => new { x.EnteredBankCode, x.EnteredBranchCode, x.TranCode, x.SrCode });
            modelBuilder.Entity<nach_dbtl_av_dtl>().HasIndex(u => u.SrCode).IsUnique();
            modelBuilder.Entity<nach_dbtl_av_mst>().HasKey(x => new { x.EnteredBankCode, x.EnteredBranchCode, x.TranCode });
            modelBuilder.Entity<nach_dbtl_omc_mst>().HasKey(x => new { x.TranCode, x.BankCode, x.Code });
            modelBuilder.Entity<nach_dbtl_omc_mst>().HasIndex(u => u.TranCode).IsUnique();
            modelBuilder.Entity<nach_dbtl_reg_mst>().HasKey(x => new { x.EnteredBankCode, x.EnteredBranchCode, x.TranCode });
            modelBuilder.Entity<nach_file_config_dtl>().HasKey(x => new { x.BankCode, x.TranCode, x.SrCode, x.ConfigFlag });
            modelBuilder.Entity<nach_io_trn_mst>().HasKey(x => new { x.EnteredBankCode, x.EnteredBranchCode, x.TranCode });
            modelBuilder.Entity<nach_file_config_mst>().HasKey(x => new { x.BankCode, x.TranCode });
            modelBuilder.Entity<nach_io_trn_dtl>().HasKey(x => new { x.EnteredBankCode, x.EnteredBranchCode, x.TranCode, x.SrCode });
            modelBuilder.Entity<nach_io_trn_dtl_repo>().HasKey(x => new { x.EnteredBankCode, x.EnteredBranchCode, x.TranCode, x.SrCode });
            modelBuilder.Entity<nach_iw_mandate_mst>().HasKey(x => new { x.EnterdBankCode, x.EnterdBranchCode, x.TranCode });





            /*modelBuilder.Entity<BlockRejectListAud>().HasKey(x => new { x.id, x.TranCode });

            modelBuilder.Entity<BlockRejectListAud>().HasKey(x => new { x.id, x.TranCode });

            modelBuilder.Entity<BranchMst>().HasKey(x => new { x.BankCode, x.BranchCode });

            modelBuilder.Entity<LanguageDetails>().HasKey(x => new { x.TranCode, x.LangCode, x.LangKey });

            modelBuilder.Entity<LeaveTrn>().HasKey(x => new { x.TranCode, x.UserId, x.LeaveType, x.FromDate, x.ToDate });

            modelBuilder.Entity<ReasonCode>().HasKey(x => new { x.TranCode, x.BankCode });

            modelBuilder.Entity<ShortLink>().HasKey(x => new { x.TranCode, x.RefNumber });

            modelBuilder.Entity<UserActivity>().HasKey(x => new { x.BankCode, x.UserId, x.AuditId, x.AudTimeStamp, x.LastActivityData });

            modelBuilder.Entity<UserTimeLog>().HasKey(x => new { x.TranCode, x.UserId });*/

        }

        /* public DbSet<SmartNachApi.Model.Student> Student { get; set; } = default!;*/
        public DbSet<NACH.DAL.Model.acct_type_mst> acct_Type_Msts { get; set; } = default!;
        public DbSet<NACH.DAL.Model.bank_iin_mst> bank_Iin_Msts { get; set; } = default!;
        public DbSet<NACH.DAL.Model.BankMaster> bank_Msts { get; set; } = default!;
        public DbSet<NACH.DAL.Model.cancel_reason_code> cancel_Reason_Codes { get; set; } = default!;
        public DbSet<NACH.DAL.Model.city_mst> city_Msts { get; set; } = default!;
        public DbSet<NACH.DAL.Model.comp_mst> comp_Msts { get; set; } = default!;
        public DbSet<NACH.DAL.Model.BranchMst> branch_Msts { get; set; } = default!;
        public DbSet<NACH.DAL.Model.country_mst> country_Msts { get; set; } = default!;
        public DbSet<NACH.DAL.Model.data_imp_template_dtl> data_Imp_Template_Dtls { get; set; } = default!;
        public DbSet<NACH.DAL.Model.data_imp_template_hdr> data_Imp_Template_Hdrs { get; set; } = default!;
        public DbSet<NACH.DAL.Model.dummy> dummies { get; set; } = default!;
        public DbSet<NACH.DAL.Model.file_type_mst> file_Type_Msts { get; set; } = default!;
        public DbSet<NACH.DAL.Model.form_mst> form_Msts { get; set; } = default!;

        public DbSet<NACH.DAL.Model.inw_clr_chq_dtl> inw_Clr_Chq_Dtls { get; set; } = default!;
        public DbSet<NACH.DAL.Model.LoginMst> LoginMst { get; set; } = default!;
        public DbSet<NACH.DAL.Model.mail_sms_temp_mst> mail_Sms_Temp_Msts { get; set; } = default!;
        public DbSet<NACH.DAL.Model.mandate_mst> mandate_Msts { get; set; } = default!;
        public DbSet<NACH.DAL.Model.mndt_dtl> mndt_Dtls { get; set; } = default!;
        public DbSet<NACH.DAL.Model.mndt_mst> mndt_Msts { get; set; } = default!;
        public DbSet<NACH.DAL.Model.nach_account_mst> nach_Account_Msts { get; set; } = default!;
        public DbSet<NACH.DAL.Model.nach_apbs_uid_resp> Nach_Apbs_Uid_Resps { get; set; } = default!;
        public DbSet<NACH.DAL.Model.nach_apbs_reg_mst> Nach_Apbs_Reg_Msts { get; set; } = default!;
        public DbSet<NACH.DAL.Model.nach_config_column> nach_Config_Columns { get; set; } = default!;
        public DbSet<NACH.DAL.Model.nach_dbtl_av_dtl> nach_Dbtl_Av_Dtls { get; set; } = default!;
        public DbSet<NACH.DAL.Model.nach_dbtl_av_mst> nach_Dbtl_Av_Msts { get; set; } = default!;
        public DbSet<NACH.DAL.Model.nach_dbtl_omc_mst> nach_Dbtl_Omc_Msts { get; set; } = default!;
        public DbSet<NACH.DAL.Model.nach_dbtl_reg_mst> nach_Dbtl_Reg_Msts { get; set; } = default!;
        public DbSet<NACH.DAL.Model.nach_file_config_dtl> nach_File_Config_Dtls { get; set; } = default!;
        public DbSet<NACH.DAL.Model.nach_file_config_mst> nach_File_Config_Msts { get; set; } = default!;

        public DbSet<NACH.DAL.Model.nach_file_error_log> nach_File_Error_Logs { get; set; } = default!;
        public DbSet<NACH.DAL.Model.nach_io_trn_dtl> nach_Io_Trn_Dtls { get; set; } = default!;
        public DbSet<NACH.DAL.Model.nach_io_trn_dtl_repo> nach_Io_Trn_Dtl_Repos { get; set; } = default!;
        public DbSet<NACH.DAL.Model.nach_io_trn_mst> nach_Io_Trn_Msts { get; set; } = default!;
        public DbSet<NACH.DAL.Model.nach_iw_mandate_mst> nach_Iw_Mandate_Msts { get; set; } = default!;
        public DbSet<NACH.DAL.Model.nach_mms_category_mst> Nach_Mms_Category_Msts { get; set; } = default!;
        public DbSet<NACH.DAL.Model.nach_mms_ow_repository> Nach_Mms_Ow_Repositories { get; set; } = default!;
        public DbSet<NACH.DAL.Model.nach_mms_reason_mst> Nach_Mms_Reason_Msts { get; set; } = default!;
        public DbSet<NACH.DAL.Model.nach_oac_dtl> nach_Oac_Dtls { get; set; } = default!;
        public DbSet<NACH.DAL.Model.nach_oac_mst> nach_Oac_Msts { get; set; } = default!;
        public DbSet<NACH.DAL.Model.nach_ow_mandate_mst> nach_Ow_Mandate_Msts { get; set; } = default!;
        public DbSet<NACH.DAL.Model.nach_ow_response_mst> nach_Ow_Response_Msts { get; set; } = default!;
        public DbSet<NACH.DAL.Model.nach_ow_schdl_dtl> nach_Ow_Schdl_Dtls { get; set; } = default!;
        public DbSet<NACH.DAL.Model.nach_ow_trn_dtl> nach_Ow_Trn_Dtls { get; set; } = default!;
        public DbSet<NACH.DAL.Model.nach_ow_trn_mst> nach_Ow_Trn_Msts { get; set; } = default!;
        public DbSet<NACH.DAL.Model.nach_return_reason_mst> nach_Return_Reason_Msts { get; set; } = default!;
        public DbSet<NACH.DAL.Model.nach_type_mst> nach_Type_Msts { get; set; } = default!;
        public DbSet<NACH.DAL.Model.npci_response_dtl> npci_Response_Dtls { get; set; } = default!;
        public DbSet<NACH.DAL.Model.otp_mst> otp_Msts { get; set; } = default!;
        public DbSet<NACH.DAL.Model.ow_mndt_response_mst> ow_Mndt_Response_Msts { get; set; } = default!;
        public DbSet<NACH.DAL.Model.page_notes_mst> page_Notes_Msts { get; set; } = default!;
        public DbSet<NACH.DAL.Model.parameter_mst> parameter_Msts { get; set; } = default!;
        public DbSet<NACH.DAL.Model.reject_reason_code> reject_Reason_Codes { get; set; } = default!;
        public DbSet<NACH.DAL.Model.role_mst> role_Msts { get; set; } = default!;
        public DbSet<NACH.DAL.Model.seller_mst> seller_Msts { get; set; } = default!;
        public DbSet<NACH.DAL.Model.sequence_mst> sequence_Msts { get; set; } = default!;
        public DbSet<NACH.DAL.Model.StateMst> stateMsts { get; set; } = default!;
        public DbSet<NACH.DAL.Model.temp_io_mandate_mst> temp_Io_Mandate_Msts { get; set; } = default!;
        public DbSet<NACH.DAL.Model.user_activity> user_Activities { get; set; } = default!;
        public DbSet<NACH.DAL.Model.user_branch_permission> user_Branch_Permissions { get; set; } = default!;
        public DbSet<NACH.DAL.Model.user_mst> user_Msts { get; set; } = default!;
        public DbSet<NACH.DAL.Model.user_permission> user_Permissions { get; set; } = default!;
        public DbSet<NACH.DAL.Model.user_permission_dtl> user_Permission_Dtls { get; set; } = default!;
        public DbSet<NACH.DAL.Model.user_time_log> user_Time_Logs { get; set; } = default!;
        public DbSet<NACH.DAL.Model.verify_reject_reason> verify_Reject_Reasons { get; set; } = default!;







    }
}
