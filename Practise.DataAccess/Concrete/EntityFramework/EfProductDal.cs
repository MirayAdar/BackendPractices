using Practise.Core.DataAccess.EntityFramework;
using Practise.DataAccess.Abstract;
using Practise.DataAccess.Concrete.EntityFramework.Contexts;
using Practise.Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Practise.DataAccess.Concrete.EntityFramework
{
    public class EfProductDal : EntityRepositoryBase<Product, NorthwindContext>, IProductDal
    {

    }
}
