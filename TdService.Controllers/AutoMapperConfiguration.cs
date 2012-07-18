namespace TdService
{
    using System.Collections.Generic;

    using AutoMapper;

    using TdService.Services.Messaging.Order;
    using TdService.Services.ViewModels.Order;

    public class AutoMapperConfiguration
    {
        public static void Configure()
        {
            Mapper.CreateMap<GetRecentOrdersResponse, OrderViewModel>();
        }
    }
}