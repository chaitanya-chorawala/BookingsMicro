namespace Reservation.Common.Model;

public class GenericResponseWithPaging<T>
{
    public T Data { get; set; }
    public IEnumerable<PagingResponse> Pagination { get; set; }
}
