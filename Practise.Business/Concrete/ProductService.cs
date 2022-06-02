using FluentValidation;
using Practise.Business.Abstract;
using Practise.Business.ReturnMessages;
using Practise.Business.ValidationRules.FluentValidator;
using Practise.Core.Aspects.Autofac.Transaction;
using Practise.Core.Aspects.Autofac.Validation;
using Practise.Core.CrossCuttingConcerns.Validation;
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
        [ValidationAspect(typeof(ProductValidator))]
        public IResult Add(Product product)
        {
            ValidationTool.Validate(new ProductValidator(), product); // aşağıdaki işlem yerine merkezi bir şekilde yönetmek için yazdık ama daha merkezisi yukarıda
            //ProductValidator productValidator = new ProductValidator();
            //var result = productValidator.Validate(product);
            //if (!result.IsValid)
            //{
            //    throw new ValidationException(result.Errors);
            //}
            _productDal.Add(product);
            return new SuccessResult( Messages.ProductAdded);
        }

        public IResult Delete(Product product)
        {
            _productDal.Delete(product);
            return new SuccessResult(Messages.ProductDeleted);
        }
        public IResult Update(Product product)
        {
            _productDal.Update(product);
            return new SuccessResult( Messages.ProductUpdated);
        }

        [TransactionScopeAspect]
        public IResult TransactionalOperation(Product product) // update başarılı olsun add başarısız olsun dolayısıyla update işlemini geri al kurgusu
        {
            _productDal.Update(product);
            _productDal.Add(product);
            return new SuccessResult(Messages.ProductUpdated);
        }
    }
}
