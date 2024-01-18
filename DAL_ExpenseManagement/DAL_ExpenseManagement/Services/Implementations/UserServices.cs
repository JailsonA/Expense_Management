using DAL_ExpenseManagement.Data.Enum;
using DAL_ExpenseManagement.Models;
using DAL_ExpenseManagement.Repositories.Interfaces;
using DAL_ExpenseManagement.Services.Interfaces;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL_ExpenseManagement.Services.Implementations
{
    public class UserServices : IUserServices
    {
        private readonly IUserRepository _userRepository;

        public UserServices(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }

        public async Task<bool> CreateUser(User user)
        {
            user.Role = RolEnum.User;
            user.status = true;
            return await _userRepository.CreateUser(user);
        }

        public async Task<bool> DeleteUser(int userId)
        {
            return await _userRepository.DeleteUser(userId);
        }

        public async Task<IEnumerable<User>> GetAllUsers()
        {
            return await _userRepository.GetAllUsers();
        }

        public async Task<User> GetUserById(int id)
        {
            return await _userRepository.GetUserById(id);
        }

        public async Task<User?> Update(User user)
        {
            var userToUpdate = await _userRepository.GetUserById(user.Id);
            if (userToUpdate != null)
            {
                userToUpdate.FullName = user.FullName ?? userToUpdate.FullName;
                userToUpdate.Email = user.Email ?? userToUpdate.Email;
                userToUpdate.Password = user.Password ?? userToUpdate.Password;

                try
                {
                    return await _userRepository.UpdateUser(userToUpdate);
                }
                catch (Exception ex)
                {
                    throw;
                }
            }

            return null;
        }

    }
}
