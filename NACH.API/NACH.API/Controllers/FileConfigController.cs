using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using NACH.DAL.Data;
using NACH.API.ControllerModel.Request.nachFileConfigCbs;
using NACH.API.ControllerModel.Request.Parameter;
using NACH.API.ControllerModel.Response;

using NACH.API.Services;

namespace NACH.API.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class FileConfigController : BaseController
    {
        private readonly ICommon _iCommon;
        private readonly ApplicationDbContext context;

        string ls_argu_flag = "";

        public FileConfigController(
        ILogger<FileConfigController> logger,
        IConfiguration configuration,
        ApplicationDbContext context,ICommon iCommon
       )
        : base(context: context)
        {

            _iCommon = iCommon;
        }

        [HttpPost]
        [Route("get-NachFileConfigCBS")]
        public IActionResult getNachFileConfigCBS([FromBody] getNachFileConfigCBS request)
        {
            var data = _context.nach_File_Config_Msts;
            if (request.ls_flag == "CBS")
            {
                data.Select(x => new
                {
                    TranCode = x.TranCode,
                    ConfigNm = x.ConfigNm,
                    BankCode = x.BankCode,
                    NachType = x.NachType
                }).Where(x => x.BankCode == request.BankCode && (x.NachType == "CBSC" || x.NachType == "CBSD"));
            }
            else if (request.ls_flag == "RET_CBS")
            {
                data.Select(x => new
                {
                    TranCode = x.TranCode,
                    ConfigNm = x.ConfigNm,
                    BankCode = x.BankCode,
                    ConfigType = x.ConfigType
                }).Where(x => x.BankCode == request.BankCode && x.ConfigType == "R");
            }

            return Ok(new SuccessResponse
            {
                Response = data,
            });
        }
    }
}
