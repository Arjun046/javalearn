using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using NACH.DAL.Data;
using NACH.DAL.Model;
using NACH.API.ControllerModel.Request.City;
using NACH.API.ControllerModel.Response;

using NACH.API.Filter;

using NACH.API.Models.Response;
using NACH.API.Services;

namespace NACH.API.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class CityController : BaseController
    {
        private readonly ApplicationDbContext context;
        private readonly ICommon _iCommon;

        public CityController(IConfiguration configuration, ApplicationDbContext context )
            : base(context: context)
        {
            

        }

        [HttpPost]
        [Route("add-city")]
        public async Task<IActionResult> CityAdd([FromBody] CityAddModel request)
        {
            if (request is null)
            {
                return BadRequest(new ErrorResponse { Message = "Invalid City request" });
            }

            var val = await _context.city_Msts.FirstOrDefaultAsync(u => u.CityNm == request.CityName);
            if (val != null)
                return Ok(new ErrorResponse { Message = "City already exists!" });

            city_mst category = new city_mst
            {
                CityNm = request.CityName,
                StateCode = request.StateCode,
                Status = "Y",

                CreatedBy = request.UserId,
                CreatedDate = DateTime.Now,
                CreatedIp = request.IpAddress
            };

            _context.city_Msts.Add(category);
            await _context.SaveChangesAsync();

            return Ok(new SuccessResponse
            {
                Message = "City has been successfully added"
            });
        }

        [HttpPost]
        [Route("get-city-list")]
        public async Task<IActionResult> CityListGet([FromBody] PaginationFilter filter)
        {

            var validFilter = new PaginationFilter(filter.PageNumber, filter.PageSize);

            var citys = await _context.city_Msts.Select(x => new {
                TranCode = x.TranCode,
                CityName = x.CityNm,
                StateCode = x.StateCode,
                StateName = _context.stateMsts.FirstOrDefault(s => s.TranCode == x.StateCode).StateNm,
                Status = x.Status,

                CreatedBy = x.CreatedBy,
                CreatedDate = x.CreatedDate,
                CreatedIp = x.CreatedIp,
                ModifiedBy = x.ModifiedBy,
                ModifiedDate = x.ModifiedDate,
                ModifiedIp = x.ModifiedIp,
            }).Skip((validFilter.PageNumber - 1) * validFilter.PageSize)
                .Take(validFilter.PageSize)
                .OrderBy(x => x.TranCode)
                .ToListAsync();

            var totalRecords = await _context.city_Msts.CountAsync();
            var totalPages = (int)Math.Ceiling((double)totalRecords / validFilter.PageSize);

            return Ok(new PagedResponse
            {
                PageSize = validFilter.PageSize,
                PageNumber = validFilter.PageNumber,
                TotalRecords = totalRecords,
                TotalPages = totalPages,
                Message = "",
                Response = citys
            });
        }

        [HttpPost]
        [Route("get-city")]
        public async Task<IActionResult> CityGet([FromBody] CityDeleteModel request)
        {

            var category = await _context.city_Msts.Select(x => new {
                TranCode = x.TranCode,
                CityName = x.CityNm,
                StateCode = x.StateCode,
                StateName = _context.stateMsts.FirstOrDefault(s => s.TranCode == x.StateCode).StateNm,
                Status = x.Status,

                CreatedBy = x.CreatedBy,
                CreatedDate = x.CreatedDate,
                CreatedIp = x.CreatedIp,
                ModifiedBy = x.ModifiedBy,
                ModifiedDate = x.ModifiedDate,
                ModifiedIp = x.ModifiedIp,
            }).Where(y => y.TranCode == request.TranCode).FirstOrDefaultAsync();

            return Ok(new SuccessResponse
            {
                Message = "",
                Response = category
            });
        }

        [HttpPut]
        [Route("edit-city")]
        public async Task<IActionResult> CityEdit([FromBody] CityEditModel request)
        {
            if (request is null)
            {
                return BadRequest(new ErrorResponse { Message = "Invalid City request" });
            }
            var model = await _context.city_Msts.FirstOrDefaultAsync(u => u.TranCode == request.TranCode);
            if (model == null)
                return Ok(new ErrorResponse { Message = "City not exists!" });

            model.CityNm = request.CityName;
            model.StateCode = request.StateCode;
            model.Status = "Y";

            model.ModifiedBy = request.UserId;
            model.ModifiedDate = DateTime.Now;
            model.ModifiedIp = request.IpAddress;

            _context.city_Msts.Update(model);
            await _context.SaveChangesAsync();

            return Ok(new SuccessResponse
            {
                Message = "City has been successfully update"
            });
        }


        [HttpPost]
        [Route("delete-city")]
        public async Task<IActionResult> CityDelete([FromBody] CityDeleteModel request)
        {
            if (request is null)
            {
                return BadRequest(new ErrorResponse { Message = "Invalid City request" });
            }
            var model = await _context.city_Msts.FirstOrDefaultAsync(u => u.TranCode == request.TranCode);
            if (model == null)
                return Ok(new ErrorResponse { Message = "City not exists!" });

            _context.city_Msts.Remove(model);
            await _context.SaveChangesAsync();

            return Ok(new SuccessResponse
            {
                Message = "City has been successfully update"
            });
        }
    }
}
