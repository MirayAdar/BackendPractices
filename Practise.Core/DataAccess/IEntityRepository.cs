using Practise.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Practise.Core.DataAccess
{
    //Bu kısıtlamayı sonrasında T yerine tip verirken bir hataya yol açmamasını hedefliyoruz. new()in amacı IEntity dahil olmasın
    public interface IEntityRepository<T> where T:class, IEntity, new()
    {
        IList<T> GetList(Expression<Func<T, bool>> filter = null); // List<T> GetAll();
        T Get(Expression<Func<T, bool>> filter); // T GetById(int id); yerine her türlü veriyi gönderebilmek için bu şekilde yazıyoruz
        void Add(T entity);
        void Update(T entity);
        void Delete(T entity);
    }
}
