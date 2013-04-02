namespace TdService.Model.Packages.Exceptions
{
    using System;
    using TdService.Model.Packages.States;
    using TdService.Resources;

    public class InvalidPackageStateException:Exception
    {
        public InvalidPackageStateException(PackageStatus stateFrom, PackageStatus stateTo)
            :base(string.Format(PackageStatusResources.InvalidPackageStateException,stateFrom.ToString(), stateTo.ToString()))
        {
            
        }
    }
}
