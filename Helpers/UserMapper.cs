using AutoMapper;
using Microsoft.AspNetCore.Identity.Data;
using Hotel_Vilobiot.DTO.Request;
using Hotel_Vilobiot.Models;
using RegisterRequest = Microsoft.AspNetCore.Identity.Data.RegisterRequest;

namespace Hotel_Vilobiot.Helpers;

public class UserMapper : Profile
{
    public UserMapper()
    {
        CreateMap<Guest, RegisterRequest>().ReverseMap();
        CreateMap<Guest, EditGuestRequest>().ReverseMap();
    }
}