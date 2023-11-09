using System.Runtime.InteropServices;

namespace RazorController;

internal class WindowsApi
{
    private const string Kernel32 = "kernel32.dll";
    
    [DllImport(Kernel32, SetLastError = true)]
    public static extern IntPtr LoadLibrary(string lpLibFileName);
    
    [DllImport(Kernel32, SetLastError = true)]
    public static extern bool FreeLibrary(IntPtr hLibModule);
    
    [DllImport(Kernel32, SetLastError = true)]
    public static extern IntPtr GetProcAddress(IntPtr hModule, string lpProcName);
}