using Practise.Core.DataAccess.EntityFramework;
using Practise.DataAccess.Abstract;
using Practise.DataAccess.Concrete.EntityFramework.Contexts;
using Practise.Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Practise.DataAccess.Concrete.EntityFramework
{
   public class EfCategoryDal: EntityRepositoryBase<Category, NorthwindContext>, ICategoryDal
    {
    }
}
