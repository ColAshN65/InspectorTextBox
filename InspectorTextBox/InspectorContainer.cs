using CommunityToolkit.Mvvm.ComponentModel;
using InspectorTextBox.Events;

namespace InspectorTextBox;

/// <summary>
///     Class that implements interaction with the InspectorBox at the ViewModel level.
///     It contains a Value property, which is checked by the specified validators.
/// </summary>
public partial class InspectorContainer : ObservableObject, IDisposable
{
    [ObservableProperty]
    private string _value;

    [ObservableProperty]
    private string _notification;

    private IEnumerable<IInspectorValidator> validators;

    private InspectorState _state;
    private InspectorState State
    {
        get => _state;
        set
        {
            _state = value;
            StateChanged?.Invoke(this, new InspectorEventArgs(value, Value));
        }
    }

    public event InspectorEventHandler StateChanged;
    public event InspectorEventHandler ValueChanged;

    public InspectorContainer(IEnumerable<IInspectorValidator> validators, string value = "")
    {
        this.validators = validators;
        Value = value;
    }

    public void SetValidators(IEnumerable<IInspectorValidator> newValidators)
        => validators = newValidators;

    public void Dispose()
    {
        StateChanged = null;
    }

    partial void OnValueChanged(string value)
    {
        ValidateValue(value);
        ValueChanged?.Invoke(this, new InspectorEventArgs(State, value));
    }

    private async void ValidateValue(string value)
    {
        State = InspectorState.Validating;

        foreach (var validator in validators)
        {
            string result = await validator.ValidateAsync(value);

            if (result is not null)
            {
                Notification = result;

                State = InspectorState.Error;
                return;
            }
        }

        Notification = "";
        State = InspectorState.Ready;
    }
}
