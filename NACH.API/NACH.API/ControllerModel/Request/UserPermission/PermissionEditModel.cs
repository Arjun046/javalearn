namespace NACH.API.ControllerModel.Request.UserPermission
{
    public class PermissionEditModel : BaseRequestModel
    {
        public string UserId { get; set; }

        public string FormNm { get; set; }

        public string formCaption { get; set; }

        public int? SeqNo { get; set; }


        public string? Type { get; set; }

        public string? MainForm { get; set; }

        public string? BtnSave { get; set; }

        public string? BtnUpdate { get; set; }

        public string? BtnDelete { get; set; }


        public string? BtnShow { get; set; }


        public string? FormOpen { get; set; }

        public string? FormAutoAuth { get; set; }

    }
}
