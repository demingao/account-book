//*************************************
// All rights reserved
// filename:AccountEventBase
// description:this is a class file
// created by kikao
// created at 2014/8/24 20:46:33
// version 1.0
//*************************************

using Apworks.Events;

namespace AccountBook.Events.Account
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;
    using Apworks;
    public class AccountEventBase:DomainEvent
    {
        public Guid Id { get; set; }
    }
}
