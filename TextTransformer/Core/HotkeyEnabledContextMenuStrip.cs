﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Windows.Forms;

namespace TextTransformer.Core
{

    //https://github.com/dwmkerr/firekeys/blob/master/src/FireKeys/FireKeys/HotkeyEnabledContextMenuStrip.cs
    public class HotkeyEnabledContextMenuStrip : ContextMenuStrip
    {

        //private int hotkeyUniqueId = 123; //???

        private int uniqueHotkeyIdCounter = 140; //???

        private const int WM_HOTKEY = 0x0312;

        private readonly Dictionary<int, HotKeyBinding> hotKeyCodesToHotKeys = new Dictionary<int, HotKeyBinding>(); 

        public Control InitialPositionControl { get; set; }

        [DllImport("user32.dll")]
        private static extern bool RegisterHotKey(IntPtr hWnd, int id, uint fsModifiers, uint vk);

        [DllImport("user32.dll")]
        private static extern bool UnregisterHotKey(IntPtr hWnd, int id);

        protected override void Dispose(bool disposing)
        {
            UnregisterHotkeyBindings();
            base.Dispose(disposing);
        }

        public void UnregisterHotkeyBindings()
        {
            foreach (var keyBinding in hotKeyCodesToHotKeys.Values)
                UnregisterHotKey(Handle, keyBinding.WindowsHotkeyId);
            hotKeyCodesToHotKeys.Clear();
        }

        public void RegisterHotKeyToMenuItem(HotKeyBinding hotKey)
        {
            hotKey.WindowsHotkeyId = uniqueHotkeyIdCounter++;

            hotKey.HotKeyRegisteredSuccessfully = RegisterHotKey(Handle, 
                hotKey.WindowsHotkeyId, (uint) hotKey.HotKeyModifiers, (uint) hotKey.HotKeyCharacter);

            hotKeyCodesToHotKeys[hotKey.WindowsHotkeyId] = hotKey;
        }

        protected override void WndProc(ref Message m)
        {
            base.WndProc(ref m);

            if (m.Msg == WM_HOTKEY)
            {
                var hotKeyId = (int) m.WParam;

                HotKeyBinding hotKey;
                if (hotKeyCodesToHotKeys.TryGetValue(hotKeyId, out hotKey) == false)
                {
                    return;
                }

                hotKey.Action();
            }
        }

    }
}
