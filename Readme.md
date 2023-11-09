## C# Library for sending Keyboard and Mouse input using Razor Synapse


### Requirements
- [Razer Synapse](https://www.razer.com/synapse-3) (Must have the macro addon installed.)

## Credits
* Python wrapper - [0736b/rzctl-py](https://github.com/0736b/rzctl-py)
* Library - [thefat32/rzctl](https://github.com/thefat32/rzctl)

## Usage example:

        public static void Main()
        {
        MouseSimulator _mouse = new MouseSimulator();
        KeyboardSimulator _keyboard = new KeyboardSimulator();

        _mouse.MouseClick(Button.Right, 100);
        Thread.Sleep(50);
        
        _keyboard.KeyPress(Key.I);
        _mouse.MouseMove(300, 200);
        
        Thread.Sleep(50);
        _mouse.MouseMove(300, 200, false);
        Thread.Sleep(50);
        
        _keyboard.KeyDown(Key.Enter);
        Thread.Sleep(50);
        _keyboard.KeyUp(Key.Enter);
    }