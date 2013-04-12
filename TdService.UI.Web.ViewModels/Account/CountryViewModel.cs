using TdService.Resources;
namespace TdService.UI.Web.ViewModels.Account
{
    public class CountryViewModel
    {
        public int Id { get; set; }
        public string TranslatedName
        {
            get
            {
                return Countries.ResourceManager.GetString(this.Code);
            }
        }

        public string Code { get; set; }
        public string DefaultName { get; set; }
    }
}
