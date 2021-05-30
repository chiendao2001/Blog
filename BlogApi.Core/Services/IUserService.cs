using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using BlogApi.Core.Models;

namespace BlogApi.Core.Services
{
    public interface IUserService
    {
        Task<User> GetUserById(int id);
        Task<IEnumerable<User>> GetAllUsers();
        Task<User> CreateUser(User newUser);
        void UpdateUser(User userToBeUpdated, User user);
        void DeleteUser(User user);
    }
}
