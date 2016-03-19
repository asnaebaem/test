using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UnitTestProject1.Parameters
{
    public static class SeleniumParameters
    {
        public static string IEDriverPath = @"C:\";
        public static string URL = "www.wp.pl";
        public static string InputId = "szukaj1";
        public static string XPath = "/html/body/header/div[1]/div/div[3]/form/input[2]";
    }
}
