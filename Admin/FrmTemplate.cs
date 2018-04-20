using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using DevExpress.XtraEditors;
using System.Collections;

namespace Admin
{
    public partial class FrmTemplate : XtraForm
    {
        #region
        /// <summary>
        /// 构造函数
        /// </summary>
        public FrmTemplate()
        {
            InitializeComponent();


        }
         /// <summary>
        /// 窗体加载事件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void frmTemplate_Load(object sender, EventArgs e)
        {
            //记录系统日志
 
        }



        #endregion

        #region 按钮方法
        /// <summary>
        /// 查询
        /// </summary>
        protected virtual void Query()
        {
        }
        /// <summary>
        /// 查找
        /// </summary>
        protected virtual void Find()
        {
        }
        /// <summary>
        /// 查看
        /// </summary>
        protected virtual void View()
        {
        }
        /// <summary>
        /// 打开
        /// </summary>
        protected virtual void Open()
        {
        }
        /// <summary>
        /// 添加
        /// </summary>
        protected virtual void Add()
        {
        }
        /// <summary>
        /// 复制
        /// </summary>
        protected virtual void Copy()
        {
        }
        /// <summary>
        /// 删除
        /// </summary>
        protected virtual void Delete()
        {

        }
        /// <summary>
        /// 保存
        /// </summary>
        protected virtual void Save()
        {
        }
        /// <summary>
        /// 审核
        /// </summary>
        protected virtual void Audit()
        {
        }
        /// <summary>
        /// 反审核
        /// </summary>
        protected virtual void ReverseAudit()
        {
        }
        /// <summary>
        /// 通过
        /// </summary>
        protected virtual void Success()
        {
        }
        /// <summary>
        /// 退回
        /// </summary>
        protected virtual void Fail()
        {
        }
        /// <summary>
        /// 导入
        /// </summary>
        protected virtual void Import()
        {
        }
        /// <summary>
        /// 导出
        /// </summary>
        protected virtual void Export()
        {
        }
        /// <summary>
        /// 打印
        /// </summary>
        protected virtual void Print()
        {
        }
        /// <summary>
        /// 图形
        /// </summary>
        protected virtual void Graph()
        {
        }
        /// <summary>
        /// 设置
        /// </summary>
        protected virtual void Setting()
        {
        }
        /// <summary>
        /// 退出
        /// </summary>
        protected virtual void Exit()
        {
        }
        /// <summary>
        /// 读会员卡
        /// </summary>
        protected virtual void Card()
        {
        }
        #endregion

        #region 按钮事件


        private void btnQuery_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            Query();
        }
        private void btnFind_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            Find();
        }
        private void btnView_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            View();
        }
        private void btnOpen_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            Open();
        }
        private void btnAdd_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            Add();
        }
        private void btnCopy_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            Copy();
        }
        private void btnEdit_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            Update();
        }
        private void btnDelete_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            Delete();
        }
        private void btnSave_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            Save();
        }
        private void btnAudit_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            Audit();
        }
        private void btnReverseAudit_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            ReverseAudit();
        }
        private void btnSuccess_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            Success();
        }
        private void btnFail_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            Fail();
        }
        private void btnImport_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            Import();
        }
        private void btnExport_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            Export();
        }
        private void btnPrint_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            Print();
        }
        private void btnGraph_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            Graph();
        }
        private void btnSetting_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            Setting();
        }
        private void btnExit_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            Exit();
        }
        private void btnCard_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            Card();
        }

        #endregion

        #region 显示拥有的操作按钮
        /// <summary>
        /// 显示拥有的操作按钮
        /// </summary>
        /// <param name="strRightButtons">需要权限验证显示的按钮集合（View,Add,Update,Delete,Save,Audit,ReverseAudit,Success,Fail,Import,Export,Print）</param>
        /// <param name="strDisplayButtons">无需权限可直接显示的按钮集合（View,Add,Update,Delete,Save,Audit,ReverseAudit,Success,Fail,Import,Export,Print）</param>
        protected void ShowButtonRight(string[] strDisplayButtons)
        {
            #region 无需权限验证可显示的按钮
            if (strDisplayButtons != null)
            {
                foreach (DevExpress.XtraBars.BarLargeButtonItem barItem in barManager1.Items)
                {
                    string strBtnName = barItem.Name.Replace("btn", "");
                    if (Common.Utils.Contains(strDisplayButtons, strBtnName))
                    {
                        //显示按钮
                        barItem.Visibility = DevExpress.XtraBars.BarItemVisibility.Always;
                    }
                }
            }
            #endregion

        }
        #endregion


        
    }
}