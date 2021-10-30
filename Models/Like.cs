using System;

namespace VSC_TweetsApi.Models
{
    public class Like
    {
        public Int32 LikeId { get; set;}
        public String  UserName {get; set;}
        public Int32 Post_id {get; set;}
    }
}