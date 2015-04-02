using System;
using System.Runtime.Serialization;
using System.Windows.Forms;

namespace TextTransformer.Core
{

    [Flags]
    public enum HotKeyModifiers : uint
    {
        None = 0,
        Alt = 1,
        Control = 2,
        Shift = 4,
        Windows = 8
    }

    public class HotKeyBinding
    {

        public HotKeyBinding()
        {
            
        }

        public Action Action { get; set; }

        public Keys HotKeyCharacter { get; set; }

        public HotKeyModifiers HotKeyModifiers { get; set; }

        public int WindowsHotkeyId { get; set; }

        public bool HotKeyRegisteredSuccessfully { get; set; }

    }
}