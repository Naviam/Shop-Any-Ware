namespace TdService.Services.Messaging.Address
{
    public class GetCountriesResponse:ResponseBase
    {
        public int Id { get; set; }
        public string TranslatedName { get; set; }
    }
}
