
using Hotel_Vilobiot.Models;
using Microsoft.EntityFrameworkCore;

namespace Hotel_Vilobiot.Data.Seeds;

public static class HotelSeed
{
    public static void Seed(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Hotel>().HasData(
            new Hotel("Vilobiot Grand Hotel", "Tbilisi", 5m) { Id = 1 },
            new Hotel("Vilobiot City Hotel", "Batumi", 4m) { Id = 2 },
            new Hotel("Vilobiot Mountain Hotel", "Gudauri", 4.5m) { Id = 3 },
            new Hotel("Vilobiot Palace", "Kutaisi", 5m) { Id = 4 },
            new Hotel("Vilobiot Seaside Resort", "Batumi", 4.5m) { Id = 5 },
            new Hotel("Vilobiot Garden Hotel", "Tbilisi", 3.5m) { Id = 6 },
            new Hotel("Vilobiot Royal Suites", "Tbilisi", 5m) { Id = 7 },
            new Hotel("Vilobiot Riverside", "Kutaisi", 4m) { Id = 8 },
            new Hotel("Vilobiot Mountain View", "Bakuriani", 4m) { Id = 9 },
            new Hotel("Vilobiot Coastline Hotel", "Kobuleti", 4m) { Id = 10 },
            new Hotel("Vilobiot Central Inn", "Rustavi", 3m) { Id = 11 },
            new Hotel("Vilobiot Wine Resort", "Telavi", 4.5m) { Id = 12 },
            new Hotel("Vilobiot Forest Lodge", "Borjomi", 4m) { Id = 13 },
            new Hotel("Vilobiot Black Sea Palace", "Batumi", 5m) { Id = 14 },
            new Hotel("Vilobiot Old Town Hotel", "Tbilisi", 4m) { Id = 15 }
        );
    }
}
