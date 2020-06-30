using System;
using System.Collections.Generic;
using System.Data;
using ATM.Models;
using Dapper;

namespace ATM.Repositories
{
  public class CardsRepository
  {
    private readonly IDbConnection _db;

    public CardsRepository(IDbConnection db)
    {
      _db = db;
    }

    internal IEnumerable<Card> Get()
    {
      // string sql = "SELECT * FROM cards WHERE userId = @UserId";
      string sql = @"SELECT * FROM cards WHERE isPrivate = 0";
      return _db.Query<Card>(sql);
    }

    internal Card GetById(int id)
    {
      string sql = @"SELECT * FROM cards WHERE id = @id";
      return _db.QueryFirstOrDefault<Card>(sql, new { id });
    }

    internal Card Create(Card CardData)
    {
      string sql = @"INSERT INTO cards (userId, name, description, img, isPrivate) VALUES (@UserId, @Name, @Description, @Img, @IsPrivate);
      SELECT LAST_INSERT_ID();";
      int id = _db.ExecuteScalar<int>(sql, CardData);
      CardData.Id = id;
      return CardData;
    }

    internal void Edit(Card update)
    {
      string sql = @"UPDATE cards SET name = @Name, description = @Description, img = @img, isPrivate = @IsPrivate, views = @Views, shares = @Shares, cards = @Cards WHERE id = @Id";
      _db.Execute(sql, update);
    }

    internal IEnumerable<Card> GetMyCards(string userId)
    {
      string sql = @"SELECT * FROM cards WHERE userId = @UserId";
      return _db.Query<Card>(sql, new { userId });
    }

    internal void Delete(int id)
    {
      string sql = @"DELETE FROM cards WHERE id = @id";
      _db.Execute(sql, new { id });
    }

  }
}

// //     public int Id { get; set; }
//     public string UserId { get; set; }
//     public string Cardholder { get; set; }
//     public string Description { get; set; }
//     public string Img { get; set; }
//     public bool IsPrivate { get; set; }
//     public int Views { get; set; }
//     public int Shares { get; set; }
//     public int Keeps { get; set; }
