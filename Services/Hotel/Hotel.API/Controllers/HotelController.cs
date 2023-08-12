using Hotel.Core.Contract.Persistence;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Hotel.API.Controllers;

[Route("api/[controller]")]
[ApiController, Authorize]
public class HotelController : ControllerBase
{
    private readonly IHotelRepository _hotelRepository;

    public HotelController(IHotelRepository hotelRepository)
    {
        _hotelRepository = hotelRepository;
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
            var hotelList = await _hotelRepository.GetHotelById(id);
            return Ok(hotelList);
        }
        catch (Exception)
        {
            throw;
        }
    }
}
