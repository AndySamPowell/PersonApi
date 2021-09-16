using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using PersonApi.Models;

namespace PersonApi.Repository
{
    public interface ITransactionRepository
    {
        Task<IEnumerable<Transaction>> Get();
        Task<Transaction> Get(int code);
        Task<Transaction> Create(Transaction transaction);
        Task Update(Transaction transaction);
        Task Delete(int code);
    }
}
