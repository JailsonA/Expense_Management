using DAL_ExpenseManagement.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL_ExpenseManagement.Repositories.Interfaces
{
    public interface IUserRepository
    {
        // Get Section
        Task<IEnumerable<User>> GetAllUsers();
        Task<User> GetUserById(int id);

        // Post Section
        Task<bool> CreateUser(User user);
        Task<User> UpdateUser(User user);
        Task<bool> DeleteUser(int userId);
    }
}
