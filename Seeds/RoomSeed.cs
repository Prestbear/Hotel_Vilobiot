
using Hotel_Vilobiot.Enum;
using Microsoft.EntityFrameworkCore;

namespace Hotel_Vilobiot.Data.Seeds;

public static class RoomSeed
{
    public static void Seed(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Room>().HasData(
            new Room(101, 1) { Id = 1, HotelId = 1, PricePerNight = 120, RoomType = RoomTypeEnum.small_one, Status = true },
            new Room(102, 1) { Id = 2, HotelId = 1, PricePerNight = 150, RoomType = RoomTypeEnum.small_two, Status = true },
            new Room(103, 1) { Id = 3, HotelId = 1, PricePerNight = 180, RoomType = RoomTypeEnum.medium_one, Status = false },

            new Room(201, 2) { Id = 4, HotelId = 2, PricePerNight = 100, RoomType = RoomTypeEnum.small_one, Status = true },
            new Room(202, 2) { Id = 5, HotelId = 2, PricePerNight = 160, RoomType = RoomTypeEnum.medium_two, Status = true },

            new Room(101, 1) { Id = 6, HotelId = 3, PricePerNight = 200, RoomType = RoomTypeEnum.large_two, Status = true },
            new Room(201, 2) { Id = 7, HotelId = 3, PricePerNight = 300, RoomType = RoomTypeEnum.large_three, Status = true },

            new Room(101, 1) { Id = 8, HotelId = 4, PricePerNight = 250, RoomType = RoomTypeEnum.luxury_one, Status = true },
            new Room(102, 1) { Id = 9, HotelId = 4, PricePerNight = 350, RoomType = RoomTypeEnum.luxury_two, Status = false },

            new Room(301, 3) { Id = 10, HotelId = 5, PricePerNight = 400, RoomType = RoomTypeEnum.luxury_three, Status = true },
            new Room(302, 3) { Id = 11, HotelId = 5, PricePerNight = 500, RoomType = RoomTypeEnum.luxury_four, Status = true },

            new Room(101, 1) { Id = 12, HotelId = 6, PricePerNight = 80, RoomType = RoomTypeEnum.small_one, Status = true },

            new Room(501, 5) { Id = 13, HotelId = 7, PricePerNight = 600, RoomType = RoomTypeEnum.luxury_five, Status = true },

            new Room(201, 2) { Id = 14, HotelId = 8, PricePerNight = 140, RoomType = RoomTypeEnum.medium_one, Status = true },

            new Room(101, 1) { Id = 15, HotelId = 9, PricePerNight = 220, RoomType = RoomTypeEnum.large_three, Status = true },

            new Room(301, 3) { Id = 16, HotelId = 10, PricePerNight = 190, RoomType = RoomTypeEnum.medium_two, Status = false },

            new Room(101, 1) { Id = 17, HotelId = 11, PricePerNight = 70, RoomType = RoomTypeEnum.small_two, Status = true },

            new Room(401, 4) { Id = 18, HotelId = 12, PricePerNight = 320, RoomType = RoomTypeEnum.extra_large_four, Status = true },

            new Room(201, 2) { Id = 19, HotelId = 13, PricePerNight = 240, RoomType = RoomTypeEnum.extra_large_five, Status = true },

            new Room(501, 5) { Id = 20, HotelId = 14, PricePerNight = 550, RoomType = RoomTypeEnum.luxury_five, Status = true }
        );
    }
}
