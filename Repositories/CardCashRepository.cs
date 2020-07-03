using System;
using System.Collections.Generic;
using System.Data;
using ATM.Models;
using Dapper;

namespace ATM.Repositories
{
  public class CardCashRepository
  {
    private readonly IDbConnection _db;

    public CardCashRepository(IDbConnection db)
    {
      _db = db;
    }

    internal CardCash Create(CardCash newCC)
    {
      string sql = @"
        INSERT INTO cardcash (vaultId, keepId, userId)
        VALUES (@VaultId, @KeepId, @UserId);
        SELECT LAST_INSERT_ID();";
      int id = _db.ExecuteScalar<int>(sql, newCC);
      newCC.Id = id;
      return newCC;
    }

    internal CardCash FindByIds(int cardId, int cashId)
    {
      string sql = @"SELECT * FROM cardcash WHERE 
      (cardId = @CardId AND cashId = @CashId)";
      return _db.QueryFirstOrDefault<CardCash>(sql, new { cardId, cashId });
    }

    internal CardCash GetById(int id)
    {
      string sql = @"SELECT * FROM cashcard WHERE id = @id";
      return _db.QueryFirstOrDefault(sql, new { id });
    }

    // NOTE Changed @userId to @UserId and @id to @Id
    // internal Cash GetCashByCardId(Card card)
    // {
    //   string sql = @"SELECT c.* FROM cardcash cc
    //     INNER JOIN cash c ON c.id = cc.cashId
    //     WHERE (cardId = @Id AND cc.userId = @UserId)";
    //   return _db.QuerySingleOrDefault<Cash>(sql, card);
    // }

    internal Cash GetCashByCardId(int id)
    {
      string sql = @"SELECT c.* FROM cardcash cc
       INNER JOIN cash c ON c.id = cc.cardId
       WHERE(cardId = @cardId AND cc.userId = @userId)";
      return _db.QuerySingleOrDefault<Cash>(sql, id);
    }

    internal void Delete(int id)
    {
      string sql = @"DELETE FROM cardcash WHERE id = @Id";
      _db.Execute(sql, new { id });
    }
  }
}