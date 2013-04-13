// --------------------------------------------------------------------------------------------------------------------
// <copyright file="PackageAssembledState.cs" company="Naviam">
//   Vadim Shaporov. 2013
// </copyright>
// <summary>
//   The package assembled state.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace TdService.Model.Packages.States
{
    using TdService.Resources;

    /// <summary>
    /// The package assembled state.
    /// </summary>
    public class PackageAssembledState : IPackageState
    {
        /// <summary>
        /// Gets a value indicating whether can be modified.
        /// </summary>
        public bool CanBeModified
        {
            get { return false; }
        }

        /// <summary>
        /// Gets a value indicating whether can items be modified.
        /// </summary>
        public bool CanItemsBeModified
        {
            get { return false; }
        }

        /// <summary>
        /// Gets a value indicating whether can be sent.
        /// </summary>
        public bool CanBeSent
        {
            get { return false; }
        }

        /// <summary>
        /// Gets a value indicating whether can be removed.
        /// </summary>
        public bool CanBeRemoved
        {
            get { return false; }
        }

        /// <summary>
        /// Gets a value indicating whether can be disposed.
        /// </summary>
        public bool CanBeDisposed
        {
            get { return false; }
        }

        /// <summary>
        /// Gets a value indicating whether can be paid for.
        /// </summary>
        public bool CanBePaidFor
        {
            get { return true; }
        }

        /// <summary>
        /// Gets the translated name.
        /// </summary>
        public string TranslatedName
        {
            get { return PackageStatusResources.Assembled; }
        }

        /// <summary>
        /// Gets a value indicating whether can be assembled.
        /// </summary>
        public bool CanBeAssembled
        {
            get { return false; }
        }
    }
}