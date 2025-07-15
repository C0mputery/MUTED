using System;

namespace Godot;

[InputMap(nameof(InputAction))]
public partial class InputSystem : Node {
    public static Vector2 GetMovementInput() {
        return Input.GetVector(Forwards.Action, Forwards.Action, Forwards.Action, Forwards.Action);
    }
}

public class InputAction(StringName action) {
    public StringName Action => action;

    public bool IsPressed => Input.IsActionPressed(action);
    public bool IsJustPressed => Input.IsActionJustPressed(action);
    public bool IsJustReleased => Input.IsActionJustReleased(action);
    public float Strength => Input.GetActionStrength(action);

    public event Action Pressed;
    public void InvokePressed() => Pressed?.Invoke();
    public void Press() {
        Input.ActionPress(action);
        InvokePressed();
    }

    public event Action Released;
    public void InvokeReleased() => Released?.Invoke();
    public void Release() {
        Input.ActionRelease(action);
        InvokeReleased();
    }
}