namespace InspectorTextBox.Example.Validators;

public class MaxStringLengthValidator : IInspectorValidator
{
    public MaxStringLengthValidator(int maxValue)
        => this.maxValue = maxValue;

    public async Task<string?> ValidateAsync(string value)
    {
        return await Task.Run(() => {
            if (value.Length > maxValue)
                return $"Value too long(Max {maxValue})";

            return null;
        });
    }

    private readonly int maxValue;
}
