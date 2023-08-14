namespace Reservation.Common.Model;

public enum ReservationStatus
{
    PENDING = 0,
    SUCCESS = 1
}

public enum ReservationType
{
    HOTEL = 0,
    ACTIVITY = 1
}

public enum ReservationEvent
{
    Hotel_Publish,
    Undetermine
}