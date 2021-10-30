using System;
using VSC_TweetsApi.Models;
using System.Threading;
using System.Threading.Tasks;
using System.Collections.Generic;

namespace VSC_TweetsApi.Repositoies
{
    public interface IUsersRepository
    {

        Task<User> Get(int id);
        Task<IEnumerable<User>> GetAll();
        Task Add(User item);
        Task Delete(int id);
        Task Update(User item);

    }
}