using System;
using Microsoft.EntityFrameworkCore;
using VSC_TweetsApi.Models;
using System.Threading;
using System.Threading.Tasks;

namespace VSC_TweetsApi.DAL
{
     public class DataContext: DbContext, IDataContext
    {
        public DataContext(DbContextOptions<DataContext> options) : base(options)
        {
             
        }

        public DbSet<Tweet> Tweets { get; init; }
        public DbSet<Like> Likes { get; init; }
        public DbSet<Retweet> ReTweets { get; init; }
        public DbSet<User> Users { get; init; }
    }
}
