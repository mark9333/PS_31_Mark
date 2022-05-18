using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UserLogin
{
    public static class Logger
    {
        private static List<string> currentSessionActivities = new List<string>();
        private static LogsContext logsContext = new LogsContext();

        static public void LogActivity(string activity)
        {
            string activityLine = DateTime.Now + ";" + LoginValidation.currentUserUsername + ";" + LoginValidation.currentUserRole + ";" + activity;
            currentSessionActivities.Add(activityLine);

            if (File.Exists("test.txt") == true)
            {
                File.WriteAllText("test.txt", activityLine);
            }

            logsContext.Logs.Add(new Logs(LoginValidation.currentUserUsername, activity));
            logsContext.SaveChanges();
        }

        static public void LogActivity(string activity, int errorCode)
        {
            string activityLine = DateTime.Now + ";" + errorCode + ";" + LoginValidation.currentUserRole + ";" + activity;
            currentSessionActivities.Add(activityLine);

            if (File.Exists("log.txt") == true)
            {
                File.WriteAllText("log.txt", activityLine);
            }

            logsContext.Logs.Add(new Logs(LoginValidation.currentUserUsername, activity));
            logsContext.SaveChanges();
        }

        static public IEnumerable<string> getCurrentSessionActivities(string filter)
        {
            List<string> filteredActivities = (from activity in currentSessionActivities where activity.Contains(filter) select activity).ToList();

            return filteredActivities;
        }
    }
}
