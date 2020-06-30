using System;
using System.Collections.Generic;
using System.Data;
using ATM.Models;
using ATM.Repositories;

namespace ATM.Services
{
  public class CashService
  {
    private readonly CashRepository _repo;
    public CashService(CashRepository repo)
    {
      _repo = repo;
    }
    public IEnumerable<Cash> Get()
    {
      var exists = _repo.Get();
      if (exists == null)
      {
        throw new Exception("There are no Cashs");
      }
      return exists;
    }

    public Cash Create(Cash newCash)
    {
      var newerCash = _repo.Create(newCash);
      return newerCash;
    }

    internal Cash GetById(int id)
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
        throw new Exception("You do not own this Cash peasant!");
      }
      _repo.Delete(id);
      return "Successfully Destroyed";
    }

    internal IEnumerable<Cash> GetMyCash(string userId)
    {
      var exists = _repo.GetMyCash(userId);
      if (exists == null)
      {
        throw new Exception("You have no Cash");
      }
      return exists;
    }

    internal string Edit(Cash update)
    {
      var exists = GetById(update.Id);
      if (exists == null)
      {
        throw new Exception("Invalid id");
      }
      else if (update.UserId != exists.UserId)
      {
        throw new Exception("You do not own this Cash peasant!");
      }
      _repo.Edit(update);
      return "Successfully Updated";
    }
  }
}