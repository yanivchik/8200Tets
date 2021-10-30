using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using VSC_TweetsApi.Models;
using VSC_TweetsApi.Repositoies;

namespace VSC_TweetsApi.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class TweetController : ControllerBase
    {
        private readonly ITweetsRepository _tweetRepository;
        private readonly ILikesRepository _likesRepository;
        public TweetController(ITweetsRepository tweetRepository, ILikesRepository likeRepository)
        {
            _tweetRepository = tweetRepository;
            _likesRepository = likeRepository;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Tweet>>> GetTweets()
        {
            IEnumerable<Tweet> tweets = await _tweetRepository.GetAll();
            IEnumerable<Like> likes = await _likesRepository.GetAll();

            List<Tweet> new_tweets = new List<Tweet>();

            foreach (var t in tweets)
            {
                Int32 count_likes = likes.Where(x => x.Post_id == t.TweetId).Count();

                 var new_tweet = new Tweet
                 {
                     TweetId = t.TweetId,
                     Content = t.Content,
                     Username = t.Username,
                     TimeStamp = t.TimeStamp,
                     User_Id = t.User_Id,
                     Likes_count = count_likes
                 };

                new_tweets.Add(new_tweet);
            }
            
            return Ok(new_tweets);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Tweet>> GetTweet(int id)
        {
            var tweet = await _tweetRepository.Get(id);
            if (tweet == null)
                return NotFound();

            return Ok(tweet);
        }

        [HttpPost]
        public async Task<ActionResult> CreateTweet(Tweet createTweet)
        {
            Tweet tweet = new()
            {
                Username = createTweet.Username,
                Content = createTweet.Content,
                TimeStamp = DateTime.UtcNow
            };

            await _tweetRepository.Add(tweet);
            return Ok();
        }

    }
}
