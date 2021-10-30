using System;
using VSC_TweetsApi.Models;
using System.Threading;
using System.Threading.Tasks;
using System.Collections.Generic;

namespace VSC_TweetsApi.Repositoies
{
    public interface ITweetsRepository
    {
        //////Tweet operatons
        // We use Generic Type because we use the same operationf for 
        // our class of properties (Tweet class, retweet class, like class and usere class)
        /////////////////////////////

        Task<Tweet> Get(int id);
        Task<IEnumerable<Tweet>> GetAll();
        Task Add(Tweet tweet);
        Task Delete(int id);
        Task Update(Tweet item);




    }
}