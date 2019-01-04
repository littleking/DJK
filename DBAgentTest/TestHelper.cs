using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;
using System.Xml;

namespace DBAgentTest
{
    public class TestHelper
    {
        private int StartUp;
        private int BandTime;
        private int PatientTime;
        private int CommonTime;
        private int PrepareTime;
        private string dbpath = "";

        public TestHelper()
        {
            StartUp = 10;
            BandTime = 6;
            PatientTime = 3;
            CommonTime = 2;
            PrepareTime = 15;
            dbpath = "C:\\Clasp32\\DATA\\data.db3";
        }

        public void TestLaunch(bool bShow)
        {
            AgentDll.launchEx(bShow);
            Thread.Sleep(StartUp * 1000);
        }

        public void ExecSql(string dbpath, string sql)
        {
            AgentDll.exec_sql(dbpath, sql);
        }

        public void CloseBandTest()
        {
            AgentDll.btn_tformcomport_close();

        }

        public void TestToStart()
        {
            Thread.Sleep(BandTime * 1000);
            AgentDll.btn_Continue();
            Thread.Sleep(CommonTime * 1000 * 2);
            AgentDll.btn_Password();
            Thread.Sleep(PatientTime * 1000);
            AgentDll.btn_Demographics();
            Thread.Sleep(CommonTime * 1000);
            AgentDll.btn_LoadPatientData();
            Thread.Sleep(CommonTime * 2000);
            AgentDll.choose_one_patient();
            Thread.Sleep(CommonTime * 1000);
            AgentDll.btn_Previous_Patient();
            Thread.Sleep(CommonTime * 1000);
            //AgentDll.btn_Previous_Patient();
            Thread.Sleep(CommonTime * 1000);
            AgentDll.btn_PatForm1_Close();
            Thread.Sleep(CommonTime * 1000);
            AgentDll.btn_Calibration();
            Thread.Sleep(CommonTime * 1000);
            AgentDll.manul_Calib_device();
            Thread.Sleep(CommonTime * 1000);
        }


        public void OneClickTest()
        {
            Thread.Sleep(BandTime * 1000);
            AgentDll.btn_Continue();
            Thread.Sleep(CommonTime * 1000 * 2);
            AgentDll.btn_Password();
            Thread.Sleep(PatientTime * 1000);
            AgentDll.btn_Demographics();
            Thread.Sleep(CommonTime * 1000);
            AgentDll.btn_LoadPatientData();
            Thread.Sleep(CommonTime * 2000);
            AgentDll.choose_one_patient();
            Thread.Sleep(CommonTime * 1000);
            AgentDll.btn_Previous_Patient();
            Thread.Sleep(CommonTime * 1000);
            //AgentDll.btn_Previous_Patient();
            Thread.Sleep(CommonTime * 1000);
            AgentDll.btn_PatForm1_Close();
            Thread.Sleep(CommonTime * 1000);
            AgentDll.btn_Calibration();
            Thread.Sleep(CommonTime * 1000);
            AgentDll.manul_Calib_device();
            Thread.Sleep(CommonTime * 1000);
            AgentDll.start_test();
            Thread.Sleep(PrepareTime * 1000);
            AgentDll.do_test();
            Thread.Sleep(CommonTime * 1000);
            AgentDll.export_report();
            Thread.Sleep(5 * 1000);
        }

        public void TestStart()
        {
            AgentDll.start_test();
            Thread.Sleep(PrepareTime * 1000);
            AgentDll.do_test();       
        }

        public void ExportReport()
        {
            Thread.Sleep(CommonTime * 1000);
            AgentDll.export_report();
        }
        public void Nutrition()
        {
            Thread.Sleep(CommonTime * 1000);
            AgentDll.nutr_load();
        }

        public void Risk()
        {
            Thread.Sleep(CommonTime * 1000);
            AgentDll.risk_load_data();
        }

        public void Emotion()
        {
            Thread.Sleep(CommonTime * 1000);
            AgentDll.make_emotion_chart();
        }


        public bool TestBand(out string str)
        {
            List<string> list = new List<string>();
            str = "";
            bool rtn = true;
            if (!TestHead())
            {
                rtn = false;
                list.Add("头部");
            }
            if (!TestLH())
            {
                rtn = false;
                list.Add("左手");
            }
            if (!TestRH())
            {
                rtn = false;
                list.Add("右手");
            }
            if (!TestLF())
            {
                rtn = false;
                list.Add("左脚");
            }
            if (!TestRF())
            {
                rtn = false;
                list.Add("右脚");
            }
            string msg = "";
            if (list.Count > 0)
            {
                list.ForEach(a => msg += a + ",");
                msg = msg.TrimEnd(',');
            }
            str = msg;
            return rtn;
        }
        public bool TestLF()
        {
            bool rtn = false;
            StringBuilder buf = new StringBuilder(1024);
            AgentDll.btn_check_lfoot_band(buf);
            string txt = buf.ToString();
            if (txt == "LFOOT_OK")
                rtn = true;
            return rtn;
        }

        public bool TestRF()
        {
            bool rtn = false;
            StringBuilder buf = new StringBuilder(1024);
            AgentDll.btn_check_rfoot_band(buf);
            string txt = buf.ToString();
            if (txt == "RFOOT_OK")
                rtn = true;
            return rtn;
        }

        public bool TestRH()
        {
            bool rtn = false;
            StringBuilder buf = new StringBuilder(1024);
            AgentDll.btn_check_rhand_band(buf);
            string txt = buf.ToString();
            if (txt == "RHAND_OK")
                rtn = true;
            return rtn;
        }

        public bool TestLH()
        {
            bool rtn = false;
            StringBuilder buf = new StringBuilder(1024);
            AgentDll.btn_check_lhand_band(buf);
            string txt = buf.ToString();
            if (txt == "LHAND_OK")
                rtn = true;
            return rtn;
        }

        public bool TestHead()
        {
            bool rtn = false;
            StringBuilder buf = new StringBuilder(1024);
            AgentDll.btn_check_head_band(buf);
            string txt = buf.ToString();
            if (txt == "HEAD_OK")
                rtn = true;
            return rtn;
        }

    }
}
