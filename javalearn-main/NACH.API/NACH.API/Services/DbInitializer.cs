using NACH.DAL.Data;


namespace NACH.API.Services
{
    public static class DbInitializer
    {
        public static async Task Initialize(ApplicationDbContext context, IFunctional functional)
        {
            context.Database.EnsureCreated();

            await functional.CreateDefaultAPIServices();
            await functional.CreateDefaultLanguageDetails();

            if (context.bank_Msts.Any())
            {
                return;
            }
            else
            {
                await functional.CreateCompanyInfo();
                await functional.CreateBranchInfo();
                await functional.CreateDefaultSuperAdmin();
                await functional.InitAppData();
                return;
            }
        }
    }
}
