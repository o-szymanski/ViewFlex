using System.Globalization;
using System.Windows.Controls;

namespace ViewFlex.ExpensesModule;

public class DecimalValidationRule : ValidationRule
{
    public override ValidationResult Validate(object value, CultureInfo cultureInfo)
    {
        var input = value?.ToString();
        if (string.IsNullOrWhiteSpace(input)) return new ValidationResult(false, "Input can not be empty.");
        if (!decimal.TryParse(input, out _)) return new ValidationResult(false, "Input value is not decimal");
        return ValidationResult.ValidResult;
    }
}
