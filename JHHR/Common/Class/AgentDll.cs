using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;

namespace JHHY
{
    public class AgentDll
    {

        [DllImport("agent.dll")]
        public static extern bool check_dev_con();

        [DllImport("agent.dll")]
        public static extern void launchEx(bool bShow);

        [DllImport("agent.dll")]
        public static extern void export_report();

        [DllImport("agent.dll")]
        public static extern void risk_load_data();

        [DllImport("agent.dll")]
        public static extern void make_emotion_chart();

        [DllImport("agent.dll")]
        public static extern void nutr_load();

        [DllImport("agent.dll")]
        public static extern void exit_target();

        [DllImport("dbagent.dll", CharSet = CharSet.Unicode)]
        public static extern void exec_sql(string dbPath, string sql);

        [DllImport("dbagent.dll")]
        public static extern void clear_patient(string dbPath);

        [DllImport("dbagent.dll", CharSet = CharSet.Unicode)]
        public static extern void dump_table(string dbPath, string tablename, string filename);

        [DllImport("agent.dll")]
        public static extern void btn_tformcomport_close();

        [DllImport("agent.dll")]
        public static extern void btn_Continue();

        [DllImport("agent.dll")]
        public static extern void btn_Password();

        [DllImport("agent.dll")]
        public static extern void btn_check_head_band(StringBuilder result);

        [DllImport("agent.dll")]
        public static extern void btn_check_rhand_band(StringBuilder result);
        [DllImport("agent.dll")]
        public static extern void btn_check_lhand_band(StringBuilder result);
        [DllImport("agent.dll")]
        public static extern void btn_check_lfoot_band(StringBuilder result);
        [DllImport("agent.dll")]
        public static extern void btn_check_rfoot_band(StringBuilder result);

        [DllImport("agent.dll")]
        public static extern void btn_Demographics(); 

         [DllImport("agent.dll")]
        public static extern void btn_LoadPatientData();

        [DllImport("agent.dll")]
        public static extern void choose_one_patient();

        [DllImport("agent.dll")]
        public static extern void btn_Previous_Patient();

        [DllImport("agent.dll")]
        public static extern void btn_PatForm1_Close();

        [DllImport("agent.dll")]
        public static extern void btn_Calibration();

        [DllImport("agent.dll")]
        public static extern void manul_Calib_device();

        [DllImport("agent.dll")]
        public static extern void start_test();

        [DllImport("agent.dll")]
        public static extern void do_test();


    }
}
