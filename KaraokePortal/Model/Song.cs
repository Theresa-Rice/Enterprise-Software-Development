//Kirsty Chan 232093Z IT3682


namespace KaraokePortal.Model
{
    public class Song
    {
        public Guid SongID { get; set; }
        public string Name { get; set; }
        public string Genre { get; set; }

        public ICollection<SongScores> SongScores { get; set; } = new HashSet<SongScores>();
    }
}
