using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using ApplicationView.Forms.Business;
using ApplicationView.Forms.Category;
using ApplicationView.Forms.Configurations;
using ApplicationView.Forms.Product;
using ApplicationView.Forms.Provider;
using ApplicationView.Forms.Roles;
using ApplicationView.Forms.turnswork;
using ApplicationView.Forms.User;
using ApplicationView.Patern.singleton;
using Microsoft.EntityFrameworkCore;
using PlayerUI.Forms;
using ApplicationView.Forms.MsgBox;
using System.Windows.Forms;
using ApplicationView.DataModel.Repositories.IRepository;
using ApplicationView.DataModel.Repositories.Repository;
using ApplicationView.DataModel.Context;
using ApplicationView.Resolver.Security;
using ApplicationView.DataService.Iservice;
using ApplicationView.DataService.Service;

namespace ApplicationView.Configurations
{
    public static class ConfigurationBase
    {
        public static IHostBuilder CreateHostBuilder()
        {
            try
            {
                return Host.CreateDefaultBuilder()
               .ConfigureServices((context, services) => {

                   services.AddDbContext<DbGestionStockContext>(options => options.UseSqlServer(StringgConnection.GetString()));
                   services.AddScoped<newfrmlogin>();
                   services.AddScoped<frmrole>();
                   services.AddScoped<frmlogin>();
                   services.AddScoped<frmbusiness>();
                   services.AddScoped<frmcategory>();
                   services.AddScoped<frmprovider>();
                   services.AddScoped<frmProduct>();
                   services.AddScoped<frmIncreasePriceAfterTwelve>();
                   services.AddScoped<frmusr>();
                   services.AddScoped<frmturns>();
                   services.AddScoped<frmopenworkturns>();
                   services.AddScoped<frmoffer>();
                   //services.AddScoped<frmlegit>();
                   //services.AddScoped<frmdetailLegit>();

                   //services.AddEntityFrameworkS<DbGestionStockContext>();

                   services.AddScoped<RepoPathern>();

                   services.AddScoped<IRoleRepository, RoleRepository>();
                   services.AddScoped<IBusinessRepository, BusinessRepository>();
                   services.AddScoped<IAccountRepository, AccountRepository>();
                   services.AddScoped<ICategoryRepository, CategoryRepository>();
                   services.AddScoped<IProviderRepository, ProviderRepository>();
                   services.AddScoped<IProductRepository, ProductRepository>();
                   services.AddScoped<ISaleRepository, SaleRepository>();
                   services.AddScoped<ISaleDetailRepoository, SaleDetailRepoository>();
                   services.AddScoped<IIncreasePriceAfterTwelveRepository, IncreasePriceAfterTwelveRepository>();
                   services.AddScoped<IUserRepository, UserRepository>();
                   services.AddScoped<ITurnRepository, TurnRepository>();
                   services.AddScoped<IOpenWorkTurnsRepository, OpenWorkTurnsRepository>();
                   services.AddScoped<ISettingBusinessRepository, SettingBusinessRepository>();
                   services.AddScoped<ILegitRepository, LegitRepository>();
                   services.AddScoped<ILotRepository, LotRepository>();
                   services.AddScoped<IPaymentTypeRepository, PaymentTypeRepository>();
                   services.AddScoped<IModuleRepository, ModuleRepository>();
                   services.AddScoped<IPromotionRepository, PromotionRepository>();

                   services.AddScoped<IRoleService, RoleService>();
                   services.AddScoped<IBusnessService, BusnessService>();
                   services.AddScoped<IAccountService, AccountService>();
                   services.AddScoped<ICategoryService, CategoryService>();
                   services.AddScoped<IProviderService, ProviderService>();
                   services.AddScoped<IProductService, ProductService>();
                   services.AddScoped<ISaleService, SaleService>();
                   services.AddScoped<ISaleDetailService, SaleDetailService>();
                   services.AddScoped<IIncreasePriceAfterTwelveService, IncreasePriceAfterTwelveService>();
                   services.AddScoped<IUserService, UserService>();
                   services.AddScoped<ITurnService, TurnService>();
                   services.AddScoped<IOpenWorkTurnsService, OpenWorkTurnsService>();
                   services.AddScoped<ISettingBusinessService, SettingBusinessService>();
                   services.AddScoped<ILegitService, LegitService>();
                   services.AddScoped<IModuleService, ModuleService>();
                   services.AddScoped<IPromotionService, PromotionService>();

                    //AUtoMapper

                    services.AddAutoMapper(typeof(DataService.Profiles.GestionStockMapperProfile));

               });
            }
            catch (System.Exception ex)
            {
                RJMessageBox.Show(ex.Message, "Sistema de ventas", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return null;
            }
        }
    }
}
