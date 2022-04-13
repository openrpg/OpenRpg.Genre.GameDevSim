using OpenRpg.Genres.GameDevSim.Types;
using OpenRpg.Genres.GameDevSim.Variables;

namespace OpenRpg.Genres.GameDevSim.Extensions
{
    public static class CompanyVariableExtensions
    {
        public static int Money(this ICompanyVariables stats) => (int)stats.Get(CompanyVariableTypes.Money);
        public static void Money(this ICompanyVariables stats, int value) => stats[CompanyVariableTypes.Money] = value;
        public static void AddMoney(this ICompanyVariables stats, int value)
        {
            var currentMoney = (int)(stats.Get(CompanyVariableTypes.Money) ?? 0);
            stats[CompanyVariableTypes.Money] = currentMoney + value;
        }

        public static int WeekNumber(this ICompanyVariables stats) => (int)stats.Get(CompanyVariableTypes.WeekNumber);
        public static void WeekNumber(this ICompanyVariables stats, int value) => stats[CompanyVariableTypes.WeekNumber] = value;
        public static void AddWeekNumber(this ICompanyVariables stats, int value)
        {
            var currentWeek = (int)(stats.Get(CompanyVariableTypes.WeekNumber) ?? 0);
            stats[CompanyVariableTypes.WeekNumber] = currentWeek + value;
        }
    }
}