//*************************************
// All rights reserved
// filename:CommodityModifyCommand
// description:this is a class file
// created by kikao
// created at 2014/8/25 21:27:09
// version 1.0
//*************************************
namespace AccountBook.Commands.Commodity
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;
    [Serializable]
    public class CommodityModifyCommand:CommodityCommandBase
    {
        public string Name { get; set; }

        public float Price { get; set; }

        public string Describe { get; set; }

        public DateTime RecordTime { get; set; }

        public Guid Creater { get; set; }
    }
}
