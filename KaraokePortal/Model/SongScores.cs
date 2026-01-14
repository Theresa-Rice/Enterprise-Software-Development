//Kirsty Chan 232093Z IT3682


namespace KaraokePortal.Model
{
    public class SongScores
    {
        public Guid SongScoresID { get; set; }
        public Guid SongID { get; set; }
        public Song Song { get; set; }
        public Guid SingerID { get; set; }
        public Singer Singer { get; set; }
        public double Score { get; set; }
    }
}
