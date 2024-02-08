namespace MarketManagementSystem.Models
{
  public static class TransactionsRepository
  {
    private static List<Transaction> _transactions = new List<Transaction>();

    public static IEnumerable<Transaction> GetByDayAndCashier(DateTime date, string cashierName)
    {
      if (string.IsNullOrEmpty(cashierName))
      {
        return _transactions.Where(t => DateTime.Equals(t.TimeStamp.Date, date.Date));
      }

      return _transactions
        .Where(t => DateTime.Equals(t.TimeStamp.Date, date.Date) &&
          string.Equals(t.CashierName.ToLower(), cashierName.ToLower()));
    }

    public static IEnumerable<Transaction> Search(string cashierName, DateTime startDate, DateTime endDate)
    {
      if (string.IsNullOrEmpty(cashierName))
      {
        return _transactions.Where(t => t.TimeStamp.Date >= startDate.Date && t.TimeStamp.Date <= endDate.Date);
      }

      return _transactions
        .Where(t => t.TimeStamp.Date >= startDate.Date && t.TimeStamp.Date <= endDate.Date &&
          string.Equals(t.CashierName.ToLower(), cashierName.ToLower()));
    }

    public static void Add(string cashierName, int productId, string productName, double price, int qty, int qtyToSell)
    {
      if (_transactions == null)
      {
        _transactions = new List<Transaction>();
      }
      var maxId = _transactions.Any() ? _transactions.Max(t => t.TransactionId) : 0;
      var transaction = new Transaction
      {
        TransactionId = maxId + 1,
        TimeStamp = DateTime.Now,
        ProductId = productId,
        ProductName = productName,
        Price = price,
        QtyBefore = qty,
        QtySold = qtyToSell,
        CashierName = cashierName
      };

      _transactions.Add(transaction);
    }
  }
}