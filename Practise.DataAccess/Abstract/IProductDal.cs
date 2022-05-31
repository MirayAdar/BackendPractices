using Practise.Core.DataAccess;
using Practise.Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Practise.DataAccess.Abstract
{
    public interface IProductDal:IEntityRepository<Product>
    {

    }
}
