using AutoMapper;
using Microsoft.AspNetCore.Identity.Data;
using Hotel_Vilobiot.DTO.Request;
using Hotel_Vilobiot.Models;
using RegisterRequest = Microsoft.AspNetCore.Identity.Data.RegisterRequest;

namespace Hotel_Vilobiot.Helpers;

public class GuestMapper : Profile
{
    public GuestMapper()
    {
        CreateMap<Guest, RegisterRequest>().ReverseMap();
        CreateMap<Guest, EditGuestRequest>().ReverseMap();
    }
}