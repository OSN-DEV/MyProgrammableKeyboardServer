using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;


namespace RemoteControl
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {

        private static class NativeMethods {
            public delegate IntPtr KeyboardGlobalHookCallback(int code, uint msg, ref KBDLLHOOKSTRUCT hookData);

            // https://msdn.microsoft.com/ja-jp/library/cc430103.aspx
            [System.Runtime.InteropServices.DllImport("user32.dll")]
            public static extern IntPtr SetWindowsHookEx(int idHook, KeyboardGlobalHookCallback lpfn, IntPtr hMod, uint dwThreadId);

            // https://msdn.microsoft.com/ja-jp/library/cc429591.aspx
            [System.Runtime.InteropServices.DllImport("user32.dll")]
            public static extern IntPtr CallNextHookEx(IntPtr hhk, int nCode, uint msg, ref KBDLLHOOKSTRUCT hookData);

            // https://msdn.microsoft.com/ja-jp/library/cc430120.aspx
            [System.Runtime.InteropServices.DllImport("user32.dll")]
            [return: System.Runtime.InteropServices.MarshalAs(System.Runtime.InteropServices.UnmanagedType.Bool)]
            public static extern bool UnhookWindowsHookEx(IntPtr hhk);

            [System.Runtime.InteropServices.DllImport("user32.dll")]
            public static extern uint keybd_event(byte bVk, byte bScan, uint dwFlags, UIntPtr dwExtraInfo);
        }

        private static class KeyStroke {
            public const uint KeyDown = 0x100;
            public const uint KeyUp = 0x101;
            public const uint SysKeyDown = 0x104;
            public const uint SysKeyup = 0x105;
        }

        private static class ScanCode {
            public const byte Alpha = 0x71;
            public const byte Kana = 0x72;
            public const byte IMENonconvert = 0x1D;
            public const byte IMEConvert = 0x1C;
        }

        private static class VirtualKey {
            public const byte IMENonconvert = 0x1D;
            public const byte IMEConvert = 0x1C;
        }

        private static class Flags {
            public const uint KeyDown = 0x0;
            public const uint KeyUp = 0x02;
        }

        [System.Runtime.InteropServices.StructLayout(System.Runtime.InteropServices.LayoutKind.Sequential)]
        private struct KBDLLHOOKSTRUCT {
            public uint vkCode;
            public uint scanCode;
            public uint flags;
            public uint time;
            public IntPtr dwExtraInfo;
        }

        private static IntPtr Handle;
        private static event NativeMethods.KeyboardGlobalHookCallback hookCallback;










        public MainWindow()
        {
            InitializeComponent();
            remoteControl1.StartServer();
        }

        private void buttonRed_Click(object sender, RoutedEventArgs e)
        {
            Background = new SolidColorBrush(Colors.Red);
        }

        private void buttonGreen_Click(object sender, RoutedEventArgs e)
        {
            Background = new SolidColorBrush(Colors.Green);
        }

        private void buttonBlue_Click(object sender, RoutedEventArgs e)
        {
            Background = new SolidColorBrush(Colors.Blue);
        }

        private void remoteControl11_RemoteControl(object sender, RoutedEventArgs e1)
        {
            var e = e1 as RemoteControl1.RemoteControlEventArgs;
            if (e.pageParams.ContainsKey("red"))
                buttonRed_Click(null, null);
            if (e.pageParams.ContainsKey("blue"))
                buttonBlue_Click(null, null);
            if (e.pageParams.ContainsKey("green"))
                buttonGreen_Click(null, null);
            if (e.pageParams.ContainsKey("pgup")) {
                NativeMethods.keybd_event(0x21, 0, 0, (UIntPtr)0);
                NativeMethods.keybd_event(0x21, 0, 2, (UIntPtr)0);
            }
            // https://msdn.microsoft.com/en-us/library/windows/desktop/dd375731(v=vs.85).aspx
            if (e.pageParams.ContainsKey("pgdown")) {
                NativeMethods.keybd_event(0x22, 0, 0, (UIntPtr)0);
                NativeMethods.keybd_event(0x22, 0, 2, (UIntPtr)0);
            }
            if (e.pageParams.ContainsKey("name") && e.pageParams["name"] != "")
                textBlockHello.Text = "Hello " + e.pageParams["name"] + "!";
            else
                textBlockHello.Text = "";
        }
    }
}
