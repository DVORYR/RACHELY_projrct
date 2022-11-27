using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

#nullable disable

namespace DAL.Models
{
    public partial class tripContext : DbContext
    {
        public tripContext()
        {
        }

        public tripContext(DbContextOptions<tripContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Area> Areas { get; set; }
        public virtual DbSet<Attraction> Attractions { get; set; }
        public virtual DbSet<PreviousTrip> PreviousTrips { get; set; }
        public virtual DbSet<Restaurant> Restaurants { get; set; }
        public virtual DbSet<Sitetype> Sitetypes { get; set; }
        public virtual DbSet<SubArea> SubAreas { get; set; }
        public virtual DbSet<TourGuide> TourGuides { get; set; }
        public virtual DbSet<Transportation> Transportations { get; set; }
        public virtual DbSet<TravelItinerary> TravelItineraries { get; set; }
        public virtual DbSet<TravelSite> TravelSites { get; set; }
        public virtual DbSet<User> Users { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
                optionsBuilder.UseSqlServer("Server= AGRIPAS-CLASS5-\\SQLEXPRESS;Database= trip;Trusted_Connection=True;");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Area>(entity =>
            {
                entity.HasKey(e => e.IdArea);

                entity.ToTable("area");

                entity.Property(e => e.IdArea)
                    .ValueGeneratedNever()
                    .HasColumnName("idArea");

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("name");
            });

            modelBuilder.Entity<Attraction>(entity =>
            {
                entity.HasKey(e => e.IdAttractions);

                entity.ToTable("attractions");

                entity.Property(e => e.IdAttractions).HasColumnName("idAttractions");

                entity.Property(e => e.Address)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("address");

                entity.Property(e => e.AreaId).HasColumnName("areaId");

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("name");

                entity.Property(e => e.Phone).HasColumnName("phone");

                entity.Property(e => e.Price).HasColumnName("price");

                entity.HasOne(d => d.Area)
                    .WithMany(p => p.Attractions)
                    .HasForeignKey(d => d.AreaId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_attractions_subArea");
            });

            modelBuilder.Entity<PreviousTrip>(entity =>
            {
                entity.HasKey(e => e.IdPreviousTrips);

                entity.Property(e => e.IdPreviousTrips).HasColumnName("idPreviousTrips");

                entity.Property(e => e.Date)
                    .HasColumnType("date")
                    .HasColumnName("date");

                entity.Property(e => e.UserId)
                    .IsRequired()
                    .HasMaxLength(9)
                    .IsUnicode(false)
                    .HasColumnName("userId");

                entity.HasOne(d => d.User)
                    .WithMany(p => p.PreviousTrips)
                    .HasForeignKey(d => d.UserId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_PreviousTrips_users");
            });

            modelBuilder.Entity<Restaurant>(entity =>
            {
                entity.HasKey(e => e.IdRestaurants);

                entity.ToTable("restaurants");

                entity.Property(e => e.IdRestaurants).HasColumnName("idRestaurants");

                entity.Property(e => e.Address)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("address");

                entity.Property(e => e.AreaId).HasColumnName("areaId");

                entity.Property(e => e.MeatyDairy)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("meaty/dairy");

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("name");

                entity.Property(e => e.Phone).HasColumnName("phone");

                entity.HasOne(d => d.Area)
                    .WithMany(p => p.Restaurants)
                    .HasForeignKey(d => d.AreaId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_restaurants_subArea");
            });

            modelBuilder.Entity<Sitetype>(entity =>
            {
                entity.HasKey(e => e.IdSiteType);

                entity.ToTable("Sitetype");

                entity.Property(e => e.IdSiteType).HasColumnName("idSiteType");

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("name");
            });

            modelBuilder.Entity<SubArea>(entity =>
            {
                entity.HasKey(e => e.IdSubArea);

                entity.ToTable("subArea");

                entity.Property(e => e.IdSubArea).HasColumnName("idSubArea");

                entity.Property(e => e.Area).HasColumnName("area");

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("name");

                entity.HasOne(d => d.AreaNavigation)
                    .WithMany(p => p.SubAreas)
                    .HasForeignKey(d => d.Area)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_subArea_area");
            });

            modelBuilder.Entity<TourGuide>(entity =>
            {
                entity.HasKey(e => e.IdTourGuides);

                entity.Property(e => e.IdTourGuides).HasColumnName("idTourGuides");

                entity.Property(e => e.AreaId).HasColumnName("areaId");

                entity.Property(e => e.FullName)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("fullName");

                entity.Property(e => e.Gender)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("gender");

                entity.Property(e => e.Phone).HasColumnName("phone");

                entity.Property(e => e.Recommendations)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.HasOne(d => d.Area)
                    .WithMany(p => p.TourGuides)
                    .HasForeignKey(d => d.AreaId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_TourGuides_subArea");
            });

            modelBuilder.Entity<Transportation>(entity =>
            {
                entity.HasKey(e => e.IdTransportation);

                entity.ToTable("Transportation");

                entity.Property(e => e.IdTransportation).HasColumnName("idTransportation");

                entity.Property(e => e.AreaId).HasColumnName("areaId");

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("name");

                entity.Property(e => e.Phone).HasColumnName("phone");

                entity.Property(e => e.Recommendations)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.HasOne(d => d.Area)
                    .WithMany(p => p.Transportations)
                    .HasForeignKey(d => d.AreaId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Transportation_area");
            });

            modelBuilder.Entity<TravelItinerary>(entity =>
            {
                entity.HasKey(e => e.IdTravelItineraries);

                entity.ToTable("travelItineraries");

                entity.Property(e => e.IdTravelItineraries)
                    .ValueGeneratedOnAdd()
                    .HasColumnName("idTravelItineraries");

                entity.Property(e => e.IdPreviousTrips).HasColumnName("idPreviousTrips");

                entity.Property(e => e.StartTime).HasColumnName("startTime");

                entity.Property(e => e.TravelSitesId).HasColumnName("travelSitesId");

                entity.HasOne(d => d.IdPreviousTripsNavigation)
                    .WithMany(p => p.TravelItineraries)
                    .HasForeignKey(d => d.IdPreviousTrips)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_travelItineraries_PreviousTrips");

                entity.HasOne(d => d.IdTravelItinerariesNavigation)
                    .WithOne(p => p.TravelItinerary)
                    .HasForeignKey<TravelItinerary>(d => d.IdTravelItineraries)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_travelItineraries_TravelSite");
            });

            modelBuilder.Entity<TravelSite>(entity =>
            {
                entity.HasKey(e => e.IdTravelsite);

                entity.ToTable("TravelSite");

                entity.Property(e => e.IdTravelsite).HasColumnName("idTravelsite");

                entity.Property(e => e.Accessibility).HasColumnName("accessibility");

                entity.Property(e => e.Address)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("address");

                entity.Property(e => e.IdArea).HasColumnName("idArea");

                entity.Property(e => e.IdSiteType).HasColumnName("idSiteType");

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("name");

                entity.Property(e => e.Payment).HasColumnName("payment");

                entity.Property(e => e.SuitableFor)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.Time).HasColumnName("time");

                entity.HasOne(d => d.IdAreaNavigation)
                    .WithMany(p => p.TravelSites)
                    .HasForeignKey(d => d.IdArea)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_TravelSite_area");

                entity.HasOne(d => d.IdSiteTypeNavigation)
                    .WithMany(p => p.TravelSites)
                    .HasForeignKey(d => d.IdSiteType)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_TravelSite_Sitetype");
            });

            modelBuilder.Entity<User>(entity =>
            {
                entity.ToTable("users");

                entity.Property(e => e.Id)
                    .HasMaxLength(9)
                    .IsUnicode(false)
                    .HasColumnName("id");

                entity.Property(e => e.City)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("city");

                entity.Property(e => e.Email)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("email");

                entity.Property(e => e.FirstName)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("firstName");

                entity.Property(e => e.LastName)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("lastName");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
