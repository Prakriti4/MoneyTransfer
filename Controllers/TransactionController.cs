using Microsoft.AspNetCore.Mvc;
using MoneyTransferApplication.Models;
using MoneyTransferApplication.Services.Interface;
using MoneyTransferApplication.ViewModel.Transaction;
using System;
using System.Threading.Tasks;

namespace MoneyTransferApplication.Controllers
{
    public class TransactionController : Controller
    {
        private readonly ITransactionService _transactionService;

        public TransactionController(ITransactionService transactionService)
        {
            _transactionService = transactionService;
        }

        [HttpPost]
        public async Task<IActionResult> TransferMoney(CreateTransactionVM transaction)
        {
            if (!ModelState.IsValid) return View(transaction);

            await _transactionService.CreateTransactionAsync(transaction);
            return RedirectToAction("Index");
        }

        public async Task<IActionResult> Report(DateTime fromDate, DateTime toDate)
        {
            var transactions = await _transactionService.GetTransactionsByDateRangeAsync(fromDate, toDate);
            return View(transactions);
        }
    }
}
