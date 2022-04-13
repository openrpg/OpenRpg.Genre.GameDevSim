using GameDevStory.ConsoleApp.Data.Generators;
using OpenRpg.Core.Common;

namespace GameDevStory.ConsoleApp.Extensions;

public static class DataGeneratorExtensions
{
    public static Dictionary<object, object> GenerateDictionary<T>(this IDataGenerator<T> dataGenerator)
        where T : IHasDataId
    {
        return dataGenerator.Data
            .ToDictionary(x => (object)x.Id, x => (object)x);
    }
}