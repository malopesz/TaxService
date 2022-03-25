namespace Tax.API.Settings
{
    public class TaxApiSettings
    {
        public TaxJarApi TaxJarApi { get; set; }
    }

    public class TaxJarApi
    {
        public TaxJarApiUrls Urls { get; set; }
        public string TaxJarApiKey { get; set; }
    }

    public class TaxJarApiUrls
    {
        public string CalculateTax { get; set; }
        public string GetTaxRateByLocation { get; set; }
    }
}
