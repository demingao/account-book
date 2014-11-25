//*************************************
// All rights reserved
// filename:AccountRegisterCommand
// description:this is a class file
// created by kikao
// created at 2014/8/25 21:22:19
// version 1.0
//*************************************
namespace AccountBook.Commands.Account
{
    using Apworks.Commands;
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;
    [Serializable]
    public class AccountRegisterCommand:AccountCommandBase
    {
        public string LoginName { get; set; }
        public string Password { set; get; }
        public string UserName { set; get; }
    }
}
