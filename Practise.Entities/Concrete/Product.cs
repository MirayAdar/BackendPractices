using Practise.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Practise.Entities.Concrete
{
    //IEntity'i daha sonrasında kısıtlamalarda kullanmak için oluşturduk
    public class Product: IEntity
    {
        public int ProductId { get; set; }
        public string ProductName { get; set; }
        public int CategoryId { get; set; }
        public string QuantityPerUnit { get; set; }
        public decimal UnitPrice { get; set; }
        public short UnitsPerUnit { get; set; }
    }
}
