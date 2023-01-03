using System.ComponentModel.DataAnnotations;

namespace BoardGamesListAPI.Validators
{
    public class SortColumnValidator : ValidationAttribute
    {
        public readonly Type entityType;
        public SortColumnValidator(Type entityType)
            : base("Value must match an existing column.")
        {
            this.entityType = entityType;
        }

        protected override ValidationResult? IsValid(object? value, ValidationContext validationContext)
        {
            if(entityType!=null)
            {
                var strValue = value as string;
                if (!string.IsNullOrEmpty(strValue)
                    && entityType.GetProperties()
                        .Any(p => p.Name == strValue))
                    return ValidationResult.Success;
            }
            return new ValidationResult(ErrorMessage);
        }
    }
}
