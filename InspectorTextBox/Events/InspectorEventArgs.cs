namespace InspectorTextBox.Events;

public class InspectorEventArgs : EventArgs
{
    public InspectorState State { get; }
    public InspectorEventArgs(InspectorState state)
    {
        State = state;
    }
}
