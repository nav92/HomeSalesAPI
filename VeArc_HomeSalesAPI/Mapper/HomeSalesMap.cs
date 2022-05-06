using VeArc_HomeSalesAPI.Models;
using CsvHelper;
using CsvHelper.Configuration;

namespace VeArc_HomeSalesAPI.Mapper
{
    public sealed class HomeSalesMap: ClassMap< HomeSales >
    {
        public HomeSalesMap()
        {
            Map(x => x.PROPERTYZIP).Name("PROPERTYZIP");
            Map(x => x.SCHOOLCODE).Name("SCHOOLCODE");
            Map(x => x.SCHOOLDESC).Name("SCHOOLDESC");
            Map(x => x.RECORDDATE).Name("RECORDDATE");
            Map(x => x.SALEDATE).Name("SALEDATE");
            Map(x => x.PRICE).Name("PRICE");
        }
    }
}
