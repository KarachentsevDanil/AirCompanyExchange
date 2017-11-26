using System.Data.Entity;
using AirCompanyExchange.Entities;

namespace AirCompanyExchange.Context
{
    public class AirDbContext : DbContext
    {
        public AirDbContext()
            : base(@"data source=WS003HRK01\SQLEXPRESS;
                        initial catalog=AirCompanyExchange;
                        integrated security=True;MultipleActiveResultSets=True;
                        App=EntityFramework")
        {
            Configuration.ProxyCreationEnabled = false;
            Configuration.LazyLoadingEnabled = false;
            Configuration.AutoDetectChangesEnabled = true;
        }

        public DbSet<Company> Companies { get; set; }

        public DbSet<Plane> Planes { get; set; }

        public DbSet<PlaneModel> PlaneModels { get; set; }

        public DbSet<PlaneType> PlaneTypes { get; set; }

        public DbSet<Rent> Rents { get; set; }

        public DbSet<RentPlane> RentPlanes { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            Database.SetInitializer(new AirDbInitializer());

            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Company>()
                .HasKey(x => x.CompanyId);

            modelBuilder.Entity<Plane>()
                .HasKey(x => x.CompanyId);

            modelBuilder.Entity<Plane>()
                .HasRequired(x => x.Company)
                .WithMany(x => x.Planes)
                .HasForeignKey(x => x.CompanyId);

            modelBuilder.Entity<Plane>()
                .HasRequired(x => x.PlaneModel)
                .WithMany(x => x.Planes)
                .HasForeignKey(x => x.PlaneModelId);

            modelBuilder.Entity<PlaneModel>()
                .HasKey(x => x.PlaneModelId);

            modelBuilder.Entity<PlaneModel>()
                .HasRequired(x => x.PlaneType)
                .WithMany()
                .HasForeignKey(x => x.PlaneTypeId);

            modelBuilder.Entity<PlaneType>()
                .HasKey(x => x.PlaneTypeId);

            modelBuilder.Entity<Rent>()
                .HasKey(x => x.RentId);

            modelBuilder.Entity<Rent>()
                .HasRequired(x => x.Company)
                .WithMany(x => x.Rents)
                .HasForeignKey(x => x.CompanyId);

            modelBuilder.Entity<RentPlane>()
                .HasKey(x => new { x.PlaneId , x.RentId });

            modelBuilder.Entity<RentPlane>()
                .HasRequired(x => x.Plane)
                .WithMany(x => x.Rents)
                .HasForeignKey(x => x.PlaneId);

            modelBuilder.Entity<RentPlane>()
                .HasRequired(x => x.Rent)
                .WithMany(x => x.Planes)
                .HasForeignKey(x => x.RentId);
        }
    }
}
