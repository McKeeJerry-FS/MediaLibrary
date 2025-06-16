using Microsoft.EntityFrameworkCore;

namespace MediaLibrary.Server.Data
{
    public class MediaLibraryDbContext : DbContext
    {
        public MediaLibraryDbContext() { }

        public MediaLibraryDbContext(DbContextOptions<MediaLibraryDbContext> options) : base(options) { }


        public DbSet<Person>? Persons { get; set; }
        public DbSet<Movie>? Movies { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Person>(b => {
                b.Property(x => x.Name).IsRequired();
                b.Navigation(x => x.Movies).AutoInclude(); // AutoInclude to eagerly load Movies
            });

            modelBuilder.Entity<Movie>(b =>
            {
                b.Property(x => x.Name).IsRequired();
                b.HasOne(x => x.Director)
                    .WithMany()
                    .HasForeignKey(x => x.DirectorId)
                    .OnDelete(DeleteBehavior.Restrict);
                b.HasOne(x => x.MusicComposer)
                    .WithMany()
                    .HasForeignKey(x => x.MusicComposerId)
                    .OnDelete(DeleteBehavior.Restrict);
                b.Navigation(x => x.Director).AutoInclude(); // AutoInclude to eagerly load Director
                b.Navigation(x => x.MusicComposer).AutoInclude(); // AutoInclude to eagerly load MusicComposer
                b.Navigation(x => x.Actors).AutoInclude(); // AutoInclude to eagerly load Actors
            });

            modelBuilder.Entity<MovieCategory>(b =>
            {
                b.HasKey(mc => new { mc.Category, mc.MovieId });
            });

            modelBuilder.Entity<MovieActor>(b =>
            {
                b.HasKey(ma => new { ma.MovieId, ma.PersonId });
            });

        }
    }
}
