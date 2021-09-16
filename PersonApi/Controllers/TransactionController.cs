using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;
using PersonApi.Models;
using PersonApi.Repository;

namespace PersonApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TransactionController : ControllerBase
    {
        private readonly ITransactionRepository _transactionRepository;

        public TransactionController(ITransactionRepository transactionRepository)
        {
            _transactionRepository = transactionRepository;
        }

        [HttpGet]
        public async Task<IEnumerable<Transaction>> GetTransaction()
        {
            return await _transactionRepository.Get();
        }

        [HttpGet("{code}")]
        public async Task<ActionResult<Transaction>> GetTransaction(int code)
        {
            return await _transactionRepository.Get(code);
        }

        [HttpPost]
        public async Task<ActionResult<Transaction>> PostTransaction([FromBody] Transaction tranaction)
        {

            var newTransaction = await _transactionRepository.Create(tranaction);
            return CreatedAtAction(nameof(GetTransaction), new { code = newTransaction.Code }, newTransaction);
        }

        [HttpPut]
        public async Task<ActionResult> PutTransaction(int code, [FromBody] Transaction tranaction)
        {
            if (code != tranaction.Code)
            {
                return BadRequest();
            }

            await _transactionRepository.Update(tranaction);

            return NoContent();
        }

        [HttpDelete("{code}")]
        public async Task<ActionResult> Delete(int code)
        {
            var transactionToDelete = await _transactionRepository.Get(code);
            if (transactionToDelete == null)
                return NotFound();

            await _transactionRepository.Delete(transactionToDelete.Code);
            return NoContent();
        }
    }
}
