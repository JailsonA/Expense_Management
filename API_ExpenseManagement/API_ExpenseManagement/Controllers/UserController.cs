using API_ExpenseManagement.ModelsDTO;
using DAL_ExpenseManagement.Models;
using DAL_ExpenseManagement.Services.Implementations;
using DAL_ExpenseManagement.Services.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace API_ExpenseManagement.Controllers
{
    [Route("[controller]/[Action]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly IUserServices _userServices;

        public UserController(IUserServices userServices)
        {
            _userServices = userServices;
        }
        // GET: User
        [HttpGet]
        public async Task<IActionResult> GetAllUser()
        {
            try
            {
                var users = await _userServices.GetAllUsers();
                if (users != null)
                    return Ok(users);
            }
            catch (Exception)
            {
                throw;
            }
            return BadRequest();
        }

        // GET: User by id
        [HttpGet]
        public async Task<IActionResult> GetUserById(int id)
        {
            try
            {
                var user = await _userServices.GetUserById(id);
                if (user != null)
                    return Ok(user);
            }
            catch (Exception)
            {

                throw;
            }
            return BadRequest();
        }

        // POST: Add new user
        [HttpPost]
        public async Task<IActionResult> CreateUser(UserDTO user)
        {
            try
            {
                User newUser = new User()
                {
                    FullName = user.FullName,
                    Password = user.Password,
                    Email = user.Email,
                };
                bool result = await _userServices.CreateUser(newUser);
                return Ok(new { message = "User Add Succesfull", data = result });
            }
            catch (Exception)
            {

                throw;
            }
        }

        // PUT: edit user
        [HttpPut]
        public async Task<IActionResult> EditUser(UserDTO user)
        {
            try
            {
                User newUser = new User()
                {
                    Id = user.Id,
                    FullName = user.FullName ?? null,
                    Password = user.Password ?? null,
                    Email = user.Email ?? null,
                };
                var result = await _userServices.Update(newUser);
                if (result != null)
                    return Ok(new { message = "User Update Succesfull", data = result });
                else
                    return BadRequest();
            }
            catch (Exception)
            {

                throw;
            }
        }

        // DELETE: delete user
        [HttpDelete]
        public async Task<IActionResult> DeleteUser(int id)
        {
            try
            {
                bool result = await _userServices.DeleteUser(id);
                if (result)
                    return Ok(new { message = "User Delete Succesfull", data = result });
                else
                    return BadRequest();
            }
            catch (Exception)
            {

                throw;
            }
        }
    }
}
