using System;
using System.Collections.Generic;
using Vacay.Models;
using Vacay.Repositories;

namespace Vacay.Services
{
  public class VacationsService
  {
    private readonly VacationsRepository _vacationsRepository;

    public VacationsService(VacationsRepository vacationsRepository)
    {
      _vacationsRepository = vacationsRepository;
    }
    internal List<Vacation> Get()
    {
     return _vacationsRepository.Get(); 
    }

    internal Vacation Get(int vacationId)
    {
      Vacation foundVacation = _vacationsRepository.Get(vacationId);
      if(foundVacation ==  null)
      {
        throw new SystemException("Invalid Vacation Id");
      }
      return foundVacation;
    }

    internal Vacation Create(Vacation data)
    {
      return _vacationsRepository.Create(data);
    }

    internal Vacation Delete(int vacationId)
    {
      var vacation = Get(vacationId);
      _vacationsRepository.Delete(vacationId);
      return vacation;
    }

    internal Vacation Edit(int vacationId, Vacation data)
    {
      var trip = Get(vacationId);

      trip.Destination = data.Destination ?? trip.Destination;
      _vacationsRepository.Edit(vacationId, data);
      return trip;

    }
}
}