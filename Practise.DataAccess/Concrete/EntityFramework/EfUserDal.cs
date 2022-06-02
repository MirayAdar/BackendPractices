using Practise.Core.DataAccess.EntityFramework;
using Practise.Core.Entities.Concrete;
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
    public class EfUserDal : EntityRepositoryBase<User, NorthwindContext>, IUserDal
    {
        public List<OperationClaim> GetClaims(User user)
        {
            using (var context = new NorthwindContext()) {
                var result = from operationClaim in context.OperationClaims
                             join userOperationClaim in context.UserOperationClaims
                             on operationClaim.Id equals userOperationClaim.OperationClaimId
                             where userOperationClaim.UserId == user.Id
                             select new OperationClaim { Id = operationClaim.Id, Name = operationClaim.Name };

                return result.ToList();

          }
        }
    }
}
