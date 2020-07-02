using Microsoft.eShopWeb.ApplicationCore.Interfaces;


namespace Microsoft.eShopWeb.ApplicationCore.Entities
{
    public class Stock : BaseEntity, IAggregateRoot
    {

        public int Quantity { get; set; }

    }
}
