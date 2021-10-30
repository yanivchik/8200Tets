using System;

namespace VSC_TweetsApi.Models
{
    public class Retweet
    {
         public Int32 RetweetId { get; set;}
         public String Username {get; set;}
         public Int32 Post_Id { get; set;}
         public DateTime Timestamp { get; set;}
    }
}