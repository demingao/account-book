//*************************************
// All rights reserved
// filename:CommodityEventBase
// description:this is a class file
// created by kikao
// created at 2014/8/24 20:51:37
// version 1.0
//*************************************

using Apworks.Events;

namespace AccountBook.Events.Commodity
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;
    using Apworks;

    public class CommodityEventBase:DomainEvent
    {
        public Guid Id { get; set; }
    }
}
