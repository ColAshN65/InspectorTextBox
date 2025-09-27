namespace InspectorTextBox.Events;

public class InspectorEventArgs : EventArgs
{
    public InspectorState State { get; }
    public string Value { get; }
    public InspectorEventArgs(InspectorState state, string value)
    {
        State = state;
        Value = value;
    }
}
