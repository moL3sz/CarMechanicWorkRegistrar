using System.ComponentModel;
using System.Reflection;

namespace CarMechanicClient.Managers
{
    public static class EnumManager
    {
        public static string GetDescription(this Enum value)
        {
            string desc = value.GetType()
                            .GetMember(value.ToString())
                            .First()
                            .GetCustomAttribute<DescriptionAttribute>().Description;

            return desc;


        }
    }
}
