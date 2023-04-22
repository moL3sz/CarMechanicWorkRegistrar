
using WorkRegistrarAPI.Enums;

namespace WorkRegistrarAPI.Data
{
    public class GlobalStaticVariables
    {
        public static Dictionary<WorkCatagory, long> WORKCATEGORY_HOURS = new Dictionary<WorkCatagory, long>
        {
            { WorkCatagory.BODYWORK, 3 },
            { WorkCatagory.ENGINE, 8 },
            { WorkCatagory.LANDING_GEAR, 6 },
            { WorkCatagory.BRAKE_SYSTEM, 4 },
        };

        public static Dictionary<Tuple<short, short>, double> MANUFACTURE_YEAR_RATE = new Dictionary<Tuple<short, short>, double>
        {
            { new Tuple<short, short>(0, 5), 0.5 },
            { new Tuple<short, short>(5, 10), 1 },
            { new Tuple<short, short>(10, 20), 1.5 },
            { new Tuple<short, short>(20, short.MaxValue), 2.0 },
        };
        public static Dictionary<Tuple<short, short>, double> ISSUE_SERIOUSNESS_RATE = new Dictionary<Tuple<short, short>, double>
        {
            { new Tuple<short, short>(1, 2), 0.2 },
            { new Tuple<short, short>(3, 4), 0.4 },
            { new Tuple<short, short>(5, 7), 0.6 },
            { new Tuple<short, short>(8, 9), 0.8 },
            { new Tuple<short, short>(10, short.MaxValue), 1 },

        };
    }
}
