using System.ComponentModel.DataAnnotations;

namespace RoyalMoanaDivingSites.API.DTO.Validations
{
    public class DifficultyValidation : ValidationAttribute
    {
        public DifficultyValidation(Type managerType)
        {
            ManagerType = managerType;
        }

        public Type ManagerType { get; set; }
        public override bool IsValid(object? value)
        {
            if (string.IsNullOrEmpty(value?.ToString())) return true;
            foreach (var test in ManagerType.GetEnumValues())
            {
                if (test.ToString() == (string)value)
                {
                    return true;
                }
            }
            return false;
        }
    }
}
