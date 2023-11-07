using System.Runtime.InteropServices;

namespace RazorController;

public class DllWrapper : IDisposable
{
    private readonly string DllTempName;
    private readonly IntPtr DllPointer;
    
    public readonly LibraryMethods.Initialize Initialize;
    public readonly LibraryMethods.MouseMove MouseMove;
    public readonly LibraryMethods.MouseClick MouseClick;
    public readonly LibraryMethods.KeyboardInput KeyboardInput;
    
    public bool Disposed;

    public DllWrapper(Byte[] DllBytes) {
        DllTempName = Path.GetTempFileName();
        File.WriteAllBytes(DllTempName, DllBytes);
        DllPointer = WindowsApi.LoadLibrary(DllTempName);
        Initialize = GetFunction<LibraryMethods.Initialize>("init");
        MouseMove = GetFunction<LibraryMethods.MouseMove>("mouse_move");
        MouseClick = GetFunction<LibraryMethods.MouseClick>("mouse_click");
        KeyboardInput = GetFunction<LibraryMethods.KeyboardInput>("keyboard_input");

        Disposed = false;
    }
    
    ~DllWrapper() {
        Dispose();
    }

    public void Dispose() {
        if (!Disposed) {
            WindowsApi.FreeLibrary(DllPointer);
            File.Delete(DllTempName);
            Disposed = true;
        }
    }
    
    private TDelegate GetFunction<TDelegate>(string procedureName) {
        IntPtr procedureAddress = WindowsApi.GetProcAddress(DllPointer, procedureName);
        return Marshal.GetDelegateForFunctionPointer<TDelegate>(procedureAddress);
    }

    
}