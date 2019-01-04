﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using DevExpress.XtraEditors;
using DevExpress.XtraWaitForm;

namespace QiYuan
{
    public partial class WaitForm3 : WaitForm
    {
        public WaitForm3()
        {
            InitializeComponent();
            this.progressPanel1.AutoHeight = true;
            this.progressPanel1.AutoSize = true;
        }

        #region Overrides

        public override void SetCaption(string caption)
        {
            base.SetCaption(caption);
            this.progressPanel1.Caption = caption;
        }
        public override void SetDescription(string description)
        {
            base.SetDescription(description);
            this.progressPanel1.Description = description;
        }
        public override void ProcessCommand(Enum cmd, object arg)
        {
            WaitFormCommand command = (WaitFormCommand)cmd;
            if (command == WaitFormCommand.SetProgress)
            {
                progressBarControl1.EditValue = arg;
            }
            base.ProcessCommand(cmd, arg);
        }

        #endregion

        public enum WaitFormCommand
        {
            SetProgress
        }

        private void killP()
        {
            System.Diagnostics.Process[] processList = System.Diagnostics.Process.GetProcesses();
            foreach (System.Diagnostics.Process process in processList)
            {
                if (process.ProcessName.ToUpper() == "CONMAIN")
                {
                    process.Kill(); //结束进程
                }
            }
        }

        private void simpleButton1_Click(object sender, EventArgs e)
        {
            if (XtraMessageBox.Show("检测程序将被强制关闭!", "关闭", MessageBoxButtons.YesNo, MessageBoxIcon.Error) == DialogResult.Yes)
            {
                killP();
                System.Environment.Exit(0);


            }
        }
    }
}