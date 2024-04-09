using System.ComponentModel;

namespace NACH.API.Enum
{
    public enum Rights
    {
        ADD = 1,
        EDIT,
        VIEW,
        DELETE
    }

    public enum Form
    {
        [Description("Bank Master")]
        BANK = 1,
        [Description("Branch Master")]
        BRANCH,
        [Description("Account Type Master")]
        ACCT_TYPE_MASTER,
        [Description("Holiday Master")]
        HOLIDAY_MASTER,
        [Description("Occupation Master")]
        OCCUPATION_MASTER,
        [Description("Leave Master")]
        LEAVE_MASTER,
        [Description("LeaveType Master")]
        LEAVETYPE_MASTER,
        [Description("Reason Master")]
        REASON_MASTER,
        [Description("Question Master")]
        QUESTION_MASTER,
        [Description("Services Master")]
        SERVICES_MASTER,
        [Description("Role Master")]
        ROLE_MASTER,
        [Description("Report")]
        REPORT,
        [Description("Assign Kyc")]
        ASSIGN_KYC,
        [Description("Configuration")]
        CONFIGURATION
    }
}

