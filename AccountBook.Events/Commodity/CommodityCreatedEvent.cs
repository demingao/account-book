//*************************************
// All rights reserved
// filename:CommodityCreatedEvent
// description:this is a class file
// created by kikao
// created at 2014/8/24 20:52:57
// version 1.0
//*************************************
namespace AccountBook.Events.Commodity
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;

    public class CommodityCreatedEvent:CommodityEventBase
    {
        public string Name { get; set; }

        public float Price { get; set; }

        public string Describe { get; set; }

        public DateTime RecordTime { get; set; }

        public Guid Creater { get; set; }
    }
}
