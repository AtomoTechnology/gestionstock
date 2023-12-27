using ApplicationView.BusnessEntities.BE;
using ApplicationView.BusnessEntities.Dtos;
using ApplicationView.DataModel.Entities;
using ApplicationView.DataModel.SPEntities;
using AutoMapper;

namespace ApplicationView.DataService.Profiles
{
    public class GestionStockMapperProfile : Profile
    {
        public GestionStockMapperProfile()
        {
            //Entity to BE vice versa
            CreateMap<Account, AccountBE>()
            .ForMember(u => u.FirstName, p => p.MapFrom(z => z.User.FirstName))
            .ForMember(u => u.LastName, p => p.MapFrom(z => z.User.LastName))
            .ForMember(u => u.Email, p => p.MapFrom(z => z.User.Email))
            .ForMember(u => u.Phone, p => p.MapFrom(z => z.User.Phone))
            .ReverseMap();

            CreateMap<Business, BusinessBE>().ReverseMap();
            CreateMap<Category, CategoryBE>().ReverseMap();
            CreateMap<IncreasePriceAfterTwelve, IncreasePriceAfterTwelveBE>().ReverseMap();
            CreateMap<Legit, LegitBE>().ReverseMap();

            CreateMap<Lot, LotBE>().ReverseMap();
            CreateMap<ModuleAccount, ModuleAccountBE>().ReverseMap();
            CreateMap<Module, ModuleBE>().ReverseMap();

            CreateMap<OpenWorkTurn, OpenWorkTurnBE>()
            .ForMember(u => u.TurnName, p => p.MapFrom(z => z.Turn.TurnName))
            .ForMember(u => u.DateFrom, p => p.MapFrom(z => z.Turn.DateFrom))
            .ForMember(u => u.DateTo, p => p.MapFrom(z => z.Turn.DateTo))
            .ReverseMap();

            CreateMap<PaymentType, PaymentTypeBE>().ReverseMap();
            CreateMap<Product, ProductBE>().ReverseMap();
            CreateMap<ProductWithStock, ProductWithStockBE>().ReverseMap();
            CreateMap<Promotion, PromotionBE>().ReverseMap();
            CreateMap<PromotionDetail, PromotionDetailBE>().ReverseMap();

            CreateMap<Provider, ProviderBE>().ReverseMap();
            CreateMap<Role, RoleBE>().ReverseMap();
            CreateMap<Sale, SaleBE>().ReverseMap();
            CreateMap<SaleDetail, SaleDetailBE>().ReverseMap();
            CreateMap<SaleDetail, SaleDetailDto>().ReverseMap(); 
            CreateMap<ClossCashier, ClossCashierBE>().ReverseMap();

            CreateMap<SettingBusiness, SettingBusinessBE>().ReverseMap();
            CreateMap<SubModuleAccount, SubModuleAccountBE>().ReverseMap();
            CreateMap<SubModule, SubModuleBE>().ReverseMap();
            CreateMap<Turns, TurnsBE>().ReverseMap();

            CreateMap<UpdateStockProduct, UpdateStockProductBe>().ReverseMap();
            CreateMap<User, UserBE>().ReverseMap();

            //SP to DTO  vice versa
            CreateMap<AccountSP, AccountDTO>().ReverseMap();
            CreateMap<SaleWithLogit, SaleWithLogitDto>().ReverseMap();
            CreateMap<SearchSaleSP, SearchSaleSPDTO>().ReverseMap(); 
        }
    }
}
