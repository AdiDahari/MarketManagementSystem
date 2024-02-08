using MarketManagementSystem.Models;
using Microsoft.AspNetCore.Mvc;

namespace MarketManagementSystem.ViewComponents
{
    [ViewComponent]
    public class TransactionsViewComponent : ViewComponent
    {
        public IViewComponentResult Invoke(string userName)
        {
            var transactions = TransactionsRepository.GetByDayAndCashier(DateTime.Now, userName);
            return View(transactions);
        }
    }
}