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
  public class CardsController : ControllerBase
  {
    private readonly CardsService _cs;
    private readonly CardCashService _ccs;
    public CardsController(CardsService cs, CardCashService ccs)
    {
      _cs = cs;
      _ccs = ccs;
    }

    [HttpGet]
    public ActionResult<IEnumerable<Card>> Get()
    {
      try
      {
        // NOTE this should be user specific right?
        // var userId = HttpContext.User.FindFirst(ClaimTypes.NameIdentifier).Value;
        return Ok(_cs.Get());
      }
      catch (Exception e)
      {
        return BadRequest(e.Message);
      };
    }

    // TODO pin and # verification
    // TODO Withdrawl verification (CardCashService)
    // TODO Card creation number check and create cardcash table
    // TODO Deposit cash check/change (CardCashService)
    // TODO custom errors
    // TODO Sanitize user inputs

    [HttpGet("verify/{id}/{pin}")]
    [Authorize]
    public ActionResult<bool> VerifyCredentials(int id, int pin)
    {
      try
      {
        var userId = HttpContext.User.FindFirst(ClaimTypes.NameIdentifier).Value;
        return Ok(_ccs.VerifyCredentials(id, pin, userId));
      }
      catch (Exception e)
      {
        return BadRequest(e.Message);
      }
    }

    [HttpGet("mine")]
    [Authorize]
    public ActionResult<IEnumerable<Card>> GetMyCards()
    {
      try
      {
        var userId = HttpContext.User.FindFirst(ClaimTypes.NameIdentifier).Value;
        return Ok(_cs.GetMyCards(userId));
      }
      catch (Exception e)
      {
        return BadRequest(e.Message);
      };
    }

    // Probably gonna need a get all for users private Items

    [HttpGet("{id}")]
    public ActionResult<Card> Get(int id)
    {
      try
      {
        return Ok(_cs.GetById(id));
      }
      catch (Exception e)
      {
        return BadRequest(e.Message);
      }
    }

    [HttpPost]
    [Authorize]
    public ActionResult<Card> Post([FromBody] Card newCard)
    {
      try
      {
        var userId = HttpContext.User.FindFirst(ClaimTypes.NameIdentifier).Value;
        newCard.UserId = userId;
        return Ok(_cs.Create(newCard));
      }
      catch (Exception e)
      {
        return BadRequest(e.Message);
      }
    }

    [HttpPut("{id}")]
    [Authorize]
    public ActionResult<Card> Put([FromBody] Card update)
    {
      try
      {
        var userId = HttpContext.User.FindFirst(ClaimTypes.NameIdentifier).Value;
        update.UserId = userId;
        return Ok(_cs.Edit(update));
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
        return Ok(_cs.Delete(id, userId));
      }
      catch (Exception e)
      {
        return BadRequest(e.Message);
      }
    }
  }
}