namespace VeArc_HomeSalesAPI.Models
{
    public class DistictHomeSales
    {
        public string? SchoolCode { get; set; }
        public string? SchoolDesc { get; set; }
        public string? SaleDate { get; set; }
        public List<HomeSales>? HomeSaleList { get; set; }
    }
}
