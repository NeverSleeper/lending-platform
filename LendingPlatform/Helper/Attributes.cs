using System;
using System.ComponentModel.DataAnnotations;

namespace LendingPlattform.Helper
{
    /// <summary>
    /// Validate if a guid is empty.
    /// </summary>
    /// <remarks> The source of this code is in the description.</remarks>
    /// <see cref="https://stackoverflow.com/questions/7187576/validation-of-guid"/>
    [AttributeUsage(AttributeTargets.Property | AttributeTargets.Field | AttributeTargets.Parameter, AllowMultiple = false)]
    public class ValidGuid : ValidationAttribute
    {
        public override bool IsValid(object value)
        {
            if (value == null || (Guid)value == Guid.Empty)
                return false;

            var type = value.GetType();
            return !Equals(value, Activator.CreateInstance(Nullable.GetUnderlyingType(type) ?? type));
        }        
    }
}
