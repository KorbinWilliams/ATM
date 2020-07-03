using System;
using System.Collections.Generic;
using System.Data;
using ATM.Services;
using ATM.Models;
using ATM.Repositories;
using Microsoft.AspNetCore.Mvc;

namespace ATM.Services
{
  public class CardCashService
  {
    private readonly CardsService _cs;
    private readonly CardCashRepository _repo;
    public CardCashService(CardCashRepository repo, CardsService cs)
    {
      _repo = repo;
      _cs = cs;
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

    // internal Cash GetCashByCardId(Card card)
    // {
    //   var exists = _repo.GetCashByCardId(card);
    //   // if (exists == null)
    //   // {
    //   //   throw new Exception("This is not the VaultKeep you are looking for");
    //   // }
    //   // else if (exists.UserId != userId)
    //   // {
    //   //   throw new Exception("Get yer own VaultKeep ya ninnie!");
    //   // }
    //   return exists;
    // }

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

    internal bool VerifyCredentials(int id, int pin, string userId)
    {
      Cash exists = _repo.GetCashByCardId(id);
      Card card = _cs.GetById(id);
      if (exists == null)
      {
        throw new Exception("could not find any accounts associated with that card");
      }
      else if (exists.UserId != userId)
      {
        throw new Exception("You do not own the account associated with this card.");
      }
      else if (card.Pin == 0 || card.Pin != pin)
      {
        throw new Exception("Incorrect information. Please try again.");
      }
      return true;
    }
  }
}

