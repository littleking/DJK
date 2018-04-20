using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using DevExpress.XtraEditors;

namespace Admin
{
    public partial class FrmAddSource : FrmTemplate
    {
        public DJK.Model.admin_Clarity _model;
        private DJK.DAL.admin_Clarity _dal;
        public FrmAddSource()
        {
            InitializeComponent();
            ShowButtonRight(new string[] { "Save", "Exit" });
            _dal = new DJK.DAL.admin_Clarity();
            _model = new DJK.Model.admin_Clarity();
            initialData();
        }

        private void initialData()
        {
            this.comboType.Text = "info";
            this.txtNum.Text = getCurrent("info");
            this.txtMin.Text = "0";
            this.txtMax.Text = "150";
            
        }

        private string getCurrent(string dataType)
        {
            string currentNum = _dal.getCurrent(dataType);
            return currentNum;
        }

        private void comboType_SelectedValueChanged(object sender, EventArgs e)
        {
            string dataType = this.comboType.Text;
            this.txtNum.Text = getCurrent(dataType);
        }

        protected override void Save()
        {

            if (txtNum.Text.Trim().Length == 0)
            {
                XtraMessageBox.Show("请输入编号！", "提示", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            else if (_dal.checkCurrent(comboType.Text, txtNum.Text.Trim()))
            {
                XtraMessageBox.Show("编号已存在，无法添加重复的数据！", "提示", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            else if(txtMin.Text.Trim().Length == 0)
            {
                XtraMessageBox.Show("请输入最小值！", "提示", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            else if (txtMin.Text.Trim().Length == 0)
            {
                XtraMessageBox.Show("请输入最大值！", "提示", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            else
            {
                _model = new DJK.Model.admin_Clarity();
                _model.SourceMax = int.Parse(this.txtMax.Text.Trim());
                _model.SourceMin = int.Parse(this.txtMin.Text.Trim());
                _model.SourceNum = int.Parse(this.txtNum.Text.Trim());
                _model.SourceTable = this.comboType.Text;
                CloseForm();

            }

        }

        public void CloseForm()
        {
            this.Close();
            this.Dispose();
        }

        protected override void Exit()
        {
            _model = null;
            CloseForm();
        }

        private void FrmAddSource_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (_model != null)
            {
                if (_model.SourceTable == null)
                {
                    _model = null;
                }
            }
        }
    }
}
