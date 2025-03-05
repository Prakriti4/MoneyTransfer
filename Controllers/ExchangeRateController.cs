using Microsoft.AspNetCore.Mvc;
using MoneyTransferApplication.Services.Interface;

namespace MoneyTransferApplication.Controllers
{
    public class ExchangeRateController:Controller
    {
        private readonly IExchangeRateService _exchangeRateService;

        public ExchangeRateController(IExchangeRateService exchangeRateService)
        {
            _exchangeRateService = exchangeRateService;
        }

        //public async Task<IActionResult> Index()
        //{
        //    var rates = await _exchangeRateService.GetCurrentExchangeRate();
        //    return View(rates);
        //}
    }
}
