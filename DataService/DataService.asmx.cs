using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Services;
using DJK.Common;
using Newtonsoft.Json;
using DJK.DAL;
using Formula;

namespace DataService
{
    /// <summary>
    /// DataService 的摘要说明
    /// </summary>
    [WebService(Namespace = "http://tempuri.org/")]
    [WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
    [System.ComponentModel.ToolboxItem(false)]
    // 若要允许使用 ASP.NET AJAX 从脚本中调用此 Web 服务，请取消注释以下行。 
    // [System.Web.Script.Services.ScriptService]
    public class DataService : System.Web.Services.WebService
    {


        [WebMethod]
        public string GetData(string verifyCode)
        {
            ResultCalculation rc = new ResultCalculation(verifyCode);
            string result = rc.getResult();
            if (result.Length > 0)
            {
                return result;
            }
            else
            {
                return "0";
            }
        }

        [WebMethod]
        public int SendData(string dataJson)
        {
            HealthData hd = new HealthData();
            try
            {
                hd = JsonConvert.DeserializeObject<HealthData>(dataJson);
                TestDatas tds = hd.TestDatas;
                HeadData head = hd.HeadData;
                string healthData = JsonConvert.SerializeObject(tds);
                string uploadTime = head.uploadTime;
                string verifyCode = head.verifyCode;
                string orgID = head.organizationID;
                string devNo = head.deviceNo;
                DJK.Model.djk_cloudData model = new DJK.Model.djk_cloudData();
                model.healthData = healthData;
                model.orgnizationID = orgID;
                model.deviceNo = devNo;
                model.verifyCode = verifyCode;
                model.savedDate = Convert.ToDateTime(uploadTime);
                DJK.DAL.djk_cloudData dalCloud = new djk_cloudData();
                int rtn =dalCloud.Add(model);
                if (rtn > 0)
                {
                    return 1;
                }
                else
                {
                    return 0;
                }
            }
            catch (Exception ex)
            {
                
                string ss = ex.ToString();
                return 0;
            }
        }
    }
}
