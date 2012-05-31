// -----------------------------------------------------------------------
// <copyright file="IMembershipService.cs" company="TdService">
// Vitali Hatalski. 2012.
// </copyright>
// -----------------------------------------------------------------------

namespace TdService.Services.Interfaces
{
    using TdService.Services.Messaging.Membership;

    /// <summary>
    /// Interface of membership service.
    /// </summary>
    public interface IMembershipService
    {
        /// <summary>
        /// Register user.
        /// </summary>
        /// <param name="request">
        /// The request.
        /// </param>
        /// <returns>
        /// Register user response.
        /// </returns>
        RegisterUserResponse RegisterUser(RegisterUserRequest request);

        /// <summary>
        /// Login user.
        /// </summary>
        /// <param name="request">
        /// The request.
        /// </param>
        void LoginUser(LoginUserRequest request);

        /// <summary>
        /// </summary>
        /// <param name="request">
        /// The request.
        /// </param>
        /// <returns>
        /// </returns>
        bool ValidateUser(ValidateUserRequest request);

        /// <summary>
        /// Get user.
        /// </summary>
        /// <param name="request">
        /// The request.
        /// </param>
        /// <returns>
        /// Get user response object.
        /// </returns>
        GetUserResponse GetUser(GetUserRequest request);
    }
}