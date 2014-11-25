//*************************************
// All rights reserved
// filename:CommodityModifiedEvent
// description:this is a class file
// created by kikao
// created at 2014/8/24 20:55:32
// version 1.0
//*************************************
namespace AccountBook.Events.Commodity
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;

    public class CommodityModifiedEvent : CommodityEventBase
    {
        public string Name { get; set; }

        public float Price { get; set; }

        public string Describe { get; set; }

        public DateTime RecordTime { get; set; }

        public Guid Creater { get; set; }
    }
}
