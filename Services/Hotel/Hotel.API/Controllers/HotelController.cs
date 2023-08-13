using Hotel.Core.Contract.Persistence;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Hotel.API.Controllers;

[Route("api/[controller]")]
[ApiController]
public class HotelController : ControllerBase
{
    private readonly IHotelRepository _hotelRepository;
    private readonly IHotelService _hotelService;

    public HotelController(IHotelRepository hotelRepository, IHotelService hotelService)
    {
        _hotelRepository = hotelRepository;
        _hotelService = hotelService;
    }

    /// <summary>
    /// List all hotels
    /// </summary>
    /// <returns></returns>     
    [AllowAnonymous]
    [HttpGet("ListAllHotel")]
    public async Task<IActionResult> ListAllHotel()
    {
        try
        {
            var hotelList = await _hotelRepository.HotelList();
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
