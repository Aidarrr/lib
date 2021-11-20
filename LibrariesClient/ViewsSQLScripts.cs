using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibrariesClient
{
    class ViewsSQLScripts
    {
        public static string getOpenViewScript(string viewName)
        {
            return String.Format("SELECT * FROM {0}", viewName);
        }

        public static List<string> getSetScripts(Dictionary<string, int> argsNameId)
        {
            List<string> setScripts = new List<string>();

            foreach (var arg in argsNameId)
            {
                setScripts.Add(String.Format("SET {0} = {1}", arg.Key, arg.Value));
            }

            return setScripts;
        }
    }
}
