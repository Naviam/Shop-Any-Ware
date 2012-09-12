// --------------------------------------------------------------------------------------------------------------------
// <copyright file="AutoMapperConfiguration.cs" company="TdService">
//   Vitali Hatalski. 2012.
// </copyright>
// <summary>
//   The auto mapper configuration.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace TdService.UI.Web
{
    using AutoMapper;

    using TdService.Model.Addresses;
    using TdService.Model.Common;
    using TdService.Model.Items;
    using TdService.Model.Membership;
    using TdService.Model.Orders;
    using TdService.Model.Packages;
    using TdService.Services.Messaging.Address;
    using TdService.Services.Messaging.Item;
    using TdService.Services.Messaging.Membership;
    using TdService.Services.Messaging.Order;
    using TdService.Services.Messaging.Package;
    using TdService.Services.Messaging.Retailer;
    using TdService.UI.Web.ViewModels;
    using TdService.UI.Web.ViewModels.Account;
    using TdService.UI.Web.ViewModels.Item;
    using TdService.UI.Web.ViewModels.Order;
    using TdService.UI.Web.ViewModels.Package;
    using TdService.UI.Web.ViewModels.Retailer;

    using Profile = AutoMapper.Profile;

    /// <summary>
    /// The auto mapper configuration.
    /// </summary>
    public class AutoMapperConfiguration
    {
        /// <summary>
        /// Configure mapping.
        /// </summary>
        public static void Configure()
        {
            // sign up
            Mapper.CreateMap<User, SignUpResponse>()
                .ForMember(r => r.FirstName, opt => opt.MapFrom(u => u.Profile.FirstName))
                .ForMember(r => r.LastName, opt => opt.MapFrom(u => u.Profile.LastName))
                .ForMember(r => r.NotifyOnOrderStatusChanged, opt => opt.MapFrom(u => u.Profile.NotifyOnOrderStatusChanged))
                .ForMember(r => r.NotifyOnPackageStatusChanged, opt => opt.MapFrom(u => u.Profile.NotifyOnPackageStatusChanged));
            Mapper.CreateMap<SignUpResponse, SignUpViewModel>();

            // sign in
            Mapper.CreateMap<SignInViewModel, SignInRequest>();
            Mapper.CreateMap<SignInResponse, SignInViewModel>();
            ////Mapper.CreateMap<SignUpRequest, User>();

            // roles
            Mapper.CreateMap<Role, GetUserRolesResponse>();
            Mapper.CreateMap<GetUserRolesResponse, RoleViewModel>();

            // profile
            Mapper.CreateMap<ProfileViewModel, UpdateProfileRequest>();
            Mapper.CreateMap<UpdateProfileRequest, Profile>();

            // delivery address
            Mapper.CreateMap<DeliveryAddress, GetDeliveryAddressesResponse>();
            Mapper.CreateMap<GetDeliveryAddressesResponse, DeliveryAddressViewModel>();
            Mapper.CreateMap<AddOrUpdateDeliveryAddressResponse, DeliveryAddressViewModel>();
            Mapper.CreateMap<DeliveryAddressViewModel, AddOrUpdateDeliveryAddressRequest>();
            Mapper.CreateMap<AddOrUpdateDeliveryAddressRequest, DeliveryAddress>();
            Mapper.CreateMap<DeliveryAddress, AddOrUpdateDeliveryAddressResponse>();
            Mapper.CreateMap<RemoveDeliveryRequestResponse, DeliveryAddressViewModel>();

            // get recent orders
            Mapper.CreateMap<GetRecentOrdersResponse, OrderViewModel>();
            Mapper.CreateMap<Order, GetRecentOrdersResponse>();

            // add order
            Mapper.CreateMap<AddOrderResponse, OrderViewModel>();
            Mapper.CreateMap<OrderViewModel, AddOrderRequest>();
            Mapper.CreateMap<AddOrderRequest, Order>();
            Mapper.CreateMap<Order, AddOrderResponse>();

            // retailer
            Mapper.CreateMap<string, Retailer>().ConvertUsing<RetailerConverter>();
            Mapper.CreateMap<Retailer, GetRetailersResponse>();
            Mapper.CreateMap<GetRetailersResponse, RetailerViewModel>();

            // add order item
            Mapper.CreateMap<OrderItemViewModel, AddItemToOrderRequest>();
            Mapper.CreateMap<AddItemToOrderRequest, Item>();
            Mapper.CreateMap<Item, AddItemToOrderResponse>();
            Mapper.CreateMap<AddItemToOrderResponse, OrderItemViewModel>();

            // get order items
            Mapper.CreateMap<Item, GetOrderItemsResponse>();
            Mapper.CreateMap<GetOrderItemsResponse, OrderItemViewModel>();

            // add item to package

            // get package items
            Mapper.CreateMap<Item, GetPackageItemsResponse>();
            Mapper.CreateMap<GetPackageItemsResponse, PackageItemViewModel>();

            // get recent packages
            Mapper.CreateMap<Package, GetRecentPackagesResponse>();
            Mapper.CreateMap<GetRecentPackagesResponse, PackageViewModel>();

            // add package
            Mapper.CreateMap<Package, AddPackageResponse>();
            Mapper.CreateMap<AddPackageResponse, PackageViewModel>();
        }

        /// <summary>
        /// The retailer converter.
        /// </summary>
        public class RetailerConverter : ITypeConverter<string, Retailer>
        {
            /// <summary>
            /// Convert retailer url or name to retailer.
            /// </summary>
            /// <param name="context">
            /// The context.
            /// </param>
            /// <returns>
            /// The retailer.
            /// </returns>
            public Retailer Convert(ResolutionContext context)
            {
                var value = context.SourceValue.ToString();
                return new Retailer { Name = value, Url = value };
            }
        }
    }
}