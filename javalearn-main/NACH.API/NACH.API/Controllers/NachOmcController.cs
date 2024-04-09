using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using NACH.DAL.Data;
using NACH.API.ControllerModel.Request.NachDbtlOmc;
using NACH.API.ControllerModel.Request.NachType;
using NACH.API.ControllerModel.Response;

using NACH.API.Services;

namespace NACH.API.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class NachOmcController : BaseController
    {
        private readonly ICommon _iCommon;
        private readonly ApplicationDbContext context;

        public NachOmcController(
          ILogger<NachOmcController> logger,
          IConfiguration configuration,
          ApplicationDbContext context,ICommon iCommon
         )
          : base(context:context)
        {
           _iCommon = iCommon;

        }

        [HttpPost("get-OmcTypeCompany")]
        public IActionResult getOmcTypeCompany([FromBody] getOmcTypeCompany request)
        {
            if (request is null)
            {
                return BadRequest(new ErrorResponse { Message = "Invalid Omc Type request" });
            }

            var data = _context.nach_Dbtl_Omc_Msts
                .Where(x => x.Code == "BPCL" || x.Code == "HPCL" || x.Code == "IOCL")
                .Select(x => new
                {
                    Code = x.Code,
                    OmcNm = x.OmcNm
                });

            if (data == null)
            {
                return NotFound(new ErrorResponse { Message = "Omc Type Company not exists" });
            }

            return Ok(new SuccessResponse
            {
                Response = data,
                Message = "Success"
            });
        }

    }
}
