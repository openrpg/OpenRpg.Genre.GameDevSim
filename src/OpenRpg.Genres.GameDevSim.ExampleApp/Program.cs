using GameDevStory.ConsoleApp;
using GameDevStory.ConsoleApp.Lookups;
using OpenRpg.Data.Conventions.Extensions;
using OpenRpg.Genres.GameDevSim.Extensions;
using OpenRpg.Genres.GameDevSim.Models;
using Spectre.Console;

// Any config variables
var weeksToSell = 30;

// Load staff and form the company
var gooch = Services.Repository.Get<Staff>(StaffLookups.TheGoose);
Services.StatsPopulator.Populate(gooch.Stats, gooch.Effects.ToArray(), null);

var tudge = Services.Repository.Get<Staff>(StaffLookups.Tudge);
Services.StatsPopulator.Populate(tudge.Stats, tudge.Effects.ToArray(), null);

var kojima = Services.Repository.Get<Staff>(StaffLookups.HeroKojima);
Services.StatsPopulator.Populate(kojima.Stats, kojima.Effects.ToArray(), null);

var company = new Company
{
    NameLocaleId = "Tudges Money Train",
    Staff = new List<Staff> { gooch, tudge, kojima }
};
Services.StatsPopulator.Populate(company.Stats, company.Effects.ToArray(), null);

// Start the game loop
async Task GameLoop()
{
    while (true)
    {
        // Ask the user to provide game theme/genre/name
        var currentGame = UI.CreateGameFromUI();
        company.Games.Add(currentGame);
        
        // Announce we are making it
        AnsiConsole.Write(new FigletText($"{currentGame.Name.ToUpper()} - LETS GOOOOO!!")
            .LeftAligned()
            .Color(Color.Green));
        await Task.Delay(1000);

        // Show the development overview for the game
        await UI.CreateGameOverview(currentGame, company);
        await Task.Delay(1000);
    
        // Announce we are shipping it
        AnsiConsole.Write(new FigletText($"SHIPPING - {currentGame.Name.ToUpper()}!")
            .LeftAligned()
            .Color(Color.Green));
        await Task.Delay(1500);
       
        // Simulate selling the game each week
        for (var i = 0; i < weeksToSell; i++)
        {
            // Calculate how many copies we sell and how much for
            var copiesSold = Services.GameReleaseProcessor.CalculateCopiesSoldForWeek(currentGame, company);
            var salePrice = Services.GameReleaseProcessor.CalculateGameSalePrice(currentGame, company);
            var totalMoneyForWeek = copiesSold * salePrice;
            
            // Add the money to the company funds and track game related release info
            company.Variables.AddMoney(totalMoneyForWeek);
            company.Variables.AddWeekNumber(1);
            currentGame.GameReleaseInfo.WeeksOnSale++;
            currentGame.GameReleaseInfo.ProfitToDate += totalMoneyForWeek;
            currentGame.GameReleaseInfo.CopiesSoldToDate += copiesSold;
            await Task.Delay(1500);

            // Report on the sales figures
            AnsiConsole.Markup($"|- Week [green]{currentGame.GameReleaseInfo.WeeksOnSale}[/] ");
            AnsiConsole.Markup($"| [green]${totalMoneyForWeek}[/] Sales ");
            AnsiConsole.Markup($"| [blue]{copiesSold} x ${salePrice}[/] Copies ");
            AnsiConsole.MarkupLine($"| Total Sales [green]${currentGame.GameReleaseInfo.ProfitToDate}[/]");
        }

        // Restart the loop
        await Task.Delay(1500);
        AnsiConsole.Clear();
    }
}


await GameLoop();

