using FluentValidation;
using FluentValidation.Results;
using System;
using System.Collections.Concurrent;
using System.Linq;
using System.Reflection;

namespace WebMotions.Azure.WebJobs.Extensions.Slack.Validators
{
    public class SlackBlockValidator
    {
        private static readonly ConcurrentDictionary<Type, Type> _validatorsMap = new ConcurrentDictionary<Type, Type>();

        public ValidationResult Validate(object element)
        {
            var elementType = element.GetType();

            if (!_validatorsMap.TryGetValue(elementType, out Type validatorType))
            {
                var abstractValidatorType = typeof(AbstractValidator<>);
                var elementValidatorType = abstractValidatorType.MakeGenericType(elementType);
                validatorType = Assembly.GetExecutingAssembly().GetTypes().FirstOrDefault(t => t.IsSubclassOf(elementValidatorType));
                _validatorsMap.GetOrAdd(elementType, validatorType);
            }

            if (validatorType == null)
            {
                throw new NullReferenceException($"Cannot find a validator for type {elementType}");
            }

            var validator = (IValidator)Activator.CreateInstance(validatorType);
            return validator.Validate(new ValidationContext<object>(element));
        }
    }
}