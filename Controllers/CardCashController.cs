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
  public class CardCashController : ControllerBase
  {
    private readonly CardCashService _ccs;
    private readonly CardsService _cs;
    public CardCashController(CardCashService ccs, CardsService cs)
    {
      _ccs = ccs;
      _cs = cs;
    }

    // [HttpGet("{vaultId}/cash")]
    // [Authorize]
    // public ActionResult<IEnumerable<Cash>> GetCashByCardId(int cardId)
    // {
    //   try
    //   {
    //     var userId = HttpContext.User.FindFirst(ClaimTypes.NameIdentifier).Value;
    //     Card card = _cs.GetById(cardId);
    //     return Ok(_ccs.GetCashByCardId(card));
    //   }
    //   catch (Exception e)
    //   {
    //     return BadRequest(e.Message);
    //   }
    // }

    [HttpPost]
    [Authorize]
    public ActionResult<CardCash> Create([FromBody] CardCash newData)
    {
      try
      {
        var userId = HttpContext.User.FindFirst(ClaimTypes.NameIdentifier).Value;
        newData.UserId = userId;
        _ccs.Create(newData);
        return Ok("Success");
      }
      catch (Exception e)
      {
        return BadRequest(e.Message);
      }
    }

    [HttpDelete("{vaultId}/cash/{cashId}")]
    [Authorize]
    public ActionResult<String> Delete([FromBody] int cardId, int cashId)
    {
      try
      {
        // 415
        var userId = HttpContext.User.FindFirst(ClaimTypes.NameIdentifier).Value;
        return Ok(_ccs.Delete(cardId, cashId, userId));
      }
      catch (Exception e)
      {
        return BadRequest(e.Message);
      }
    }
  }
}

