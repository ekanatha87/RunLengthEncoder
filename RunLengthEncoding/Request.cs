using System.ComponentModel.DataAnnotations;

public class Request
{
    private string _input;

    [Required(ErrorMessage = "Input cannot be empty.")]
    [RegularExpression("^[a-zA-Z]+$", ErrorMessage = "Input must contain only letters.")]
    public string Input
    {
        get => _input;
        set => _input = value?.Replace(" ", "").ToLower();
    }
}
