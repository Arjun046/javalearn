using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using NACH.DAL.Data;
using NACH.API.ControllerModel.Request.Bank;
using NACH.API.ControllerModel.Request.NachType;
using NACH.API.ControllerModel.Response;
//using SmartNachApi.Data;
using NACH.API.Services;

namespace NACH.API.Controllers
{
    [ApiController]
    public class BankController:BaseController
    {
        private readonly ICommon _iCommon;
        private readonly ApplicationDbContext context;
        public BankController(
        ILogger<BankController> logger,
        IConfiguration configuration,
        ApplicationDbContext context, ICommon iCommon
       )
        : base(context:context)
        {
            _iCommon= iCommon;

        }




        [HttpPut]
        [Route("edit-bank")]
        //[UserPermission(PermissionEnum.Form.BANK, PermissionEnum.Rights.EDIT)]
        public async Task<IActionResult> bankEdit(BankEdit bankEditModel)
        {
            if (bankEditModel is null)
            {
                return BadRequest(new ErrorResponse { Message = "Invalid client request" });
            }
            var bank = await _context.bank_Msts.FirstOrDefaultAsync(u => u.BankCode == bankEditModel.BankCode);
            if (bank == null)
                return Ok(new ErrorResponse { Message = "Bank not exists!" });

            bank.BankName = bankEditModel.BankName;
            bank.BankCategory = bankEditModel.BankCategory;
            bank.RegestrationDate = bankEditModel.RegestrationDate;
            bank.BsrCode = bankEditModel.BsrCode;
            bank.UniqueFiuld = bankEditModel.UniqueFiuld;
            bank.ContactPerson = bankEditModel.ContactPerson;
            bank.Designation = bankEditModel.Designation;
            bank.Address = bankEditModel.Address;
            bank.CityName = bankEditModel.CityName;
            bank.StateCode = bankEditModel.StateCode;
            bank.CountryCode = bankEditModel.CountryCode;
            bank.PinCode = bankEditModel.PinCode;
            bank.Mobile = bankEditModel.Mobile;
            bank.Phone = bankEditModel.Phone;
            bank.Email = bankEditModel.Email;
            bank.Fax = bankEditModel.Fax;
            bank.UtilityVersion = bankEditModel.UtilityVersion;
            bank.DataStructureVersion = bankEditModel.DataStructureVersion;

            bank.ModifiedBy = bankEditModel.UserId;
            bank.ModifiedDate = DateTime.Now;
            bank.ModifiedIp = bankEditModel.IpAddress;

            _context.bank_Msts.Update(bank);
            await _context.SaveChangesAsync();

            return Ok(new SuccessResponse
            {
                Message = "Bank has been successfully update"
            });
        }


        


    }
}
