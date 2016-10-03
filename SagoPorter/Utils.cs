using System;
using System.Collections.Generic;
using System.Text;
using System.Reflection;
using System.IO;
using System.Drawing;
using System.Threading;
using System.Runtime.InteropServices;

using PorterProto;

namespace SagoPorter
{
    internal static class TerminalInfo
    {
        public const string TermVersion = "0.1.110716";
    }

    internal static class Utils
    {
        public static event EventHandler SpecialUserLoggedIn;
        public static event EventHandler SpecialUserLoggedOut;

        internal static readonly int PASSWORD_HASH = -680989098;

        internal static bool loggedIn = false;
        public static bool LoggedIn
        {
            get { return loggedIn; }
        }

        internal static bool LogIn(int hash)
        {
            if (loggedIn) return true;

            if (hash == PASSWORD_HASH)
            {
                loggedIn = true;

                if (SpecialUserLoggedIn != null)
                    SpecialUserLoggedIn.Invoke(new object(), EventArgs.Empty);

                return true;
            }

            return false;
        }

        internal static void LogOut()
        {
            if (!loggedIn) return;

            loggedIn = false;

            if (SpecialUserLoggedOut != null)
                SpecialUserLoggedOut.Invoke(new object(), EventArgs.Empty); 
        }
    }  

    internal static class WindowsManager
    {
        public static event EventHandler MinimizeRequested;
        public static void InvokeMinimizeRequested()
        {
            if (MinimizeRequested != null)
                MinimizeRequested.Invoke(new object(), EventArgs.Empty);
        }

        public static event EventHandler CloseAllRequested;
        public static void InvokeCloseAllRequested()
        {
            if (CloseAllRequested != null)
                CloseAllRequested.Invoke(new object(), EventArgs.Empty);
        }
    }

    internal static class PowerManagement
    {
        private const int SUSPEND_TIME = 20000;

        private const int POWER_STATE_ON = 0x00010000;
        private const int POWER_STATE_OFF = 0x00020000;
        private const int POWER_STATE_SUSPEND = 0x00200000;
        private const int POWER_FORCE = 4096;
        private const int POWER_STATE_RESET = 0x00800000;

        private const int LAMP_GPIO_PIN = 103; // GPIO 48

        private static gpio.uIo lampGpio;
        private static IntPtr gpioPointer;

        public static int suspendTimeOut = SUSPEND_TIME;
        private static bool exitRequested = false;
        private static bool suspendDaemonOn = false;
        private static bool lampOn = false;

        internal static bool LampOn { get { return lampOn; } }

        private static bool stopSuspendManage = false;
        public static bool StopSuspendManage
        {
            get { return stopSuspendManage; }
            set { stopSuspendManage = value; }
        }

        [DllImport("coredll.dll", EntryPoint = "SetSystemPowerState")]
        private static extern void SetSystemPowerState(string psState, Int32 StateFlags, int Options);

        public static bool InitManager()
        {
            lampGpio = new gpio.uIo((ushort)LAMP_GPIO_PIN, (ushort)gpio.tIoType.ioColibriPin); 
            gpioPointer = gpio_vyb.VybGpio_Init(null);

            if (!gpio_vyb.VybGpio_Open(gpioPointer))
                return false;

            gpio_vyb.VybGpio_ConfigureAsGpio(gpioPointer, lampGpio);
            gpio_vyb.VybGpio_SetDir(gpioPointer, lampGpio, gpio.tIoDirection.ioOutput);

            exitRequested = false;
            suspendDaemonOn = false;
            return true;
        }

        public static void StartSuspendDaemon()
        {
            if (suspendDaemonOn) return;
            ResetSuspendTime(); 
            exitRequested = false;

            (new Thread(suspendThreadMethod)).Start();
        }

        public static void TurnOnLamp()
        {
            gpio_vyb.VybGpio_SetLevel(gpioPointer, lampGpio, gpio.tIoLevel.ioHigh);
            Cntrls.BaseCntrls.BaseControl.EnableClick = true;
            lampOn = true;
        }

        public static void TurnOffLamp()
        {
            gpio_vyb.VybGpio_SetLevel(gpioPointer, lampGpio, gpio.tIoLevel.ioLow);
            Cntrls.BaseCntrls.BaseControl.EnableClick = false;
            lampOn = false;
        }

        public static void ManageExit()
        {
            exitRequested = true;
        }

        public static void ResetSuspendTime()
        {
            suspendTimeOut = SUSPEND_TIME;
        }

        public static void SuspendSystem()
        {
            SetSystemPowerState(null, POWER_STATE_SUSPEND, POWER_FORCE);
        }

        public static void ResetSystem()
        {
            SetSystemPowerState(null, POWER_STATE_RESET, POWER_FORCE);
        }

        private static void suspendThreadMethod()
        {
            suspendDaemonOn = true;
            while (!exitRequested)
            {
                if (stopSuspendManage) 
                    ResetSuspendTime();

                if (suspendTimeOut <= 0)
                    if (lampOn)
                        TurnOffLamp();
                    else { }
                else
                    if (!lampOn)
                        TurnOnLamp();

                Thread.Sleep(10);

                if (suspendTimeOut >= 10)
                    suspendTimeOut -= 10; 
            }

            gpio_vyb.VybGpio_Close(gpioPointer);
            gpio_vyb.VybGpio_Deinit(gpioPointer);
            suspendDaemonOn = false;
        }
    }
}
