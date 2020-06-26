using System;
using System.Collections.Generic;
using System.Data;
using Keepr.Models;
using Dapper;

namespace Keepr.Repositories
{
  public class ItemsRepository
  {
    private readonly IDbConnection _db;

    public ItemsRepository(IDbConnection db)
    {
      _db = db;
    }

    internal IEnumerable<Item> Get()
    {
      // string sql = "IF isPrivate = 0 OR userId = @UserId SELECT * FROM keeps END IF";
      string sql = @"SELECT * FROM items WHERE isPrivate = 0";
      return _db.Query<Item>(sql);
    }

    internal Item GetById(int id)
    {
      string sql = @"SELECT * FROM items WHERE id = @id";
      return _db.QueryFirstOrDefault<Item>(sql, new { id });
    }

    internal Item Create(Item ItemData)
    {
      string sql = @"INSERT INTO items (userId, name, description, img, isPrivate) VALUES (@UserId, @Name, @Description, @Img, @IsPrivate);
      SELECT LAST_INSERT_ID();";
      int id = _db.ExecuteScalar<int>(sql, ItemData);
      ItemData.Id = id;
      return ItemData;
    }

    internal void Edit(Item update)
    {
      string sql = @"UPDATE items SET name = @Name, description = @Description, img = @img, isPrivate = @IsPrivate, views = @Views, shares = @Shares, items = @Items WHERE id = @Id";
      _db.Execute(sql, update);
    }

    internal IEnumerable<Item> GetMyItems(string userId)
    {
      string sql = @"SELECT * FROM items WHERE userId = @UserId";
      return _db.Query<Item>(sql, new { userId });
    }

    internal void Delete(int id)
    {
      string sql = @"DELETE FROM items WHERE id = @id";
      _db.Execute(sql, new { id });
    }

  }
}

// //     public int Id { get; set; }
//     public string UserId { get; set; }
//     public string Name { get; set; }
//     public string Description { get; set; }
//     public string Img { get; set; }
//     public bool IsPrivate { get; set; }
//     public int Views { get; set; }
//     public int Shares { get; set; }
//     public int Keeps { get; set; }
