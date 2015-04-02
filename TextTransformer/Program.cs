using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Forms;
using System.Diagnostics;
using System.Windows.Forms.VisualStyles;
using System.Windows.Input;
using TextTransformer.Core;
using TextTransformer.Properties;
using System.Runtime.InteropServices;
using TextTransformer.Transformers;
using TextTransformer.UI;
using TextTransformer.Utils;
using TextTransformer.ViewModels;
using Application = System.Windows.Forms.Application;
using Clipboard = System.Windows.Forms.Clipboard;

namespace TextTransformer
{
    static class Program
    {
        [STAThread]
        private static void Main(string[] args)
        {
            if (Mutex.WaitOne(TimeSpan.Zero, true) == false) return;

            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);

            CreateContextMenu();
            CreateTrayIcon();

            _transformers = TransformerCollection.Load();

            _viewModel = new TransformViewModel(_transformers);

            Application.Run();

            Mutex.ReleaseMutex();
        }

        private static void ShowTransform()
        {
            SendCtrlC();

            //todo: 
            int tries = 0;
            while(tries < 5)
            {
                try
                {
                    _viewModel.Input = Clipboard.GetText();
                    break;
                }
                catch (Exception) { }
                Thread.Sleep(100 + tries * 100);
                tries++;
            }
           
            bool? result = new UITransformWindow(_viewModel).ShowDialog();

            if (result==true)
            {
                SendCtrlV();
            }
        }

        private static void CreateContextMenu()
        {
            _contextMenu = new HotkeyEnabledContextMenuStrip();
            _contextMenu.Name = Resources.AppName;
            
            var transformItem = new ToolStripMenuItem("&Transform");
            transformItem.Click += transformItem_Click;
            _contextMenu.Items.Add(transformItem);

            var exitItem = new ToolStripMenuItem("E&xit");
            exitItem.Click += exitItem_Click;
            _contextMenu.Items.Add(exitItem);

            _contextMenu.RegisterHotKeyToMenuItem(new HotKeyBinding()
            {
                Action = ShowTransform,
                HotKeyCharacter = Keys.NumPad3,
                HotKeyModifiers = HotKeyModifiers.Control | HotKeyModifiers.Alt
            });
        }

        private static void CreateTrayIcon()
        {
            _trayIcon = new NotifyIcon();
            _trayIcon.ContextMenuStrip = _contextMenu;
            _trayIcon.Icon = Resources.Icon;
            _trayIcon.Visible = true;
            _trayIcon.Text = Resources.AppName;
            _trayIcon.MouseDoubleClick += trayIcon_MouseDoubleClick;
        }

        static void ShowTipBalloon(string message)
        {
            _trayIcon.ShowBalloonTip(5000, Properties.Resources.AppName, message, ToolTipIcon.Info);
        }

        static void exitItem_Click(object sender, EventArgs e)
        {
            _trayIcon.Dispose();
            Application.Exit();
        }

        static void transformItem_Click(object sender, EventArgs e)
        {
            ShowTransform();
        }

        static void trayIcon_MouseDoubleClick(object sender, EventArgs e)
        {
            ShowTransform();
        }

        ////////////////////////////////////////////////////////

        private static void SendCtrlC()
        {
            KeyboardSimulator.WaitUntilNoModifiers();
            KeyboardSimulator.SimulateKeyStroke('c', ctrl: true);     
        }

        private static void SendCtrlV()
        {
            KeyboardSimulator.WaitUntilNoModifiers();
            KeyboardSimulator.SimulateKeyStroke('v', ctrl: true);
        }

        ////////////////////////////////////////////////////////

        private static TransformViewModel _viewModel;

        private static NotifyIcon _trayIcon;

        private static HotkeyEnabledContextMenuStrip _contextMenu;

        private static TransformerCollection _transformers;

        private static readonly Mutex Mutex = new Mutex(true, "{501b591b-9eef-4df3-95d3-e20af2292328}");
    }
}
