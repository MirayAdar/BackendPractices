using Practise.Business.Abstract;
using Practise.Business.ReturnMessages;
using Practise.Core.Utilities.Results;
using Practise.DataAccess.Abstract;
using Practise.Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Practise.Business.Concrete
{
    class ProductService : IProductService
    {
        private IProductDal _productDal;

        public ProductService(IProductDal productDal)
        {
            _productDal = productDal;
        }
      
        //DataResult'ın interfaceini kullanmamızın sebebi hem Error hem Success'i döndürebilmek
        public IDataResult<Product> GetById(int id)
        {
            return new SuccessDataResult<Product>(_productDal.Get(p => p.CategoryId == id));
       }

    
        public IDataResult<List<Product>> GetList()
        {
            return new SuccessDataResult<List<Product>>(_productDal.GetList().ToList());
        }

        public IDataResult<List<Product>> GetListByCategory(int categoryId)
        {
            return new SuccessDataResult<List<Product>>(_productDal.GetList(p => p.CategoryId == categoryId).ToList());
        }
        public IResult Add(Product product)
        {
            _productDal.Add(product);
            return new SuccessResult(true, Messages.ProductAdded);
        }

        public IResult Delete(Product product)
        {
            _productDal.Delete(product);
            return new SuccessResult(true, Messages.ProductDeleted);
        }
        public IResult Update(Product product)
        {
            _productDal.Update(product);
            return new SuccessResult(false, Messages.ProductUpdated);
        }
    }
}
