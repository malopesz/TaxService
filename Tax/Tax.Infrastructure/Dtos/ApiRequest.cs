namespace Tax.Infrastructure.Dtos
{
    public class ApiRequest
    {
        public string CalculateTaxApiUrl { get; set; }
        public string GetTaxRateByLocationApiUrl { get; set; }
        public string ApiKey { get; set; }
    }
}
