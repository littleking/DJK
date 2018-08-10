using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Runtime.InteropServices;
using System.Text;

namespace DBAgentTest
{ 
    public class AgentDll
    {

        [DllImport("dbagent.dll", CharSet = CharSet.Unicode)]
        public static extern void exec_sql(string dbPath, string sql);

        [DllImport("dbagent.dll")]
        public static extern void clear_patient(string dbPath);

        [DllImport("dbagent.dll", CharSet = CharSet.Unicode)]
        public static extern void dump_table(string dbPath, string tablename, string filename);

        [DllImport("agent.dll")]
        public static extern void launchEx(bool bShow);

        [DllImport("agent.dll")]
        public static extern void exit_target();

        [DllImport("agent.dll")]
        public static extern void btn_Continue();

    }
}

