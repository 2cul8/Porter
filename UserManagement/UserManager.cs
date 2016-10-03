using System;
using System.Collections.Generic;
using System.Text;
using System.IO;
using System.Threading;

using PorterProto;

namespace UserManagement
{
    public static class UserManager
    {
        public static event EventHandler UserLoggedIn;
        public static event EventHandler UserLoggedOut;

        private static UserList dataBase;

        private static User currentUser = User.Empty;
        public static User CurrentUser
        {
            get { return currentUser; }
        }

        private static UserStatistics currentUserStatistics = UserStatistics.Empty;
        public static UserStatistics CurrentUserStatistics
        {
            get { return currentUserStatistics; }
        }

        public static void InitializeManager()
        {
            dataBase = UserList.LoadUserList();

            // Controllo che i file di ogni utenti siano pronti per essere utilizzati
            UsersDataBase.InitDataBase(dataBase);
        }

        public static User UserIdNameExist(string name)
        {
            foreach (User user in dataBase)
                if (string.Compare(user.Password.ToLower(), name.ToLower()) == 0)
                    return user;

            return User.Empty;
        } 

        public static void LoginUser(User toLogin)
        {
            currentUser = toLogin;
            currentUserStatistics = UserStatistics.GetCurrentUserStatistics();

            UserStatistics.StartStatisticsDaemon();

            DeviceInterface.AttivaTask(Tasks.TASK_INSEG);

            if (UserLoggedIn != null)
                UserLoggedIn.Invoke(new object(), EventArgs.Empty);
        }

        public static void LogoutUSer()
        {
            currentUser = User.Empty;
            currentUserStatistics = UserStatistics.Empty;

            UserStatistics.StopStatisticsDaemon();

            DeviceInterface.DisattivaTask(Tasks.TASK_INSEG);

            if (UserLoggedOut != null)
                UserLoggedOut.Invoke(new object(), EventArgs.Empty);
        }
    }

    public class UserStatistics
    {
        public static readonly UserStatistics Empty = new UserStatistics();

        private static bool stopStatsDaemonRequested = false;
        private static bool daemonOn = false;

        private User ownerUser;
        private bool statsChanged = false;

        private int distance = 0;
        public int Distance
        {
            get { return distance; }
        }

        private UserStatistics() { }

        public void RefreshUserStatistics(string field, object value)
        {
            switch (field)
            {
                case Constants.DISTANCE_FIELD:

                    if (distance != (int)value)
                    {
                        distance = (int)value;
                        statsChanged = true;
                    }

                    break;

                default:
                    break;
            }
        }

        public void SaveUserStatistics()
        {
            if (!statsChanged)
                return;

            try
            {
                StreamWriter sw = File.CreateText(ownerUser.StatisticFilePath);

                StringBuilder sb = new StringBuilder();
                sb.Append(Constants.DISTANCE_FIELD);
                sb.Append(":");
                sb.Append(distance.ToString());

                sw.WriteLine(sb.ToString());

                sw.Flush();
                sw.Close();
            }
            catch (Exception ex)
            {
                // Aggiungere gestione FILE DI LOG.
            }
        }

        internal static UserStatistics GetCurrentUserStatistics()
        {
            if (UserManager.CurrentUser.Equals(User.Empty)) return Empty;

            if (!UserManager.CurrentUser.StatisticsAvaliable()) return Empty;

            string statsFile = UserManager.CurrentUser.StatisticFilePath;

            try
            {
                StreamReader sr = File.OpenText(statsFile);
                string line = string.Empty;
                while (!string.IsNullOrEmpty(line = sr.ReadLine()))
                {
                    int distance = 0;
                    string[] propValue = line.Split(":".ToCharArray());

                    switch (propValue[0])
                    {
                        case Constants.DISTANCE_FIELD:
                            distance = int.Parse(propValue[1]);
                            break;

                        default:
                            break;
                    }

                    UserStatistics sts = new UserStatistics();
                    sts.ownerUser = UserManager.CurrentUser;
                    sts.distance = distance;

                    return sts;
                }
            }
            catch
            {
                // Aggiungere gestione FILE DI LOG.
                return Empty;
            }

            return Empty;
        }

        internal static void StartStatisticsDaemon()
        {
            if (daemonOn) return;

            stopStatsDaemonRequested = false;
            (new Thread(userStatisticsDaemon)).Start();
        }

        internal static void StopStatisticsDaemon()
        {
            stopStatsDaemonRequested = false;
        }

        private static void userStatisticsDaemon()
        {
            int refreshTick = 0;

            daemonOn = true;

            while (!stopStatsDaemonRequested)
            {
                if (refreshTick >= 100)
                {
                    refreshTick = 0;

                    int distance = (int)DeviceData.GetDeviceData(DeviceDataDef.Distance);

                    //if (DeviceInterface.InviaFunzione(Constants.RESET_PARZIALI))
                    //{
                        UserManager.CurrentUserStatistics.RefreshUserStatistics(Constants.DISTANCE_FIELD, distance);
                        UserManager.CurrentUserStatistics.SaveUserStatistics();
                    //}
                }

                Thread.Sleep(10);
                refreshTick += 10;
            }

            daemonOn = false;
        }
    }

    public class UserList : List<User>
    {
        internal UserList() : base() { }

        private new void Add(User toAdd)
        {
            base.Add(toAdd);
        }

        private new void Remove(User toRemove)
        {
            base.Remove(toRemove);
        }

        internal static UserList LoadUserList()
        {
            UserList list = new UserList();

            list.Add(new User("Franco.F", "123", "000000001"));
            list.Add(new User("Marco.G", "456", "000000002"));
            list.Add(new User("Roberto.G", "789", "000000003")); 
            list.Add(new User("Test", "999", "000000004")); 

            return list;
        }
    }

    public class User
    {
        public static readonly User Empty = new User(string.Empty, string.Empty, string.Empty);

        private string name = string.Empty;
        public string Name
        {
            get { return name; }
        }

        private string psw = string.Empty;
        public string Password
        {
            get { return psw; }
        }

        private string id = string.Empty;
        public string Id
        {
            get { return id; }
        }

        private string statisticsFile = string.Empty;
        public string StatisticFilePath
        {
            get { return statisticsFile; }
            internal set { statisticsFile = value; }
        }

        internal User(string userName, string userIdName, string userId)
        {
            name = userName;
            psw = userIdName;
            id = userId;
        }

        public bool StatisticsAvaliable()
        {
            return File.Exists(statisticsFile);
        }
    }
}
