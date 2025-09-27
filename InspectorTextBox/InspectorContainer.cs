using CommunityToolkit.Mvvm.ComponentModel;
using InspectorTextBox.Events;

namespace InspectorTextBox;

public partial class InspectorContainer : ObservableObject, IDisposable
{
    [ObservableProperty]
    private string _value;

    [ObservableProperty]
    private string _notification;

    [ObservableProperty]
    private InspectorState _state;

    /*[ObservableProperty]
    private bool _isLocked;

    private bool _isReady;
    public bool IsReady
    {
        get => _isReady;
        private set
        {
            _isReady = value;
            IsReadyChanged?.Invoke(this, new InspectorEventArgs(value));
        }
    }*/

    public event InspectorEventHandler StateChanged;

    public InspectorContainer(string value = "")
        => Init([], value);
    public InspectorContainer(IEnumerable<IInspectorValidator> validators, string value = "")
        => Init(validators, value);

    public void Dispose()
    {
        StateChanged = null;
    }

    partial void OnValueChanged(string value)
        => ValidateValue(value);

    partial void OnStateChanged(InspectorState value)
    {
        StateChanged?.Invoke(this, new InspectorEventArgs(value));
    }

    private IEnumerable<IInspectorValidator> validators;

    private void Init(IEnumerable<IInspectorValidator> validators, string value)
    {
        this.validators = validators;
        Value = value;
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
