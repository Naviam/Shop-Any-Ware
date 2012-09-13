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
                .ForMember(r => r.NotifyOnPackageStatusChanged, opt => opt.MapFrom(u => u.Profile.NotifyOnPackageStatusChanged))
                .ForMember(r => r.Message, opt => opt.Ignore())
                .ForMember(r => r.ErrorCode, opt => opt.Ignore())
                .ForMember(r => r.MessageType, opt => opt.Ignore());
            Mapper.CreateMap<SignUpResponse, SignUpViewModel>()
                .ForMember(m => m.Password, opt => opt.Ignore())
                .ForMember(m => m.PasswordConfirm, opt => opt.Ignore());

            // sign in
            Mapper.CreateMap<SignInViewModel, SignInRequest>()
                .ForMember(m => m.IdentityToken, opt => opt.Ignore());
            Mapper.CreateMap<SignInResponse, SignInViewModel>()
                .ForMember(m => m.Email, opt => opt.Ignore())
                .ForMember(m => m.Password, opt => opt.Ignore())
                .ForMember(m => m.RememberMe, opt => opt.Ignore());
            ////Mapper.CreateMap<SignUpRequest, User>();

            // roles
            Mapper.CreateMap<Role, GetUserRolesResponse>()
                .ForMember(r => r.Message, opt => opt.Ignore())
                .ForMember(r => r.ErrorCode, opt => opt.Ignore())
                .ForMember(r => r.MessageType, opt => opt.Ignore());
            Mapper.CreateMap<GetUserRolesResponse, RoleViewModel>();

            // profile
            Mapper.CreateMap<ProfileViewModel, UpdateProfileRequest>()
                .ForMember(m => m.IdentityToken, opt => opt.Ignore());
            Mapper.CreateMap<UpdateProfileResponse, ProfileViewModel>();
            Mapper.CreateMap<UpdateProfileRequest, Model.Membership.Profile>()
                .ForMember(m => m.RowVersion, opt => opt.Ignore());
            Mapper.CreateMap<Model.Membership.Profile, UpdateProfileResponse>()
                .ForMember(r => r.Message, opt => opt.Ignore())
                .ForMember(r => r.ErrorCode, opt => opt.Ignore())
                .ForMember(r => r.MessageType, opt => opt.Ignore());
            Mapper.CreateMap<GetProfileResponse, ProfileViewModel>();
            Mapper.CreateMap<Model.Membership.Profile, GetProfileResponse>()
                .ForMember(r => r.Message, opt => opt.Ignore())
                .ForMember(r => r.ErrorCode, opt => opt.Ignore())
                .ForMember(r => r.MessageType, opt => opt.Ignore());

            // delivery address
            Mapper.CreateMap<DeliveryAddress, GetDeliveryAddressesResponse>()
                .ForMember(r => r.Message, opt => opt.Ignore())
                .ForMember(r => r.ErrorCode, opt => opt.Ignore())
                .ForMember(r => r.MessageType, opt => opt.Ignore());
            Mapper.CreateMap<GetDeliveryAddressesResponse, DeliveryAddressViewModel>();
            Mapper.CreateMap<AddOrUpdateDeliveryAddressResponse, DeliveryAddressViewModel>();
            Mapper.CreateMap<DeliveryAddressViewModel, AddOrUpdateDeliveryAddressRequest>()
                .ForMember(r => r.IdentityToken, opt => opt.Ignore());
            Mapper.CreateMap<AddOrUpdateDeliveryAddressRequest, DeliveryAddress>()
                .ForMember(m => m.RowVersion, opt => opt.Ignore());
            Mapper.CreateMap<DeliveryAddress, AddOrUpdateDeliveryAddressResponse>()
                .ForMember(r => r.Message, opt => opt.Ignore())
                .ForMember(r => r.ErrorCode, opt => opt.Ignore())
                .ForMember(r => r.MessageType, opt => opt.Ignore());
            Mapper.CreateMap<RemoveDeliveryRequestResponse, DeliveryAddressViewModel>()
                .ForMember(r => r.FirstName, opt => opt.Ignore())
                .ForMember(r => r.LastName, opt => opt.Ignore())
                .ForMember(r => r.ZipCode, opt => opt.Ignore())
                .ForMember(r => r.Country, opt => opt.Ignore())
                .ForMember(r => r.Region, opt => opt.Ignore())
                .ForMember(r => r.State, opt => opt.Ignore())
                .ForMember(r => r.City, opt => opt.Ignore())
                .ForMember(r => r.Phone, opt => opt.Ignore())
                .ForMember(r => r.AddressName, opt => opt.Ignore())
                .ForMember(r => r.AddressLine1, opt => opt.Ignore())
                .ForMember(r => r.AddressLine2, opt => opt.Ignore())
                .ForMember(r => r.AddressLine3, opt => opt.Ignore());

            // get recent orders
            Mapper.CreateMap<GetRecentOrdersResponse, OrderViewModel>();
            Mapper.CreateMap<Order, GetRecentOrdersResponse>()
                .ForMember(r => r.Message, opt => opt.Ignore())
                .ForMember(r => r.ErrorCode, opt => opt.Ignore())
                .ForMember(r => r.MessageType, opt => opt.Ignore());

            // add order
            Mapper.CreateMap<AddOrderResponse, OrderViewModel>();
            Mapper.CreateMap<OrderViewModel, AddOrderRequest>()
                .ForMember(m => m.IdentityToken, opt => opt.Ignore());
            Mapper.CreateMap<Order, AddOrderResponse>()
                .ForMember(r => r.Message, opt => opt.Ignore())
                .ForMember(r => r.ErrorCode, opt => opt.Ignore())
                .ForMember(r => r.MessageType, opt => opt.Ignore());

            // retailer
            Mapper.CreateMap<string, Retailer>().ConvertUsing<RetailerConverter>();
            Mapper.CreateMap<Retailer, GetRetailersResponse>()
                .ForMember(r => r.Message, opt => opt.Ignore())
                .ForMember(r => r.ErrorCode, opt => opt.Ignore())
                .ForMember(r => r.MessageType, opt => opt.Ignore());
            Mapper.CreateMap<GetRetailersResponse, RetailerViewModel>();

            // add order item
            Mapper.CreateMap<OrderItemViewModel, AddItemToOrderRequest>();
            Mapper.CreateMap<AddItemToOrderRequest, Item>();
            Mapper.CreateMap<Item, AddItemToOrderResponse>()
                .ForMember(r => r.Message, opt => opt.Ignore())
                .ForMember(r => r.ErrorCode, opt => opt.Ignore())
                .ForMember(r => r.MessageType, opt => opt.Ignore());
            Mapper.CreateMap<AddItemToOrderResponse, OrderItemViewModel>()
                .ForMember(r => r.OrderId, opt => opt.Ignore());

            // get order items
            Mapper.CreateMap<Item, GetOrderItemsResponse>()
                .ForMember(r => r.Message, opt => opt.Ignore())
                .ForMember(r => r.ErrorCode, opt => opt.Ignore())
                .ForMember(r => r.MessageType, opt => opt.Ignore());
            Mapper.CreateMap<GetOrderItemsResponse, OrderItemViewModel>()
                .ForMember(r => r.OrderId, opt => opt.Ignore());

            // add item to package

            // get package items
            Mapper.CreateMap<Item, GetPackageItemsResponse>()
                .ForMember(r => r.Message, opt => opt.Ignore())
                .ForMember(r => r.ErrorCode, opt => opt.Ignore())
                .ForMember(r => r.MessageType, opt => opt.Ignore());
            Mapper.CreateMap<GetPackageItemsResponse, PackageItemViewModel>()
                .ForMember(r => r.PackageId, opt => opt.Ignore());

            // get recent packages
            Mapper.CreateMap<Package, GetRecentPackagesResponse>()
                .ForMember(r => r.Message, opt => opt.Ignore())
                .ForMember(r => r.ErrorCode, opt => opt.Ignore())
                .ForMember(r => r.MessageType, opt => opt.Ignore());
            Mapper.CreateMap<GetRecentPackagesResponse, PackageViewModel>();

            // add package
            Mapper.CreateMap<Package, AddPackageResponse>()
                .ForMember(r => r.Message, opt => opt.Ignore())
                .ForMember(r => r.ErrorCode, opt => opt.Ignore())
                .ForMember(r => r.MessageType, opt => opt.Ignore());
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