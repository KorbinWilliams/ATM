using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using ATM.Models;
using ATM.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace ATM.Controllers
{
  [ApiController]
  [Route("api/[controller]")]
  public class CashController : ControllerBase
  {
    private readonly CashService _cas;
    public CashController(CashService cas)
    {
      _cas = cas;
    }
    [HttpGet]
    public ActionResult<IEnumerable<Cash>> Get()
    {
      try
      {
        // var userId = HttpContext.User.FindFirst(ClaimTypes.NameIdentifier).Value;
        return Ok(_cas.Get());
      }
      catch (Exception e)
      {
        return BadRequest(e.Message);
      };
    }

    [HttpGet("mine")]
    [Authorize]
    public ActionResult<IEnumerable<Cash>> GetMyCashs()
    {
      try
      {
        var userId = HttpContext.User.FindFirst(ClaimTypes.NameIdentifier).Value;
        return Ok(_cas.GetMyCash(userId));
      }
      catch (Exception e)
      {
        return BadRequest(e.Message);
      };
    }

    // Probably gonna need a get all for users private Items

    [HttpGet("{id}")]
    public ActionResult<Cash> Get(int id)
    {
      try
      {
        return Ok(_cas.GetById(id));
      }
      catch (Exception e)
      {
        return BadRequest(e.Message);
      }
    }

    // FIXME Need to change POST for cash 
    [HttpPost]
    [Authorize]
    public ActionResult<Cash> Post([FromBody] Cash newCash)
    {
      try
      {
        var userId = HttpContext.User.FindFirst(ClaimTypes.NameIdentifier).Value;
        newCash.UserId = userId;
        return Ok(_cas.Create(newCash));
      }
      catch (Exception e)
      {
        return BadRequest(e.Message);
      }
    }

    [HttpPut("{id}")]
    [Authorize]
    public ActionResult<Cash> Put([FromBody] Cash update)
    {
      try
      {
        var userId = HttpContext.User.FindFirst(ClaimTypes.NameIdentifier).Value;
        update.UserId = userId;
        return Ok(_cas.Edit(update));
      }
      catch (Exception e)
      {
        return BadRequest(e.Message);
      }
    }

    [HttpDelete("{id}")]
    [Authorize]
    public ActionResult<String> Delete(int id)
    {
      try
      {
        var userId = HttpContext.User.FindFirst(ClaimTypes.NameIdentifier).Value;
        return Ok(_cas.Delete(id, userId));
      }
      catch (Exception e)
      {
        return BadRequest(e.Message);
      }
    }
  }
}