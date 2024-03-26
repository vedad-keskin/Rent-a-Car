using Microsoft.EntityFrameworkCore;
using RentACar.Configuration;

namespace RentACar.DBContext
{
    public partial class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext()
        {
        }

        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            foreach (var relationship in modelBuilder.Model.GetEntityTypes().SelectMany(e => e.GetForeignKeys()))
            {
                relationship.DeleteBehavior = DeleteBehavior.NoAction;
            }


            modelBuilder.ApplyConfiguration(new PersonConfiguration());
            modelBuilder.ApplyConfiguration(new UserConfiguration());
        }



        public virtual DbSet<Country> Country { get; set; }
        public virtual DbSet<Car> Car { get; set; }
        public virtual DbSet<Address> Address { get; set; }
        public virtual DbSet<CarDetails> CarDetails { get; set; }
        public virtual DbSet<CarImages> CarImages { get; set; }
        public virtual DbSet<CarRent> CarRent { get; set; }
        public virtual DbSet<City> City { get; set; }
        public virtual DbSet<Rent>Rent { get; set; }
        public virtual DbSet<User> User { get; set; }
        public virtual DbSet<Person> Person { get; set; }
        public virtual DbSet<CarLocations> CarLocations { get; set; }

        public virtual DbSet<RentDate> RentDate { get; set; }

        public virtual DbSet<Region> Region { get; set; }

        public virtual DbSet<UserDetails> UserDetails { get; set; }
        public virtual DbSet<UserStatus> UserStatus { get; set; }
        public virtual DbSet<Recensions> Recensions { get; set; }
        public virtual DbSet<NewsFeed> NewsFeeds { get; set; }
        public virtual DbSet<Payments> Payments { get; set; }
        public virtual DbSet<Transactions> Transactions { get; set; }
        public virtual DbSet<UserRole> UserRole { get; set; }
        public virtual DbSet<AutentifikacijaToken> AutentifikacijaToken { get; set; }
        public virtual DbSet<Korisnik> Korisnik { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                //#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.

                

                optionsBuilder.UseSqlServer("Server=.;Database=RentACar;Trusted_Connection=True;MultipleActiveResultSets=true;TrustServerCertificate=True;");

            };

            //OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
