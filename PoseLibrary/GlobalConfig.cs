using PoseLibrary.DataAccess;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PoseLibrary
{
    public static class GlobalConfig
    {
        /// <summary>
        /// holds any sort of connection
        /// </summary>
        public static List<IDataConnection> Connections { get; private set; } = new List<IDataConnection>();

        public static void InitializeConnection()
        {
            TextConnection text = new TextConnection();
            Connections.Add(text);
        }
    }
}
