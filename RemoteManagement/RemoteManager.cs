using System;
using System.Collections.Generic;
using System.Text;
using System.Net.Sockets;
using System.Net;
using System.Threading;

using Resources;
using UserManagement;
using LogManagement;
using LocationManagement;
using PorterProto;
using RfidManager;

namespace RemoteManagement
{
    public static class RemoteManager
    {
        private const string LOG_NAME = "RemoteManager";

        private static Socket clientSocket;
        private static IPEndPoint bridgeEndPoint;
        private static Thread remoteManagerDaemon;
        private static int remoteManagerStatus = 0;
        private static bool shutDownRequested = false;

        private const int STATUS_INITIALIZED = 1;
        private const int STATUS_CONNECT_BRIDGE = 2;
        private const int STATUS_CONNECTING_BRIDGE = 3;
        private const int STATUS_CONNECTED_BRIDGE = 4;
        private const int STATUS_WAIT_NEXT_REFRESH = 100;
        private const int STATUS_SEND_REFRESH_DATA = 200;
        private const int STATUS_SHUTING_DOWN = 99999;

        public static void InitManager()
        {
            IPAddress networkBridgeIp = IPAddress.Parse("192.168.0.1"/*(string)Settings.GetSetting()*/);
            int networkBridgePort = 55555; /* int.Parse((string)Settings.GetSetting(SettingOptions.RemotingBridgePort));*/

            bridgeEndPoint = new IPEndPoint(networkBridgeIp, networkBridgePort);
            clientSocket = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);

            remoteManagerDaemon = new Thread(new ThreadStart(remoteDaemon));
        } 

        public static void StartRemoting()
        {
            if (remoteManagerStatus > 0)
                return;

            remoteManagerDaemon.Start();
        }

        public static void ShutDown()
        {
            if (remoteManagerStatus <= STATUS_CONNECTING_BRIDGE)
                return;

            shutDownRequested = true;
        }

        private static void remoteDaemon()
        {
            int waitTime = 0;
            int sleepTime = 1000;
            bool continueDaemon = true;

            while (continueDaemon)
                try
                { 
                    switch (remoteManagerStatus)
                    {
                        case 0:
                            remoteManagerStatus = STATUS_CONNECTING_BRIDGE;
                            break;

                        //case STATUS_INITIALIZED:
                        //    remoteManagerStatus = STATUS_CONNECT_BRIDGE;
                        //    break;

                        //case STATUS_CONNECT_BRIDGE:
                        //    remoteManagerStatus = STATUS_CONNECTING_BRIDGE;
                        //    break;

                        case STATUS_CONNECTING_BRIDGE:
                            try
                            {
                                clientSocket.Connect(bridgeEndPoint);
                                remoteManagerStatus = STATUS_CONNECTED_BRIDGE;
                            }
                            catch (Exception ex)
                            {
                                LogManager.WriteLog(LOG_NAME, ex.GetType().FullName);
                                LogManager.WriteLog(LOG_NAME, ex.Message);
                                LogManager.WriteLog(LOG_NAME, ex.StackTrace);
                                LogManager.WriteLog(LOG_NAME, "Bridge connection Error.");
                            }
                            break;

                        case STATUS_CONNECTED_BRIDGE:
                            waitTime = 5;
                            remoteManagerStatus = STATUS_WAIT_NEXT_REFRESH;
                            break;

                        case STATUS_WAIT_NEXT_REFRESH:
                            waitTime--;

                            if (waitTime == 0)
                                remoteManagerStatus = STATUS_SEND_REFRESH_DATA;
                            break;

                        case STATUS_SEND_REFRESH_DATA:
                            clientSocket.Send(ASCIIEncoding.ASCII.GetBytes(parseCurrentStatus()));
                            waitTime = 5;
                            remoteManagerStatus = STATUS_WAIT_NEXT_REFRESH;
                            break;


                        case STATUS_SHUTING_DOWN:
                            if (clientSocket.Connected)
                                clientSocket.Close();

                            sleepTime = 10;
                            continueDaemon = false;
                            break;
                    }

                    Thread.Sleep(sleepTime);

                    if (shutDownRequested)
                        remoteManagerStatus = STATUS_SHUTING_DOWN;
                }
                catch (Exception ex)
                {
                    continueDaemon = false;
                    LogManager.WriteLog(LOG_NAME, ex.GetType().FullName);
                    LogManager.WriteLog(LOG_NAME, ex.Message);
                    LogManager.WriteLog(LOG_NAME, ex.StackTrace);
                    LogManager.WriteLog(LOG_NAME, "Bridge comunication Error.");
                }
        }

        private static string parseCurrentStatus()
        {
            StringBuilder statusBuilder = new StringBuilder();
            statusBuilder.Append(UserManager.CurrentUser.Name); statusBuilder.Append(";");
            statusBuilder.Append(UserManager.CurrentUser.Id); statusBuilder.Append(";");
            statusBuilder.Append(BatteryStatusManager.GetBatteryPercentage(BatteryEnum.Generale)); statusBuilder.Append(";");
            statusBuilder.Append('\n');
            return statusBuilder.ToString();
        }
    }
}
