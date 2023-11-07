
namespace RazorController;

public class KeyboardSimulator : DeviceSimulator
{
    public void SetKeyState(Key code, KeyState state)
    {
        if (DllWrapper == null)
            throw new InvalidOperationException("Not initialized");
        DllWrapper.KeyboardInput(code, state);
    }

    public void KeyDown(Key code) {
        SetKeyState(code, KeyState.Down);
    }

    public void KeyUp(Key code) {
        SetKeyState(code, KeyState.Up);
    }

    public void KeyPress(Key code, int releaseDelay = 75) {
        KeyDown(code);
        Thread.Sleep(releaseDelay);
        KeyUp(code);
    }

    public bool SimulateInput(string text, int delayBetweenKeyPresses = 50, int releaseDelay = 75) {
        bool shiftDown = false;
        foreach (char letter in text) {
            if (!KeyData.KeyDictionary.TryGetValue(letter, out KeyData keyData))
                keyData =  new KeyData { Code = Key.Slash, Shift = true };
            if (keyData.Shift != shiftDown) {
                if (keyData.Shift) {
                    SetKeyState(Key.LShift, KeyState.Down);
                } else {
                    SetKeyState(Key.LShift, KeyState.Up);
                }
                shiftDown = keyData.Shift;
            }
            KeyPress(keyData.Code, releaseDelay);
            Thread.Sleep(delayBetweenKeyPresses);
        }
        if (shiftDown) {
            SetKeyState(Key.LShift, KeyState.Up);
        }
        return true;
    }
}