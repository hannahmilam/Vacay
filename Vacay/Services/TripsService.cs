using System;
using System.Collections.Generic;
using Vacay.Models;
using Vacay.Repositories;

namespace Vacay.Services
{
  public class TripsService
  {
    private readonly TripsRepository _tripsRepository;

    public TripsService(TripsRepository tripsRepository)
    {
      _tripsRepository = tripsRepository;
    }
    internal List<Trip> Get()
    {
     return _tripsRepository.Get(); 
    }

    internal Trip Get(int tripId)
    {
      Trip foundTrip = _tripsRepository.Get(tripId);
      if(foundTrip ==  null)
      {
        throw new SystemException("Invalid Trip Id");
      }
      return foundTrip;
    }

    internal Trip Create(Trip data)
    {
      return _tripsRepository.Create(data);
    }

    internal Trip Delete(int tripId)
    {
      var trip = Get(tripId);
      _tripsRepository.Delete(tripId);
      return trip;
    }

    internal Trip Edit(int tripId, Trip data)
    {
      var trip = Get(tripId);

      trip.Destination = data.Destination ?? trip.Destination;
      _tripsRepository.Edit(tripId, data);
      return trip;

    }
  }
}