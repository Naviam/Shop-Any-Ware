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
    using TdService.Model;
    using TdService.Resources.Views;
    using TdService.Services.Interfaces;
    using TdService.Services.Messaging.Membership;
    using TdService.UI.Web.Controllers.Base;
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
        /// <param name="membershipService">
        /// The membership service.
        /// </param>
        /// <param name="formsAuthentication">
        /// The forms authentication.
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
            var profile = this.membershipService.GetProfile(new GetProfileRequest { IdentityToken = this.FormsAuthentication.GetAuthenticationToken() });

            var allRoles = this.membershipService.GetAllRoles(new GetAllRolesRequest()).ConvertToRoleViewModelCollection();

            var userRolesResponse = this.membershipService.GetUserRoles(new GetUserRolesRequest { IdentityToken = this.FormsAuthentication.GetAuthenticationToken() }).ConvertToRoleViewModelCollection();

            var model = new AdminDashBoardViewModel
            {
                Roles = allRoles,
                MemberDashBoardUrl = ResolveServerUrl(VirtualPathUtility.ToAbsolute(Url.Action("ViewShopperDashboard", "Member")), false),
                CanModifyUserRoles = userRolesResponse.Exists(r => r.Name == StandardRole.Admin.ToString()),
                UserId = profile.Id
            };
            return this.View("Dashboard", model);
        }

        /// <summary>
        /// The get users in role.
        /// </summary>
        /// <param name="roleId">
        /// The role id.
        /// </param>
        /// <param name="pageSize">
        /// The page size.
        /// </param>
        /// <param name="pageNumber">
        /// The page number.
        /// </param>
        /// <returns>
        /// The <see cref="ActionResult"/>.
        /// </returns>
        [Authorize(Roles = "Admin, Operator")]
        [HttpPost]
        public ActionResult GetUsersInRole(int roleId, int pageSize, int pageNumber)
        {
            var request = new GetUsersInRoleRequest { RoleId = roleId, Skip = (pageNumber - 1) * pageSize, Take = pageSize };
            var response = this.membershipService.GetUsersInRole(request);
            var result = new { Users = response.Users.ConvertToUsersInRoleViewModel(), response.TotalCount };

            var jsonNetResult = new JsonNetResult
            {
                Formatting = (Formatting)Newtonsoft.Json.Formatting.Indented,
                Data = result
            };

            return jsonNetResult;
        }

        /// <summary>
        /// The get user by id.
        /// </summary>
        /// <param name="userId">
        /// The user id.
        /// </param>
        /// <returns>
        /// The <see cref="ActionResult"/>.
        /// </returns>
        [Authorize(Roles = "Admin, Operator")]
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

        /// <summary>
        /// The get user by email.
        /// </summary>
        /// <param name="email">
        /// The email.
        /// </param>
        /// <returns>
        /// The <see cref="ActionResult"/>.
        /// </returns>
        [Authorize(Roles = "Admin, Operator")]
        [HttpPost]
        public ActionResult GetUserByEmail(string email)
        {
            var request = new GetUserByEmailRequest { Email = email };
            var response = this.membershipService.GetUserByEmail(request);
            var result = response.ConvertToUsersInRoleViewModel();

            var jsonNetResult = new JsonNetResult
            {
                Formatting = (Formatting)Newtonsoft.Json.Formatting.Indented,
                Data = result
            };
            return jsonNetResult;
        }

        /// <summary>
        /// The add user to role.
        /// </summary>
        /// <param name="userId">
        /// The user id.
        /// </param>
        /// <param name="roleId">
        /// The role id.
        /// </param>
        /// <returns>
        /// The <see cref="ActionResult"/>.
        /// </returns>
        [Authorize(Roles = "Admin")]
        [HttpPost]
        public ActionResult AddUserToRole(int userId, int roleId)
        {
            var profile = this.membershipService.GetProfile(new GetProfileRequest { IdentityToken = this.FormsAuthentication.GetAuthenticationToken() });

            if (profile.Id.Equals(userId))
            {
                return this.GetWarningJsonFromResources("CantModifyOwnRole");
            }

            if (roleId.Equals(2))
            {
                return this.GetWarningJsonFromResources("ShopperRoleCannotBeAssigned");
            }

            var req = new AddUserToRoleRequest { RoleId = roleId, UserId = userId };
            var response = this.membershipService.AddUserToRole(req);

            var jsonNetResult = new JsonNetResult
            {
                Formatting = (Formatting)Newtonsoft.Json.Formatting.Indented,
                Data = new { response.Message, MessageType = response.MessageType.ToString() }
            };
            return jsonNetResult;
        }

        /// <summary>
        /// The remove user from role.
        /// </summary>
        /// <param name="userId">
        /// The user id.
        /// </param>
        /// <param name="roleId">
        /// The role id.
        /// </param>
        /// <returns>
        /// The <see cref="ActionResult"/>.
        /// </returns>
        [Authorize(Roles = "Admin")]
        [HttpPost]
        public ActionResult RemoveUserFromRole(int userId, int roleId)
        {
            var profile = this.membershipService.GetProfile(new GetProfileRequest { IdentityToken = this.FormsAuthentication.GetAuthenticationToken() });
            if (profile.Id.Equals(userId))
            {
                return this.GetWarningJsonFromResources("CantModifyOwnRole");
            }

            if (roleId.Equals(2))
            {
                return this.GetWarningJsonFromResources("ShopperRoleCannotBeAssigned");
            }

            var req = new RemoveUserFromRoleRequest { RoleId = roleId, UserId = userId };
            var response = this.membershipService.RemoveUserFromRole(req);

            var jsonNetResult = new JsonNetResult
            {
                Formatting = (Formatting)Newtonsoft.Json.Formatting.Indented,
                Data = new { response.Message, MessageType = response.MessageType.ToString() }
            };
            return jsonNetResult;
        }

        /// <summary>
        /// The create new user.
        /// </summary>
        /// <param name="model">
        /// The model.
        /// </param>
        /// <returns>
        /// The <see cref="ActionResult"/>.
        /// </returns>
        [Authorize(Roles = "Admin")]
        [HttpPost]
        public ActionResult CreateNewUser(NewAdminUser model)
        {
            var response =
                this.membershipService.SignUpAdmin(
                    new SignUpAdminRequest
                        {
                            AdminRole = model.IsAdmin,
                            Email = model.Email,
                            FirstName = model.FirstName,
                            LastName = model.LastName,
                            OperatorRole = model.IsOperator,
                            Password = model.Password
                        });

            var jsonNetResult = new JsonNetResult
            {
                Formatting = (Formatting)Newtonsoft.Json.Formatting.Indented,
                Data = new { response.Message, MessageType = response.MessageType.ToString(), response.BrokenRules }
            };

            return jsonNetResult;
        }

        /// <summary>
        /// The resolve server url.
        /// </summary>
        /// <param name="serverUrl">
        /// The server url.
        /// </param>
        /// <param name="forceHttps">
        /// The force https.
        /// </param>
        /// <returns>
        /// The <see cref="string"/>.
        /// </returns>
        private static string ResolveServerUrl(string serverUrl, bool forceHttps)
        {
            if (serverUrl.IndexOf("://", StringComparison.Ordinal) > -1)
            {
                return serverUrl;
            }

            var newUrl = serverUrl;
            var originalUri = System.Web.HttpContext.Current.Request.Url;
            newUrl = (forceHttps ? "https" : originalUri.Scheme) +
                "://" + originalUri.Authority + newUrl;
            return newUrl;
        }

        /// <summary>
        /// The get warning JSON from resources.
        /// </summary>
        /// <param name="key">
        /// The key.
        /// </param>
        /// <returns>
        /// The <see cref="JsonNetResult"/>.
        /// </returns>
        private JsonNetResult GetWarningJsonFromResources(string key)
        {
            return new JsonNetResult
            {
                Formatting = (Formatting)Newtonsoft.Json.Formatting.Indented,
                Data = new { Message = AdminDashboardResources.ResourceManager.GetString(key), MessageType = "Warning" }
            };
        }
    }
}