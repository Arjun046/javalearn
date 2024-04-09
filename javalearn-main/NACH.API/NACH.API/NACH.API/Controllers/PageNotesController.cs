using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using NACH.DAL.Data;
using NACH.API.ControllerModel.Request.NachType;
using NACH.API.ControllerModel.Request.PageMst;
using NACH.API.ControllerModel.Response;
using NACH.API.Services;

namespace NACH.API.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class PageNotesController : BaseController
    {
        private readonly ICommon _iCommon;
        private readonly ApplicationDbContext context;
        public PageNotesController(
              ILogger<PageNotesController> logger,
              IConfiguration configuration,
              ApplicationDbContext context,
              ICommon iCommon
             )
              : base(context: context)
        {
            _iCommon = iCommon;

        }

        [HttpPost]
        [Route("get-pagenotes")]
        public IActionResult pagenotes([FromBody] pagenotes request)
        {
            if (request is null)
            {
                return BadRequest(new ErrorResponse { Message = "Invalid Data request" });
            }
            var data = _context.page_Notes_Msts.Select(x => new {
                PageCode = x.PageCode,
                Data = x.Data,
               
            });

            return Ok(new SuccessResponse
            {
                Response = data,
                Message = "Data get successfully."
            });
        }
        [HttpPost]
        [Route("get-page-notes")]
        public IActionResult pagenotesGet([FromBody] pagenotes request)
        {
            if (request is null)
            {
                return BadRequest(new ErrorResponse { Message = "Invalid Data request" });
            }
            var data = _context.page_Notes_Msts.Select(x => new {
                PageCode = x.PageCode,
                Data = x.Data,
            }).Where(x => x.PageCode==request.PageCode);

            return Ok(new SuccessResponse
            {
                Response = data,
                Message = "Data get successfully."
            });
        }



        [HttpPut]
        [Route("edit-pagenotes")]
        public async Task<IActionResult> pagenotesEdit(pagenotesEdit request)
        {
            if (request is null)
            {
                return BadRequest(new ErrorResponse { Message = "Invalid Data request" });
            }
            var data = await _context.page_Notes_Msts.FirstOrDefaultAsync(u => u.PageCode == request.PageCode);
            if (data == null)
                return Ok(new ErrorResponse { Message = "Data not exists!" });

            data.PageCode = request.PageCode;
            data.Data = request.Data;
            

            _context.page_Notes_Msts.Update(data);
            await _context.SaveChangesAsync();

            return Ok(new SuccessResponse
            {
                Message = "Data has been successfully update."
            });
        }


    }
}
