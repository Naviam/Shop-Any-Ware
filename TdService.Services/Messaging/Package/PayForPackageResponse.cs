using TdService.Services.Messaging.Package.Base;

namespace TdService.Services.Messaging.Package
{
    public class PayForPackageResponse:BasePackageResponse
    {
        public decimal WalletAmount { get; set; }
    }
}
