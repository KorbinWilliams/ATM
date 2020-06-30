using System;
using System.Collections.Generic;
using System.Data;
using ATM.Models;
using ATM.Repositories;

namespace ATM.Services
{
  public class CardCashService
  {
    private readonly CardCashRepository _repo;
    public CardCashService(CardCashRepository repo)
    {
      _repo = repo;
    }

    internal void Create(CardCash newData)
    {
      CardCash exists = _repo.GetById(newData.Id);
      if (exists != null)
      {
        throw new Exception("Relationship already exists");
      }
      // Pretty sure I don't need this on create...
      // else if (exists.UserId != newData.UserId)
      // {
      //   throw new Exception("");
      // }
      _repo.Create(newData);
    }

    internal IEnumerable<Cash> GetCashByCardId(Card card)
    {
      var exists = _repo.GetCashByCardId(card);
      // if (exists == null)
      // {
      //   throw new Exception("This is not the VaultKeep you are looking for");
      // }
      // else if (exists.UserId != userId)
      // {
      //   throw new Exception("Get yer own VaultKeep ya ninnie!");
      // }
      return exists;
    }

    internal string Delete(int cashId, int cardId, string userId)
    {
      CardCash exists = _repo.FindByIds(cashId, cardId);
      if (exists == null)
      {
        throw new Exception("Invalid Id Combination");
      }
      else if (exists.UserId != userId)
      {
        throw new Exception("No tienes estes");
      }
      _repo.Delete(exists.Id);
      return "Successfully Deleted";
    }
  }
}

