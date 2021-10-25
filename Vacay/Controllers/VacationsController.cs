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
  public class VacationsController : ControllerBase
  {
    private readonly VacationsService _vacationsService;
    public VacationsController(VacationsService vacationsService)
    {
      _vacationsService = vacationsService;
    }

     [HttpGet]
    public ActionResult<List<Vacation>> Get()
    {
      try
    {
        var vacations = _vacationsService.Get();
        return Ok(vacations);
    }
    catch (System.Exception e)
    {
       return BadRequest(e.Message);
    }
  }
     [HttpGet("{vacationId}")]
    public ActionResult<Vacation> Get(int vacationId)
    {
      try
    {
        var vacation = _vacationsService.Get(vacationId);
        return Ok(vacation);
    }
    catch (System.Exception e)
    {
       return BadRequest(e.Message);
    }
  }
    [Authorize]
    [HttpPost]
    public async Task<ActionResult<Vacation>> Create([FromBody] Vacation data)
    {
      try
    {
        Account userInfo = await HttpContext.GetUserInfoAsync<Account>();
        data.CreatorId = userInfo.Id;
        var vacation = _vacationsService.Create(data);
        return Ok(vacation);
    }
    catch (System.Exception e)
    {
       return BadRequest(e.Message);
    }
  }

  [Authorize]
  [HttpPut("{vacationId}")]
  public async Task<ActionResult<Vacation>> Edit(int vacationId, [FromBody] Vacation data)
  {
    try
    {
        Account userInfo = await HttpContext.GetUserInfoAsync<Account>();
        data.CreatorId = userInfo.Id;
        var updatedVacation = _vacationsService.Edit(vacationId, data);
        return Ok(updatedVacation);
    }
    catch (System.Exception e)
    {
      return BadRequest(e.Message);
    }
  }

  [Authorize]
  [HttpDelete("{vacationId}")]
  public async Task<ActionResult<Vacation>> Delete(int vacationId)
  {
    try
    {
        Account userInfo = await HttpContext.GetUserInfoAsync<Account>();
        var vacation = _vacationsService.Delete(vacationId);
        return Ok(vacation);
    }
    catch (System.Exception e)
    {
      return BadRequest(e.Message);
    }
  }
  }
  }