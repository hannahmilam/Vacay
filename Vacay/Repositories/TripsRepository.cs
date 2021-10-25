using System.Collections.Generic;
using System.Data;
using System.Linq;
using Dapper;
using Vacay.Interfaces;
using Vacay.Models;

namespace Vacay.Repositories
{
  public class TripsRepository : IRepository<Trip>
  {
   
   private readonly IDbConnection _db;

    public TripsRepository(IDbConnection db)
    {
      _db = db;
    }

    public Trip Create(Trip data)
    {
      var sql = @"
      INSERT INTO trips(
        price,
        destination,
        creatorId
      )
      VALUES (
        @Price,
        @Destination,
        @CreatorId
      );
      SELECT LAST_INSERT_ID();";
      var id = _db.ExecuteScalar<int>(sql, data);
      data.Id = id;
      return data;
    }

      public List<Trip> Get()
    {
      string sql = @"
      SELECT 
      t.*,
      a.*
      FROM trips t
      JOIN accounts a on t.creatorId = a.id;";
      return _db.Query<Trip, Account, Trip>(sql, (t, a) => 
      {
        t.CreatorId = a.Id;
        return t;
      }).ToList();
    }

     public Trip Get(int id)
    {
      string sql = @"
      SELECT
      t.*,
      a.*
      FROM trips t
      JOIN accounts a on t.accountId = a.id
      WHERE t.id = @id;";
      return _db.Query<Trip, Account, Trip>(sql, (t, a) =>
      {
        t.CreatorId = a.Id;
        return t;
      }, new{id}).FirstOrDefault();
    }

    public void Delete(int id)
    {
      string sql = "DELETE FROM trips WHERE id = @id LIMIT 1;";
      var affectedRows = _db.Execute(sql, new{id});
      if(affectedRows == 0)
      {
        throw new System.Exception("unable to delete");
      }
    }

    public Trip Edit(int id, Trip data)
    {
      data.Id = id;
      var sql = @"
      UPDATE trips
      SET
        destination = @Destination
      WHERE id = @Id;
      ";
      var rowsAffected = _db.Execute(sql, data);
      if(rowsAffected == 0)
      {
        throw new System.Exception("The update failed");
      }
      return data;
    }
  }
}