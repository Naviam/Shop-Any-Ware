// --------------------------------------------------------------------------------------------------------------------
// <copyright file="PackageNewState.cs" company="TdService">
//   Vitali Hatalski. 2012.
// </copyright>
// <summary>
//   The package new state.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

using TdService.Model.Packages.States;
using TdService.Resources;
namespace TdService.Model.Packages
{
    /// <summary>
    /// The package new state.
    /// </summary>
    public class PackageNewState : IPackageState
    {
        /// <summary>
        /// Gets a value indicating whether can be modified.
        /// </summary>
        public bool CanBeModified
        {
            get
            {
                return true;
            }
        }

        /// <summary>
        /// Gets a value indicating whether can items be modified.
        /// </summary>
        public bool CanItemsBeModified
        {
            get
            {
                return true;
            }
        }

        /// <summary>
        /// Gets a value indicating whether can be sent.
        /// </summary>
        public bool CanBeSent
        {
            get
            {
                return false;
            }
        }

        /// <summary>
        /// Gets a value indicating whether can be removed.
        /// </summary>
        public bool CanBeRemoved
        {
            get
            {
                return true;
            }
        }

        /// <summary>
        /// Gets a value indicating whether can be disposed.
        /// </summary>
        public bool CanBeDisposed
        {
            get
            {
                return true;
            }
        }


        public bool CanBePaidFor
        {
            get { return false; }
        }

        public string TranslatedName
        {
            get
            {
                return PackageStatusResources.New;
            }
        }


        public bool CanBeAssembled
        {
            get { return true; }
        }
    }
}