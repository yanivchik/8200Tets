using System;
using VSC_TweetsApi.Models;
using System.Threading;
using System.Threading.Tasks;
using System.Collections.Generic;

namespace VSC_TweetsApi.Repositoies
{
    public interface ILikesRepository
    {
        //////Tweet operatons
        // We use Generic Type because we use the same operationf for 
        // our class of properties (Tweet class, retweet class, like class and usere class)
        /////////////////////////////

        Task<Like> Get(int id);
        Task<IEnumerable<Like>> GetAll();
        Task Add(Like item);
        Task Delete(int id);
        Task Update(Like item);


    }
}