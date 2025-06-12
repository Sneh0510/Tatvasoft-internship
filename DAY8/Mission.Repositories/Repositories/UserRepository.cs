using Microsoft.EntityFrameworkCore;
using Mission.Entities.Context;
using Mission.Entities.Models;
using Mission.Repositories.IRepositories;
using System;
using System.Threading.Tasks;

namespace Mission.Repositories.Repositories
{
    public class UserRepository(MissionDbContext cIDbContext) : IUserRepository
    {
        private readonly MissionDbContext _cIDbContext = cIDbContext;

        public async Task<string> DeleteUser(int id)
        {
            var user = await _cIDbContext.User.FirstOrDefaultAsync(u => u.Id == id);

            if (user == null) throw new Exception("User does not exist");

            _cIDbContext.User.Remove(user); // Hard delete
            await _cIDbContext.SaveChangesAsync();

            return "User deleted from database!";
        }

        public async Task<UserResponseModel> GetUserById(int id)
        {
            var user = await _cIDbContext.User.FirstOrDefaultAsync(u => u.Id == id);

            if (user == null) throw new Exception("User does not exist");

            return new UserResponseModel()
            {
                EmailAddress = user.EmailAddress,
                FirstName = user.FirstName,
                Id = user.Id,
                LastName = user.LastName,
                PhoneNumber = user.PhoneNumber,
                UserType = user.UserType
            };
        }
    }
}
