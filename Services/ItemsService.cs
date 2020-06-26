using System;
using System.Collections.Generic;
using System.Data;
using Keepr.Models;
using Keepr.Repositories;

namespace Keepr.Services
{
  public class ItemsService
  {
    private readonly ItemsRepository _repo;
    public ItemsService(ItemsRepository repo)
    {
      _repo = repo;
    }
    public IEnumerable<Item> Get()
    {
      var exists = _repo.Get();
      if (exists == null)
      {
        throw new Exception("There are no items");
      }
      return exists;
    }

    public Item Create(Item newItem)
    {
      var newerItem = _repo.Create(newItem);
      return newerItem;
    }

    internal Item GetById(int id)
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

    internal IEnumerable<Item> GetMyItems(string userId)
    {
      var exists = _repo.GetMyItems(userId);
      if (exists == null)
      {
        throw new Exception("You have no items");
      }
      return exists;
    }

    internal string Edit(Item update)
    {
      var exists = GetById(update.Id);
      if (exists == null)
      {
        throw new Exception("Invalid id");
      }
      else if (update.UserId != exists.UserId)
      {
        throw new Exception("You do not own this item peasant!");
      }
      _repo.Edit(update);
      return "Successfully Updated";
    }
  }
}