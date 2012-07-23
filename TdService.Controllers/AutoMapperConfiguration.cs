// --------------------------------------------------------------------------------------------------------------------
// <copyright file="AutoMapperConfiguration.cs" company="TdService">
//   Vitali Hatalski. 2012.
// </copyright>
// <summary>
//   The auto mapper configuration.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace TdService
{
    using AutoMapper;

    using TdService.Model.Common;
    using TdService.Model.Orders;
    using TdService.Services.Messaging.Order;
    using TdService.Services.ViewModels.Order;

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
            Mapper.CreateMap<GetRecentOrdersResponse, OrderViewModel>();
            Mapper.CreateMap<Order, GetRecentOrdersResponse>();
            Mapper.CreateMap<AddOrderResponse, OrderViewModel>();
            Mapper.CreateMap<OrderViewModel, AddOrderRequest>();
            Mapper.CreateMap<string, Retailer>().ConvertUsing<RetailerConverter>();
            Mapper.CreateMap<AddOrderRequest, Order>();
            Mapper.CreateMap<Order, AddOrderResponse>();
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