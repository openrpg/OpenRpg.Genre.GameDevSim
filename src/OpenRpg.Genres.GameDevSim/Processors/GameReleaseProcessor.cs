using OpenRpg.Core.Utils;
using OpenRpg.Genres.GameDevSim.Extensions;
using OpenRpg.CurveFunctions;
using OpenRpg.CurveFunctions.Curves;
using OpenRpg.Genres.GameDevSim.Models;

namespace OpenRpg.Genres.GameDevSim.Processors
{
    public class GameReleaseProcessor : IGameReleaseProcessor
    {
        public IRandomizer Randomizer { get; }
        public ICurveFunction ReleaseTimeCurve { get; }
        public int WeekOnScaleFalloff { get; }

        public GameReleaseProcessor(IRandomizer randomizer, int weekOnScaleFalloff = 60, ICurveFunction releaseTimeCurve = null)
        {
            WeekOnScaleFalloff = weekOnScaleFalloff;
            ReleaseTimeCurve = releaseTimeCurve ?? new PolynomialCurveFunction(-1.3f, 0.0f, 1f, 2f);
            Randomizer = randomizer;
        }

        public int CalculateCopiesSoldForWeek(Game game, Company company)
        {
            var weeksOnSale = game.GameReleaseInfo.WeeksOnSale + 1;
            if (weeksOnSale > WeekOnScaleFalloff)
            { weeksOnSale = WeekOnScaleFalloff; }

            var scaledSalePeriod = (float)weeksOnSale / WeekOnScaleFalloff;
            var saleValue = ReleaseTimeCurve.Plot(scaledSalePeriod);

            if (saleValue <= 0)
            { saleValue = Randomizer.Random(0.0001f, 0.01f); }
        
            var fun = game.Variables.Fun();
            var graphics = game.Variables.Graphics();
            var quality = game.Variables.Quality();
            var sound = game.Variables.Sound();
            var total = fun + graphics + quality + sound;
        
            // Account for first week/preorders
            if (weeksOnSale == 1) { total *= 5; }
            return (int)(total * Randomizer.Random(0.75f, 0.95f) * saleValue);
        }

        public int CalculateGameSalePrice(Game game, Company company)
        {
            var weeksOnSale = game.GameReleaseInfo.WeeksOnSale;
            if (weeksOnSale > 100) { return 5; }
            if (weeksOnSale > 50) { return 10; }
            if (weeksOnSale > 25) { return 20; }
            return 40;
        }
    }
}
