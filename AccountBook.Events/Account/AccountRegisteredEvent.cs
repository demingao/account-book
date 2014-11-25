//*************************************
// All rights reserved
// filename:AccountRegisteredEvent
// description:this is a class file
// created by kikao
// created at 2014/8/24 20:49:51
// version 1.0
//*************************************
namespace AccountBook.Events.Account
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;

    public class AccountRegisteredEvent:AccountEventBase
    {
        public string LoginName { get; set; }
        public string Password { set; get; }
        public string UserName { set; get; }
    }
}
