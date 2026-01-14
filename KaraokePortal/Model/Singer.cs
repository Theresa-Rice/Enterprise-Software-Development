
//Kirsty Chan 232093Z IT3682

using Microsoft.AspNetCore.Mvc;

namespace KaraokePortal.Model
{
    public class Singer
    {
        public Guid SingerID { get; set; }
        public string LastName { get; set; }
        public string FirstName { get; set; }
        public DateOnly JoinDate { get; set; }
        public ICollection<SongScores> SongScores { get; set; } = new HashSet<SongScores>();
    }
}
