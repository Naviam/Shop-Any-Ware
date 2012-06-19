// --------------------------------------------------------------------------------------------------------------------
// <copyright file="MessageType.cs" company="TdService">
//   Vitali Hatalski. 2012.
// </copyright>
// <summary>
//   Message types.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace TdService.Services.Messaging
{
    /// <summary>
    /// Message types.
    /// </summary>
    public enum MessageType
    {
        /// <summary>
        /// Success type.
        /// </summary>
        Success = 0,

        /// <summary>
        /// Warning type.
        /// </summary>
        Warning = 1,

        /// <summary>
        /// Error type.
        /// </summary>
        Error = 2
    }
}