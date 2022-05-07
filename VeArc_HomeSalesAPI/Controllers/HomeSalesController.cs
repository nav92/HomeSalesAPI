using CsvHelper;
using Microsoft.AspNetCore.Mvc;
using System.Globalization;
using System.Text;
using VeArc_HomeSalesAPI.Mapper;
using VeArc_HomeSalesAPI.Models;

namespace VeArc_HomeSalesAPI.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class HomeSalesController : ControllerBase
    {
        public List<HomeSales> HomeSalesList { get; set; }
        public HomeSalesController()
        {
            HomeSalesList = ReadCSVFile();
        }

        [HttpGet("GetDistinctSchools/{year}/{month}")]
        public List<HomeSales> GetDistinctSchools(int year, int month)
        {

            var result = HomeSalesList.Where(g => DateTime.ParseExact(g.SALEDATE, "MM-dd-yyyy", CultureInfo.InvariantCulture).Year == year && DateTime.ParseExact(g.SALEDATE, "MM-dd-yyyy", CultureInfo.InvariantCulture).Month == month).
                         OrderByDescending(g => g.PRICE).
                         GroupBy(g => new { yr = DateTime.ParseExact(g.SALEDATE, "MM-dd-yyyy", CultureInfo.InvariantCulture).Year, mth = DateTime.ParseExact(g.SALEDATE, "MM-dd-yyyy", CultureInfo.InvariantCulture).Month, g.SCHOOLCODE}).
                         Select(g => g.First()).ToList();    

            return result;

        }

        [HttpGet("GetAverageDays/{schoolName}/{year}/{month}")]
        public double GetAverageNumberOfDays(string schoolName, int year, int month)
        {
            var listOfDates = HomeSalesList.Where(g => DateTime.ParseExact(g.SALEDATE, "MM-dd-yyyy", CultureInfo.InvariantCulture).Year == year && DateTime.ParseExact(g.SALEDATE, "MM-dd-yyyy", CultureInfo.InvariantCulture).Month == month && g.SCHOOLDESC.ToUpper() == schoolName.ToUpper()).
                              Select(g => DateTime.ParseExact(g.SALEDATE, "MM-dd-yyyy", CultureInfo.InvariantCulture)).ToList();
            if (listOfDates != null && listOfDates.Count() > 0)
            {
                double average = listOfDates.Last().Day - listOfDates.First().Day / listOfDates.Count();
                return average;
            }
            else return 0;
        }

        [HttpGet]
        public List<HomeSales> ReadCSVFile()
        {
            string currentDirectory = Directory.GetCurrentDirectory();
            string path = "Data";
            string fullPath = Path.Combine(currentDirectory, path, "home-sales.csv");
            try
            {
                using (var reader = new StreamReader(fullPath, Encoding.Default))
                using (var csv = new CsvReader(reader, System.Globalization.CultureInfo.CurrentCulture))
                {
                    csv.Context.RegisterClassMap<HomeSalesMap>();
                    var records = csv.GetRecords<HomeSales>().ToList();
                    return records;
                }
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }
    }
}
