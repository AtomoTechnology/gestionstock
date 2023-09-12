using ApplicationView.Configurations;
using ApplicationView.DataModel.Repositories.IRepository;
using ApplicationView.DataService.Iservice;
using ApplicationView.DataService.Service;
using AutoMapper;
using Microsoft.Extensions.DependencyInjection;
using System;

namespace ApplicationView.Patern.singleton
{
    public class RepoPathern
    {
        #region Service
        private static IAccountService accountService;
        private static IRoleService roleService;
        private static IBusnessService businessService;
        private static ICategoryService categoryService;
        private static IProviderService providerService;
        private static IProductService productService;
        private static ISaleService saleService;
        private static ISaleDetailService saleDetailService;
        private static IIncreasePriceAfterTwelveService increaseService;
        private static IUserService userService;
        private static ITurnService turnService;
        private static IOpenWorkTurnsService openWorkRepoService;
        private static ISettingBusinessService settingBusinessService;
        private static ILegitService legitService;
        private static IModuleService moduleService;
        private static IPromotionService promotionService;
        public static IServiceProvider ServiceProvider { get; private set; }
        #endregion

        #region Mapper
        private static IMapper maapper;
        #endregion

        #region Public
        public static IAccountService AccountService
        {
            get
            {
                if (accountService == null)
                    accountService = new AccountService(GetService<IAccountRepository>(), GetService<IMapper>());
                return accountService;
            }
            set
            {
                accountService = value;
            }
        }
        public static IRoleService RoleService
        {
            get
            {
                if (roleService == null)
                    roleService = new RoleService(GetService<IRoleRepository>(), GetService<IMapper>());
                return roleService;
            }
            set
            {
                roleService = value;
            }
        }
        public static IBusnessService BusnessService
        {
            get
            {
                if (businessService == null)
                    businessService = new BusnessService(GetService<IBusinessRepository>(), GetService<IMapper>());
                return businessService;
            }
            set
            {
                businessService = value;
            }
        }
        public static ICategoryService CategoryService
        {
            get
            {
                if (categoryService == null)
                    categoryService = new CategoryService(GetService<ICategoryRepository>(), GetService<IMapper>());
                return categoryService;
            }
            set
            {
                categoryService = value;
            }
        }
        public static IProviderService ProviderService
        {
            get
            {
                if (providerService == null)
                    providerService = new ProviderService(GetService<IProviderRepository>(), GetService<IMapper>());
                return providerService;
            }
            set
            {
                providerService = value;
            }
        }
        public static IProductService ProductService
        {
            get
            {
                if (productService == null)
                    productService = new ProductService(GetService<IProductRepository>(),GetService<IMapper>());
                return productService;
            }
            set
            {
                productService = value;
            }
        }
        public static ISaleService SaleService
        {
            get
            {
                if (saleService == null)
                    saleService = new SaleService(GetService<ISaleRepository>(), GetService<IMapper>());
                return saleService;
            }
            set
            {
                saleService = value;
            }
        }
        public static ISaleDetailService SaleDetailService
        {
            get
            {
                if (saleDetailService == null)
                    saleDetailService = new SaleDetailService(GetService<ISaleDetailRepoository>(), GetService<IMapper>());
                return saleDetailService;
            }
            set
            {
                saleDetailService = value;
            }
        }
        public static IIncreasePriceAfterTwelveService IncreaseService
        {
            get
            {
                if (increaseService == null)
                    increaseService = new IncreasePriceAfterTwelveService(GetService<IIncreasePriceAfterTwelveRepository>(), GetService<IMapper>());
                return increaseService;
            }
            set
            {
                increaseService = value;
            }
        }
        public static IUserService UserService
        {
            get
            {
                if (userService == null)
                    userService = new UserService(GetService<IUserRepository>(), GetService<IMapper>());
                return userService;
            }
            set
            {
                userService = value;
            }
        }
        public static ITurnService TurnService
        {
            get
            {
                if (turnService == null)
                    turnService = new TurnService(GetService<ITurnRepository>(), GetService<IMapper>());
                return turnService;
            }
            set
            {
                turnService = value;
            }
        }
        public static IOpenWorkTurnsService OpenWorkRepoService
        {
            get
            {
                if (openWorkRepoService == null)
                    openWorkRepoService = new OpenWorkTurnsService(GetService<IOpenWorkTurnsRepository>(), GetService<IMapper>());
                return openWorkRepoService;
            }
            set
            {
                openWorkRepoService = value;
            }
        }
        public static ISettingBusinessService SettingBusinessService
        {
            get
            {
                if (settingBusinessService == null)
                    settingBusinessService = new SettingBusinessService(GetService<ISettingBusinessRepository>(), GetService<IMapper>());
                return settingBusinessService;
            }
            set
            {
                settingBusinessService = value;
            }
        }
        public static ILegitService LegitBusinessService
        {
            get
            {
                if (legitService == null)
                    legitService = new LegitService(GetService<ILegitRepository>(), GetService<IMapper>());
                return legitService;
            }
            set
            {
                legitService = value;
            }
        }
        public static IModuleService ModuleService
        {
            get
            {
                if (moduleService == null)
                    moduleService = new ModuleService(GetService<IModuleRepository>(), GetService<IMapper>());
                return moduleService;
            }
            set
            {
                moduleService = value;
            }
        }
        public static IPromotionService PromotionService
        {
            get
            {
                if (promotionService == null)
                    promotionService = new PromotionService(GetService<IPromotionRepository>(), GetService<IMapper>());
                return promotionService;
            }
            set
            {
                promotionService = value;
            }
        }
        #endregion

        private static T GetService<T>()
        {
            var host = ConfigurationBase.CreateHostBuilder().Build();
            ServiceProvider = host.Services;
            var result = ServiceProvider.GetRequiredService<T>();
            return result;
        }

    }
}
