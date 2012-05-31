// -----------------------------------------------------------------------
// <copyright file="MembershipService.cs" company="TdService">
// Vitali Hatalski. 2012.
// </copyright>
// -----------------------------------------------------------------------

namespace TdService.Services.Implementations
{
    using System;

    using TdService.Model.Membership;
    using TdService.Services.Interfaces;
    using TdService.Services.Messaging.Membership;

    /// <summary>
    /// Membership service class.
    /// </summary>
    public class MembershipService : IMembershipService
    {
        /// <summary>
        /// Membership repository.
        /// </summary>
        private readonly IMembershipRepository membershipRepository;

        /// <summary>
        /// Initializes a new instance of the <see cref="MembershipService"/> class.
        /// </summary>
        /// <param name="membershipRepository">
        /// The membership repository.
        /// </param>
        public MembershipService(IMembershipRepository membershipRepository)
        {
            this.membershipRepository = membershipRepository;
        }

        /// <summary>
        /// </summary>
        /// <param name="request">
        /// The request.
        /// </param>
        /// <returns>
        /// </returns>
        /// <exception cref="NotImplementedException">
        /// </exception>
        public RegisterUserResponse RegisterUser(RegisterUserRequest request)
        {
            var response = new RegisterUserResponse();
            var user = new User
                {
                    Email = request.Email,
                    Password = request.Password,
                    Profile = new Profile { FirstName = request.FirstName, LastName = request.LastName }
                };
            return response;
        }

        /// <summary>
        /// </summary>
        /// <param name="request">
        /// The request.
        /// </param>
        /// <exception cref="NotImplementedException">
        /// </exception>
        public void LoginUser(LoginUserRequest request)
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// Validate user against database.
        /// </summary>
        /// <param name="request">
        /// The request.
        /// </param>
        /// <returns>
        /// True if user exists in db, otherwise false.
        /// </returns>
        public bool ValidateUser(ValidateUserRequest request)
        {
            return this.membershipRepository.ValidateUser(request.Email, request.Password);
        }

        /// <summary>
        /// </summary>
        /// <param name="request">
        /// The request.
        /// </param>
        /// <returns>
        /// </returns>
        public GetUserResponse GetUser(GetUserRequest request)
        {
            var response = new GetUserResponse();
            response.User = membershipRepository.GetUser(request.Email);
            return response;
        }
    }
}