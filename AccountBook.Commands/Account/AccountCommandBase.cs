//*************************************
// All rights reserved
// filename:AccountCommandBase
// description:this is a class file
// created by kikao
// created at 2014/8/25 21:21:14
// version 1.0
//*************************************

using Apworks.Commands;

namespace AccountBook.Commands.Account
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;
    [Serializable]
    public class AccountCommandBase:Command
    {
        public Guid Id { get; set; }
    }
}
