using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MarketManagementSystem.Models
{
    public class Transaction
    {
        public int TransactionId { get; set; }
        public DateTime TimeStamp { get; set; }
        public int ProductId { get; set; }
        public string ProductName { get; set; } = string.Empty;
        public double Price { get; set; }
        public int QtyBefore { get; set; }
        public int QtySold { get; set; }
        public string CashierName { get; set; } = string.Empty;
    }
}