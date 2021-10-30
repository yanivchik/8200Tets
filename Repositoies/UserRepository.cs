using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using VSC_TweetsApi.DAL;
using VSC_TweetsApi.Models;

namespace VSC_TweetsApi.Repositoies
{
    public class UserRepository : IUsersRepository
    {

        private readonly IDataContext _context;
        public UserRepository(IDataContext context)
        {
            _context = context;
        }

        public async Task Add(User user)
        {
            _context.Users.Add(user);
            await _context.SaveChangesAsync();
        }

        public async Task Delete(int id)
        {
            var itemToRemove = await _context.Users.FindAsync(id);
            if (itemToRemove == null)
                throw new NullReferenceException();

            _context.Users.Remove(itemToRemove);
            await _context.SaveChangesAsync();
        }

        public async Task<User> Get(int id)
        {
            return await _context.Users.FindAsync(id);
        }

        public async Task<IEnumerable<User>> GetAll()
        {
            return await _context.Users.ToListAsync();
        }

        public async Task Update(User user)
        {
            var itemToUpdate = await _context.Users.FindAsync(user.UserId);
            if (itemToUpdate == null)
                throw new NullReferenceException();
            itemToUpdate.UserName = user.UserName;

            await _context.SaveChangesAsync();

        }

    }
}
