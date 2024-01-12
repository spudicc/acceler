using Acceler.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Acceler.Repository
{
    public class AccountRepository
    {
        private List<User> testUsers = new List<User>();

        public AccountRepository()
        {
            this.testUsers = new List<User>()
            {
            new User { Id = "1", Username = "user1", Password = "pw", FirstName = "Marina", LastName= "Spudic", Email = "user1@example.com", Phone = "1234567890" },
            new User { Id = "2", Username = "user2", Password = "pw", FirstName = "Dado", LastName= "Spudic", Email = "user2@example.com", Phone = "9876543210" },
            new User { Id = "3", Username = "user3", Password = "pw", FirstName = "Alic", LastName= "Dautovic", Email = "user3@example.com", Phone = "5555555555" },
            };
        }

        public List<User> GetUsers()
        {
            return testUsers;
        }

        public User GetUser(string username, string password)
        {
            return testUsers.FirstOrDefault(u => u.Username == username && u.Password == password);
        }

        public User GetUserById(string id)
        {
            return testUsers.Find(u => u.Id == id);
        }

        public int CreateUser(RegisterViewModel registerModel)
        {
            // logic for adding user
            return 1;
        }
    }
}