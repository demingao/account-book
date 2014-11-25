//*************************************
// All rights reserved
// filename:CommoditySnapshot
// description:this is a class file
// created by kikao
// created at 2014/8/24 20:26:03
// version 1.0
//*************************************

namespace AccountBook.Model.Snapshots
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;
    using Apworks;
    using Apworks.Snapshots;
    public class CommoditySnapshot : Snapshot
    {
        public Guid Id { get; set; }

        public string Name { get; set; }

        public float Price { get; set; }

        public string Describe { get; set; }

        public DateTime RecordTime { get; set; }

        public Guid Creater { get; set; }
    }
}
