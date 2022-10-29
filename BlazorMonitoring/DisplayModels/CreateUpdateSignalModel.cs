using System.ComponentModel.DataAnnotations;

namespace BlazorMonitoring.DisplayModels;

public class CreateUpdateSignalModel
{
    private string? _value;

    [Required(ErrorMessage = "Numeric value is required.")]
    public string? Value
    {
        get 
        { 
            return _value; 
        }
        set
        {
            if (double.TryParse(value, out double doubleValue))
            {
                _value = value;
            }
            else
            {
                _value = null;
            }
            
        }
    }

    [Required(ErrorMessage = "unit is required.")]
    public string? Unit { get; set; }
}
