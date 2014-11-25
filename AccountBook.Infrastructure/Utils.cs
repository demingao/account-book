//*************************************
// All rights reserved
// filename:Utils
// description:this is a class file
// created by kikao
// created at 2014/8/26 23:16:20
// version 1.0
//*************************************
namespace AccountBook.Infrastructure
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;

    public class Utils
    {
        public static string EventLogApplication
        {
            get
            {
                return "AccountBook";
            }
        }
        public static string EventLog
        {
            get { return "Application"; }
        }
    }
}
