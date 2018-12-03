using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows;

namespace MyProgamableKeyboardServer {
    class SendKeys {

        #region Declaration
        private static class NativeMethods {
            [System.Runtime.InteropServices.DllImport("user32.dll")]
            public static extern uint keybd_event(byte bVk, byte bScan, uint dwFlags, UIntPtr dwExtraInfo);
        }

        /// <summary>
        /// 
        /// </summary>
        private static class VirtualKey {
            // ref :  http://wisdom.sakura.ne.jp/system/winapi/win32/win32.html
            public static byte C = (byte)'C';
            public static byte V = (byte)'V';
            public static int None = -1;
            public static byte Alt = 0x12;
            public static byte Control = 0x11;
            public static byte Down = 0x28;
            public static byte Esc = 0x1b;
            public static byte End = 0x23;
            public static byte F1 = 0x70;
            public static byte F2 = 0x71;
            public static byte F3 = 0x72;
            public static byte F4 = 0x73;
            public static byte F5 = 0x74;
            public static byte F6 = 0x75;
            public static byte F7 = 0x76;
            public static byte F8 = 0x77;
            public static byte F9 = 0x78;
            public static byte F10 = 0x79;
            public static byte F11 = 0x7A;
            public static byte F12 = 0x7B;
            public static byte Home = 0x24;
            public static byte Left = 0x25;
            public static byte PageUp = 0x21;
            public static byte PageDown = 0x22;
            public static byte PrintScreen = 0x2A;
            public static byte Right = 0x27;
            public static byte Shift = 0x10;
            public static byte Up = 0x26;
            public static byte Win = 0x5C;
        }

        /// <summary>
        /// 
        /// </summary>
        private static class KeyEventF {
            public static uint KeyDown = 0x0000;
            public static uint KeyUp = 0x0002;
        }

        private class KeyInfo {
            public byte Key;
            public bool Win = false;
            public bool Ctrl = false;
            public bool Alt = false;
            public bool Shift = false;
        }

        private Dictionary<string, byte> _keyMapping = new Dictionary<string, byte>() {
            {"c", VirtualKey.C },
            {"v", VirtualKey.V },
            {"down", VirtualKey.Down },
            {"esc", VirtualKey.Esc },
            {"end", VirtualKey.End },
            {"f1", VirtualKey.F1 },
            {"f2", VirtualKey.F2 },
            {"f3", VirtualKey.F3 },
            {"f4", VirtualKey.F4 },
            {"f5", VirtualKey.F5 },
            {"f6", VirtualKey.F6 },
            {"f7", VirtualKey.F7 },
            {"f8", VirtualKey.F8 },
            {"f9", VirtualKey.F9 },
            {"f10", VirtualKey.F10 },
            {"f11", VirtualKey.F11 },
            {"f12", VirtualKey.F12 },
            {"home", VirtualKey.Home },
            {"left", VirtualKey.Left },
            {"pgup", VirtualKey.PageUp },
            {"pgdown", VirtualKey.PageDown },
            {"right", VirtualKey.Right },
            {"ps", VirtualKey.PrintScreen },
            {"up", VirtualKey.Up },
       };
        #endregion

        #region Constructor
        public SendKeys() {
        }
        #endregion

        #region Public Method
        /// <summary>
        /// send key
        /// </summary>
        /// <param name="keys">key</param>
        public void Send(string keys) {
            KeyInfo keyInfo = this.ParseKey(keys);
            if (null != keyInfo) {
                this.SendKey(keyInfo, KeyEventF.KeyDown);
                this.SendKey(keyInfo, KeyEventF.KeyUp);
            }
        }
        #endregion


        #region Private Method
        /// <summary>
        /// parse key
        /// </summary>
        /// <param name="keys"></param>
        /// <returns>keyinfo. if unknown key return null</returns>
        private KeyInfo ParseKey(string keys) {
            KeyInfo keyInfo = new KeyInfo();
            bool found = false;
            foreach (var key in keys.ToLower().Split('+')) {
                if ("ctrl" == key) {
                    keyInfo.Ctrl = true;
                } else if ("shift" == key) {
                    keyInfo.Shift = true;
                } else if ("alt" == key) {
                    keyInfo.Alt = true;
                } else if ("win" == key) {
                    keyInfo.Win = true;
                } else if (this._keyMapping.ContainsKey(key)) {
                    keyInfo.Key = this._keyMapping[key];
                    found = true;
                }
            }
            return found ? keyInfo : null;
        }

        /// <summary>
        /// send key
        /// </summary>
        /// <param name="keyInfo"></param>
        private void SendKey(KeyInfo keyInfo, uint keyEvent) {
            int[] keys;
            if (KeyEventF.KeyDown == keyEvent) {
                keys = new int[] {
                    keyInfo.Ctrl? VirtualKey.Control: VirtualKey.None,
                    keyInfo.Shift? VirtualKey.Shift: VirtualKey.None,
                    keyInfo.Alt? VirtualKey.Alt: VirtualKey.None,
                    keyInfo.Win? VirtualKey.Win: VirtualKey.None,
                    keyInfo.Key
                };
            } else {
                keys = new int[] {
                    keyInfo.Key,
                    keyInfo.Win? VirtualKey.Win: VirtualKey.None,
                    keyInfo.Alt? VirtualKey.Alt: VirtualKey.None,
                    keyInfo.Shift? VirtualKey.Shift: VirtualKey.None,
                    keyInfo.Ctrl? VirtualKey.Control: VirtualKey.None
                };
            }

            foreach (var key in keys) {
                if (VirtualKey.None != key) {
                    NativeMethods.keybd_event((byte)key, 0, keyEvent, (UIntPtr)0);
                }
            }
        }
        #endregion
    }
}
