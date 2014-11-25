//*************************************
// All rights reserved
// filename:GeneralExceptionHandler
// description:this is a class file
// created by kikao
// created at 2014/8/26 23:13:00
// version 1.0
//*************************************

using System.Reflection.Emit;

namespace AccountBook.Infrastructure
{
    using Apworks.Exceptions;
    using System;
    using System.Collections.Generic;
    using System.Diagnostics;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;

    public class GeneralExceptionHandler:ExceptionHandler<Exception>
    {
        protected override bool DoHandle(Exception ex)
        {
            EventLog.WriteEntry(Utils.EventLogApplication, ex.ToString(), EventLogEntryType.Error);
            return false;
        }
    }
}
