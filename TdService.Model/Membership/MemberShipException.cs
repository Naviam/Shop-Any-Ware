// --------------------------------------------------------------------------------------------------------------------
// <copyright file="MemberShipException.cs" company="Naviam">
//   Vadim Shaporov. 2013
// </copyright>
// <summary>
//   Defines the MemberShipException type.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace TdService.Model.Membership
{
    using System;

    /// <summary>
    /// The member ship exception.
    /// </summary>
    public class MemberShipException : Exception
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="MemberShipException"/> class.
        /// </summary>
        /// <param name="message">
        /// The message.
        /// </param>
        public MemberShipException(string message) : base(message)
        {
        }
    }
}
