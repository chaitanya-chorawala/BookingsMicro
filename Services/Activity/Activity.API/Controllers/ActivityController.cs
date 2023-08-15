using Activity.Core.Contract.Persistence;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Activity.API.Controllers;

[Route("api/[controller]")]
[ApiController]
public class ActivityController : ControllerBase
{
    private readonly IActivityRepository _activityRepository;
    private readonly IActivityService _activityService;

    public ActivityController(IActivityRepository activityRepository, IActivityService activityService)
    {
        _activityRepository = activityRepository;
        _activityService = activityService;
    }

    /// <summary>
    /// List all activities
    /// </summary>
    /// <returns></returns>         
    [HttpGet("ListAllActivity")]
    public async Task<IActionResult> ListAllActivity()
    {
        try
        {
            var activityList = await _activityRepository.ActivityList();
            return Ok(activityList);
        }
        catch (Exception)
        {
            throw;
        }
    }
    
    /// <summary>
    /// Get Activity By Id
    /// </summary>
    /// <param name="id"></param>
    /// <returns></returns>
    [HttpGet("GetActivityById/{id:int}")]
    public async Task<IActionResult> GetActivityById(int id)
    {
        try
        {
            var activityList = await _activityRepository.GetActivityById(id);
            return Ok(activityList);
        }
        catch (Exception)
        {
            throw;
        }
    }

    [HttpPost("BookActivity/{id:int}")]
    public async Task<IActionResult> BookActivity(int id)
    {
        try
        {
            await _activityService.BookActivity(id);
            return Ok();
        }
        catch (Exception)
        {
            throw;
        }
    }
}
