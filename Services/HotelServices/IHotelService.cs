using Hotel_Vilobiot.DTO.Request;

namespace Hotel_Vilobiot.Services.HotelServices;

public interface IHotelService
{
    public bool ReserveRoom(ReserveReqeuest req);
    public bool CancelResrvation(int reservationId);
    public bool CheckOut(CheckOutReqeust req);
}
