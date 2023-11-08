namespace RazorController;

public class DeviceSimulator
{
    protected DllWrapper DllWrapper;
    public  bool Disposed => DllWrapper?.Disposed ?? true;

    public DeviceSimulator()
    {
        byte[] dllBytes = Resouces.GetResource("rzctl.dll");
        DllWrapper = new DllWrapper(dllBytes);
        DllWrapper.Initialize();
    }

    public bool Dispose() {
        if (Disposed)
            return true;
        try {
            DllWrapper.Dispose();
            DllWrapper = null;
            return true;
        } catch (Exception exception) {
            Console.WriteLine(exception);
            return false;
        }
    }
}