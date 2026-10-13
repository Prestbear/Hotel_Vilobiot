using Microsoft.EntityFrameworkCore;
using Hotel_Vilobiot.Models;

namespace Hotel_Vilobiot.Data;

public class DataContext : DbContext
{
    public DbSet<Guest> Users { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        optionsBuilder.UseSqlServer(@"Server=localhost\SQLEXPRESS;Database=master;Trusted_Connection=True;");
    }
}