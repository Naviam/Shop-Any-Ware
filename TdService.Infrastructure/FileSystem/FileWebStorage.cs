// --------------------------------------------------------------------------------------------------------------------
// <copyright file="FileWebStorage.cs" company="TdService">
//   Vitali Hatalski. 2012.
// </copyright>
// <summary>
//   The file web storage.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace TdService.Infrastructure.FileSystem
{
    using System.Web;

    /// <summary>
    /// The file web storage.
    /// </summary>
    public class FileWebStorage : IFileStorage
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
        public string MapPath(string path)
        {
            return HttpContext.Current.Server.MapPath(path);
        }
    }
}