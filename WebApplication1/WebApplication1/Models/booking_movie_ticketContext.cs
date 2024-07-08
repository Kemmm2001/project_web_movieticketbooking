using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace WebApplication1.Models
{
    public partial class booking_movie_ticketContext : DbContext
    {
        public booking_movie_ticketContext()
        {
        }

        public booking_movie_ticketContext(DbContextOptions<booking_movie_ticketContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Booking> Bookings { get; set; } = null!;
        public virtual DbSet<Cinema> Cinemas { get; set; } = null!;
        public virtual DbSet<Country> Countries { get; set; } = null!;
        public virtual DbSet<Genre> Genres { get; set; } = null!;
        public virtual DbSet<Hall> Halls { get; set; } = null!;
        public virtual DbSet<Image> Images { get; set; } = null!;
        public virtual DbSet<ImageDetail> ImageDetails { get; set; } = null!;
        public virtual DbSet<Movie> Movies { get; set; } = null!;
        public virtual DbSet<Role> Roles { get; set; } = null!;
        public virtual DbSet<Seat> Seats { get; set; } = null!;
        public virtual DbSet<Ticket> Tickets { get; set; } = null!;
        public virtual DbSet<TimeShow> TimeShows { get; set; } = null!;
        public virtual DbSet<User> Users { get; set; } = null!;

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            var builder = new ConfigurationBuilder()
         .SetBasePath(Directory.GetCurrentDirectory())
         .AddJsonFile("appsettings.json", optional: false, reloadOnChange: true);
            IConfiguration config = builder.Build();
            string connectionString = config.GetConnectionString("MyCnn");
            optionsBuilder.UseSqlServer(connectionString);
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Booking>(entity =>
            {
                entity.HasKey(e => new { e.TicketId, e.UserId })
                    .HasName("pk_booking");

                entity.ToTable("Booking");

                entity.Property(e => e.TicketId).HasColumnName("ticket_id");

                entity.Property(e => e.UserId).HasColumnName("user_id");

                entity.Property(e => e.IsDeleted).HasColumnName("is_deleted");

                entity.HasOne(d => d.Ticket)
                    .WithMany(p => p.Bookings)
                    .HasForeignKey(d => d.TicketId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("fk_booking_ticket");

                entity.HasOne(d => d.User)
                    .WithMany(p => p.Bookings)
                    .HasForeignKey(d => d.UserId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("fk_booking_user");
            });

            modelBuilder.Entity<Cinema>(entity =>
            {
                entity.ToTable("Cinema");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.Address)
                    .HasMaxLength(100)
                    .HasColumnName("address");

                entity.Property(e => e.CinemaName)
                    .HasMaxLength(100)
                    .HasColumnName("cinema_name");

                entity.Property(e => e.IsDeleted).HasColumnName("is_deleted");
            });

            modelBuilder.Entity<Country>(entity =>
            {
                entity.ToTable("Country");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.CountryName)
                    .HasMaxLength(100)
                    .HasColumnName("country_name");

                entity.Property(e => e.IsDeleted).HasColumnName("is_deleted");
            });

            modelBuilder.Entity<Genre>(entity =>
            {
                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.GenreName)
                    .HasMaxLength(100)
                    .HasColumnName("genre_name");

                entity.Property(e => e.IsDeleted).HasColumnName("is_deleted");
            });

            modelBuilder.Entity<Hall>(entity =>
            {
                entity.ToTable("Hall");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.CinemaId).HasColumnName("cinema_id");

                entity.Property(e => e.HallName)
                    .HasMaxLength(100)
                    .HasColumnName("hall_name");

                entity.Property(e => e.IsDeleted).HasColumnName("is_deleted");

                entity.Property(e => e.NumberSeat).HasColumnName("number_seat");

                entity.HasOne(d => d.Cinema)
                    .WithMany(p => p.Halls)
                    .HasForeignKey(d => d.CinemaId)
                    .HasConstraintName("fk_hall_cinema");
            });

            modelBuilder.Entity<Image>(entity =>
            {
                entity.ToTable("Image");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.CreateDate)
                    .HasColumnType("date")
                    .HasColumnName("create_date");

                entity.Property(e => e.IsDeleted).HasColumnName("is_deleted");
            });

            modelBuilder.Entity<ImageDetail>(entity =>
            {
                entity.ToTable("ImageDetail");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.ImageId).HasColumnName("image_id");

                entity.Property(e => e.ImageName)
                    .HasMaxLength(100)
                    .HasColumnName("image_name");

                entity.Property(e => e.IsDeleted).HasColumnName("is_deleted");

                entity.HasOne(d => d.Image)
                    .WithMany(p => p.ImageDetails)
                    .HasForeignKey(d => d.ImageId)
                    .HasConstraintName("fk_image");
            });

            modelBuilder.Entity<Movie>(entity =>
            {
                entity.ToTable("Movie");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.CountryId).HasColumnName("country_id");

                entity.Property(e => e.Description).HasColumnName("description");

                entity.Property(e => e.GenreId).HasColumnName("genre_id");

                entity.Property(e => e.ImageId).HasColumnName("image_id");

                entity.Property(e => e.MovieName)
                    .HasMaxLength(100)
                    .HasColumnName("movie_name");

                entity.Property(e => e.ReleaseDate)
                    .HasColumnType("datetime")
                    .HasColumnName("release_date");

                entity.Property(e => e.YearOfManufacture)
                    .HasMaxLength(100)
                    .IsUnicode(false)
                    .HasColumnName("year_of_manufacture");

                entity.HasOne(d => d.Country)
                    .WithMany(p => p.Movies)
                    .HasForeignKey(d => d.CountryId)
                    .HasConstraintName("fk_country_movie");

                entity.HasOne(d => d.Genre)
                    .WithMany(p => p.Movies)
                    .HasForeignKey(d => d.GenreId)
                    .HasConstraintName("fk_genre_movie");

                entity.HasOne(d => d.Image)
                    .WithMany(p => p.Movies)
                    .HasForeignKey(d => d.ImageId)
                    .HasConstraintName("fk_image_movie");
            });

            modelBuilder.Entity<Role>(entity =>
            {
                entity.ToTable("Role");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.IsDeleted).HasColumnName("is_deleted");

                entity.Property(e => e.RoleName)
                    .HasMaxLength(100)
                    .HasColumnName("role_name");
            });

            modelBuilder.Entity<Seat>(entity =>
            {
                entity.ToTable("Seat");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.HallId).HasColumnName("hall_id");

                entity.Property(e => e.IsDeleted).HasColumnName("is_deleted");

                entity.Property(e => e.SeatCode)
                    .HasMaxLength(100)
                    .IsUnicode(false)
                    .HasColumnName("seat_code");

                entity.HasOne(d => d.Hall)
                    .WithMany(p => p.Seats)
                    .HasForeignKey(d => d.HallId)
                    .HasConstraintName("fk_seat_hall");
            });

            modelBuilder.Entity<Ticket>(entity =>
            {
                entity.ToTable("Ticket");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.IsDeleted).HasColumnName("is_deleted");

                entity.Property(e => e.Price).HasColumnName("price");

                entity.Property(e => e.SeatId).HasColumnName("seat_id");

                entity.Property(e => e.SellDate)
                    .HasColumnType("date")
                    .HasColumnName("sell_date");

                entity.Property(e => e.Status).HasColumnName("status");

                entity.Property(e => e.TimeshowId).HasColumnName("timeshow_id");

                entity.HasOne(d => d.Seat)
                    .WithMany(p => p.Tickets)
                    .HasForeignKey(d => d.SeatId)
                    .HasConstraintName("fk_ticket_seat");

                entity.HasOne(d => d.Timeshow)
                    .WithMany(p => p.Tickets)
                    .HasForeignKey(d => d.TimeshowId)
                    .HasConstraintName("fk_ticket_show");
            });

            modelBuilder.Entity<TimeShow>(entity =>
            {
                entity.ToTable("TimeShow");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.CinemaId).HasColumnName("cinema_id");

                entity.Property(e => e.EndTime).HasColumnName("end_time");

                entity.Property(e => e.HallId).HasColumnName("hall_id");

                entity.Property(e => e.IsDeleted).HasColumnName("is_deleted");

                entity.Property(e => e.MovieId).HasColumnName("movie_id");

                entity.Property(e => e.ShowDate)
                    .HasColumnType("date")
                    .HasColumnName("show_date");

                entity.Property(e => e.StartTime).HasColumnName("start_time");

                entity.HasOne(d => d.Cinema)
                    .WithMany(p => p.TimeShows)
                    .HasForeignKey(d => d.CinemaId)
                    .HasConstraintName("fk_cinema_show");

                entity.HasOne(d => d.Hall)
                    .WithMany(p => p.TimeShows)
                    .HasForeignKey(d => d.HallId)
                    .HasConstraintName("fk_hall_show");

                entity.HasOne(d => d.Movie)
                    .WithMany(p => p.TimeShows)
                    .HasForeignKey(d => d.MovieId)
                    .HasConstraintName("fk_movie_show");
            });

            modelBuilder.Entity<User>(entity =>
            {
                entity.ToTable("User");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.Address)
                    .HasMaxLength(100)
                    .HasColumnName("address");

                entity.Property(e => e.CreateDate)
                    .HasColumnType("date")
                    .HasColumnName("create_date");

                entity.Property(e => e.Dob)
                    .HasColumnType("date")
                    .HasColumnName("dob");

                entity.Property(e => e.Email)
                    .HasMaxLength(100)
                    .IsUnicode(false)
                    .HasColumnName("email");

                entity.Property(e => e.FullName)
                    .HasMaxLength(100)
                    .HasColumnName("full_name");

                entity.Property(e => e.Gender).HasColumnName("gender");

                entity.Property(e => e.IsDeleted).HasColumnName("is_deleted");

                entity.Property(e => e.Password)
                    .HasMaxLength(100)
                    .IsUnicode(false)
                    .HasColumnName("password");

                entity.Property(e => e.Phone)
                    .HasMaxLength(10)
                    .IsUnicode(false)
                    .HasColumnName("phone");

                entity.Property(e => e.RoleId).HasColumnName("role_id");

                entity.HasOne(d => d.Role)
                    .WithMany(p => p.Users)
                    .HasForeignKey(d => d.RoleId)
                    .HasConstraintName("fk_role_user");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
