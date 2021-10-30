using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using VSC_TweetsApi.DAL;
using VSC_TweetsApi.Models;

namespace VSC_TweetsApi.Repositoies
{
    public class ReTweetRepository : IReTweetsRepository
    {
        private readonly IDataContext _context;
        public ReTweetRepository(IDataContext context)
        {
            _context = context;

        }

        public async Task Add(Retweet retweet)
        {
            _context.ReTweets.Add(retweet);
            await _context.SaveChangesAsync();
        }

        public async Task Delete(int id)
        {
            var itemToRemove = await _context.ReTweets.FindAsync(id);
            if (itemToRemove == null)
                throw new NullReferenceException();

            _context.ReTweets.Remove(itemToRemove);
            await _context.SaveChangesAsync();
        }

        public async Task<Retweet> Get(int id)
        {
            return await _context.ReTweets.FindAsync(id);
        }

        public async Task<IEnumerable<Retweet>> GetAll()
        {
            return await _context.ReTweets.ToListAsync();
        }

        public async Task Update(Retweet retweet)
        {
            var itemToUpdate = await _context.Tweets.FindAsync(retweet.Post_Id);
            if (itemToUpdate == null)
                throw new NullReferenceException();
            itemToUpdate.Username = retweet.Username;
            await _context.SaveChangesAsync();

        }

    }
}

