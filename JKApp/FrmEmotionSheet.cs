using DevExpress.XtraEditors;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace JKApp
{
    public partial class FrmEmotionSheet : XtraForm
    {
        public FrmEmotionSheet(List<EmotionData> emotionData)
        {
            InitializeComponent();
            loadData(emotionData);
        }

        private void loadData(List<EmotionData> emotionData)
        {
            gridSheet.DataSource = emotionData;

        }
    }
}
