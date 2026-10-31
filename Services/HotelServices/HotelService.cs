using AutoMapper;
using Hotel_Vilobiot.Data;
using Hotel_Vilobiot.DTO.Request;

namespace Hotel_Vilobiot.Services.HotelServices;

public class HotelService : IHotelService
{
    private readonly IMapper _mapper;
    private readonly DataContext _context;

    public HotelService()
    {
        
    }

    public bool CancelResrvation(int reservationId)
    {
        throw new NotImplementedException();
    }

    public bool CheckOut(CheckOutReqeust req)
    {
        throw new NotImplementedException();
    }

    public bool ReserveRoom(ReserveReqeuest req)
    {
        throw new NotImplementedException();
    }
}
