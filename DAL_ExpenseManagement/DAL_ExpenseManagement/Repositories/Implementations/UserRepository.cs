using DAL_ExpenseManagement.Data;
using DAL_ExpenseManagement.Models;
using DAL_ExpenseManagement.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL_ExpenseManagement.Repositories.Implementations
{
    public class UserRepository : IUserRepository
    {
        private readonly ExpenseMContext _context;

        public UserRepository(ExpenseMContext context)
        {
            _context = context;
        }

        public async Task<bool> CreateUser(User user)
        {
            try
            {
                await _context.Users.AddAsync(user);
                await _context.SaveChangesAsync();
                return true;
            }
            catch (DbUpdateException ex)
            {
                throw new Exception("Error adding user", ex);
            }
        }

        public async Task<bool> DeleteUser(int userId)
        {
            try
            {
                var existUser = await GetUserById(userId);
                if (existUser != null)
                {
                    _context.Users.Remove(existUser);
                    await _context.SaveChangesAsync();
                    return true;
                }
            }
            catch (DbUpdateException ex)
            {
                throw new Exception("Error deleting user", ex);
            }
            return false;
        }

        public async Task<IEnumerable<User>> GetAllUsers()
        {
            try
            {
                return await _context.Users.ToListAsync() ?? Enumerable.Empty<User>();
            }
            catch (DbUpdateException ex)
            {
                throw new Exception("Error getting users", ex);
            }
        }

        public async Task<User> GetUserById(int id)
        {
            try
            {
                return await _context.Users.FirstAsync(u => u.Id == id);
            }
            catch (InvalidOperationException ex)
            {

                throw new Exception($"Error getting User with ID {id}", ex);
            }
        }

        public async Task<User> UpdateUser(User updatedUser)
        {
            try
            {
                var existingUser = await GetUserById(updatedUser.Id);
                if (existingUser != null)
                {
                    _context.Entry(existingUser).CurrentValues.SetValues(updatedUser);

                    await _context.SaveChangesAsync();
                    return existingUser;
                }
                else
                {
                    return null;
                }
            }
            catch (DbUpdateException ex)
            {
                throw new Exception("Error updating user", ex);
            }
        }


    }
}
