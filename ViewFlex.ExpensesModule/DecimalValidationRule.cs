using System.Globalization;
using System.Windows.Controls;

namespace ViewFlex.ExpensesModule;

public class DecimalValidationRule : ValidationRule
{
    public override ValidationResult Validate(object value, CultureInfo cultureInfo)
    {
        if (value is null || string.IsNullOrWhiteSpace(value.ToString())) return new ValidationResult(false, "Input can not be empty.");
        if (!decimal.TryParse(value.ToString(), out _)) return new ValidationResult(false, "Input value is not decimal");
        return ValidationResult.ValidResult;
    }
}
