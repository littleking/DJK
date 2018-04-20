namespace Admin
{
    partial class FrmTemplate
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmTemplate));
            this.imageCollection1 = new DevExpress.Utils.ImageCollection(this.components);
            this.barManager1 = new DevExpress.XtraBars.BarManager(this.components);
            this.bar1 = new DevExpress.XtraBars.Bar();
            this.btnView = new DevExpress.XtraBars.BarLargeButtonItem();
            this.btnOpen = new DevExpress.XtraBars.BarLargeButtonItem();
            this.btnAdd = new DevExpress.XtraBars.BarLargeButtonItem();
            this.btnCopy = new DevExpress.XtraBars.BarLargeButtonItem();
            this.btnUpdate = new DevExpress.XtraBars.BarLargeButtonItem();
            this.btnDelete = new DevExpress.XtraBars.BarLargeButtonItem();
            this.btnSave = new DevExpress.XtraBars.BarLargeButtonItem();
            this.btnAudit = new DevExpress.XtraBars.BarLargeButtonItem();
            this.btnReverseAudit = new DevExpress.XtraBars.BarLargeButtonItem();
            this.btnSuccess = new DevExpress.XtraBars.BarLargeButtonItem();
            this.btnFail = new DevExpress.XtraBars.BarLargeButtonItem();
            this.btnQuery = new DevExpress.XtraBars.BarLargeButtonItem();
            this.btnFind = new DevExpress.XtraBars.BarLargeButtonItem();
            this.btnImport = new DevExpress.XtraBars.BarLargeButtonItem();
            this.btnExport = new DevExpress.XtraBars.BarLargeButtonItem();
            this.btnPrint = new DevExpress.XtraBars.BarLargeButtonItem();
            this.btnGraph = new DevExpress.XtraBars.BarLargeButtonItem();
            this.btnSetting = new DevExpress.XtraBars.BarLargeButtonItem();
            this.btnCard = new DevExpress.XtraBars.BarLargeButtonItem();
            this.btnExit = new DevExpress.XtraBars.BarLargeButtonItem();
            this.barAndDockingController1 = new DevExpress.XtraBars.BarAndDockingController(this.components);
            this.barDockControlTop = new DevExpress.XtraBars.BarDockControl();
            this.barDockControlBottom = new DevExpress.XtraBars.BarDockControl();
            this.barDockControlLeft = new DevExpress.XtraBars.BarDockControl();
            this.barDockControlRight = new DevExpress.XtraBars.BarDockControl();
            this.defaultLookAndFeel1 = new DevExpress.LookAndFeel.DefaultLookAndFeel(this.components);
            this.groupControlLock = new DevExpress.XtraEditors.GroupControl();
            ((System.ComponentModel.ISupportInitialize)(this.imageCollection1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.barManager1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.barAndDockingController1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.groupControlLock)).BeginInit();
            this.SuspendLayout();
            // 
            // imageCollection1
            // 
            this.imageCollection1.ImageSize = new System.Drawing.Size(24, 24);
            this.imageCollection1.ImageStream = ((DevExpress.Utils.ImageCollectionStreamer)(resources.GetObject("imageCollection1.ImageStream")));
            this.imageCollection1.Images.SetKeyName(0, "Add.png");
            this.imageCollection1.Images.SetKeyName(1, "Audit.png");
            this.imageCollection1.Images.SetKeyName(2, "Back.png");
            this.imageCollection1.Images.SetKeyName(3, "Copy.png");
            this.imageCollection1.Images.SetKeyName(4, "Delete.png");
            this.imageCollection1.Images.SetKeyName(5, "Export.png");
            this.imageCollection1.Images.SetKeyName(6, "Fail.png");
            this.imageCollection1.Images.SetKeyName(7, "Find.png");
            this.imageCollection1.Images.SetKeyName(8, "Graph.png");
            this.imageCollection1.Images.SetKeyName(9, "Import.png");
            this.imageCollection1.Images.SetKeyName(10, "Msg.png");
            this.imageCollection1.Images.SetKeyName(11, "Next.png");
            this.imageCollection1.Images.SetKeyName(12, "Open.png");
            this.imageCollection1.Images.SetKeyName(13, "Print.png");
            this.imageCollection1.Images.SetKeyName(14, "Query.png");
            this.imageCollection1.Images.SetKeyName(15, "ReverseAudit.png");
            this.imageCollection1.Images.SetKeyName(16, "Save.png");
            this.imageCollection1.Images.SetKeyName(17, "Setting.png");
            this.imageCollection1.Images.SetKeyName(18, "Success.png");
            this.imageCollection1.Images.SetKeyName(19, "Update.png");
            this.imageCollection1.Images.SetKeyName(20, "View.png");
            this.imageCollection1.Images.SetKeyName(21, "graph.jpg");
            // 
            // barManager1
            // 
            this.barManager1.Bars.AddRange(new DevExpress.XtraBars.Bar[] {
            this.bar1});
            this.barManager1.Controller = this.barAndDockingController1;
            this.barManager1.DockControls.Add(this.barDockControlTop);
            this.barManager1.DockControls.Add(this.barDockControlBottom);
            this.barManager1.DockControls.Add(this.barDockControlLeft);
            this.barManager1.DockControls.Add(this.barDockControlRight);
            this.barManager1.Form = this;
            this.barManager1.Items.AddRange(new DevExpress.XtraBars.BarItem[] {
            this.btnQuery,
            this.btnFind,
            this.btnView,
            this.btnOpen,
            this.btnAdd,
            this.btnCopy,
            this.btnUpdate,
            this.btnDelete,
            this.btnSave,
            this.btnAudit,
            this.btnReverseAudit,
            this.btnSuccess,
            this.btnFail,
            this.btnImport,
            this.btnExport,
            this.btnPrint,
            this.btnGraph,
            this.btnSetting,
            this.btnExit,
            this.btnCard});
            this.barManager1.LargeImages = this.imageCollection1;
            this.barManager1.MaxItemId = 17;
            // 
            // bar1
            // 
            this.bar1.BarAppearance.Normal.BackColor = System.Drawing.Color.White;
            this.bar1.BarAppearance.Normal.BackColor2 = System.Drawing.Color.White;
            this.bar1.BarAppearance.Normal.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(192)))), ((int)(((byte)(255)))));
            this.bar1.BarAppearance.Normal.Options.UseBackColor = true;
            this.bar1.BarAppearance.Normal.Options.UseBorderColor = true;
            this.bar1.BarName = "Tools";
            this.bar1.CanDockStyle = ((DevExpress.XtraBars.BarCanDockStyle)((DevExpress.XtraBars.BarCanDockStyle.Top | DevExpress.XtraBars.BarCanDockStyle.Bottom)));
            this.bar1.DockCol = 0;
            this.bar1.DockRow = 0;
            this.bar1.DockStyle = DevExpress.XtraBars.BarDockStyle.Top;
            this.bar1.LinksPersistInfo.AddRange(new DevExpress.XtraBars.LinkPersistInfo[] {
            new DevExpress.XtraBars.LinkPersistInfo(this.btnView, true),
            new DevExpress.XtraBars.LinkPersistInfo(this.btnOpen, true),
            new DevExpress.XtraBars.LinkPersistInfo(this.btnAdd, true),
            new DevExpress.XtraBars.LinkPersistInfo(this.btnCopy, true),
            new DevExpress.XtraBars.LinkPersistInfo(this.btnUpdate, true),
            new DevExpress.XtraBars.LinkPersistInfo(this.btnDelete, true),
            new DevExpress.XtraBars.LinkPersistInfo(this.btnSave, true),
            new DevExpress.XtraBars.LinkPersistInfo(this.btnAudit, true),
            new DevExpress.XtraBars.LinkPersistInfo(this.btnReverseAudit, true),
            new DevExpress.XtraBars.LinkPersistInfo(this.btnSuccess, true),
            new DevExpress.XtraBars.LinkPersistInfo(this.btnFail, true),
            new DevExpress.XtraBars.LinkPersistInfo(this.btnQuery, true),
            new DevExpress.XtraBars.LinkPersistInfo(this.btnFind),
            new DevExpress.XtraBars.LinkPersistInfo(this.btnImport),
            new DevExpress.XtraBars.LinkPersistInfo(this.btnExport, true),
            new DevExpress.XtraBars.LinkPersistInfo(this.btnPrint, true),
            new DevExpress.XtraBars.LinkPersistInfo(DevExpress.XtraBars.BarLinkUserDefines.PaintStyle, this.btnGraph, "", true, true, true, 0, null, DevExpress.XtraBars.BarItemPaintStyle.CaptionInMenu),
            new DevExpress.XtraBars.LinkPersistInfo(this.btnSetting, true),
            new DevExpress.XtraBars.LinkPersistInfo(this.btnCard, true),
            new DevExpress.XtraBars.LinkPersistInfo(this.btnExit)});
            this.bar1.OptionsBar.AllowQuickCustomization = false;
            this.bar1.OptionsBar.DrawDragBorder = false;
            this.bar1.OptionsBar.RotateWhenVertical = false;
            this.bar1.OptionsBar.UseWholeRow = true;
            this.bar1.Text = "Tools";
            // 
            // btnView
            // 
            this.btnView.Caption = "浏览";
            this.btnView.CaptionAlignment = DevExpress.XtraBars.BarItemCaptionAlignment.Right;
            this.btnView.Id = 11;
            this.btnView.LargeImageIndex = 20;
            this.btnView.Name = "btnView";
            this.btnView.Visibility = DevExpress.XtraBars.BarItemVisibility.Never;
            this.btnView.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.btnView_ItemClick);
            // 
            // btnOpen
            // 
            this.btnOpen.Caption = "打开";
            this.btnOpen.CaptionAlignment = DevExpress.XtraBars.BarItemCaptionAlignment.Right;
            this.btnOpen.Id = 11;
            this.btnOpen.LargeImageIndex = 11;
            this.btnOpen.Name = "btnOpen";
            this.btnOpen.Visibility = DevExpress.XtraBars.BarItemVisibility.Never;
            this.btnOpen.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.btnOpen_ItemClick);
            // 
            // btnAdd
            // 
            this.btnAdd.Caption = "新增";
            this.btnAdd.CaptionAlignment = DevExpress.XtraBars.BarItemCaptionAlignment.Right;
            this.btnAdd.Id = 0;
            this.btnAdd.LargeImageIndex = 0;
            this.btnAdd.Name = "btnAdd";
            this.btnAdd.Visibility = DevExpress.XtraBars.BarItemVisibility.Never;
            this.btnAdd.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.btnAdd_ItemClick);
            // 
            // btnCopy
            // 
            this.btnCopy.Caption = "复制";
            this.btnCopy.CaptionAlignment = DevExpress.XtraBars.BarItemCaptionAlignment.Right;
            this.btnCopy.Id = 4;
            this.btnCopy.LargeImageIndex = 3;
            this.btnCopy.Name = "btnCopy";
            this.btnCopy.Visibility = DevExpress.XtraBars.BarItemVisibility.Never;
            this.btnCopy.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.btnCopy_ItemClick);
            // 
            // btnUpdate
            // 
            this.btnUpdate.Caption = "编辑";
            this.btnUpdate.CaptionAlignment = DevExpress.XtraBars.BarItemCaptionAlignment.Right;
            this.btnUpdate.Id = 1;
            this.btnUpdate.LargeImageIndex = 19;
            this.btnUpdate.Name = "btnUpdate";
            this.btnUpdate.Visibility = DevExpress.XtraBars.BarItemVisibility.Never;
            this.btnUpdate.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.btnEdit_ItemClick);
            // 
            // btnDelete
            // 
            this.btnDelete.Caption = "删除";
            this.btnDelete.CaptionAlignment = DevExpress.XtraBars.BarItemCaptionAlignment.Right;
            this.btnDelete.Id = 3;
            this.btnDelete.LargeImageIndex = 4;
            this.btnDelete.Name = "btnDelete";
            this.btnDelete.Visibility = DevExpress.XtraBars.BarItemVisibility.Never;
            this.btnDelete.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.btnDelete_ItemClick);
            // 
            // btnSave
            // 
            this.btnSave.Caption = "保存";
            this.btnSave.CaptionAlignment = DevExpress.XtraBars.BarItemCaptionAlignment.Right;
            this.btnSave.Id = 2;
            this.btnSave.LargeImageIndex = 16;
            this.btnSave.Name = "btnSave";
            this.btnSave.Visibility = DevExpress.XtraBars.BarItemVisibility.Never;
            this.btnSave.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.btnSave_ItemClick);
            // 
            // btnAudit
            // 
            this.btnAudit.Caption = "审核";
            this.btnAudit.CaptionAlignment = DevExpress.XtraBars.BarItemCaptionAlignment.Right;
            this.btnAudit.Id = 5;
            this.btnAudit.LargeImageIndex = 1;
            this.btnAudit.Name = "btnAudit";
            this.btnAudit.Visibility = DevExpress.XtraBars.BarItemVisibility.Never;
            this.btnAudit.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.btnAudit_ItemClick);
            // 
            // btnReverseAudit
            // 
            this.btnReverseAudit.Caption = "反审";
            this.btnReverseAudit.CaptionAlignment = DevExpress.XtraBars.BarItemCaptionAlignment.Right;
            this.btnReverseAudit.Id = 12;
            this.btnReverseAudit.LargeImageIndex = 15;
            this.btnReverseAudit.Name = "btnReverseAudit";
            this.btnReverseAudit.Visibility = DevExpress.XtraBars.BarItemVisibility.Never;
            this.btnReverseAudit.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.btnReverseAudit_ItemClick);
            // 
            // btnSuccess
            // 
            this.btnSuccess.Caption = "入帐";
            this.btnSuccess.CaptionAlignment = DevExpress.XtraBars.BarItemCaptionAlignment.Right;
            this.btnSuccess.Id = 6;
            this.btnSuccess.LargeImageIndex = 18;
            this.btnSuccess.Name = "btnSuccess";
            this.btnSuccess.Visibility = DevExpress.XtraBars.BarItemVisibility.Never;
            this.btnSuccess.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.btnSuccess_ItemClick);
            // 
            // btnFail
            // 
            this.btnFail.Caption = "返回";
            this.btnFail.CaptionAlignment = DevExpress.XtraBars.BarItemCaptionAlignment.Right;
            this.btnFail.Id = 6;
            this.btnFail.LargeImageIndex = 6;
            this.btnFail.Name = "btnFail";
            this.btnFail.Visibility = DevExpress.XtraBars.BarItemVisibility.Never;
            this.btnFail.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.btnFail_ItemClick);
            // 
            // btnQuery
            // 
            this.btnQuery.Caption = "查询";
            this.btnQuery.CaptionAlignment = DevExpress.XtraBars.BarItemCaptionAlignment.Right;
            this.btnQuery.Id = 10;
            this.btnQuery.LargeImageIndex = 14;
            this.btnQuery.Name = "btnQuery";
            this.btnQuery.Visibility = DevExpress.XtraBars.BarItemVisibility.Never;
            this.btnQuery.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.btnQuery_ItemClick);
            // 
            // btnFind
            // 
            this.btnFind.Caption = "统计";
            this.btnFind.CaptionAlignment = DevExpress.XtraBars.BarItemCaptionAlignment.Right;
            this.btnFind.Id = 13;
            this.btnFind.LargeImageIndex = 7;
            this.btnFind.Name = "btnFind";
            this.btnFind.Visibility = DevExpress.XtraBars.BarItemVisibility.Never;
            this.btnFind.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.btnFind_ItemClick);
            // 
            // btnImport
            // 
            this.btnImport.Caption = "导入";
            this.btnImport.CaptionAlignment = DevExpress.XtraBars.BarItemCaptionAlignment.Right;
            this.btnImport.Id = 7;
            this.btnImport.LargeImageIndex = 9;
            this.btnImport.Name = "btnImport";
            this.btnImport.Visibility = DevExpress.XtraBars.BarItemVisibility.Never;
            this.btnImport.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.btnImport_ItemClick);
            // 
            // btnExport
            // 
            this.btnExport.Caption = "导出";
            this.btnExport.CaptionAlignment = DevExpress.XtraBars.BarItemCaptionAlignment.Right;
            this.btnExport.Id = 7;
            this.btnExport.LargeImageIndex = 5;
            this.btnExport.Name = "btnExport";
            this.btnExport.Visibility = DevExpress.XtraBars.BarItemVisibility.Never;
            this.btnExport.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.btnExport_ItemClick);
            // 
            // btnPrint
            // 
            this.btnPrint.Caption = "打印";
            this.btnPrint.CaptionAlignment = DevExpress.XtraBars.BarItemCaptionAlignment.Right;
            this.btnPrint.Id = 8;
            this.btnPrint.LargeImageIndex = 13;
            this.btnPrint.Name = "btnPrint";
            this.btnPrint.Visibility = DevExpress.XtraBars.BarItemVisibility.Never;
            this.btnPrint.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.btnPrint_ItemClick);
            // 
            // btnGraph
            // 
            this.btnGraph.Caption = "刷新";
            this.btnGraph.CaptionAlignment = DevExpress.XtraBars.BarItemCaptionAlignment.Right;
            this.btnGraph.Id = 14;
            this.btnGraph.LargeImageIndex = 21;
            this.btnGraph.Name = "btnGraph";
            this.btnGraph.Visibility = DevExpress.XtraBars.BarItemVisibility.Never;
            this.btnGraph.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.btnGraph_ItemClick);
            // 
            // btnSetting
            // 
            this.btnSetting.Caption = "设置";
            this.btnSetting.CaptionAlignment = DevExpress.XtraBars.BarItemCaptionAlignment.Right;
            this.btnSetting.Id = 14;
            this.btnSetting.LargeImageIndex = 17;
            this.btnSetting.Name = "btnSetting";
            this.btnSetting.Visibility = DevExpress.XtraBars.BarItemVisibility.Never;
            this.btnSetting.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.btnSetting_ItemClick);
            // 
            // btnCard
            // 
            this.btnCard.Caption = "读取会员卡信息";
            this.btnCard.CaptionAlignment = DevExpress.XtraBars.BarItemCaptionAlignment.Right;
            this.btnCard.Id = 16;
            this.btnCard.LargeImageIndex = 20;
            this.btnCard.Name = "btnCard";
            this.btnCard.Visibility = DevExpress.XtraBars.BarItemVisibility.Never;
            this.btnCard.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.btnCard_ItemClick);
            // 
            // btnExit
            // 
            this.btnExit.Caption = "退出";
            this.btnExit.CaptionAlignment = DevExpress.XtraBars.BarItemCaptionAlignment.Right;
            this.btnExit.Id = 9;
            this.btnExit.LargeImageIndex = 6;
            this.btnExit.Name = "btnExit";
            this.btnExit.Visibility = DevExpress.XtraBars.BarItemVisibility.Never;
            this.btnExit.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.btnExit_ItemClick);
            // 
            // barAndDockingController1
            // 
            this.barAndDockingController1.PaintStyleName = "Skin";
            this.barAndDockingController1.PropertiesBar.AllowLinkLighting = false;
            // 
            // barDockControlTop
            // 
            this.barDockControlTop.Appearance.Options.UseImage = true;
            this.barDockControlTop.CausesValidation = false;
            this.barDockControlTop.Dock = System.Windows.Forms.DockStyle.Top;
            this.barDockControlTop.Location = new System.Drawing.Point(0, 0);
            this.barDockControlTop.Size = new System.Drawing.Size(1020, 39);
            // 
            // barDockControlBottom
            // 
            this.barDockControlBottom.CausesValidation = false;
            this.barDockControlBottom.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.barDockControlBottom.Location = new System.Drawing.Point(0, 387);
            this.barDockControlBottom.Size = new System.Drawing.Size(1020, 0);
            // 
            // barDockControlLeft
            // 
            this.barDockControlLeft.CausesValidation = false;
            this.barDockControlLeft.Dock = System.Windows.Forms.DockStyle.Left;
            this.barDockControlLeft.Location = new System.Drawing.Point(0, 39);
            this.barDockControlLeft.Size = new System.Drawing.Size(0, 348);
            // 
            // barDockControlRight
            // 
            this.barDockControlRight.CausesValidation = false;
            this.barDockControlRight.Dock = System.Windows.Forms.DockStyle.Right;
            this.barDockControlRight.Location = new System.Drawing.Point(1020, 39);
            this.barDockControlRight.Size = new System.Drawing.Size(0, 348);
            // 
            // groupControlLock
            // 
            this.groupControlLock.Appearance.BackColor = System.Drawing.Color.White;
            this.groupControlLock.Appearance.ForeColor = System.Drawing.Color.Transparent;
            this.groupControlLock.Appearance.Options.UseBackColor = true;
            this.groupControlLock.Appearance.Options.UseForeColor = true;
            this.groupControlLock.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.NoBorder;
            this.groupControlLock.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupControlLock.Location = new System.Drawing.Point(0, 39);
            this.groupControlLock.Name = "groupControlLock";
            this.groupControlLock.ShowCaption = false;
            this.groupControlLock.Size = new System.Drawing.Size(1020, 348);
            this.groupControlLock.TabIndex = 4;
            this.groupControlLock.UseDisabledStatePainter = false;
            // 
            // FrmTemplate
            // 
            this.Appearance.BackColor = System.Drawing.Color.White;
            this.Appearance.Options.UseBackColor = true;
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 14F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1020, 387);
            this.Controls.Add(this.groupControlLock);
            this.Controls.Add(this.barDockControlLeft);
            this.Controls.Add(this.barDockControlRight);
            this.Controls.Add(this.barDockControlBottom);
            this.Controls.Add(this.barDockControlTop);
            this.Name = "FrmTemplate";
            this.Text = "FrmTemplate";
            this.Load += new System.EventHandler(this.frmTemplate_Load);
            ((System.ComponentModel.ISupportInitialize)(this.imageCollection1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.barManager1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.barAndDockingController1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.groupControlLock)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private DevExpress.Utils.ImageCollection imageCollection1;
        private DevExpress.XtraBars.BarDockControl barDockControlTop;
        private DevExpress.XtraBars.BarDockControl barDockControlBottom;
        private DevExpress.XtraBars.BarDockControl barDockControlLeft;
        private DevExpress.XtraBars.BarDockControl barDockControlRight;
        protected DevExpress.XtraBars.BarLargeButtonItem btnQuery;
        protected DevExpress.XtraBars.BarLargeButtonItem btnFind;
        protected DevExpress.XtraBars.BarLargeButtonItem btnView;
        protected DevExpress.XtraBars.BarLargeButtonItem btnOpen;
        protected DevExpress.XtraBars.BarLargeButtonItem btnAdd;
        protected DevExpress.XtraBars.BarLargeButtonItem btnCopy;
        protected DevExpress.XtraBars.BarLargeButtonItem btnUpdate;
        protected DevExpress.XtraBars.BarLargeButtonItem btnDelete;
        protected DevExpress.XtraBars.BarLargeButtonItem btnSave;
        protected DevExpress.XtraBars.BarLargeButtonItem btnAudit;
        protected DevExpress.XtraBars.BarLargeButtonItem btnReverseAudit;
        protected DevExpress.XtraBars.BarLargeButtonItem btnSuccess;
        protected DevExpress.XtraBars.BarLargeButtonItem btnFail;
        protected DevExpress.XtraBars.BarLargeButtonItem btnImport;
        protected DevExpress.XtraBars.BarLargeButtonItem btnExport;
        protected DevExpress.XtraBars.BarLargeButtonItem btnPrint;
        protected DevExpress.XtraBars.BarLargeButtonItem btnGraph;
        protected DevExpress.XtraBars.BarLargeButtonItem btnSetting;
        protected DevExpress.XtraBars.BarLargeButtonItem btnExit;
        protected DevExpress.XtraBars.BarLargeButtonItem btnCard;
        private DevExpress.XtraBars.BarManager barManager1;
        public DevExpress.XtraBars.Bar bar1;
        private DevExpress.XtraBars.BarAndDockingController barAndDockingController1;
        private DevExpress.LookAndFeel.DefaultLookAndFeel defaultLookAndFeel1;
        public DevExpress.XtraEditors.GroupControl groupControlLock;
    }
}