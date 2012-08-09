// -----------------------------------------------------------------------
// <copyright file="FileStorage.cs" company="TdService">
// Vitali Hatalski. 2012.
// </copyright>
// -----------------------------------------------------------------------

namespace TdService.Infrastructure.FileSystem
{
    using System;
    using System.IO;

    /// <summary>
    /// File storage
    /// </summary>
    public class FileStorage : IFileStorage
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
            return Path.Combine(Environment.CurrentDirectory, path);
        }
    }
}
