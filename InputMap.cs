using Godot;

namespace MÜTED;


[InputMap(nameof(GameInput))]
public static partial class MyGameInput;

// Example custom input action class
public class GameInput(StringName action)
{
    public StringName Action => action;

    public bool IsPressed => Input.IsActionPressed(action);
    public bool IsJustPressed => Input.IsActionJustPressed(action);
    public bool IsJustReleased => Input.IsActionJustReleased(action);
    public float Strength => Input.GetActionStrength(action);

    public void Press() => Input.ActionPress(action);
    public void Release() => Input.ActionRelease(action);
}