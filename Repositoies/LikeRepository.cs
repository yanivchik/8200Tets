using System;
using VSC_TweetsApi.Models;
using System.Threading;
using System.Threading.Tasks;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using VSC_TweetsApi.DAL;
using System.Linq;

namespace VSC_TweetsApi.Repositoies
{
    public class LikeRepository : ILikesRepository
    {
        private readonly IDataContext _context;
        public LikeRepository(IDataContext context)
        {
            _context = context;

        }

        public async Task Add(Like like)
        {
            _context.Likes.Add(like);
            await _context.SaveChangesAsync();
        }

        public async Task Delete(int id)
        {
            var itemToRemove = await _context.Likes.FindAsync(id);
            if (itemToRemove == null)
                throw new NullReferenceException();

            _context.Likes.Remove(itemToRemove);
            await _context.SaveChangesAsync();
        }

        public async Task<Like> Get(int id)
        {
            return await _context.Likes.FindAsync(id);
        }

        public async Task<IEnumerable<Like>> GetAll()
        {
            return await _context.Likes.ToListAsync();
        }

        public async Task Update(Like like)
        {
            var itemToUpdate = await _context.Tweets.FindAsync(like.LikeId);
            if (itemToUpdate == null)
                throw new NullReferenceException();
            itemToUpdate.Username = like.UserName;
            itemToUpdate.TweetId = like.Post_id;

            await _context.SaveChangesAsync();

        }
    }
}
