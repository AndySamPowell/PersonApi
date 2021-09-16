using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using PersonApi.Models;
using PersonApi.Repository;

namespace PersonApi.Repository
{
    public class TransactionRepository : ITransactionRepository
    {
        private readonly PersonDbContext _context;

        public TransactionRepository(PersonDbContext context)
        {
            _context = context;
        }

        public async  Task<Transaction> Create(Transaction transaction)
        {
            _context.Transactions.Add(transaction);
            await _context.SaveChangesAsync();

            return transaction;
        }

        public async Task Delete(int code)
        {
            var transactionToDelete = await _context.Transactions.FindAsync(code);
            _context.Transactions.Remove(transactionToDelete);
            await _context.SaveChangesAsync();
        }

        public async Task<IEnumerable<Transaction>> Get()
        {
            return await _context.Transactions.ToListAsync();
        }

        public async Task<Transaction> Get(int code)
        {
            return await _context.Transactions.FindAsync(code);
        }

        public async Task Update(Transaction transaction)
        {
            _context.Entry(transaction).State = EntityState.Modified;
            await _context.SaveChangesAsync();
        }
    }
}
