using System.Reflection;

namespace RazorController;

public class Resouces
{
    public static byte[] GetResource(string name) {
        TypeInfo typeInfo = typeof(Resouces).GetTypeInfo();
        Assembly assembly = typeInfo.Assembly;
        string path = typeInfo.Namespace + ".lib." + name;
        using Stream? stream = assembly.GetManifestResourceStream(path);
        if (stream == null)
        {
            throw new DllNotFoundException(name);
        }
        byte[] result = new byte[stream.Length];
        stream.Read(result, 0, (int)stream.Length);
        return result;
    }
}