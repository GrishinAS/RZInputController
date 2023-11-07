using System.Runtime.InteropServices;

namespace RazorController;

public class LibraryMethods
{
    [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
    public delegate bool Initialize();
    
    [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
    public delegate void MouseMove(int x, int y, bool from_start_point);
    public delegate void MouseClick(MouseInput click_mask);
    
    public delegate void KeyboardInput(Key scan_code, KeyState up_down);
}