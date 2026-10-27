using Hotel_Vilobiot.Data.Seeds;
using Hotel_Vilobiot.Models;
using Microsoft.EntityFrameworkCore;

namespace Hotel_Vilobiot.Data;

public class DataContext : DbContext
{
    public DbSet<Guest> Guests { get; set; }
    public DbSet<Hotel> Hotels { get; set; }
    public DbSet<Reservation> Reservations { get; set; }
    public DbSet<Room> Rooms { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        // optionsBuilder.UseSqlServer(@"Server=localhost\SQLEXPRESS;Database=master;Trusted_Connection=True;");// Giorgi
        //optionsBuilder.UseSqlServer(@"Server=localhost\SQLEXPRESS;Database=Hotel_Vilobiot;Trusted_Connection=True;TrustServerCertificate=True;"); // Giorgi 2
        optionsBuilder.UseSqlServer(@"Data Source=(localdb)\MSSQLLocalDB;Initial Catalog=hotel;Integrated Security=True;Connect Timeout=30;Encrypt=True;Trust Server Certificate=False;Application Intent=ReadWrite;Multi Subnet Failover=False;Command Timeout=30"); // - IT Laptop(poop)
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);
        HotelSeed.Seed(modelBuilder);
        RoomSeed.Seed(modelBuilder);
    }
}