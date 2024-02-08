using MarketManagementSystem.Models;
using MarketManagementSystem.ViewModels;
using Microsoft.AspNetCore.Mvc;

namespace MarketManagementSystem.Controllers
{
  public class TransactionsController : Controller
  {
    public IActionResult Index()
    {
      TransactionsViewModel transactionsViewModel = new TransactionsViewModel();
      return View(transactionsViewModel);
    }

    public IActionResult Search(TransactionsViewModel transactionsViewModel)
    {
      var transactions = TransactionsRepository.Search(
        transactionsViewModel.CashierName,
        transactionsViewModel.StartDate,
        transactionsViewModel.EndDate);

      transactionsViewModel.Transactions = transactions;

      return View("Index", transactionsViewModel);
    }


  }
}