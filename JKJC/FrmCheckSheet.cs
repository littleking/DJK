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

namespace JKJC
{
    public partial class FrmCheckSheet : XtraForm
    {
        public FrmCheckSheet(string result)
        {
            InitializeComponent();
            loadData(result);
        }

        private void loadData(string result)
        {
            //string strOrder = webService.getResult("order");
            HealthResult hResult = getHealthResult(result);
            List<DatasItem> datas = hResult.datas;
            string haha = "";
            gridSheet.DataSource = datas;

        }
        private HealthResult getHealthResult(string strJson)
        {
            HealthResult vj = new HealthResult();
            try
            {
                vj = JsonConvert.DeserializeObject<HealthResult>(strJson);
            }
            catch (Exception ex)
            {
                string ss = ex.ToString();
            }
            return vj;
        }
    }
}
