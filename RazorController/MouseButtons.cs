namespace RazorController;

public class MouseButtons
{
    public static readonly Dictionary<MouseEvent, MouseInput> ButtonsDictionary;

    static MouseButtons()
    {
        ButtonsDictionary = new Dictionary<MouseEvent, MouseInput>
        {
            { new MouseEvent { Button = Button.Left, Direction = KeyState.Up}, MouseInput.LeftButtonUp },
            { new MouseEvent { Button = Button.Left, Direction = KeyState.Down}, MouseInput.LeftButtonDown },
            { new MouseEvent { Button = Button.Right, Direction = KeyState.Up}, MouseInput.RightButtonUp },
            { new MouseEvent { Button = Button.Right, Direction = KeyState.Down}, MouseInput.RightButtonDown },
            { new MouseEvent { Button = Button.ScrollWheel, Direction = KeyState.Up}, MouseInput.WheelButtonUp },
            { new MouseEvent { Button = Button.ScrollWheel, Direction = KeyState.Down}, MouseInput.WheelButtonDown },
        };
    }
    
    
}

public struct MouseEvent
{
    public Button Button;
    public KeyState Direction;

    public MouseEvent(Button button, KeyState direction)
    {
        Button = button;
        Direction = direction;
    }
}
public enum Button
{
    Left,
    Right,
    ScrollWheel
}

public enum MouseInput : uint
{
    LeftButtonDown  = 1,
    LeftButtonUp = 2,
    RightButtonDown = 4,
    RightButtonUp = 8,
    WheelButtonDown = 16,
    WheelButtonUp = 32,
    ScrollDown = 4287104000,
    ScrollUp = 7865344,
    
}