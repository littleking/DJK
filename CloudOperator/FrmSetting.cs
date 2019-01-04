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
        public FrmSetting()
        {
            InitializeComponent();
            string ip = ReadAppSetting("OperatorIP");
            string port = ReadAppSetting("OperatorPort");
            this.txtIP.Text = ip;
            this.txtPort.Text = port;
        }

        private void simpleButton2_Click(object sender, EventArgs e)
        {
            string ip = txtIP.Text.Trim();
            string port = txtPort.Text.Trim();
            if (ip == "")
            {
                XtraMessageBox.Show("请输入IP地址", "错误", MessageBoxButtons.OK, MessageBoxIcon.Stop);
            }
            else if(port == "")
            {
                XtraMessageBox.Show("请输入端口", "错误", MessageBoxButtons.OK, MessageBoxIcon.Stop);
            }
            else
            {
                SetValue("OperatorIP", ip);
                SetValue("OperatorPort", port);
                XtraMessageBox.Show("服务地址信息保存成功", "成功", MessageBoxButtons.OK, MessageBoxIcon.Information);
                this.Close();
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
