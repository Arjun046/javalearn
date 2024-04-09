using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using NACH.DAL.Data;
using NACH.DAL.Model;
using NACH.API.ControllerModel.Request.Country;
using NACH.API.ControllerModel.Response;

using NACH.API.Filter;

using NACH.API.Models.Response;
using NACH.API.Services;

namespace NACH.API.Controllers
{
    [ApiController]
    //[ValidateSession]
    public class CountryController : BaseController
    {
        private readonly ApplicationDbContext context;

        public CountryController(IConfiguration configuration, ApplicationDbContext context)
            : base(context: context)
        {


        }

        [HttpPost]
        [Route("add-country")]
        public async Task<IActionResult> CountryAdd([FromBody] CountryAddModel request)
        {
            if (request is null)
            {
                return BadRequest(new ErrorResponse { Message = "Invalid City request" });
            }

            var val = await _context.country_Msts.FirstOrDefaultAsync(u => u.CountryName == request.CountryName);
            if (val != null)
                return Ok(new ErrorResponse { Message = "City already exists!" });

            country_mst model = new country_mst
            {
                CountryName = request.CountryName,
                SortName = request.SortName,
                PhoneCode = request.PhoneCode,

                CreatedBy = request.UserId,
                CreatedDate = DateTime.Now,
                CreatedIp = request.IpAddress
            };

            _context.country_Msts.Add(model);
            await _context.SaveChangesAsync();

            return Ok(new SuccessResponse
            {
                Message = "City has been successfully added"
            });
        }

        [HttpPost]
        [Route("get-country-list")]
        public async Task<IActionResult> CountryListGet([FromBody] PaginationFilter filter)
        {

            var validFilter = new PaginationFilter(filter.PageNumber, filter.PageSize);

            var countrys = await _context.country_Msts.Select(x => new {
                TranCode = x.TranCode,
                CountryName = x.CountryName,
                SortName = x.SortName,
                PhoneCode = x.PhoneCode,

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

            var totalRecords = await _context.country_Msts.CountAsync();
            var totalPages = (int)Math.Ceiling((double)totalRecords / validFilter.PageSize);

            return Ok(new PagedResponse
            {
                PageSize = validFilter.PageSize,
                PageNumber = validFilter.PageNumber,
                TotalRecords = totalRecords,
                TotalPages = totalPages,
                Message = "",
                Response = countrys
            });
        }

        [HttpPost]
        [Route("get-country")]
        public async Task<IActionResult> CountryGet([FromBody] CountryDeleteModel request)
        {

            var category = await _context.country_Msts.Select(x => new {
                TranCode = x.TranCode,
                CountryName = x.CountryName,
                SortName = x.SortName,
                PhoneCode = x.PhoneCode,

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
        [Route("edit-country")]
        public async Task<IActionResult> CountryEdit([FromBody] CountryEditModel request)
        {
            if (request is null)
            {
                return BadRequest(new ErrorResponse { Message = "Invalid Country request" });
            }
            var model = await _context.country_Msts.FirstOrDefaultAsync(u => u.TranCode == request.TranCode);
            if (model == null)
                return Ok(new ErrorResponse { Message = "Country not exists!" });

            model.CountryName = request.CountryName;
            model.SortName = request.SortName;
            model.PhoneCode = request.PhoneCode;

            model.ModifiedBy = request.UserId;
            model.ModifiedDate = DateTime.Now;
            model.ModifiedIp = request.IpAddress;

            _context.country_Msts.Update(model);
            await _context.SaveChangesAsync();

            return Ok(new SuccessResponse
            {
                Message = "Country has been successfully update"
            });
        }


        [HttpPost]
        [Route("delete-country")]
        public async Task<IActionResult> CountryDelete([FromBody] CountryDeleteModel request)
        {
            if (request is null)
            {
                return BadRequest(new ErrorResponse { Message = "Invalid Country request" });
            }
            var model = await _context.country_Msts.FirstOrDefaultAsync(u => u.TranCode == request.TranCode);
            if (model == null)
                return Ok(new ErrorResponse { Message = "Country not exists!" });

            var val = await _context.stateMsts.AnyAsync(u => u.CountryCode == request.TranCode);
            if (val)
                return Ok(new ErrorResponse { Message = "Country Record can't be deleted because it's used in State!" });

            _context.country_Msts.Remove(model);
            await _context.SaveChangesAsync();

            return Ok(new SuccessResponse
            {
                Message = "Country has been successfully deleted"
            });
        }
    }
}
