using System;
using VSC_TweetsApi.Models;
using System.Threading;
using System.Threading.Tasks;
using System.Collections.Generic;

namespace VSC_TweetsApi.Repositoies
{
    public interface IReTweetsRepository
    {

        Task<Retweet> Get(int id);
        Task<IEnumerable<Retweet>> GetAll();
        Task Add(Retweet item);
        Task Delete(int id);
        Task Update(Retweet item);
    }
}