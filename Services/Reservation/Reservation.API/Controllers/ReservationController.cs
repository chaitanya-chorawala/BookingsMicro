using Reservation.Common.Model;
using Reservation.Core.Contract.Persistence;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.DataProtection.KeyManagement;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Caching.Distributed;
using System.Text.Json;

namespace Reservation.API.Controllers;

[Route("api/[controller]")]
[ApiController]
public class ReservationController : ControllerBase
{
    private readonly IReservationRepository _reservationRepository;
    private readonly IReservationService _reservationService;
    private readonly IDistributedCache _cache;

    public ReservationController(IReservationRepository reservationRepository, IReservationService reservationService, IDistributedCache cache)
    {
        _reservationRepository = reservationRepository;
        _reservationService = reservationService;
        _cache = cache;
    }

    /// <summary>
    /// List all reservations
    /// </summary>
    /// <returns></returns>     
    [AllowAnonymous]
    [HttpGet("ListAllReservation")]
    public async Task<IActionResult> ListAllReservation()
    {
        try
        {
            string cacheKey = "reservationList";            

            var cacheStr = await _cache.GetStringAsync(cacheKey);
            if (!string.IsNullOrEmpty(cacheStr))
            {
                var cachedReservationList = JsonSerializer.Deserialize<IEnumerable<ReservationResponse>>(cacheStr);
                return Ok(cachedReservationList);
            }  
            
            var reservationList = await _reservationRepository.ReservationList();
            cacheStr = JsonSerializer.Serialize(reservationList);
            _cache.SetString(cacheKey, cacheStr);

            return Ok(reservationList);
        }
        catch (Exception)
        {
            throw;
        }
    }
    
    /// <summary>
    /// Get Reservation By Id
    /// </summary>
    /// <param name="id"></param>
    /// <returns></returns>
    [HttpGet("GetReservationById/{id:int}")]
    public async Task<IActionResult> GetReservationById(int id)
    {
        try
        {
            var reservation = await _reservationRepository.GetReservationById(id);
            return Ok(reservation);
        }
        catch (Exception)
        {
            throw;
        }
    }

    /// <summary>
    /// Book activity By Id
    /// </summary>
    /// <param name="activityid"></param>
    /// <returns></returns>    
    [HttpPost("BookActivity/{activityid:int}")]
    public async Task<IActionResult> BookActivity(int activityid)
    {
        try
        {
            await _reservationService.BookActivity(activityid,"");
            return Ok();
        }
        catch (Exception)
        {
            throw;
        }
    }
}
