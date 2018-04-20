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
using DJK.Model;
using DJK.DAL;

namespace Admin
{
    public partial class FrmAdd : FrmTemplate
    {

        public DJK.Model.admin_MedicalData _model;
        private DJK.DAL.admin_MedicalData dalData;
        private string _code;
        private int _parentID;

        public FrmAdd(string code,int pid,int currentID,bool addSub)
        {
            InitializeComponent();
            ShowButtonRight(new string[] { "Save", "Exit" });
            _model = null;
            dalData = new DJK.DAL.admin_MedicalData();
            _code = code;
            if (addSub)
            {
                _parentID = currentID;
            }
            else
            {
                _parentID = pid;
            }
            txtCode.Text = getCode(_parentID,code);
            initFormula();



        }

        private string getCode(int parentID,string code)
        {
            string newCode = dalData.getMaxCode(parentID,code);
            return newCode;
        }

        protected override void Save()
        {
            if (txtCode.Text.Trim().Length == 0)
            {
                XtraMessageBox.Show("请输入编码！", "提示", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            else if (txtItem.Text.Trim().Length == 0)
            {
                if (txtCode.Text.Length == 0)
                {
                    XtraMessageBox.Show("请输入项目名称！", "提示", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            }
            else
            {
                _model = new DJK.Model.admin_MedicalData();
                _model.Code = txtCode.Text.Trim();
                _model.Item = txtItem.Text.Trim();
                _model.ParentID = _parentID;
                if (txtMin.Text.Trim().Length > 0)
                {
                    _model.DataMin = int.Parse(txtMin.Text.Trim());
                }
                if (txtMax.Text.Trim().Length > 0)
                {
                    _model.DataMax = int.Parse(txtMax.Text.Trim());
                }
                if (lookUpFormula.EditValue.ToString().Length>0)
                {
                    _model.DataFormula = int.Parse(lookUpFormula.EditValue.ToString());
                }
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

        private void FrmAdd_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (_model != null)
            {
                if (_model.Code == null)
                {
                    _model = null;
                }
            }
        }

        private void initFormula()
        {
            DataTable t = new DataTable();
            t.Columns.Add("ID", typeof(int));
            t.Columns.Add("FormulaDescription", typeof(string));
            t.Rows.Add(new object[] { 1, "默认值" });
            t.Rows.Add(new object[] { 2, "最大值" });
            lookUpFormula.Properties.DataSource = t;
            lookUpFormula.Properties.ValueMember = "ID";
            lookUpFormula.Properties.DisplayMember = "FormulaDescription";
        }
    }
}
