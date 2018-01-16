using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;

namespace DJKUI
{
    public class AgentDll
    {
        [DllImport("agent.dll")]
        public static extern void launchEx(bool bShow);

        [DllImport("agent.dll")]
        public static extern void exit_target();

        [DllImport("dbagent.dll", CharSet = CharSet.Unicode)]
        public static extern void exec_sql(StringBuilder sql);

        [DllImport("agent.dll")]
        public static extern void btn_check_head_band(StringBuilder result);

        [DllImport("dbagent.dll", CharSet = CharSet.Unicode)]
        public static extern void showForm();
    }
}
