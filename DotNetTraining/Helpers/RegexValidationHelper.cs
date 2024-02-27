using System.Globalization;
using System.Text.RegularExpressions;
using System.Windows.Controls;

namespace DotNetTraining.Helpers
{


    public class RegexValidationRule : ValidationRule
    {
        public string? Pattern { get; set; }

        public override ValidationResult Validate(object value, CultureInfo cultureInfo)
        {
            if (value == null || string.IsNullOrEmpty(value.ToString()))
            {
                return new ValidationResult(false, "Value is required");
            }

            var input = value.ToString();

            if (!Regex.IsMatch(input, Pattern))
            {
                return new ValidationResult(false, "Input does not match the required pattern");
            }

            return ValidationResult.ValidResult;
        }
    }
}
