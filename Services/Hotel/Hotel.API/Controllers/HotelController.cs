using Hotel.Common.Model;
using Hotel.Core.Contract.Persistence;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.DataProtection.KeyManagement;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Caching.Distributed;
using System.Text.Json;

namespace Hotel.API.Controllers;

[Route("api/[controller]")]
[ApiController]
public class HotelController : ControllerBase
{
    private readonly IHotelRepository _hotelRepository;
    private readonly IHotelService _hotelService;
    private readonly IDistributedCache _cache;

    public HotelController(IHotelRepository hotelRepository, IHotelService hotelService, IDistributedCache cache)
    {
        _hotelRepository = hotelRepository;
        _hotelService = hotelService;
        _cache = cache;
    }

    /// <summary>
    /// List all hotels
    /// </summary>
    /// <returns></returns>         
    [HttpGet("ListAllHotel")]
    public async Task<IActionResult> ListAllHotel()
    {
        try
        {
            string cacheKey = "hotelList";            

            var cacheStr = await _cache.GetStringAsync(cacheKey);
            if (!string.IsNullOrEmpty(cacheStr))
            {
                var cachedHotelList = JsonSerializer.Deserialize<IEnumerable<HotelResponse>>(cacheStr);
                return Ok(cachedHotelList);
            }  
            
            var hotelList = await _hotelRepository.HotelList();
            cacheStr = JsonSerializer.Serialize(hotelList);

            var cacheEntryOptions = new DistributedCacheEntryOptions()
                        .SetSlidingExpiration(TimeSpan.FromSeconds(60))
                        .SetAbsoluteExpiration(TimeSpan.FromSeconds(3600));

            await _cache.SetStringAsync(cacheKey, cacheStr, cacheEntryOptions);

            return Ok(hotelList);
        }
        catch (Exception)
        {
            throw;
        }
    }
    
    /// <summary>
    /// Get Hotel By Id
    /// </summary>
    /// <param name="id"></param>
    /// <returns></returns>
    [HttpGet("GetHotelById/{id:int}")]
    public async Task<IActionResult> GetHotelById(int id)
    {
        try
        {
            var hotel = await _hotelRepository.GetHotelById(id);
            return Ok(hotel);
        }
        catch (Exception)
        {
            throw;
        }
    }

    /// <summary>
    /// Book hotel By Id
    /// </summary>
    /// <param name="id"></param>
    /// <returns></returns>    
    [Authorize]
    [HttpPost("BookHotel/{id:int}")]
    public async Task<IActionResult> BookHotel(int id)
    {
        try
        {
            await _hotelService.BookHotel(id);
            return Ok();
        }
        catch (Exception)
        {
            throw;
        }
    }
}
