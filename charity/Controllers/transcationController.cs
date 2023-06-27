using Microsoft.AspNetCore.Mvc;
using charity.TransactionService;
using charity.Models;
using Microsoft.AspNetCore.Cors;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace MongoExample.Controllers
{
    [ApiController]
    [Route("api/transaction")]
    [EnableCors("AllowAllOrigins")]
    public class TransactionController : ControllerBase
    {
        private readonly TransactionService _transactionService;

        public TransactionController(TransactionService transactionService)
        {
            _transactionService = transactionService;
        }

        [HttpGet]
        public async Task<List<Transaction>> Get()
        {
            return await _transactionService.GetTransactionsAsync();
        }

        [HttpPost]
        public async Task<IActionResult> Post([FromBody] Transaction transaction)
        {
            await _transactionService.AddTransactionAsync(transaction);
            return CreatedAtAction(nameof(Get), new { id = transaction.Id }, transaction);
        }
    }
}
