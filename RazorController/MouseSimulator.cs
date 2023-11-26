namespace RazorController;

public class MouseSimulator : DeviceSimulator
{
    /// <summary>
    /// Moves the mouse cursor to a specified point on the screen.
    /// </summary>
    /// <param name="x">
    /// The horizontal offset from the current mouse position if going from a point,
    /// or a number in the range of 1 to 65536, where 1 is the top left corner of the screen.
    /// Note: x and/or y cannot be 0 unless going from the start point.
    /// </param>
    /// <param name="y">
    /// The vertical offset from the current mouse position if going from a point,
    /// or a number in the range of 1 to 65536, where 1 is the top left corner of the screen.
    /// Note: x and/or y cannot be 0 unless going from the start point.
    /// </param>
    /// <param name="fromStartPoint">If true, the x and y parameters represent the offset from the current mouse position.
    /// Otherwise, they specify a point on the screen.</param>
    /// <remarks>
    ///  If multiple monitors are used, the input values remain the same,
    /// but the outcome may vary. It is recommended to avoid dealing with multiple monitors due to potential issues.
    /// </remarks>
    public void MouseMove(int x, int y, bool fromStartPoint  = true)
    {
        if (DllWrapper == null) throw new InvalidOperationException("Not initialized");
        if (!fromStartPoint && (x == 0 || y == 0))
            throw new ArgumentException("x and/or y can not be 0 unless going from start point");
        DllWrapper.MouseMove(x, y, fromStartPoint);
    }

    public void MouseInput(Button button, KeyState direction)
    {
        if (DllWrapper == null) throw new InvalidOperationException("Not initialized");
        var mouseInput = MouseButtons.ButtonsDictionary[new MouseEvent(button, direction)];
        DllWrapper.MouseClick(mouseInput);
    }
    
    public void MouseClick(Button button, int releaseDelay = 75)
    {
        MouseInput(button, KeyState.Down);
        Thread.Sleep(releaseDelay);
        MouseInput(button, KeyState.Up);
    }
    
    public void MouseScroll(KeyState direction, int lines = 1)
    {
        if (DllWrapper == null) throw new InvalidOperationException("Not initialized");
        if (direction == KeyState.Down)
            for (int i = 0; i < lines; i++)
                DllWrapper.MouseClick(RazorController.MouseInput.ScrollDown);
        else
            for (int i = 0; i < lines; i++)
                DllWrapper.MouseClick(RazorController.MouseInput.ScrollUp);
        
    }
}