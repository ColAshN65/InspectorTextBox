namespace InspectorTextBox;

public interface IInspectorValidator
{
    Task<string?> ValidateAsync(string value);
}
