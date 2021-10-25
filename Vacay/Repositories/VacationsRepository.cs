using System.Collections.Generic;
using System.Data;
using Vacay.Interfaces;
using Vacay.Models;

namespace Vacay.Repositories
{
  public class VacationsRepository : IRepository<Vacation>
  {
    private readonly IDbConnection _db;

    public VacationsRepository(IDbConnection db)
    {
      _db = db;
    }
    public Vacation Create(Vacation data)
    {
      throw new System.NotImplementedException();
    }

    public List<Vacation> Get()
    {
      throw new System.NotImplementedException();
    }

    public Vacation Get(int id)
    {
      throw new System.NotImplementedException();
    }
    public void Delete(int id)
    {
      throw new System.NotImplementedException();
    }

    public Vacation Edit(int id, Vacation data)
    {
      throw new System.NotImplementedException();
    }

  }
}