using System;
using System.Collections.Generic;
using System.Data;
using ATM.Models;
using Dapper;

namespace ATM.Repositories
{
  public class CashRepository
  {
    private readonly IDbConnection _db;

    public CashRepository(IDbConnection db)
    {
      _db = db;
    }

    internal IEnumerable<Cash> Get()
    {
      // string sql = "SELECT * FROM cards WHERE userId = @UserId";
      string sql = @"SELECT * FROM cash WHERE isPrivate = 0";
      return _db.Query<Cash>(sql);
    }

    internal Cash GetById(int id)
    {
      string sql = @"SELECT * FROM cash WHERE id = @id";
      return _db.QueryFirstOrDefault<Cash>(sql, new { id });
    }

    internal Cash Create(Cash CashData)
    {
      string sql = @"INSERT INTO cash (userId, name, description, img, isPrivate) VALUES (@UserId, @Name, @Description, @Img, @IsPrivate);
      SELECT LAST_INSERT_ID();";
      int id = _db.ExecuteScalar<int>(sql, CashData);
      CashData.Id = id;
      return CashData;
    }

    internal void Edit(Cash update)
    {
      string sql = @"UPDATE cash SET name = @Name, description = @Description, img = @img, isPrivate = @IsPrivate, views = @Views, shares = @Shares, cash = @Cash WHERE id = @Id";
      _db.Execute(sql, update);
    }

    internal IEnumerable<Cash> GetMyCash(string userId)
    {
      string sql = @"SELECT * FROM cash WHERE userId = @UserId";
      return _db.Query<Cash>(sql, new { userId });
    }

    internal void Delete(int id)
    {
      string sql = @"DELETE FROM cash WHERE id = @id";
      _db.Execute(sql, new { id });
    }

  }
}