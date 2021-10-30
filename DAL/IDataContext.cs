using System;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using VSC_TweetsApi.Models;


namespace VSC_TweetsApi.DAL
{
    public interface IDataContext
    {
        DbSet<Tweet> Tweets { get; init;}
        DbSet<Like> Likes { get; init;}
        DbSet<Retweet> ReTweets { get; init;}
        DbSet<User> Users { get; init;}
        Task<Int32> SaveChangesAsync(CancellationToken cancellationToken = default);
    }
}