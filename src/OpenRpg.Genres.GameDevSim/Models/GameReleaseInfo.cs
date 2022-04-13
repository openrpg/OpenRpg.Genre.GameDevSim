namespace OpenRpg.Genres.GameDevSim.Models
{
    public class GameReleaseInfo
    {
        public int WeeksOnSale { get; set; }
        public int ProfitToDate { get; set; }
        public int CopiesSoldToDate { get; set; }
        public bool HasDigitalRelease { get; set; }
        public bool HasPhysicalRelease { get; set; }
    }
}