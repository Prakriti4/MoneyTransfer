using Microsoft.AspNetCore.Mvc;
using MoneyTransferApplication.Models;
using MoneyTransferApplication.Services.Interface;
using MoneyTransferApplication.ViewModel.BankAccount;
using System;
using System.Threading.Tasks;

namespace MoneyTransferApplication.Controllers
{
    public class BankAccountController : Controller
    {
        private readonly IBankAccountService _bankAccountService;

        public BankAccountController(IBankAccountService bankAccountService)
        {
            _bankAccountService = bankAccountService;
        }

        public async Task<IActionResult> Index()
        {
            var accounts = await _bankAccountService.GetAllBankAccountsAsync();
            return View(accounts);
        }

        [HttpPost]
        public async Task<IActionResult> Add(CreateBankAccountVM account)
        {
            if (!ModelState.IsValid) return View(account);

            await _bankAccountService.CreateBankAccountAsync(account);
            return RedirectToAction("Index");
        }
    }
}
