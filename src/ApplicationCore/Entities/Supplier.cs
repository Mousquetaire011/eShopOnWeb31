using Microsoft.eShopWeb.ApplicationCore.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace Microsoft.eShopWeb.ApplicationCore.Entities
{
    public class Supplier : BaseEntity, IAggregateRoot
    {
        public string Name { get; set; }
    }
}
