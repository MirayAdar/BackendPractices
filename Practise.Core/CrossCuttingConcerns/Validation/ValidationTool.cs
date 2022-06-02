using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Practise.Core.CrossCuttingConcerns.Validation
{
    public static class ValidationTool
    {
        public static void Validate(IValidator validator, object entity) // IEntity tipinde bir entity de geçebilirdik ama dtolara da uygulamak istersek diye genel object dedik
        { 
            var result = validator.Validate((IValidationContext)entity);
            if (!result.IsValid)
            {
                throw new ValidationException(result.Errors);
            }
        }
        
    }
}
