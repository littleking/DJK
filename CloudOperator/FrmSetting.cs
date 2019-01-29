using DevExpress.XtraEditors;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml;

namespace CloudOperator
{
    public partial class FrmSetting : DevExpress.XtraEditors.XtraForm
    {
        private RegHelper rh;
        public FrmSetting()
        {
            InitializeComponent();
            rh = new RegHelper();
            //rh.testKey();
            PortSetting.remoteIP = ReadAppSetting("OperatorIP");
            PortSetting.remotePort = ReadAppSetting("OperatorPort");
            PortSetting.localIP = ReadAppSetting("LocalIP");
            PortSetting.localPort = ReadAppSetting("LocalPort");
            string devicePort = rh.getDevicePort();
            if(devicePort == "")
            {
                PortSetting.devicePort = "32033";
            }
            else
            {
                PortSetting.devicePort = devicePort;
            }
            this.txtIP.Text = PortSetting.remoteIP;
            this.txtPort.Text = PortSetting.remotePort;
            this.txtLocalIP.Text = PortSetting.localIP;
            this.txtLocalPort.Text = PortSetting.localPort;
            this.txtDevicePort.Text = PortSetting.devicePort;
        }

        private void simpleButton2_Click(object sender, EventArgs e)
        {
            bool saved = true;
            string ip = txtIP.Text.Trim();
            string port = txtPort.Text.Trim();
            string localIP = txtLocalIP.Text.Trim();
            string localPort = txtLocalPort.Text.Trim();
            string devicePort = txtDevicePort.Text.Trim();
            if (ip == "")
            {
                XtraMessageBox.Show("请输入远程IP地址", "错误", MessageBoxButtons.OK, MessageBoxIcon.Stop);
            }
            else if(port == "")
            {
                XtraMessageBox.Show("请输入远程端口", "错误", MessageBoxButtons.OK, MessageBoxIcon.Stop);
            }
            else if (localIP == "")
            {
                XtraMessageBox.Show("请输入本地IP地址", "错误", MessageBoxButtons.OK, MessageBoxIcon.Stop);
            }
            else if (localPort == "")
            {
                XtraMessageBox.Show("请输入本地端口", "错误", MessageBoxButtons.OK, MessageBoxIcon.Stop);
            }
            else if (devicePort == "")
            {
                XtraMessageBox.Show("请输入设备端口", "错误", MessageBoxButtons.OK, MessageBoxIcon.Stop);
            }
            else
            {
                if (ip != PortSetting.remoteIP)
                {
                    SetValue("OperatorIP", ip);
                    PortSetting.remoteIP = ip;
                }
                if (port != PortSetting.remotePort)
                {
                    SetValue("OperatorPort", port);
                    PortSetting.remotePort = port;
                }
                if (localIP != PortSetting.localIP)
                {
                    SetValue("LocalIP", localIP);
                    PortSetting.localIP = localIP;
                }
                if (localPort != PortSetting.localPort)
                {
                    SetValue("LocalPort", localPort);
                    PortSetting.localPort = localPort;
                }
                if (devicePort != PortSetting.devicePort)
                {
                    if (rh.setDevicePort(devicePort))
                    {
                        PortSetting.devicePort = devicePort;
                    }
                    else
                    {
                        saved = false;
                    }

                }
                if (saved) {
                    XtraMessageBox.Show("服务地址信息保存成功", "成功", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    this.Close();
                }
                else
                {
                    XtraMessageBox.Show("设备端口设置失败", "失败", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
        }

        private string ReadAppSetting(string key)
        {
            string rtn = "";
            try
            {
                string xPath = "/configuration/appSettings//add[@key='" + key + "']";
                XmlDocument doc = new XmlDocument();
                string exeFileName = System.Reflection.Assembly.GetExecutingAssembly().GetName().Name;
                doc.Load(exeFileName + ".exe.config");
                XmlNode node = doc.SelectSingleNode(xPath);
                return node.Attributes["value"].Value.ToString();
            }catch(Exception ex)
            {
                return rtn;
            }
        }

        private void SetValue(string AppKey, string AppValue)
        {
            System.Xml.XmlDocument xDoc = new System.Xml.XmlDocument();
            xDoc.Load(System.Windows.Forms.Application.ExecutablePath + ".config");

            System.Xml.XmlNode xNode;
            System.Xml.XmlElement xElem1;
            System.Xml.XmlElement xElem2;
            xNode = xDoc.SelectSingleNode("//appSettings");

            xElem1 = (System.Xml.XmlElement)xNode.SelectSingleNode("//add[@key='" + AppKey + "']");
            if (xElem1 != null) xElem1.SetAttribute("value", AppValue);
            else
            {
                xElem2 = xDoc.CreateElement("add");
                xElem2.SetAttribute("key", AppKey);
                xElem2.SetAttribute("value", AppValue);
                xNode.AppendChild(xElem2);
            }
            xDoc.Save(System.Windows.Forms.Application.ExecutablePath + ".config");
        }

        private void simpleButton1_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
