namespace RazorController;

public class DeviceSimulator
{
    protected DllWrapper? DllWrapper;
    public bool Initialized => DllWrapper != null;
    public  bool Disposed => DllWrapper?.Disposed ?? true;

    public bool Initialize() {
        if (Initialized)
            return true;
        try {
            byte[] dllBytes = Resouces.GetResource("rzctl.dll");
            DllWrapper = new DllWrapper(dllBytes);
            DllWrapper.Initialize();
            return true;
        } catch (Exception exception) {
            Console.WriteLine(exception);
            return false;
        }
    }

    public  bool Dispose() {
        if (Disposed)
            return true;
        try {
            DllWrapper?.Dispose();
            DllWrapper = null;
            return true;
        } catch (Exception exception) {
            Console.WriteLine(exception);
            return false;
        }
    }
}