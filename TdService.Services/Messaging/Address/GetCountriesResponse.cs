namespace TdService.Services.Messaging.Address
{
    public class GetCountriesResponse:ResponseBase
    {
        public int Id { get; set; }
        public string DefaultName { get; set; }
        public string Code { get; set; }
    }
}
