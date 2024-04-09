using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using NACH.DAL.Data;
using NACH.DAL.Model;
using NACH.API.ControllerModel.Request.AcctType;
using NACH.API.ControllerModel.Response;
//using SmartNachApi.Data;
using NACH.API.Filter;
//using SmartNachApi.Model;
using NACH.API.Models.Response;
using NACH.API.Services;

namespace NACH.API.Controllers
{
    [Route("[controller]")]
    [ApiController]

    public class AcctTypeController : BaseController
    {
        private readonly ILogger _logger;
        private readonly ApplicationDbContext context;


        public AcctTypeController(
           ILogger<AcctTypeController> logger,
           IConfiguration configuration,
           ApplicationDbContext context
          )
           : base(context:context)
        {
            
           
            _logger = logger;

        }

        [HttpPost]
        [Route("add-accttype")]
       // [UserPermission(PermissionEnum.Form.ACCT_TYPE_MASTER, PermissionEnum.Rights.ADD)]
        public async Task<IActionResult> AcctTypeAdd(AcctTypeAddModel request)
        {
            if (request is null)
            {
                return BadRequest(new ErrorResponse { Message = "Invalid Account Type request" });
            }
            var val = await _context.acct_Type_Msts.FirstOrDefaultAsync(u => u.BankCode == request.BankCode && u.BranchCode == request.BranchCode && u.AccountType == request.AccountType);
            if (val != null)
                return Ok(new ErrorResponse { Message = "Account Type already exists!" });

            acct_type_mst acctType = new acct_type_mst
            {
                BankCode = request.BankCode,
                BranchCode = request.BranchCode,
                AccountType = request.AccountType,
                TypeName = request.TypeName,
                CbsCode = request.CbsCode,
                VerifyStatus = request.VerifyStatus,

                CreatedBy = request.UserId,
                CreatedDate = DateTime.Now,
                CreatedIp = request.IpAddress
            };

            _context.acct_Type_Msts.Add(acctType);
            await _context.SaveChangesAsync();

            return Ok(new SuccessResponse
            {
                Message = "Account Type has been successfully added"
            });
        }

        [HttpPost]
        [Route("get-accttype-list")]
       // [UserPermission(PermissionEnum.Form.ACCT_TYPE_MASTER, PermissionEnum.Rights.VIEW)]
        public async Task<IActionResult> AcctTypeListGet([FromBody] PaginationFilter filter)
        {

            var validFilter = new PaginationFilter(filter.PageNumber, filter.PageSize);

            var acctType = await _context.acct_Type_Msts.Select(x => new {
                BankCode = x.BankCode,
                BranchCode = x.BranchCode,
                TranCode = x.TranCode,
                AccountType = x.AccountType,
                TypeName = x.TypeName,
                CbsCode = x.CbsCode,
                VerifyStatus = x.VerifyStatus,

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

            var totalRecords = await _context.acct_Type_Msts.CountAsync();
            var totalPages = (int)Math.Ceiling((double)totalRecords / validFilter.PageSize);

            return Ok(new PagedResponse
            {
                PageSize = validFilter.PageSize,
                PageNumber = validFilter.PageNumber,
                TotalRecords = totalRecords,
                TotalPages = totalPages,
                Message = "",
                Response = acctType
            });
        }


        [HttpPost]
        [Route("get-accttype")]
        //[UserPermission(PermissionEnum.Form.ACCT_TYPE_MASTER, PermissionEnum.Rights.VIEW)]
        public IActionResult AcctTypeGet([FromBody] AcctTypeGetModel typeGetModel)
        {

            var acctType = _context.acct_Type_Msts.Select(x => new {
                BankCode = x.BankCode,
                BranchCode = x.BranchCode,
                TranCode = x.TranCode,
                AccountType = x.AccountType,
                TypeName = x.TypeName,
                CbsCode = x.CbsCode,
                CreatedBy = x.CreatedBy,
                CreatedDate = x.CreatedDate,
                CreatedIp = x.CreatedIp,
                ModifiedBy = x.ModifiedBy,
                ModifiedDate = x.ModifiedDate,
                ModifiedIp = x.ModifiedIp,
                VerifyStatus = x.VerifyStatus
            }).Where(x => x.BankCode == typeGetModel.BankCode && x.BranchCode == typeGetModel.BranchCode && x.TranCode == typeGetModel.TranCode);

            return Ok(new SuccessResponse
            {
                Message = "",
                Response = acctType
            });
        }

        [HttpPut]
        [Route("edit-accttype")]
        //[UserPermission(PermissionEnum.Form.ACCT_TYPE_MASTER, PermissionEnum.Rights.EDIT)]
        public async Task<IActionResult> AcctTypeEdit([FromBody] AcctTypeEditModel request)
        {
            if (request is null)
            {
                return BadRequest(new ErrorResponse { Message = "Invalid Account Type  request" });
            }
            var acctType = await _context.acct_Type_Msts.FirstOrDefaultAsync(u => u.BankCode == request.BankCode && u.BranchCode == request.BranchCode && u.TranCode == request.TranCode);
            if (acctType == null)
                return Ok(new ErrorResponse { Message = "Account Type not exists!" });

            var val = await _context.acct_Type_Msts.FirstOrDefaultAsync(u => u.BankCode == request.BankCode && u.BranchCode == request.BranchCode && u.TranCode != request.TranCode && u.AccountType == request.AccountType);
            if (val != null)
                return Ok(new ErrorResponse { Message = "AccountType already exists!" });

            acctType.BankCode = request.BankCode;
            acctType.BranchCode = request.BranchCode;
            acctType.TranCode = request.TranCode;
            acctType.AccountType = request.AccountType;
            acctType.TypeName = request.TypeName;
            acctType.CbsCode = request.CbsCode;
            acctType.VerifyStatus = request.VerifyStatus;

            acctType.ModifiedBy = request.UserId;
            acctType.ModifiedDate = DateTime.Now;
            acctType.ModifiedIp = request.IpAddress;

            _context.acct_Type_Msts.Update(acctType);
            await _context.SaveChangesAsync();

            return Ok(new SuccessResponse
            {
                Message = "Account Type has been successfully update"
            });
        }

        
    }
}
