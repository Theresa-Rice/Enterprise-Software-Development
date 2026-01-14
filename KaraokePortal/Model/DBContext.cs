//Kirsty Chan 232093Z IT3682


using Microsoft.EntityFrameworkCore;

namespace KaraokePortal.Model
{
    public class DBContext: DbContext
    {
        public DBContext(DbContextOptions<DBContext> options) : base(options) {}

        public DbSet<Song> Song { get; set; }
        public DbSet<Singer> Singer { get; set; }
        public DbSet<SongScores> SongScores { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<SongScores>()
                       .HasOne(ss => ss.Singer)
                       .WithMany(s => s.SongScores)
                       .HasForeignKey(ss => ss.SingerID);

            modelBuilder.Entity<SongScores>()
                        .HasOne(ss => ss.Song)
                        .WithMany(s => s.SongScores)
                        .HasForeignKey(ss => ss.SongID);
        }
    }
}
