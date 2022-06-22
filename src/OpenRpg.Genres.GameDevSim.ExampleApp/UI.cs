using OpenRpg.Genres.GameDevSim.Extensions;
using OpenRpg.Genres.GameDevSim.Models;
using OpenRpg.Data.Conventions.Extensions;
using Spectre.Console;

namespace GameDevStory.ConsoleApp;

// To keep things simple this is where all UI logic lives
public class UI
{
    public static BarChartItem[] CreateDevelopmentChartItems(Game game)
    {
        return new[]
        {
            new BarChartItem("Fun", (int)game.State.Fun(), Color.Blue),
            new BarChartItem("Graphics", (int)game.State.Graphics(), Color.Green),
            new BarChartItem("Quality", (int)game.State.Quality(), Color.Yellow),
            new BarChartItem("Sound", (int)game.State.Sound(), Color.Red),
            new BarChartItem("Stability", (int)game.State.Stability(), Color.Grey)
        };
    }
    
    public static BarChartItem[] CreateProgressChartItems(Game game)
    {
        return new[]
        {
            new BarChartItem("Progress", (int)game.State.Progress(), Color.White)
        };
    }
    
    public static Panel CreateCharacterPanel(Staff character)
    {
        var characterChart = new BarChart()
            .Width(60)
            .CenterLabel()
            .WithMaxValue(30)
            .AddItem("Creativity", character.Stats.Creativity(), Color.Yellow)
            .AddItem("Logic", character.Stats.Logic(), Color.Blue)
            .AddItem("Understanding", character.Stats.Understanding(), Color.Red)
            .AddItem("Stamina", character.Stats.Stamina(), Color.Green);
    
        var panel = new Panel(characterChart);
        panel.Border = BoxBorder.Rounded;
        var title = $"{character.NameLocaleId} | Lvl {character.Class.Level} {character.Class.ClassTemplate.NameLocaleId}";
        panel.Header = new PanelHeader(title, Justify.Center);

        return panel;
    }
    
    public static async Task CreateGameOverview(Game game, Company company)
    {
        var gameChart = new BarChart()
            .Width(200)
            .CenterLabel()
            .WithMaxValue(500)
            .AddItems(CreateDevelopmentChartItems(game));
    
        var progressChart = new BarChart()
            .Width(200)
            .CenterLabel()
            .WithMaxValue(100)
            .AddItems(CreateProgressChartItems(game));
    
        var developerTable = new Table();
        developerTable.Border = TableBorder.None;
        foreach (var staffMember in company.Staff)
        { developerTable.AddColumn(new TableColumn(CreateCharacterPanel(staffMember))); }
        
        var overallTable = new Table();
        overallTable.Width = 200;
        overallTable.Border = TableBorder.None;
        overallTable.AddColumn(new TableColumn(new Rule()));
        overallTable.AddRow(progressChart);
        overallTable.AddRow(new Rule());
        overallTable.AddRow(gameChart);
        overallTable.AddRow(new Rule());

        var developedByText = new Text("Developed By");
        developedByText.Alignment = Justify.Center;
        overallTable.AddRow(developedByText);
        overallTable.AddRow(developerTable);
        
        var panel = new Panel(overallTable);
        panel.Border = BoxBorder.Rounded;
        panel.Expand = false;
        panel.Header = new PanelHeader($" {company.NameLocaleId} Is Developing - {game.Name} | {game.Theme.NameLocaleId} {game.Genre.NameLocaleId} Game ", Justify.Center);
        
        await AnsiConsole.Live(panel)
            .StartAsync(async ctx => 
            {
                while (game.State.Progress() < 100)
                {
                    Services.GameDevelopmentProcessor.UpdateDevelopment(game, company);
                    gameChart.Data.Clear();
                    gameChart.Data.AddRange(CreateDevelopmentChartItems(game));
                    
                    progressChart.Data.Clear();
                    progressChart.Data.AddRange(CreateProgressChartItems(game));
                    ctx.Refresh();
                    
                    await Task.Delay(500);
                }
            });
    }

    public static Game CreateGameFromUI()
    {
        var allGenres = Services.Repository.GetAll<GameGenre>();
        var gameGenrePrompt = new SelectionPrompt<GameGenre>()
            .Title("What [green]Genre[/] Is Your Game?")
            .PageSize(10)
            .UseConverter(x => x.NameLocaleId)
            .AddChoices(allGenres);

        var gameGenre = AnsiConsole.Prompt(gameGenrePrompt);
        
        var allThemes = Services.Repository.GetAll<GameTheme>();
        var gameThemePrompt = new SelectionPrompt<GameTheme>()
            .Title("What [green]Theme[/] Is Your Game?")
            .PageSize(10)
            .UseConverter(x => x.NameLocaleId)
            .AddChoices(allThemes);

        var gameTheme = AnsiConsole.Prompt(gameThemePrompt);
        
        var gameName = AnsiConsole.Ask<string>($"What do you want to name your [green]{gameGenre.NameLocaleId} {gameTheme.NameLocaleId}[/] game?");
        return new Game
        {
            Name = gameName,
            Genre = gameGenre,
            Theme = gameTheme
        };
    }
}