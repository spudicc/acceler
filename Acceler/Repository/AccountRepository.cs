using Acceler.DAL;
using Acceler.Models;
using Acceler.Models.ViewModels;
using System;
using System.Collections.Generic;
using System.Data.Entity.Migrations;
using System.Linq;
using System.Web;

namespace Acceler.Repository
{
    public class AccountRepository
    {
        private AccelerDbContext context = new AccelerDbContext();

        public AccountRepository()
        {
        }

        public User CreateUser(User user)
        {
            try
            {
                this.CreateRideOwner(user);

                context.Users.Add(user);

                context.SaveChanges();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            return user;
        }

        public UserProfileViewModel UpdateUser(UserProfileViewModel model)
        {
            var userUpdate = new User
            {
                Id = model.Id,
                Password = model.Password,
                Username = model.Username,
                FirstName = model.FirstName,
                LastName = model.LastName,
                Email = model.Email,
                Phone = model.Phone
            };

            try
            {
                context.Users.AddOrUpdate(userUpdate);

                context.SaveChanges();

            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }

            return model;
        }

        public User GetUser(string username, string password)
        {
            return context.Users.FirstOrDefault(u => u.Username == username && u.Password == password);
        }

        public User GetUser(int id)
        {
            return context.Users.FirstOrDefault(u => u.Id == id);
        }

        public IEnumerable<User> GetUsers()
        {
            return context.Users;
        }

        public int CreateRideOwner(User user)
        {
            var owner = new RideOwner
            {
                User = user,
                CreatedRides = new List<Ride>()
            };

            try
            {
                return context.RideOwners.Add(owner).Id;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public RideOwner GetRideOwner(int userId)
        {
            return context.RideOwners.FirstOrDefault(u => u.UserId == userId);
        }

        public UserProfileViewModel GetUserProfile(int id)
        {
            var userInfo = context.Users.First(u => u.Id == id);
            var rideOwnerInfo = context.RideOwners.FirstOrDefault(u => u.UserId == id);

            var userProfileViewModel = new UserProfileViewModel
            {
                Id = id,
                Username = userInfo.Username,
                FirstName = userInfo.FirstName,
                LastName = userInfo.LastName,
                Email = userInfo.Email,
                Phone = userInfo.Phone,
                CreatedRides = rideOwnerInfo?.CreatedRides,
                JoinedRides = userInfo.JoinedRides
            };

            return userProfileViewModel;
        }
    }
}