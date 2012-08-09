// --------------------------------------------------------------------------------------------------------------------
// <copyright file="IFileStorage.cs" company="TdService">
//   Vitali Hatalski. 2012.
// </copyright>
// <summary>
//   The FileStorage interface.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace TdService.Infrastructure.FileSystem
{
    /// <summary>
    /// The FileStorage interface.
    /// </summary>
    public interface IFileStorage
    {
        /// <summary>
        /// Get absolute server path.
        /// </summary>
        /// <param name="path">
        /// The path.
        /// </param>
        /// <returns>
        /// Absolute server path.
        /// </returns>
        string MapPath(string path);
    }
}