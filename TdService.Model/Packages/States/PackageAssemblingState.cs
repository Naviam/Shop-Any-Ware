﻿
using TdService.Resources;

namespace TdService.Model.Packages.States
{
    public class PackageAssemblingState : IPackageState
    {
        public bool CanBeModified
        {
            get { return false; }
        }

        public bool CanItemsBeModified
        {
            get { return false; }
        }

        public bool CanBeSent
        {
            get { return false; }
        }

        public bool CanBeRemoved
        {
            get { return false; }
        }

        public bool CanBeDisposed
        {
            get { return false; }
        }


        public bool CanBePaidFor
        {
            get { return false; }
        }


        public string TranslatedName
        {
            get
            {
                return PackageStatusResources.Assembling;
            }
        }


        public bool CanBeAssembled
        {
            get { return false; }
        }
    }
}