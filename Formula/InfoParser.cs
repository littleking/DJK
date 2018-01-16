using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Formula
{
    public class InfoParser
    {
        public string No { get; set; }

        public string Value { get; set; }

        public string Name { get; set; }

        public InfoParser()
        {
            No = "";
            Value = "";
            Name = "";
        }
    }

    public class MatrixParser
    {
        public string No { get; set; }

        public string Value { get; set; }

        public string Name { get; set; }

        public string OldValue { get; set; }

        public MatrixParser()
        {
            No = "";
            Value = "";
            Name = "";
            OldValue = "";
        }
    }
}
