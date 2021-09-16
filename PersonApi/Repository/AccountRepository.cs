using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using PersonApi.Models;

namespace PersonApi.Repository
{
    public class AccountRepository : IAccountRepository
    {
        
        private readonly PersonDbContext _context;

        public AccountRepository(PersonDbContext context)
        {
            _context = context;
        }

        public async Task<Account> Create(Account account)
        {
            _context.Accounts.Add(account);
            await _context.SaveChangesAsync();

            return account;
        }

        public async Task Delete(int code)
        {
            var accountToDelete = await _context.Accounts.FindAsync(code);
            _context.Accounts.Remove(accountToDelete);
            await _context.SaveChangesAsync();
        }

        public async Task<IEnumerable<Account>> Get()
        {
            return await _context.Accounts.ToListAsync();
        }

        public async Task<Account> Get(int code)
        {
            return await _context.Accounts.FindAsync(code);
        }

        public async Task Update(Account account)
        {
            _context.Entry(account).State = EntityState.Modified;
            await _context.SaveChangesAsync();
        }
    }
    
}
