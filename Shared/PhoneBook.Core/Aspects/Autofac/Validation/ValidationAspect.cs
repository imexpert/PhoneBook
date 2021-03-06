using System;
using System.Linq;
using Castle.DynamicProxy;
using PhoneBook.Core.CrossCuttingConcerns.Validation;
using PhoneBook.Core.Utilities.Interceptors;
using PhoneBook.Core.Utilities.Messages;
using FluentValidation;

namespace PhoneBook.Core.Aspects.Autofac.Validation
{
    /// <summary>
    /// ValidationAspect
    /// </summary>
    public class ValidationAspect : MethodInterception
    {
        private readonly Type _validatorType;

        public ValidationAspect(Type validatorType)
        {
            if (!typeof(IValidator).IsAssignableFrom(validatorType))
            {
                throw new ArgumentException(AspectMessages.WrongValidationType);
            }

            _validatorType = validatorType;
        }

        protected override void OnBefore(IInvocation invocation)
        {
            var validator = (IValidator)Activator.CreateInstance(_validatorType);
            var entityType = _validatorType.BaseType.GetGenericArguments()[0];
            var entities = invocation.Arguments.Where(t => t.GetType() == entityType);
            foreach (var entity in entities)
            {
                ValidationTool.Validate(validator, entity);
            }
        }
    }
}