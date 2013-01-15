// -----------------------------------------------------------------------
// <copyright file="AdminController.cs" company="TdService">
// Vitali Hatalski. 2012.
// </copyright>
// -----------------------------------------------------------------------

namespace TdService.UI.Web.Controllers
{
    using System;
    using System.Web;
    using System.Web.Mvc;
    using System.Xml;
    using TdService.Infrastructure.Authentication;
    using TdService.Services.Interfaces;
    using TdService.Services.Messaging.Membership;
    using TdService.UI.Web.Mapping;
    using TdService.UI.Web.ViewModels.Admin;

    /// <summary>
    /// This controller is responsible for administrative tasks.
    /// </summary>
    public class AdminController : BaseAuthController
    {
        /// <summary>
        /// User repository.
        /// </summary>
        private readonly IMembershipService membershipService;

        /// <summary>
        /// Initializes a new instance of the <see cref="AdminController"/> class.
        /// </summary>
        /// <param name="membershipRepository">
        /// The membership Repository.
        /// </param>
        /// <param name="formsAuthentication">
        /// The forms Authentication.
        /// </param>
        public AdminController(IMembershipService membershipService, IFormsAuthentication formsAuthentication)
            : base(formsAuthentication)
        {
            this.membershipService = membershipService;
        }

        /// <summary>
        /// Testing the new interface.
        /// </summary>
        /// <returns>
        /// Returns the page with the new interface.
        /// </returns>
        public ActionResult Dashboard()
        {
            var userRolesResponse = this.membershipService.GetUserRoles(new GetUserRolesRequest { IdentityToken = this.FormsAuthentication.GetAuthenticationToken() });
            var roles = userRolesResponse.ConvertToRoleViewModelCollection();
            var model = new AdminDashBoardViewModel { Roles = roles,
                                                      MemberDashBoardUrl = ResolveServerUrl(VirtualPathUtility.ToAbsolute(Url.Action("ViewShopperDashboard", "Member")), false)
            };
            return this.View("Dashboard", model);
        }

        /// <summary>
        /// Gets users for the  specified role
        /// </summary>
        /// <param name="roleId"></param>
        /// <returns></returns>
        [Authorize(Roles = "Admin")]
        [HttpPost]
        public ActionResult GetUsersInRole(int roleId, int pageSize, int pageNumber)
        {
            var skip = pageNumber * pageSize;
            var request = new GetUsersInRoleRequest { RoleId = roleId, Skip = (pageNumber-1) * pageSize, Take = pageSize };
            var response = this.membershipService.GetUsersInRole(request);
            var result = new { Users = response.Users.ConvertToUsersInRoleViewModel(), TotalCount = response.TotalCount };

            var jsonNetResult = new JsonNetResult
            {
                Formatting = (Formatting)Newtonsoft.Json.Formatting.Indented,
                Data = result
            };

            return jsonNetResult;
        }

        /// <summary>
        /// Gets users for the  specified role
        /// </summary>
        /// <param name="roleId"></param>
        /// <returns></returns>
        [Authorize(Roles = "Admin")]
        [HttpPost]
        public ActionResult GetUserById(int userId)
        {
            var request = new GetUserByIdRequest { UserId = userId };
            var response = this.membershipService.GetUserById(request);
            var result = response.ConvertToUsersInRoleViewModel();

            var jsonNetResult = new JsonNetResult
            {
                Formatting = (Formatting)Newtonsoft.Json.Formatting.Indented,
                Data = result
            };
            return jsonNetResult;
        }

        [Authorize(Roles = "Admin")]
        [HttpPost]
        public ActionResult AddUserToRole(int userId, int roleId)
        {
            var req = new AddUserToRoleRequest { RoleId = roleId, UserId = userId };
            var response = this.membershipService.AddUserToRole(req);

            var jsonNetResult = new JsonNetResult
            {
                Formatting = (Formatting)Newtonsoft.Json.Formatting.Indented,
                Data = new { Message = response.Message, MessageType = response.MessageType.ToString() }
            };
            return jsonNetResult;
        }

        [Authorize(Roles = "Admin")]
        [HttpPost]
        public ActionResult RemoveUserFromRole(int userId, int roleId)
        {
            var req = new RemoveUserFromRoleRequest { RoleId = roleId, UserId = userId };
            var response = this.membershipService.RemoveUserFromRole(req);

            var jsonNetResult = new JsonNetResult
            {
                Formatting = (Formatting)Newtonsoft.Json.Formatting.Indented,
                Data = new { Message = response.Message, MessageType = response.MessageType.ToString() }
            };
            return jsonNetResult;
        }

        private static string ResolveServerUrl(string serverUrl, bool forceHttps)
        {
            if (serverUrl.IndexOf("://") > -1)
                return serverUrl;

            string newUrl = serverUrl;
            Uri originalUri = System.Web.HttpContext.Current.Request.Url;
            newUrl = (forceHttps ? "https" : originalUri.Scheme) +
                "://" + originalUri.Authority + newUrl;
            return newUrl;
        }

    }
}