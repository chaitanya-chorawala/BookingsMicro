namespace Reservation.Common.Model;

public class PagingResponse
{
    public int? CurrentPageIndex { get; set; }
    public int? PreviousPageIndex { get; set; }
    public int? NextPageIndex { get; set; }
    public int? CurrentPageSize { get; set; }
    public int? TotalRecord { get; set; }
}
