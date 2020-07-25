using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RecapProject1.Entities
{
    public class Product    // Bu tekil yapılır. DB de adı Products dır. Nesne yaparken teke indirirsin.
    {
        public int ProductId { get; set; }
        public int CategoryId { get; set; }
        public string ProductName { get; set; }

        public decimal UnitPrice { get; set; }

        public Int16 UnitsInStock { get; set; }          //db de smallint tipi burda int16 ya denk gelir. int ın küçük versiyonudur.

        public string QuantityPerUnit { get; set; }
    }
}
