namespace TdService.UI.Web.Mapping
{
    using System.Collections.Generic;
    using AutoMapper;
    using TdService.Services.Messaging.Membership;
    using TdService.UI.Web.ViewModels.Admin;
    using UserResponseModel = TdService.Services.Messaging.Membership.GetUsersInRoleResponse.UserResponseModel;
    public static class UsersViewModelMapper
    {
        public static List<UsersInRoleViewModel> ConvertToUsersInRoleViewModel(this List<UserResponseModel> response)
        {
            return Mapper.Map<List<UserResponseModel>, List<UsersInRoleViewModel>>(response);
        }

        public static UsersInRoleViewModel ConvertToUsersInRoleViewModel(this GetUserByIdResponse response)
        {
            return Mapper.Map<GetUserByIdResponse, UsersInRoleViewModel>(response);
        }
    }
}
