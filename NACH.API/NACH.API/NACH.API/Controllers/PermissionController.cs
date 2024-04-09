using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using NACH.DAL.Data;
using NACH.API.ControllerModel.Request.NachType;
using NACH.API.ControllerModel.Request.UserPermission;
using NACH.API.ControllerModel.Response;

using NACH.API.Services;

namespace NACH.API.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class PermissionController : BaseController
    {
        private readonly ICommon _iCommon;
        private readonly ApplicationDbContext context;

        public PermissionController(
       ILogger<PermissionController> logger,
       IConfiguration configuration,
       ApplicationDbContext context,
            ICommon iCommon
      )
       : base(context: context)
        {

            _iCommon = iCommon;
        }

       


        [HttpPost]
        [Route("get-permission")]
        public IActionResult UserPerMissionGet([FromBody] UserPerGet request)
        {
            if (request is null)
            {
                return BadRequest(new ErrorResponse { Message = "Invalid User request" });
            }
            var data = _context.form_Msts.Select(x => new
            {
                FormNm = x.FormNm,
                FormCaption = x.FormCaption,
                SeqNo = x.SeqNo,
                Type = x.Type,
                MainForm = x.MainForm,
                FormSave = x.FormSave,
                FormUpdate = x.FormUpdate,
                FormDelete = x.FormDelete,
                FormShow = x.FormShow,  
                FormView = x.FormView,
                FormAutoAuth = x.FormAutoAuth,
                UserId = _context.user_Permissions.FirstOrDefault(a => a.FormNm == x.FormNm && a.UserId == a.UserId).UserId,

                BtnSave = _context.user_Permissions.FirstOrDefault(a => a.FormNm == x.FormNm && a.UserId == a.UserId).BtnSave,
                BtnUpdate = _context.user_Permissions.FirstOrDefault(a => a.FormNm == x.FormNm && a.UserId == a.UserId).BtnUpdate,
                BtnDelete = _context.user_Permissions.FirstOrDefault(a => a.FormNm == x.FormNm && a.UserId == a.UserId).BtnDelete,
                BtnShow = _context.user_Permissions.FirstOrDefault(a => a.FormNm == x.FormNm && a.UserId == a.UserId).BtnShow,
                FormOpen = _context.user_Permissions.FirstOrDefault(a => a.FormNm == x.FormNm && a.UserId == a.UserId).FormOpen,
                FormAutoAuthU = _context.user_Permissions.FirstOrDefault(a => a.FormNm == x.FormNm && a.UserId == a.UserId).FormAutoAuth,

            }).Where(x => x.Type == "M")
            .OrderBy(x => x.SeqNo);

            return Ok(new SuccessResponse
            {
                Response = data
                
            });
        }

        [HttpPut]
        [Route("edit-Permission")]
        public async Task<IActionResult> PermissionEdit(PermissionEditModel request)
        {
            if (request is null)
            {
                return BadRequest(new ErrorResponse { Message = "Invalid User request" });
            }
            var data = await _context.user_Permissions.FirstOrDefaultAsync(u => u.UserId == request.UserId);
            if (data == null)
                return Ok(new ErrorResponse { Message = "User not exists!" });

            data.UserId = request.UserId;
            data.FormNm = request.FormNm;
            data.formCaption = request.formCaption;
            data.SeqNo = request.SeqNo;
            data.Type = request.Type;
            data.MainForm = request.MainForm;
            data.BtnSave = request.BtnSave;
            data.BtnUpdate = request.BtnUpdate;
            data.BtnDelete = request.BtnDelete;
            data.BtnShow = request.BtnShow;
            data.FormOpen = request.FormOpen;
            data.FormAutoAuth = request.FormAutoAuth;

            _context.user_Permissions.Update(data);
            await _context.SaveChangesAsync();

            return Ok(new SuccessResponse
            {
                Message = "User has been successfully update"
            });
        }


    }
}
