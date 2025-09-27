namespace InspectorTextBox;

/// <summary>
///     Interface for validation in <see cref="InspectorContainer"/>
/// </summary>
public interface IInspectorValidator
{
    /// <summary>
    ///     The method that must validate the value.
    /// </summary>
    /// <returns>
    ///     It must returns NULL if validation is successful. Otherwise, returns a message.
    /// </returns>
    Task<string?> ValidateAsync(string value);
}
