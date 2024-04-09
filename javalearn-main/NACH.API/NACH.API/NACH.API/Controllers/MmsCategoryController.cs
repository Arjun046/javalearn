using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using NACH.DAL.Data;
using NACH.DAL.Model;
using NACH.API.ControllerModel.Request.NachMmsCategory;
using NACH.API.ControllerModel.Request.NachType;
using NACH.API.ControllerModel.Response;

using NACH.API.Services;

namespace NACH.API.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class MmsCategoryController : BaseController
    {
        private readonly ICommon _iCommon;
        private readonly ApplicationDbContext context;
        public MmsCategoryController(
        ILogger<MmsCategoryController> logger,
        IConfiguration configuration,
        ApplicationDbContext context,ICommon iCommon
       )
        : base(context: context)
        {
           _iCommon = iCommon;

        }

        [HttpPost]
        [Route("add-nachcategory")]
        public async Task<IActionResult> NachmmsCatAdd(NachMmsCategoryAdd request)
        {
            if (request is null)
            {
                return BadRequest(new ErrorResponse { Message = "Invalid Nach MMS Category request" });
            }

            var data = await _context.Nach_Mms_Category_Msts.FirstOrDefaultAsync(u => u.TranCode == request.TranCode);
            if (data != null)
                return Ok(new ErrorResponse { Message = " Nach MMS Category  already exists!" });

            nach_mms_category_mst model = new nach_mms_category_mst
            {
                AchType = request.AchType,
                CategoryDesc = request.CategoryDesc,
                CategoryCode = request.CategoryCode,
            };

            _context.Nach_Mms_Category_Msts.Add(model);
            await _context.SaveChangesAsync();

            return Ok(new SuccessResponse
            {
                Message = "NACH MMS Category has been successfully add"
            });
        }

        [HttpPut]
        [Route("edit-nachcategory")]
        public async Task<IActionResult> NachmmsCatEdit(NachMmsCategoryAdd request)
        {
            if (request is null)
            {
                return BadRequest(new ErrorResponse { Message = "Invalid Nach MMS Category request" });
            }
            var data = await _context.Nach_Mms_Category_Msts.FirstOrDefaultAsync(u => u.TranCode == request.TranCode);
            if (data == null)
                return Ok(new ErrorResponse { Message = "Nach MMS Category not exists!" });

            data.TranCode = request.TranCode;
           data.CategoryDesc = request.CategoryDesc;
            //data.CategoryCode = request.CategoryCode;
            data.AchType = request.AchType;
            

            _context.Nach_Mms_Category_Msts.Update(data);
            await _context.SaveChangesAsync();

            return Ok(new SuccessResponse
            {
                Message = "Nach MMS Category has been successfully update"
            });
        }


        [HttpPost]
        [Route("get-nachcategory")]
        public IActionResult NachmmsCatGet([FromBody] NachMmsCategoryGet request)
        {
            if (request is null)
            {
                return BadRequest(new ErrorResponse { Message = "Invalid Nach MMS Category request" });
            }

            var data = _context.Nach_Mms_Category_Msts
                .Where(x => x.TranCode == request.TranCode)
                .Select(x => new
                {
                    TranCode = x.TranCode,
                    AchType = x.AchType,
                    CategoryCode = x.CategoryCode,
                    ACH_TYPE_NM = x.AchType == "Cr" ? "Credit" : "Debit"
                })
                .OrderBy(x => x.TranCode);

            if (data == null)
            {
                return NotFound(new ErrorResponse { Message = "Nach MMS Category not exists" });
            }

            return Ok(new SuccessResponse
            {
                Response = data
            });
        }


        [HttpPost]
        [Route("get-Category")]
        public IActionResult NachmmsgetCategory([FromBody] NachMmsCategoryGet request)
        {
            if (request is null)
            {
                return BadRequest(new ErrorResponse { Message = "Invalid Nach MMS Category request" });
            }

            var data = _context.Nach_Mms_Category_Msts
                .Where(x => x.TranCode == request.TranCode)
                .Select(x => new
                {
                    CategoryCode = x.CategoryCode,
                    CategoryDesc = x.CategoryDesc,
                    TranCode = x.TranCode
                });

            if (data == null)
            {
                return NotFound(new ErrorResponse { Message = "Nach MMS Category not exists" });
            }

            return Ok(new SuccessResponse
            {
                Response = data
            });
        }


    }
}
