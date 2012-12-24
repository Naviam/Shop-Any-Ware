namespace TdService.UI.Web.Mapping
{
    using AutoMapper;

    using TdService.Services.Messaging.Membership;
    using TdService.UI.Web.ViewModels.Admin;

    public static class UsersInRolesViewModelMapper
    {
        public static UsersInRoleViewModel ConvertToUsersInRoleViewModel(this GetUsersInRoleResponse response)
        {
            return Mapper.Map<GetUsersInRoleResponse, UsersInRoleViewModel>(response);
        }
    }
}
