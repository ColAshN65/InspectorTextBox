namespace InspectorTextBox.Example.Validators;

public class MinStringLengthValidator : IInspectorValidator
{
    public MinStringLengthValidator(int minValue)
        => this.minValue = minValue;

    public async Task<string?> ValidateAsync(string value)
    {
        return await Task.Run(() => {
            if (value.Length < minValue)
                return $"Value too short (Min {minValue})";

            return null;
        });    }

    private readonly int minValue;
}
