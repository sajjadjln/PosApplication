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
        // why it does not accept  new IDataConnection(); but accept whit list 
        public static void InitilizeConnection()
        { 
            TextConnection text = new TextConnection();
            Connections.Add(text);
        }
    }
}
