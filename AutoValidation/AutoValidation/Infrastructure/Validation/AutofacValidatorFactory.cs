using System;
using Autofac;
using FluentValidation;

namespace AutoValidation.Infrastructure.Validation {
    public class AutofacValidatorFactory : IValidatorFactory {
        private readonly IComponentContext _container;

        public AutofacValidatorFactory(IComponentContext provider) {
            _container = provider;
        }

        public IValidator<T> GetValidator<T>() {
            return (IValidator<T>)GetValidator(typeof(T));
        }

        public IValidator GetValidator(Type type) {
            var genericType = typeof(IValidator<>).MakeGenericType(type);
            object validator;
            if (_container.TryResolve(genericType, out validator))
                return (IValidator)validator;
            return null;
        }
    }
}