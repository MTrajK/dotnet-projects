namespace DotNet.AIAgents.Samples.Common.Utils
{
    using System;

    public class CompanyInfo
    {
        public string? Name { get; set; }

        public string? Industry { get; set; }

        public DateOnly? Founded { get; set; }

        public bool? IsPublic { get; set; }

        public string? StockSymbol { get; set; }

        public override string ToString()
        {
            string isPublicValue = IsPublic.HasValue ?
                (IsPublic.Value ? "Yes" : "No") :
                "/";
            string foundedFormated = Founded.HasValue ?
                Founded.Value.ToString("yyyy-MM-dd"):
                "/";
            return $"Name: {Name}\nIndustry: {Industry}\nFounded: {foundedFormated}\nIs public: {isPublicValue}\nStock symbol: {StockSymbol}";
        }
    }
}
