using Microsoft.eShopWeb.ApplicationCore.Entities.OrderAggregate;
using Microsoft.eShopWeb.ApplicationCore.Interfaces;
using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace Microsoft.eShopWeb.ApplicationCore.Entities
{
    public class BankingOperations : BaseEntity, IAggregateRoot
    {
        public string OperationLabel { get; set; }
        [NotMapped]
        public int SelectedOrderId { get; set; }
        public Order Order { get; set; }
        public Supplier Supplier { get; set; }
        public double Credit { get; set; }
        public double Debit { get; set; }
        public DateTime OperationDate { get; set; }
        public DateTime BankingDate { get; set; }
    }
}
