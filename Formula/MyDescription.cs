using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Formula
{
    public class MyDescription : Attribute
    {
        public string DisplayName { get; set; }
        public string DisplayCode { get; set; }

        public MyDescription(string dn,string code)
        { 
            DisplayName = dn;
            DisplayCode = code;
        }


    }


}
