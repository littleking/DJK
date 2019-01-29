using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Win32;

namespace CloudOperator
{
    public class RegHelper
    {
        //HKEY_LOCAL_MACHINE\SYSTEM\CurrentControlSet\Enum\FTDIBUS\VID_0403+PID_6001+A9KBFP4WA\0000\Device Parameters


        private static string keyNode = "SYSTEM\\CurrentControlSet\\Enum\\FTDIBUS\\";

        public RegHelper()
        {

        }

        public bool checkClientPort()
        {
            string node = "SOFTWARE\\SimplyCore LLC\\USB Redirector Client\\6.0\\USB Client\\";
            string key = "TcpPort";
            return IsRegeditKeyExit(node, key);
        }

        public string getDevicePort()
        {
            string info = "";
            string node = "SOFTWARE\\SimplyCore LLC\\USB Redirector Client\\6.0\\USB Client";
            string key = "TcpPort";
            if (IsRegeditKeyExit(node, key))
            {
                RegistryKey myKey = GetRegistryKey(node);
                try
                {
                    byte[] array = (byte[])myKey.GetValue(key);
                    int i = System.BitConverter.ToInt16(array, 0);
                    info = i.ToString();
                }
                catch (Exception ex)
                {
                    info = "";
                }
                myKey.Close();
            }
            return info;
        }

        public bool setDevicePort(string portStr)
        {
            
            bool rtn = false;
            int i = 0;
            try
            {
                i = int.Parse(portStr);
            }catch(Exception ex)
            {
                return rtn;
            }
            byte[] port = System.BitConverter.GetBytes(i);
            string node = "SOFTWARE\\SimplyCore LLC\\USB Redirector Client\\6.0\\USB Client";
            string key = "TcpPort";
            if (IsRegeditKeyExit(node, key))
            {
                RegistryKey myKey = GetRegistryKey(node);
                try
                {
                    myKey.SetValue(key, port);
                    rtn = true;
                    myKey.Close();
                }
                catch (Exception ex)
                {
                    rtn = false;
                }
                myKey.Close();
            }
            return rtn;
        }

        public bool checkCOM(string com,string deviceSN)
        {
            bool rtn = false;
            string deviceID= "VID_0403+PID_6001+" + deviceSN + "A";
            string node = keyNode + deviceID + "\\0000\\Device Parameters";
            string key = "PortName";
            if (IsRegeditKeyExit(node,key))
            {
                RegistryKey myKey = GetRegistryKey(node);
                string info = "";
                try
                {
                    info = myKey.GetValue(key).ToString();
                }catch(Exception ex)
                {
                    info = "";
                }
                if (info != com)
                {
                    myKey.SetValue(key, com);
                    rtn = true;
                    
                }
                myKey.Close();
            }
            return rtn;
        }

        public void testKey()
        { 
            RegistryKey machinelocalItem = GetRegistryKey("SYSTEM");
            string[] subkeyNames = machinelocalItem.GetSubKeyNames();
            foreach (string keyName in subkeyNames)
            {
                RegistryKey hh = machinelocalItem.OpenSubKey(keyName);
                string[] subkeyNames2 = hh.GetSubKeyNames();
                if (subkeyNames2.Length ==2)
                {
                    string ddds = "";
                }
            }
        }

        

        private bool IsRegeditKeyExit(string node,string key)
        {
            string[] subkeyNames;
            try
            {
                
                RegistryKey software = GetRegistryKey(node);
                 subkeyNames = software.GetValueNames();
                //取得该项下所有键值的名称的序列，并传递给预定的数组中
                foreach (string keyName in subkeyNames)
                {
                    if (keyName == key) //判断键值的名称
                    {
                        return true;
                    }
                }
            }catch(Exception ex)
            {
                return false;
            }
            return false;
        }

        private RegistryKey GetRegistryKey(string keyPath)
        {
            RegistryKey localMachineRegistry
                = RegistryKey.OpenBaseKey(RegistryHive.LocalMachine,
                                          Environment.Is64BitOperatingSystem
                                              ? RegistryView.Registry64
                                              : RegistryView.Registry32);

            return string.IsNullOrEmpty(keyPath)
                ? localMachineRegistry
                : localMachineRegistry.OpenSubKey(keyPath,true);
        }

    }

}
