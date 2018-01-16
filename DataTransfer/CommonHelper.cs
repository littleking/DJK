using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DataTransfer
{
    class CommonHelper
    {
    }

    public class DataList
    {
        public string serialCode { get; set; }

        public int sourceID { get; set; }

        public List<TestData> testDatas { get; set; }
    }

    public class TestData
    {
        public string description { get; set; }
        public string value { get; set; }

        public string code { get; set; }
    }

}
