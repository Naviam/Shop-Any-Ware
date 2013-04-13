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
    // ReSharper disable AccessToStaticMemberViaDerivedType
        // ReSharper restore AccessToStaticMemberViaDerivedType
        // ReSharper restore AccessToStaticMemberViaDerivedType
        // ReSharper restore AccessToStaticMemberViaDerivedType
    using System.Collections.Generic;
    using System.Linq;

    using AutoMapper;

    using TdService.Model.Addresses;
    using TdService.Model.Balance;
    using TdService.Model.Common;
    using TdService.Model.Items;
    using TdService.Model.Membership;
    using TdService.Model.Orders;
    using TdService.Model.Packages;
    using TdService.Services.Messaging.Address;
    using TdService.Services.Messaging.Item;
    using TdService.Services.Messaging.Item.Base;
    using TdService.Services.Messaging.Membership;
    using TdService.Services.Messaging.Order;
    using TdService.Services.Messaging.Package;
    using TdService.Services.Messaging.Retailer;
    using TdService.Services.Messaging.Transactions;
    using TdService.UI.Web.ViewModels.Account;
    using TdService.UI.Web.ViewModels.Admin;
    using TdService.UI.Web.ViewModels.Ballance;
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
                .ForMember(r => r.BrokenRules, opt => opt.Ignore())
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
                .ForMember(r => r.BrokenRules, opt => opt.Ignore())
                .ForMember(r => r.Message, opt => opt.Ignore())
                .ForMember(r => r.ErrorCode, opt => opt.Ignore())
                .ForMember(r => r.MessageType, opt => opt.Ignore());
            Mapper.CreateMap<GetUserRolesResponse, RoleViewModel>();

            Mapper.CreateMap<Role, GetAllRolesResponse>()
                .ForMember(r => r.BrokenRules, opt => opt.Ignore())
                .ForMember(r => r.Message, opt => opt.Ignore())
                .ForMember(r => r.ErrorCode, opt => opt.Ignore())
                .ForMember(r => r.MessageType, opt => opt.Ignore());
            Mapper.CreateMap<GetAllRolesResponse, RoleViewModel>();

            // profile
            Mapper.CreateMap<User, GetProfileResponse>()
                .ForMember(resp => resp.Balance, opt => opt.MapFrom(source => source.Wallet.Amount))
                .ForMember(resp => resp.WalletId, opt => opt.MapFrom(source => source.Wallet.Id))
                .ForMember(resp => resp.Id, opt => opt.MapFrom(source => source.Profile.Id))
                .ForMember(resp => resp.LastName, opt => opt.MapFrom(source => source.Profile.LastName))
                .ForMember(resp => resp.FirstName, opt => opt.MapFrom(source => source.Profile.FirstName))
                .ForMember(resp => resp.NotifyOnOrderStatusChanged, opt => opt.MapFrom(source => source.Profile.NotifyOnOrderStatusChanged))
                .ForMember(resp => resp.NotifyOnPackageStatusChanged, opt => opt.MapFrom(source => source.Profile.NotifyOnPackageStatusChanged))
                .ForMember(r => r.Message, opt => opt.Ignore()).ForMember(r => r.ErrorCode, opt => opt.Ignore()).ForMember(
                    r => r.BrokenRules, opt => opt.Ignore()).ForMember(r => r.MessageType, opt => opt.Ignore());
            
            Mapper.CreateMap<ProfileViewModel, UpdateProfileRequest>()
                .ForMember(m => m.IdentityToken, opt => opt.Ignore());
            Mapper.CreateMap<UpdateProfileResponse, ProfileViewModel>()
                .ForMember(m => m.Email, opt => opt.Ignore());
            Mapper.CreateMap<UpdateProfileRequest, Model.Membership.Profile>()
                .ForMember(m => m.RowVersion, opt => opt.Ignore());
            Mapper.CreateMap<Model.Membership.Profile, UpdateProfileResponse>()
                .ForMember(r => r.BrokenRules, opt => opt.Ignore())
                .ForMember(r => r.Message, opt => opt.Ignore())
                .ForMember(r => r.ErrorCode, opt => opt.Ignore())
                .ForMember(r => r.MessageType, opt => opt.Ignore());
            Mapper.CreateMap<GetProfileResponse, ProfileViewModel>()
                .ForMember(m => m.Email, opt => opt.Ignore());

            // delivery address
            Mapper.CreateMap<DeliveryAddress, GetDeliveryAddressesResponse>()
                .ForMember(r => r.CountryNameTranslated, opt => opt.MapFrom(da => da.Country.TranslatedName))
                .ForMember(r => r.Message, opt => opt.Ignore())
                .ForMember(r => r.BrokenRules, opt => opt.Ignore())
                .ForMember(r => r.ErrorCode, opt => opt.Ignore())
                .ForMember(r => r.MessageType, opt => opt.Ignore());
            Mapper.CreateMap<GetDeliveryAddressesResponse, DeliveryAddressViewModel>();
            Mapper.CreateMap<AddOrUpdateDeliveryAddressResponse, DeliveryAddressViewModel>();
            Mapper.CreateMap<DeliveryAddressViewModel, AddOrUpdateDeliveryAddressRequest>()
                .ForMember(r => r.IdentityToken, opt => opt.Ignore());
            Mapper.CreateMap<AddOrUpdateDeliveryAddressRequest, DeliveryAddress>()
                .ForMember(m => m.RowVersion, opt => opt.Ignore());
            Mapper.CreateMap<DeliveryAddress, AddOrUpdateDeliveryAddressResponse>()
                  .ForMember(r => r.CountryNameTranslated, opt => opt.MapFrom(da => da.Country.TranslatedName))
                  .ForMember(r => r.Message, opt => opt.Ignore())
                  .ForMember(r => r.BrokenRules, opt => opt.Ignore())
                  .ForMember(r => r.ErrorCode, opt => opt.Ignore())
                  .ForMember(r => r.MessageType, opt => opt.Ignore());
            Mapper.CreateMap<RemoveDeliveryRequestResponse, DeliveryAddressViewModel>()
                .ForMember(r => r.FirstName, opt => opt.Ignore())
                .ForMember(r => r.LastName, opt => opt.Ignore())
                .ForMember(r => r.ZipCode, opt => opt.Ignore())
                .ForMember(r => r.CountryId, opt => opt.Ignore())
                .ForMember(r => r.Region, opt => opt.Ignore())
                .ForMember(r => r.State, opt => opt.Ignore())
                .ForMember(r => r.City, opt => opt.Ignore())
                .ForMember(r => r.Phone, opt => opt.Ignore())
                .ForMember(r => r.AddressName, opt => opt.Ignore())
                .ForMember(r => r.AddressLine1, opt => opt.Ignore())
                .ForMember(r => r.AddressLine2, opt => opt.Ignore())
                .ForMember(r => r.AddressLine3, opt => opt.Ignore());

            // get my recent orders
            Mapper.CreateMap<GetMyOrdersResponse, OrderViewModel>();
            Mapper.CreateMap<GetAllOrdersResponse, OrderViewModel>();
            Mapper.CreateMap<Order, GetMyOrdersResponse>()
                .ForMember(r => r.BrokenRules, opt => opt.Ignore())
                .ForMember(r => r.Message, opt => opt.Ignore())
                .ForMember(r => r.ErrorCode, opt => opt.Ignore())
                .ForMember(r => r.MessageType, opt => opt.Ignore());
            Mapper.CreateMap<Order, GetAllOrdersResponse>()
                .ForMember(r => r.BrokenRules, opt => opt.Ignore())
                .ForMember(r => r.Message, opt => opt.Ignore())
                .ForMember(r => r.ErrorCode, opt => opt.Ignore())
                .ForMember(r => r.MessageType, opt => opt.Ignore());

            // get my history orders

            // add order
            Mapper.CreateMap<AddOrderResponse, OrderViewModel>()
                .ForMember(o => o.ReturnedDate, opt => opt.Ignore());
            Mapper.CreateMap<OrderViewModel, AddOrderRequest>()
                .ForMember(m => m.IdentityToken, opt => opt.Ignore());
            Mapper.CreateMap<Order, AddOrderResponse>()
                .ForMember(r => r.BrokenRules, opt => opt.Ignore())
                .ForMember(r => r.Message, opt => opt.Ignore())
                .ForMember(r => r.ErrorCode, opt => opt.Ignore())
                .ForMember(r => r.MessageType, opt => opt.Ignore());

            // update order
            Mapper.CreateMap<OrderViewModel, UpdateOrderRequest>()
                .ForMember(m => m.IdentityToken, opt => opt.Ignore());
            Mapper.CreateMap<UpdateOrderResponse, OrderViewModel>()
                .ForMember(r => r.CanBeReceived, opt => opt.Ignore())
                .ForMember(r => r.ReturnedDate, opt => opt.Ignore())
                .ForMember(r => r.CreatedDate, opt => opt.Ignore())
                .ForMember(r => r.ReceivedDate, opt => opt.Ignore())
                .ForMember(r => r.CanBeModified, opt => opt.Ignore())
                .ForMember(r => r.CanBeRemoved, opt => opt.Ignore())
                .ForMember(r => r.CanBeRequestedForReturn, opt => opt.Ignore())
                .ForMember(r => r.CanItemsBeModified, opt => opt.Ignore());
            Mapper.CreateMap<Order, UpdateOrderResponse>()
                .ForMember(r => r.BrokenRules, opt => opt.Ignore())
                .ForMember(r => r.Message, opt => opt.Ignore())
                .ForMember(r => r.ErrorCode, opt => opt.Ignore())
                .ForMember(r => r.MessageType, opt => opt.Ignore());

            // remove order
            Mapper.CreateMap<Order, RemoveOrderResponse>()
                .ForMember(r => r.BrokenRules, opt => opt.Ignore())
                .ForMember(r => r.Message, opt => opt.Ignore())
                .ForMember(r => r.ErrorCode, opt => opt.Ignore())
                .ForMember(r => r.MessageType, opt => opt.Ignore());
            Mapper.CreateMap<RemoveOrderResponse, OrderViewModel>()
                .ForMember(r => r.RetailerUrl, opt => opt.Ignore())
                .ForMember(r => r.OrderNumber, opt => opt.Ignore())
                .ForMember(r => r.TrackingNumber, opt => opt.Ignore())
                .ForMember(r => r.CreatedDate, opt => opt.Ignore())
                .ForMember(r => r.ReceivedDate, opt => opt.Ignore())
                .ForMember(r => r.ReturnedDate, opt => opt.Ignore())
                .ForMember(r => r.Status, opt => opt.Ignore())
                .ForMember(r => r.CanBeReceived, opt => opt.Ignore())
                .ForMember(r => r.CanBeModified, opt => opt.Ignore())
                .ForMember(r => r.CanBeRemoved, opt => opt.Ignore())
                .ForMember(r => r.CanBeRequestedForReturn, opt => opt.Ignore())
                .ForMember(r => r.CanItemsBeModified, opt => opt.Ignore());

            // order received
            Mapper.CreateMap<OrderReceivedResponse, OrderViewModel>();
            Mapper.CreateMap<Order, OrderReceivedResponse>()
                .ForMember(r => r.BrokenRules, opt => opt.Ignore())
                .ForMember(r => r.Message, opt => opt.Ignore())
                .ForMember(r => r.ErrorCode, opt => opt.Ignore())
                .ForMember(r => r.MessageType, opt => opt.Ignore());

            // retailer
            Mapper.CreateMap<string, Retailer>().ConvertUsing<RetailerConverter>();
            Mapper.CreateMap<Retailer, GetRetailersResponse>()
                .ForMember(r => r.BrokenRules, opt => opt.Ignore())
                .ForMember(r => r.Message, opt => opt.Ignore())
                .ForMember(r => r.ErrorCode, opt => opt.Ignore())
                .ForMember(r => r.MessageType, opt => opt.Ignore());
            Mapper.CreateMap<GetRetailersResponse, RetailerViewModel>();

            // items global
            Mapper.CreateMap<Item, ItemResponse>()
                .ForMember(r => r.BrokenRules, opt => opt.Ignore())
                .ForMember(r => r.Message, opt => opt.Ignore())
                .ForMember(r => r.ErrorCode, opt => opt.Ignore())
                .ForMember(r => r.MessageType, opt => opt.Ignore());
            Mapper.CreateMap<ItemResponse, ItemViewModel>()
                 .ForMember(r => r.BrokenRules, opt => opt.Ignore())
                .ForMember(r => r.Message, opt => opt.Ignore())
                .ForMember(r => r.ErrorCode, opt => opt.Ignore())
                .ForMember(r => r.MessageType, opt => opt.Ignore());

            // add order item
            Mapper.CreateMap<OrderItemViewModel, AddItemToOrderRequest>()
                .ForMember(dest => dest.IdentityToken, opt => opt.Ignore()); 
            Mapper.CreateMap<AddItemToOrderRequest, Item>()
                .ForMember(r => r.Id, opt => opt.Ignore())
                .ForMember(r => r.Images, opt => opt.Ignore())
                .ForMember(r => r.Package, opt => opt.Ignore())
                .ForMember(r => r.PackageId, opt => opt.Ignore())
                .ForMember(r => r.Order, opt => opt.Ignore())
                .ForMember(r => r.OrderId, opt => opt.Ignore())
                .ForMember(r => r.Weight, opt => opt.ResolveUsing<WeightResolver>())
                .ForMember(r => r.Dimensions, opt => opt.ResolveUsing<DimensionsResolver>());
            Mapper.CreateMap<Item, AddItemToOrderResponse>()
                .ForMember(r => r.OrderId, opt => opt.Ignore())
                .ForMember(r => r.BrokenRules, opt => opt.Ignore())
                .ForMember(r => r.Message, opt => opt.Ignore())
                .ForMember(r => r.ErrorCode, opt => opt.Ignore())
                .ForMember(r => r.MessageType, opt => opt.Ignore());
            Mapper.CreateMap<AddItemToOrderResponse, OrderItemViewModel>()
                .ForMember(dest => dest.OperatorMode, opt => opt.Ignore());

            // edit order item
            Mapper.CreateMap<Item, EditOrderItemResponse>()
                .ForMember(r => r.Message, opt => opt.Ignore())
                .ForMember(r => r.ErrorCode, opt => opt.Ignore())
                .ForMember(r => r.MessageType, opt => opt.Ignore());
            Mapper.CreateMap<OrderItemViewModel, EditOrderItemRequest>()
                .ForMember(dest => dest.IdentityToken, opt => opt.Ignore()); 
            Mapper.CreateMap<EditOrderItemResponse, OrderItemViewModel>()
                .ForMember(dest => dest.OperatorMode, opt => opt.Ignore()); 

            // edit package item
            Mapper.CreateMap<Item, EditPackageItemResponse>()
                .ForMember(r => r.Message, opt => opt.Ignore())
                .ForMember(r => r.ErrorCode, opt => opt.Ignore())
                .ForMember(r => r.MessageType, opt => opt.Ignore());
            Mapper.CreateMap<PackageItemViewModel, EditPackageItemRequest>()
                .ForMember(dest => dest.OrderId, opt => opt.Ignore())
                .ForMember(dest => dest.IdentityToken, opt => opt.Ignore());
            Mapper.CreateMap<EditPackageItemResponse, PackageItemViewModel>()
                .ForMember(dest => dest.OperatorMode, opt => opt.Ignore()); 

            // remove order item
            Mapper.CreateMap<OrderItemViewModel, RemoveItemRequest>()
                .ForMember(r => r.IdentityToken, opt => opt.Ignore());
            Mapper.CreateMap<Item, RemoveItemResponse>()
                .ForMember(r => r.OrderId, opt => opt.Ignore())
                .ForMember(r => r.Message, opt => opt.Ignore())
                .ForMember(r => r.ErrorCode, opt => opt.Ignore())
                .ForMember(r => r.MessageType, opt => opt.Ignore());
            Mapper.CreateMap<RemoveItemResponse, OrderItemViewModel>()
                .ForMember(dest => dest.Images, opt => opt.Ignore())
                .ForMember(dest => dest.OperatorMode, opt => opt.Ignore());

            // get order items
            Mapper.CreateMap<Item, GetOrderItemsResponse>()
                .ForMember(r => r.BrokenRules, opt => opt.Ignore())
                .ForMember(r => r.Message, opt => opt.Ignore())
                .ForMember(r => r.ErrorCode, opt => opt.Ignore())
                .ForMember(r => r.MessageType, opt => opt.Ignore());
            Mapper.CreateMap<GetOrderItemsResponse, OrderItemViewModel>().ForMember(r => r.OrderId, opt => opt.Ignore())
                .ForMember(dest => dest.OperatorMode, opt => opt.Ignore());

            // item images
            Mapper.CreateMap<ItemImage, ItemImageResponse>();
            Mapper.CreateMap<ItemImageResponse, ItemImageViewModel>()
                .ForMember(r => r.BrokenRules, opt => opt.Ignore())
                .ForMember(r => r.Message, opt => opt.Ignore())
                .ForMember(r => r.ErrorCode, opt => opt.Ignore())
                .ForMember(r => r.MessageType, opt => opt.Ignore())
                .ForMember(r => r.ItemId, opt => opt.Ignore());
            Mapper.CreateMap<AddItemImageResponse, ItemImageViewModel>();

            // add item to package
            
            // get package items
            Mapper.CreateMap<List<Item>, GetPackageItemsResponse>()
                .ForMember(dest => dest.Items, opt => opt.MapFrom(src => src))
                .ForMember(r => r.BrokenRules, opt => opt.Ignore())
                .ForMember(r => r.Message, opt => opt.Ignore())
                .ForMember(r => r.ErrorCode, opt => opt.Ignore())
                .ForMember(r => r.MessageType, opt => opt.Ignore());
            Mapper.CreateMap<GetPackageItemsResponse, PackageItemsViewModel>()
                .ForMember(r => r.OrderId, opt => opt.Ignore())
                .ForMember(r => r.PackageId, opt => opt.Ignore());

            // move package items to existing package
            Mapper.CreateMap<List<Item>, MoveOrderItemsToExistingPackageResponse>()
                .ForMember(dest => dest.Items, opt => opt.MapFrom(src => src))
                .ForMember(r => r.OrderId, opt => opt.Ignore())
                .ForMember(r => r.BrokenRules, opt => opt.Ignore())
                .ForMember(r => r.Message, opt => opt.Ignore())
                .ForMember(r => r.ErrorCode, opt => opt.Ignore())
                .ForMember(r => r.MessageType, opt => opt.Ignore())
                .ForMember(r => r.PackageId, opt => opt.Ignore());
            Mapper.CreateMap<MoveOrderItemsToExistingPackageResponse, PackageItemsViewModel>();

            // move package items to new package
            Mapper.CreateMap<List<Item>, MoveOrderItemsToNewPackageResponse>()
                .ForMember(dest => dest.Items, opt => opt.MapFrom(src => src))
                .ForMember(r => r.OrderId, opt => opt.Ignore())
                .ForMember(r => r.BrokenRules, opt => opt.Ignore())
                .ForMember(r => r.Message, opt => opt.Ignore())
                .ForMember(r => r.ErrorCode, opt => opt.Ignore())
                .ForMember(r => r.MessageType, opt => opt.Ignore())
                .ForMember(r => r.PackageId, opt => opt.Ignore());
            Mapper.CreateMap<MoveOrderItemsToNewPackageResponse, PackageItemsViewModel>();

            // move package items to original order
            Mapper.CreateMap<List<Item>, MoveOrderItemsToOriginalOrderResponse>()
                .ForMember(dest => dest.Items, opt => opt.MapFrom(src => src))
                .ForMember(r => r.BrokenRules, opt => opt.Ignore())
                .ForMember(r => r.Message, opt => opt.Ignore())
                .ForMember(r => r.ErrorCode, opt => opt.Ignore())
                .ForMember(r => r.MessageType, opt => opt.Ignore())
                .ForMember(r => r.PackageId, opt => opt.Ignore());
            Mapper.CreateMap<MoveOrderItemsToOriginalOrderResponse, PackageItemsViewModel>()
                .ForMember(r => r.OrderId, opt => opt.Ignore());

            // move single package item to original order
            Mapper.CreateMap<Item, MoveItemBackToOriginalOrderResponse>()
                .ForMember(dest => dest.Item, opt => opt.MapFrom(src => src))
                .ForMember(r => r.BrokenRules, opt => opt.Ignore())
                .ForMember(r => r.Message, opt => opt.Ignore())
                .ForMember(r => r.ErrorCode, opt => opt.Ignore())
                .ForMember(r => r.MessageType, opt => opt.Ignore())
                .ForMember(r => r.OrderId, opt => opt.Ignore())
                .ForMember(r => r.PackageId, opt => opt.Ignore());
            Mapper.CreateMap<MoveItemBackToOriginalOrderResponse, MoveItemBackToOriginalOrderViewModel>();

            // move single item to exist. package
            Mapper.CreateMap<Item, MoveOrderItemToExistingPackageResponse>()
                .ForMember(dest => dest.Item, opt => opt.MapFrom(src => src))
                .ForMember(r => r.BrokenRules, opt => opt.Ignore())
                .ForMember(r => r.Message, opt => opt.Ignore())
                .ForMember(r => r.ErrorCode, opt => opt.Ignore())
                .ForMember(r => r.MessageType, opt => opt.Ignore())
                .ForMember(r => r.OrderId, opt => opt.Ignore())
                .ForMember(r => r.PackageId, opt => opt.Ignore());
            Mapper.CreateMap<MoveOrderItemToExistingPackageResponse, MoveOrderItemToExistingPackageViewModel>();

            // get recent packages
            Mapper.CreateMap<Package, GetRecentPackagesResponse>()
                .ForMember(r => r.BrokenRules, opt => opt.Ignore())
                .ForMember(r => r.Message, opt => opt.Ignore())
                .ForMember(r => r.ErrorCode, opt => opt.Ignore())
                .ForMember(r => r.MessageType, opt => opt.Ignore())
                .ForMember(r => r.Country, opt => opt.MapFrom(p => p.DeliveryAddress.Country));
            Mapper.CreateMap<GetRecentPackagesResponse, PackageViewModel>();

            // add package
            Mapper.CreateMap<Package, AddPackageResponse>()
                .ForMember(r => r.BrokenRules, opt => opt.Ignore())
                .ForMember(r => r.Message, opt => opt.Ignore())
                .ForMember(r => r.ErrorCode, opt => opt.Ignore())
                .ForMember(r => r.MessageType, opt => opt.Ignore());
            Mapper.CreateMap<AddPackageResponse, PackageViewModel>();

            // assemble package
            Mapper.CreateMap<Package, AssemblePackageResponse>()
                .ForMember(r => r.BrokenRules, opt => opt.Ignore())
                .ForMember(r => r.Message, opt => opt.Ignore())
                .ForMember(r => r.ErrorCode, opt => opt.Ignore())
                .ForMember(r => r.MessageType, opt => opt.Ignore());
            Mapper.CreateMap<AssemblePackageResponse, PackageViewModel>();

            // package assembled
            Mapper.CreateMap<Package, PackageAssembledResponse>()
                .ForMember(r => r.BrokenRules, opt => opt.Ignore())
                .ForMember(r => r.Message, opt => opt.Ignore())
                .ForMember(r => r.ErrorCode, opt => opt.Ignore())
                .ForMember(r => r.MessageType, opt => opt.Ignore());
            Mapper.CreateMap<PackageAssembledResponse, PackageViewModel>();

            // pay for package 
            Mapper.CreateMap<Package, PayForPackageResponse>()
                .ForMember(r => r.BrokenRules, opt => opt.Ignore())
                .ForMember(r => r.Message, opt => opt.Ignore())
                .ForMember(r => r.ErrorCode, opt => opt.Ignore())
                .ForMember(r => r.MessageType, opt => opt.Ignore());
            Mapper.CreateMap<PayForPackageResponse, PayForPackageViewModel>();

            // send package
            Mapper.CreateMap<Package, SendPackageResponse>()
                .ForMember(r => r.BrokenRules, opt => opt.Ignore())
                .ForMember(r => r.Message, opt => opt.Ignore())
                .ForMember(r => r.ErrorCode, opt => opt.Ignore())
                .ForMember(r => r.MessageType, opt => opt.Ignore());
            Mapper.CreateMap<SendPackageResponse, PackageViewModel>();

            // get transactions
            Mapper.CreateMap<Transaction, GetTransactionsResponse>()
                .ForMember(dest => dest.Currency, opt => opt.MapFrom(src => src.Currency.AlphabeticCode))
                .ForMember(r => r.BrokenRules, opt => opt.Ignore())
                .ForMember(r => r.Message, opt => opt.Ignore())
                .ForMember(r => r.ErrorCode, opt => opt.Ignore())
                .ForMember(r => r.MessageType, opt => opt.Ignore());
            Mapper.CreateMap<GetTransactionsResponse, TransactionsViewModel>()
                .ForMember(r => r.OperationTypeTranslated, opt => opt.Ignore()); 

            // add transaction
            Mapper.CreateMap<AddTransactionResponse, TransactionsViewModel>();
            Mapper.CreateMap<TransactionsViewModel, AddTransactionRequest>()
                .ForMember(r => r.IdentityToken, opt => opt.Ignore())
                .ForMember(r => r.Token, opt => opt.Ignore());
            Mapper.CreateMap<Transaction, AddTransactionResponse>()
                .ForMember(r => r.BrokenRules, opt => opt.Ignore())
                .ForMember(r => r.Message, opt => opt.Ignore())
                .ForMember(r => r.ErrorCode, opt => opt.Ignore())
                .ForMember(r => r.MessageType, opt => opt.Ignore())
                .ForMember(r => r.PayPalRedirectUrl, opt => opt.Ignore());
            Mapper.CreateMap<AddTransactionRequest, Transaction>()
                .ForMember(r => r.Id, opt => opt.Ignore())
                .ForMember(r => r.Currency, opt => opt.Ignore())
                .ForMember(r => r.PayerId, opt => opt.Ignore())
                .ForMember(r => r.Commission, opt => opt.Ignore());

            // admin dashboard
            Mapper.CreateMap<User, UserResponse>().ConvertUsing<UsersInRoleConverter>();
            Mapper.CreateMap<User, GetUserByIdResponse>().ConvertUsing<GetUserByIdConverter>();
            Mapper.CreateMap<User, GetUserByEmailResponse>().ConvertUsing<GetUserByEmailConverter>();
            Mapper.CreateMap<UserResponse, UsersInRoleViewModel>()
                .ForMember(r => r.BrokenRules, opt => opt.Ignore())
                .ForMember(r => r.Message, opt => opt.Ignore())
                .ForMember(r => r.ErrorCode, opt => opt.Ignore())
                .ForMember(r => r.MessageType, opt => opt.Ignore()); 
            Mapper.CreateMap<GetUserByIdResponse, UsersInRoleViewModel>();
            Mapper.CreateMap<GetUserByEmailResponse, UsersInRoleViewModel>();

            // get users' packages
            Mapper.CreateMap<Package, UserPackageResponse>().ConvertUsing<UserPackageConverter>();
            Mapper.CreateMap<GetUsersPackagesResponse, UsersPackagesViewModel>()
                .ForMember(r => r.BrokenRules, opt => opt.Ignore())
                .ForMember(r => r.Message, opt => opt.Ignore())
                .ForMember(r => r.ErrorCode, opt => opt.Ignore())
                .ForMember(r => r.MessageType, opt => opt.Ignore());
            Mapper.CreateMap<UserPackageResponse, UserPackageViewModel>();

            // update package total size
            Mapper.CreateMap<PackageSizePopupViewModel, UpdatePackageTotalSizeRequest>()
                .ForMember(r => r.IdentityToken, opt => opt.Ignore());
            Mapper.CreateMap<UpdatePackageTotalSizeResponse, PackageViewModel>();
            Mapper.CreateMap<Package, UpdatePackageTotalSizeResponse>()
                .ForMember(r => r.Country, opt => opt.MapFrom(p => p.DeliveryAddress.Country)); 

            // countries
            Mapper.CreateMap<GetCountriesResponse, CountryViewModel>();
            Mapper.CreateMap<Country, GetCountriesResponse>();
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

        /// <summary>
        /// The user package converter.
        /// </summary>
        public class UserPackageConverter : ITypeConverter<Package, UserPackageResponse>
        {
            /// <summary>
            /// The convert.
            /// </summary>
            /// <param name="context">
            /// The context.
            /// </param>
            /// <returns>
            /// The <see cref="UserPackageResponse"/>.
            /// </returns>
            public UserPackageResponse Convert(ResolutionContext context)
            {
                var package = context.SourceValue as Package;
                if (package == null)
                {
                    return null;
                }

                var converted = new UserPackageResponse
                                    {
                                        UserId = package.UserId,
                                        Email = package.User.Email,
                                        Status = package.StatusTranslated,
                                        PackageId = package.Id,
                                        ItemsCount = package.Items.Count,
                                        DispatchMethod = package.DispatchMethod.ToString(),
                                        PackageName = package.Name
                                    };
                return converted;
            }
        }

        /// <summary>
        /// Type converter User->GetUsersInRoleResponse
        /// </summary>
        public class UsersInRoleConverter : ITypeConverter<User, UserResponse>
        {
            /// <summary>
            /// The convert.
            /// </summary>
            /// <param name="context">
            /// The context.
            /// </param>
            /// <returns>
            /// The <see cref="UserResponse"/>.
            /// </returns>
            public UserResponse Convert(ResolutionContext context)
            {
                var user = context.SourceValue as User;
                if (user != null)
                {
                    var converted = new UserResponse
                                        {
                                            Email = user.Email,
                                            FullName = string.Concat(user.Profile.FirstName, " ", user.Profile.LastName),
                                            Id = user.Id,
                                            LastAccessDate = user.LastAccessDate,
                                            OrdersCount = user.Orders.Count,
                                            PackagesCount = user.Packages.Count,
                                            Roles = user.Roles.Select(r => r.Id).ToList()
                                        };
                    return converted;
                }

                return null;
            }
        }

        /// <summary>
        /// Type converter User->GetUsersInRoleResponse
        /// </summary>
        public class GetUserByIdConverter : ITypeConverter<User, GetUserByIdResponse>
        {
            /// <summary>
            /// The convert.
            /// </summary>
            /// <param name="context">
            /// The context.
            /// </param>
            /// <returns>
            /// The <see cref="GetUserByIdResponse"/>.
            /// </returns>
            public GetUserByIdResponse Convert(ResolutionContext context)
            {
                var user = context.SourceValue as User;
                if (user != null)
                {
                    var converted = new GetUserByIdResponse
                                        {
                                            Email = user.Email,
                                            FullName = string.Concat(user.Profile.FirstName, " ", user.Profile.LastName),
                                            Id = user.Id,
                                            LastAccessDate = user.LastAccessDate,
                                            OrdersCount = user.Orders.Count,
                                            PackagesCount = user.Packages.Count,
                                            Roles = user.Roles.Select(r => r.Id).ToList()
                                        };
                    return converted;
                }

                return null;
            }
        }

        /// <summary>
        /// Type converter User->GetUsersInRoleResponse
        /// </summary>
        public class GetUserByEmailConverter : ITypeConverter<User, GetUserByEmailResponse>
        {
            /// <summary>
            /// The convert.
            /// </summary>
            /// <param name="context">
            /// The context.
            /// </param>
            /// <returns>
            /// The <see cref="GetUserByEmailResponse"/>.
            /// </returns>
            public GetUserByEmailResponse Convert(ResolutionContext context)
            {
                var user = context.SourceValue as User;
                if (user != null)
                {
                    var converted = new GetUserByEmailResponse
                                        {
                                            Email = user.Email,
                                            FullName = string.Concat(user.Profile.FirstName, " ", user.Profile.LastName),
                                            Id = user.Id,
                                            LastAccessDate = user.LastAccessDate,
                                            OrdersCount = user.Orders.Count,
                                            PackagesCount = user.Packages.Count,
                                            Roles = user.Roles.Select(r => r.Id).ToList()
                                        };
                    return converted;
                }

                return null;
            }
        }

        /// <summary>
        /// The dimensions resolver.
        /// </summary>
        public class DimensionsResolver : ValueResolver<AddItemToOrderRequest, Dimensions>
        {
            /// <summary>
            /// The resolve core.
            /// </summary>
            /// <param name="source">
            /// The source.
            /// </param>
            /// <returns>
            /// The <see cref="Dimensions"/>.
            /// </returns>
            protected override Dimensions ResolveCore(AddItemToOrderRequest source)
            {
                return new Dimensions
                    {
                        Girth = source.DimensionsGirth,
                        Height = source.DimensionsHeight,
                        Length = source.DimensionsLength,
                        Width = source.DimensionsWidth
                    };
            }
        }

        /// <summary>
        /// The weight resolver.
        /// </summary>
        public class WeightResolver : ValueResolver<AddItemToOrderRequest, Weight>
        {
            /// <summary>
            /// The resolve core.
            /// </summary>
            /// <param name="source">
            /// The source.
            /// </param>
            /// <returns>
            /// The <see cref="Weight"/>.
            /// </returns>
            protected override Weight ResolveCore(AddItemToOrderRequest source)
            {
                return new Weight
                           {
                               Pounds = source.WeightPounds
                               ////,Ounces = source.WeightOunces
                           };
            }
        }
    }
}