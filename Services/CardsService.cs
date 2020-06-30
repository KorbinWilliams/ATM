using System;
using System.Collections.Generic;
using System.Data;
using ATM.Models;
using ATM.Repositories;

namespace ATM.Services
{
  public class CardsService
  {
    private readonly CardsRepository _repo;
    public CardsService(CardsRepository repo)
    {
      _repo = repo;
    }
    public IEnumerable<Card> Get()
    {
      var exists = _repo.Get();
      if (exists == null)
      {
        throw new Exception("There are no Cards");
      }
      return exists;
    }

    public Card Create(Card newCard)
    {
      var newerCard = _repo.Create(newCard);
      return newerCard;
    }

    internal Card GetById(int id)
    {
      var exists = _repo.GetById(id);
      if (exists == null)
      {
        throw new Exception("Invalid id");
      }
      return exists;
    }

    internal string Delete(int id, string userId)
    {
      var exists = GetById(id);
      if (exists == null)
      {
        throw new Exception("Invalid id");
      }
      else if (userId != exists.UserId)
      {
        throw new Exception("You do not own this Keep peasant!");
      }
      _repo.Delete(id);
      return "Successfully Destroyed";
    }

    internal IEnumerable<Card> GetMyCards(string userId)
    {
      var exists = _repo.GetMyCards(userId);
      if (exists == null)
      {
        throw new Exception("You have no Cards");
      }
      return exists;
    }

    internal string Edit(Card update)
    {
      var exists = GetById(update.Id);
      if (exists == null)
      {
        throw new Exception("Invalid id");
      }
      else if (update.UserId != exists.UserId)
      {
        throw new Exception("You do not own this Card peasant!");
      }
      _repo.Edit(update);
      return "Successfully Updated";
    }
  }
}