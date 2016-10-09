using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;


namespace Website.TheWorldMap.Models
{
    public class WorldRepository : IWorldRepository
    {
        private WorldContext _context;

        public WorldRepository(WorldContext context)
        {
            _context = context;
        }

        public void AddStop(string tripName, Stop newstop)
        {
            var trip = GetTripByName(tripName);
            if ((trip) != null)
            {
                // this is add foreign key
                trip.Stops.Add(newstop);

                //this is add to stops
                _context.Stops.Add(newstop);
            }
        }

        public void AddTrip(Trip trip)
        {
            _context.Add(trip);
        }

        public IEnumerable<Trip> GetAllTrips()
        {
            return _context.Trips.ToList();
        }

        public Trip GetTripByName(string tripName)
        {
            return _context.Trips.Include(t => t.Stops)
                                 .Where(t => t.Name.ToLower() == tripName.ToLower())
                                 .FirstOrDefault();
        }

        public async Task<bool> SaveChangesAsync()
        {
            return (await _context.SaveChangesAsync()) > 0;
        }
    }
}
