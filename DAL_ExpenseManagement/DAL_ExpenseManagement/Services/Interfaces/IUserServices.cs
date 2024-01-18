using DAL_ExpenseManagement.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL_ExpenseManagement.Services.Interfaces
{
    public interface IUserServices
    {
        // Get Section
        Task<IEnumerable<User>> GetAllUsers();
        Task<User> GetUserById(int id);

        // Post Section
        Task<bool> CreateUser(User user);
        Task<User> Update(User user);
        Task<bool> DeleteUser(int userId);
    }
}
