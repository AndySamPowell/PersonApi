using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using PersonApi.Models;

namespace PersonApi.Repository
{
    public interface IAccountRepository
    {
        Task<IEnumerable<Account>> Get();
        Task<Account> Get(int code);
        Task<Account> Create(Account account);
        Task Update(Account account);
        Task Delete(int code);
    }
}
