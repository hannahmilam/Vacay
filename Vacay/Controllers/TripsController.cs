using System.Collections.Generic;
using System.Threading.Tasks;
using CodeWorks.Auth0Provider;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Vacay.Models;
using Vacay.Services;

namespace Vacay.Controller
{
  [ApiController]
  [Route("api/[controller]")]
  public class TripsController : ControllerBase
  {
    private readonly TripsService _tripsService;
    public TripsController(TripsService tripsService)
    {
      _tripsService = tripsService;
    }

     [HttpGet]
    public ActionResult<List<Trip>> Get()
    {
      try
    {
        var trip = _tripsService.Get();
        return Ok(trip);
    }
    catch (System.Exception e)
    {
       return BadRequest(e.Message);
    }
  }
     [HttpGet("{tripId}")]
    public ActionResult<Trip> Get(int tripId)
    {
      try
    {
        var trip = _tripsService.Get(tripId);
        return Ok(trip);
    }
    catch (System.Exception e)
    {
       return BadRequest(e.Message);
    }
  }
    [Authorize]
    [HttpPost]
    public async Task<ActionResult<Trip>> Create([FromBody] Trip data)
    {
      try
    {
        Account userInfo = await HttpContext.GetUserInfoAsync<Account>();
        data.CreatorId = userInfo.Id;
        var trip = _tripsService.Create(data);
        return Ok(trip);
    }
    catch (System.Exception e)
    {
       return BadRequest(e.Message);
    }
  }

  [Authorize]
  [HttpPut("{tripId}")]
  public async Task<ActionResult<Trip>> Edit(int tripId, [FromBody] Trip data)
  {
    try
    {
        Account userInfo = await HttpContext.GetUserInfoAsync<Account>();
        data.CreatorId = userInfo.Id;
        var updatedtrip = _tripsService.Edit(tripId, data);
        return Ok(updatedtrip);
    }
    catch (System.Exception e)
    {
      return BadRequest(e.Message);
    }
  }

  [Authorize]
  [HttpDelete("{tripId}")]
  public async Task<ActionResult<Trip>> Delete(int tripId)
  {
    try
    {
        Account userInfo = await HttpContext.GetUserInfoAsync<Account>();
        var trip = _tripsService.Delete(tripId);
        return Ok(trip);
    }
    catch (System.Exception e)
    {
      return BadRequest(e.Message);
    }
  }
  }
  }