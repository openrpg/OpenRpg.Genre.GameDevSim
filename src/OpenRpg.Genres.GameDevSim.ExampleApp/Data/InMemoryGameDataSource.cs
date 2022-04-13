using GameDevStory.ConsoleApp.Data.Generators;
using GameDevStory.ConsoleApp.Extensions;
using OpenRpg.Core.Classes;
using OpenRpg.Data.InMemory;
using OpenRpg.Genres.GameDevSim.Models;

namespace GameDevStory.ConsoleApp.Data;

public class InMemoryGameDataSource : InMemoryDataSource
{
    public InMemoryGameDataSource()
    {
        var classDataGenerator = new ClassDataGenerator();
        var gameGenreDataGenerator = new GameGenreDataGenerator();
        var gameThemeDataGenerator = new GameThemeDataGenerator();
        var staffDataGenerator = new StaffDataGenerator(classDataGenerator);
        
        Database = new Dictionary<Type, Dictionary<object, object>>(new []
        {
            new KeyValuePair<Type, Dictionary<object, object>>(typeof(IClassTemplate), classDataGenerator.GenerateDictionary()),
            new KeyValuePair<Type, Dictionary<object, object>>(typeof(GameGenre), gameGenreDataGenerator.GenerateDictionary()),
            new KeyValuePair<Type, Dictionary<object, object>>(typeof(GameTheme), gameThemeDataGenerator.GenerateDictionary()),
            new KeyValuePair<Type, Dictionary<object, object>>(typeof(Staff), staffDataGenerator.GenerateDictionary())
        });
    }
}