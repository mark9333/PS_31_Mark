using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UserLogin
{
    internal class Logs
    {
        public int logsId { get; set; }
        public DateTime? date { get; set; }
        public string activity { get; set; }
        public string userName { get; set; }

        public Logs(string username, string logs)
        {
            date = DateTime.Now;
            userName = username;
            activity = logs;
        }
        public override string ToString()
        {
            return date + " " + userName + " " + activity + "\r\n";
        }
    }
}
