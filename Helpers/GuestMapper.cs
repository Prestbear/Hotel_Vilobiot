using AutoMapper;
using Hotel_Vilobiot.DTO.Request;
using Hotel_Vilobiot.Models;

namespace Hotel_Vilobiot.Helpers;

public class GuestMapper : Profile
{
    public GuestMapper()
    {
        CreateMap<Guest, RegisterRequest>().ReverseMap();
        CreateMap<Guest, EditGuestRequest>().ReverseMap();
        CreateMap<Guest, LoginRequest>().ReverseMap();

        //Hotel
        CreateMap<Hotel, ReserveReqeuest>().ReverseMap();
        CreateMap<Hotel, CheckOutReqeust>().ReverseMap();




    }
}