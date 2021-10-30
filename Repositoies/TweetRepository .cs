using System;
using VSC_TweetsApi.Models;
using System.Threading;
using System.Threading.Tasks;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using VSC_TweetsApi.DAL;

namespace VSC_TweetsApi.Repositoies
{
    public class TweetRepository : ITweetsRepository
    {
        private readonly IDataContext _context;
        public TweetRepository(IDataContext context)
        {
        _context = context;
    
        }

        public async Task Add(Tweet tweet)
        {
            _context.Tweets.Add(tweet);
            await _context.SaveChangesAsync();
        }

        public async Task Delete(int id)
        {
            var itemToRemove = await _context.Tweets.FindAsync(id);
            if (itemToRemove == null)
                throw new NullReferenceException();

            _context.Tweets.Remove(itemToRemove);
            await _context.SaveChangesAsync();
        }

        public async Task<Tweet> Get(int id)
        {
            return await _context.Tweets.FindAsync(id);
        }

        public async Task<IEnumerable<Tweet>> GetAll()
        {
            return await _context.Tweets.ToListAsync();
        }

        public async Task Update(Tweet tweet)
        {
            var itemToUpdate = await _context.Tweets.FindAsync(tweet.TweetId);
            if (itemToUpdate == null)
                throw new NullReferenceException();
            itemToUpdate.Content = tweet.Content;
            await _context.SaveChangesAsync();

        }

       
    }
}