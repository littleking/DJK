using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DJK.Common
{
    class DCHelper
    {
    }

    public class HeadData
    {
        /// <summary>
        /// 
        /// </summary>
        public string verifyCode { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public string organizationID { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public string uploadTime { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public string deviceNo { get; set; }
    }

    public class TestData
    {
        /// <summary>
        /// 
        /// </summary>
        public string no { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public string name { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public string value { get; set; }
    }


    public class TestDatas
    {
        /// <summary>
        /// 
        /// </summary>
        public List<TestData> MatrixDatas { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public List<TestData> InfoDatas { get; set; }
    }

    public class HealthData
    {
        /// <summary>
        /// 
        /// </summary>
        public HeadData HeadData { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public TestDatas TestDatas { get; set; }
    }
}
