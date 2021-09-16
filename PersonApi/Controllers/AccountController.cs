using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using PersonApi.Models;
using PersonApi.Repository;

namespace PersonApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AccountController : ControllerBase
    {
        private readonly IAccountRepository _accountRepository;

        public AccountController(IAccountRepository accountRepository)
        {
            _accountRepository = accountRepository;
        }

        [HttpGet]
        public async Task<IEnumerable<Account>> GetAccount()
        {
            return await _accountRepository.Get();
        }

        [HttpGet("{code}")]
        public async Task<ActionResult<Account>> GetAccounts(int code)
        {
            return await _accountRepository.Get(code);
        }

        [HttpPost]
        public async Task<ActionResult<Account>> PostAccount([FromBody] Account account)
        { 
        
            var newAccount = await _accountRepository.Create(account);
            return CreatedAtAction(nameof(GetAccount), new { code = newAccount.Code }, newAccount);
        }

        [HttpPut]
        public async Task<ActionResult> PutAccount(int code, [FromBody] Account account)
        {
            if (code != account.Code)
            {
                return BadRequest();
            }

            await _accountRepository.Update(account);

            return NoContent();
        }

        [HttpDelete("{code}")]
        public async Task<ActionResult> Delete(int code)
        {
            var accountToDelete = await _accountRepository.Get(code);
            if (accountToDelete == null)
                return NotFound();

            await _accountRepository.Delete(accountToDelete.Code);
            return NoContent();
        }
    }
}

