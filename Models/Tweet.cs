using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace VSC_TweetsApi.Models
{
    public class Tweet
    {
        public Int32 TweetId {get; set;}
        public String Content {get; set;}
        public Int32 User_Id { get; set;}
        public String Username {get; set;}
        public DateTime TimeStamp  {get; set;}
        [NotMapped]
        public Int32 Likes_count { get; set; }
    }
}