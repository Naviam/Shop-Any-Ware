// -----------------------------------------------------------------------
// <copyright file="MembershipService.cs" company="TdService">
// Vitali Hatalski. 2012.
// </copyright>
// -----------------------------------------------------------------------

namespace TdService.Services.Implementations
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using TdService.Infrastructure.Domain;
    using TdService.Infrastructure.Email;
    using TdService.Infrastructure.Logging;
    using TdService.Model;
    using TdService.Model.Membership;
    using TdService.Resources;
    using TdService.Services.Base;
    using TdService.Services.Interfaces;
    using TdService.Services.Mapping;
    using TdService.Services.Messaging;
    using TdService.Services.Messaging.Membership;
    using Profile = TdService.Model.Membership.Profile;

    /// <summary>
    /// Membership service class.
    /// </summary>
    public class MembershipService :ServiceBase, IMembershipService
    {
        /// <summary>
        /// Membership repository.
        /// </summary>
        private readonly IUserRepository userRepository;

        /// <summary>
        /// The role repository.
        /// </summary>
        private readonly IRoleRepository roleRepository;

        /// <summary>
        /// The profile repository.
        /// </summary>
        private readonly IProfileRepository profileRepository;

        /// <summary>
        /// The membership repository.
        /// </summary>
        private readonly IMembershipRepository membershipRepository;

        /// <summary>
        /// The email service.
        /// </summary>
        private readonly IEmailService emailService;

        /// <summary>
        /// Initializes a new instance of the <see cref="MembershipService"/> class.
        /// </summary>
        /// <param name="logger">
        /// The logger.
        /// </param>
        /// <param name="emailService">
        /// The email Service.
        /// </param>
        /// <param name="userRepository">
        /// The user repository.
        /// </param>
        /// <param name="roleRepository">
        /// The role repository.
        /// </param>
        /// <param name="profileRepository">
        /// The profile Repository.
        /// </param>
        /// <param name="membershipRepository">
        /// The membership Repository.
        /// </param>
        public MembershipService(
            ILogger logger,
            IEmailService emailService,
            IUserRepository userRepository,
            IRoleRepository roleRepository,
            IProfileRepository profileRepository,
            IMembershipRepository membershipRepository):base(logger)
        {
            this.emailService = emailService;
            this.userRepository = userRepository;
            this.roleRepository = roleRepository;
            this.profileRepository = profileRepository;
            this.membershipRepository = membershipRepository;
        }

        /// <summary>
        /// Sign up shopper.
        /// </summary>
        /// <param name="request">
        /// The request.
        /// </param>
        /// <returns>
        /// Sign up shopper response.
        /// </returns>
        public SignUpResponse SignUpShopper(SignUpRequest request)
        {
            var role = new Role { Name = StandardRole.Shopper.ToString(), Description = string.Empty };
            var user = new User
                {
                    Email = request.Email,
                    Password = request.Password,
                    Profile =
                        new Profile
                            {
                                FirstName = request.FirstName,
                                LastName = request.LastName,
                                NotifyOnOrderStatusChanged = true,
                                NotifyOnPackageStatusChanged = true
                            },
                    ActivationCode = Guid.NewGuid()
                };
            var response = new SignUpResponse { BrokenRules = user.Profile.GetBrokenRules().ToList() };
            response.BrokenRules.AddRange(role.GetBrokenRules());
            response.BrokenRules.AddRange(user.GetBrokenRules());

            if (response.BrokenRules.Any())
            {
                response.MessageType = MessageType.Warning;
                response.Message = CommonResources.SignUpErrorMessage;
                return response;
            }

            var userExists = this.membershipRepository.GetUser(request.Email);
            if (userExists != null)
            {
                response.MessageType = MessageType.Warning;
                response.Message = CommonResources.SignUpErrorMessage;
                response.BrokenRules.Add(UserBusinessRules.EmailExists);
                return response;
            }

            try
            {
                var result = this.membershipRepository.CreateUser(user, new List<Role>(){role});
                this.emailService.SendMail(
                    EmailResources.EmailActivationFrom,
                    result.Email,
                    EmailResources.EmailActivationSubject,
                    string.Format(EmailResources.EmailActivationBody, "shopanyware.com", result.Id, result.ActivationCode));
                return result.ConvertToRegisterUserResponse();
            }
            catch (Exception e)
            {
                response.MessageType = MessageType.Error;
                response.Message = CommonResources.SignUpErrorMessage;
                this.logger.Error(CommonResources.SignUpErrorMessage, e);
                return response;
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        public SignUpAdminResponse SignUpAdmin(SignUpAdminRequest request)
        {
            var roles = new List<Role>();
            if (request.AdminRole) roles.Add(new Role { Name = StandardRole.Admin.ToString()});
            if (request.OperatorRole) roles.Add(new Role { Name = StandardRole.Operator.ToString()});

            var user = new User
            {
                Email = request.Email,
                Password = request.Password,
                Profile =
                    new Profile
                    {
                        FirstName = request.FirstName,
                        LastName = request.LastName,
                        NotifyOnOrderStatusChanged = true,
                        NotifyOnPackageStatusChanged = true
                    },
                ActivationCode = Guid.NewGuid()
            };
            var response = new SignUpAdminResponse { BrokenRules = user.Profile.GetBrokenRules().ToList() };
            response.BrokenRules.AddRange(user.GetBrokenRules());

            if (!request.AdminRole && !request.OperatorRole)
            {
                response.BrokenRules.Add(UserBusinessRules.NoRolesSpecified);
            }

            if (response.BrokenRules.Any())
            {
                response.MessageType = MessageType.Warning;
                response.Message = CommonResources.SignUpErrorMessage;
                return response;
            }

            var userExists = this.membershipRepository.GetUser(request.Email);
            if (userExists != null)
            {
                response.MessageType = MessageType.Warning;
                response.Message = CommonResources.SignUpErrorMessage;
                response.BrokenRules.Add(UserBusinessRules.EmailExists);
                return response;
            }

            try
            {
                var result = this.membershipRepository.CreateUser(user, roles);
                //this.emailService.SendMail(
                //    EmailResources.EmailActivationFrom,
                //    result.Email,
                //    EmailResources.EmailActivationSubject,
                //    string.Format(EmailResources.EmailActivationBody, "shopanyware.com", result.Id, result.ActivationCode));
                return response;
            }
            catch (Exception e)
            {
                response.MessageType = MessageType.Error;
                response.Message = CommonResources.SignUpErrorMessage;
                this.logger.Error(CommonResources.SignUpErrorMessage, e);
                return response;
            }

        }

        /// <summary>
        /// Register user.
        /// </summary>
        /// <param name="request">
        /// The request.
        /// </param>
        /// <returns>
        /// Register user response.
        /// </returns>
        public SignUpResponse RegisterUser(SignUpRequest request)
        {
            var response = new SignUpResponse();
            var user = new User
                {
                    Email = request.Email,
                    Password = request.Password,
                    Profile =
                        new Profile
                            {
                                FirstName = request.FirstName,
                                LastName = request.LastName,
                                NotifyOnOrderStatusChanged = true,
                                NotifyOnPackageStatusChanged = true
                            }
                };

            try
            {
                ////ThrowExceptionIfUserIsInvalid(user);
                var createdUser = this.userRepository.CreateUser(user);
                this.profileRepository.FindOrAddProfile(user.Profile);
                this.userRepository.SaveChanges();
                this.profileRepository.SaveChanges();

                var role = this.roleRepository.GetRoleByName(request.RoleName);
                if (role == null)
                {
                    this.roleRepository.AddRole(new Role { Name = request.RoleName, Description = string.Empty });
                    this.roleRepository.SaveChanges();
                    role = this.roleRepository.GetRoleByName(request.RoleName);
                }

                createdUser.Roles.Add(role);
                this.userRepository.SaveChanges();
            }
            catch (InvalidUserException)
            {
                response.MessageType = MessageType.Error;
                response.ErrorCode = ErrorCode.UserEmailExists.ToString();
            }

            return response;
        }

        /// <summary>
        /// Validate user against database.
        /// </summary>
        /// <param name="request">
        /// The request.
        /// </param>
        /// <returns>
        /// The <see cref="SignInResponse"/>.
        /// </returns>
        public SignInResponse SignIn(SignInRequest request)
        {
            var response = new SignInResponse();
            if (this.userRepository.ValidateUser(request.Email, request.Password))
            {
                return response;
            }

            response.MessageType = MessageType.Error;
            response.ErrorCode = ErrorCode.UserNotValid.ToString();
            return response;
        }

        /// <summary>
        /// The get user roles.
        /// </summary>
        /// <param name="request">
        /// The request.
        /// </param>
        /// <returns>
        /// The Get user roles response collection.
        /// </returns>
        public List<GetUserRolesResponse> GetUserRoles(GetUserRolesRequest request)
        {
            var user = this.userRepository.GetUserByEmail(request.IdentityToken);
            if (user != null)
            {
                if (user.Roles != null)
                {
                    return user.Roles.ConvertToGetUserRolesResponseCollection();
                }
            }

            return new List<GetUserRolesResponse>();
        }

        /// <summary>
        /// Get user's profile.
        /// </summary>
        /// <param name="request">
        /// The request.
        /// </param>
        /// <returns>
        /// Get profile response object.
        /// </returns>
        public GetProfileResponse GetProfile(GetProfileRequest request)
        {
            var response = new GetProfileResponse();
            var user = this.userRepository.GetUserByEmail(request.IdentityToken);
            if (user == null)
            {
                response.MessageType = MessageType.Error;
                response.ErrorCode = ErrorCode.UserNotFound.ToString();
                return response;
            }

            if (user.Profile == null)
            {
                response.MessageType = MessageType.Error;
                response.ErrorCode = ErrorCode.ProfileNotFound.ToString();
                return response;
            }
            response = user.ConvertToGetProfileResponse();
            response.WalletId = user.Wallet.Id;
            response.Balance = user.Wallet.Amount;
            return response;
        }

        /// <summary>
        /// Update profile.
        /// </summary>
        /// <param name="request">
        /// The update profile request.
        /// </param>
        /// <returns>
        /// The update profile.
        /// </returns>
        public UpdateProfileResponse UpdateProfile(UpdateProfileRequest request)
        {
            var profile = request.ConvertToProfile();

            var response = new UpdateProfileResponse { BrokenRules = profile.GetBrokenRules().ToList() };

            if (response.BrokenRules.Any())
            {
                response.MessageType = MessageType.Warning;
                response.Message = CommonResources.ProfileUpdateErrorMessage;
                return response;
            }

            try
            {
                var updatedProfile = this.membershipRepository.UpdateProfile(request.IdentityToken, profile);
                response = updatedProfile.ConvertToUpdateProfileResponse();
                response.Message = CommonResources.ProfileUpdateSuccessMessage;
                return response;
            }
            catch (Exception e)
            {
                response.MessageType = MessageType.Error;
                response.Message = CommonResources.ProfileUpdateErrorMessage;
                this.logger.Error(CommonResources.ProfileUpdateErrorMessage, e);
                return response;
            }
        }

        /// <summary>
        /// The generate change password link.
        /// </summary>
        /// <param name="request">
        /// The request.
        /// </param>
        /// <returns>
        /// The TdService.Services.Messaging.Membership.ChangePasswordLinkResponse.
        /// </returns>
        public ChangePasswordLinkResponse GenerateChangePasswordLink(ChangePasswordLinkRequest request)
        {
            return null;
        }

        /// <summary>
        /// Gets users in role
        /// </summary>
        /// <param name="request">The GetUsersInRoleRequest request. Pass role ID as '-1' to get all users</param>
        /// <returns></returns>
        public GetUsersInRoleResponse GetUsersInRole(GetUsersInRoleRequest request)
        {
            Tuple<List<User>, int> tuple;

            if (request.RoleId.Equals(-1))
            {
                tuple = userRepository.GetAllUsers(request.Skip, request.Take);
            }
            else
            {
                tuple = userRepository.GetUsersInRole(request.RoleId, request.Skip, request.Take);
            }

            var result = new GetUsersInRoleResponse { Users = tuple.Item1.ConvertToGetUsersInRoleResponseCollection(), TotalCount = tuple.Item2 };
            return result;
        }

        /// <summary>
        /// Getsuser by id
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        public GetUserByIdResponse GetUserById(GetUserByIdRequest request)
        {
            var user = userRepository.GetUserById(request.UserId);
            if (user == null)
            {
                return new GetUserByIdResponse { MessageType = MessageType.Warning, Message = CommonResources.UserNotFound };
            }
            var result = user.ConvertToGetUserByIdResponse();
            return result;
        }


        /// <summary>
        /// 
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        public AddUserToRoleResponse AddUserToRole(AddUserToRoleRequest request)
        {
            roleRepository.AddUserToRole(request.UserId, request.RoleId);
            roleRepository.SaveChanges();
            return new AddUserToRoleResponse { Message = CommonResources.ResourceManager.GetString("UserAddedToRole"), MessageType = MessageType.Success };
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        public RemoveUserFromRoleResponse RemoveUserFromRole(RemoveUserFromRoleRequest request)
        {
            roleRepository.RemoveUserFromRole(request.UserId, request.RoleId);
            roleRepository.SaveChanges();
            return new RemoveUserFromRoleResponse { Message = CommonResources.ResourceManager.GetString("UserRemovedFromRole"), MessageType = MessageType.Success };
        }


        /// <summary>
        /// 
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        public List<GetAllRolesResponse> GetAllRoles(GetAllRolesRequest request)
        {
            var roles = roleRepository.GetAllRoles().ToList().ConvertToGetAllRolesResponseCollection();
            return roles;
        }

        /// <summary>
        /// Gets user by email
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        public GetUserByEmailResponse GetUserByEmail(GetUserByEmailRequest request)
        {
            var user = userRepository.GetUserByEmail(request.Email);
            if (user == null)
            {
                return new GetUserByEmailResponse { MessageType = MessageType.Warning, Message = CommonResources.UserNotFound };
            }
            var result = user.ConvertToGetUserByEmailResponse();
            return result;
        }



    }
}