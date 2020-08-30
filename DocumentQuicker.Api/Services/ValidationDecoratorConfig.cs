using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using FluentValidation;

namespace DocumentQuicker.Api.Services
{
    public class ValidationDecoratorConfig
    {
        private readonly IDictionary<Type, IValidator> _validators = new ConcurrentDictionary<Type, IValidator>();

        public void AddValidator<T>(AbstractValidator<T> validator)
        {
            _validators.Add(typeof(T), validator);
        }

        public void AddValidator<T>(IValidator<T> validator)
        {
            _validators.Add(typeof(T), validator);
        }

        public void AddValidator(Type type, IValidator validator)
        {
            _validators.Add(type, validator);
        }

        public void AddValidators(Assembly assembly)
        {
            var allTypes = assembly.GetTypes().Where(x => x.IsClass && !x.IsAbstract).ToList();
            foreach (var type in allTypes)
            {
                if (!typeof(IValidator).IsAssignableFrom(type) || (type.BaseType == null || !type.BaseType.IsGenericType)) 
                    continue;
                
                if(type.GetConstructor(Type.EmptyTypes) == null)
                    continue;
                    
                var genericConstraintTypes = type.BaseType.GenericTypeArguments;
                if(genericConstraintTypes.Length != 1)
                    continue;

                var modelType = genericConstraintTypes.First();
                
                try
                {
                    var instance = Activator.CreateInstance(type);
                    AddValidator(modelType, instance as IValidator);
                }
                catch
                {
                    //ignore
                }
            }
        }

        public IValidator<T> FindValidator<T>(T type) where T : class
        {
            if (_validators.TryGetValue(type.GetType(), out var validator))
                return validator as IValidator<T>;
            
            throw new KeyNotFoundException($"Validation Decorator Config do not contain validator for {type} type");
        }
    }
}