using Acceler.DAL;
using Acceler.Models;
using Microsoft.Ajax.Utilities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.WebPages;

namespace Acceler.Repository
{
    public class RideRepository
    {
        private AccelerDbContext context = new AccelerDbContext();

        private AccountRepository accountRepository = new AccountRepository();

        public RideRepository()
        {

        }

        public void CreateRide(Ride ride)
        {
            var rideowner = accountRepository.GetRideOwner(ride.RideOwnerId.Value);

            try
            {
                if (rideowner == null)
                    accountRepository.CreateRideOwner(accountRepository.GetUser(ride.RideOwnerId.Value));

                ride.RideOwnerId = accountRepository.GetRideOwner(ride.RideOwnerId.Value).Id;

                context.Rides.Add(ride);
                context.SaveChanges();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public Ride GetRide(int rideId)
        {
            var ride = context.Rides.FirstOrDefault(r => r.Id == rideId);
            ride.Waypoints = context.Waypoints.Where(w => w.RideId == ride.Id.ToString()).ToList();

            return ride;
        }

        public IEnumerable<Ride> GetRides()
        {
            var rides = context.Rides;
            foreach (var ride in rides)
            {
                ride.Waypoints = context.Waypoints.Where(w => w.RideId == ride.Id.ToString()).ToList();
            }
            return rides;
        }

        public void AddMemberToRide(User member, int rideId)
        {
            try
            {
                context.Rides.FirstOrDefault(r => r.Id == rideId).RideMembers.Add(context.Users.FirstOrDefault(u => u.Id == member.Id));
                context.SaveChanges();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public IEnumerable<Waypoint> CreateWaypoints(ICollection<Waypoint> waypoints)
        {
            try
            {
                context.Waypoints.AddRange(waypoints);
                context.SaveChanges();
                return waypoints;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
    }
}