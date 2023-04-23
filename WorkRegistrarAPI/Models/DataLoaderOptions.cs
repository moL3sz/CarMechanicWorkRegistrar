using WorkRegistrarAPI.Enums;

namespace WorkRegistrarAPI.Models
{
    public class DataLoaderOptions
    {

        public int PageSize { get; set; } = int.MaxValue;

        public int PageNumber { get; set; } = 1;

    }
}
