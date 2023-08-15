using Activity.Core.Contract.Common;
using Activity.Core.Contract.Persistence;
using Microsoft.Extensions.Configuration;
using System.Net.Http;
using System.Net.Http.Headers;

namespace Activity.Persistence.Service;

public class ActivityService : IActivityService
{
    private HttpClient _httpClient;
    private readonly string _reservationAPI;
    private readonly string _token;

    public ActivityService(HttpClient httpClient, IConfiguration configuration, IClaimPrincipalAccessor claimPrincipalAccessor)
    {
        _httpClient = httpClient;
        _reservationAPI = configuration["ServiceUrls:ReservationAPI"]!;
        _token = claimPrincipalAccessor.AccessToken;
    }
    public async Task BookActivity(int id)
    {        
        //message to be send 
        HttpRequestMessage message = new HttpRequestMessage();
        message.Headers.Add("Accept", "application/json");
        message.RequestUri = new Uri($"{_reservationAPI}/BookActivity/{id}");
        message.Method = HttpMethod.Post;

        _httpClient.DefaultRequestHeaders.Clear();
        _httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", _token);
        await _httpClient.SendAsync(message);        
    }
}
