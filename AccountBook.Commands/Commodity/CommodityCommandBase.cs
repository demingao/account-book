//*************************************
// All rights reserved
// filename:CommodityCommandBase
// description:this is a class file
// created by kikao
// created at 2014/8/25 21:23:55
// version 1.0
//*************************************

using Apworks.Commands;

namespace AccountBook.Commands.Commodity
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;

    public class CommodityCommandBase:Command
    {
        public Guid Id { get; set; }
    }
}
