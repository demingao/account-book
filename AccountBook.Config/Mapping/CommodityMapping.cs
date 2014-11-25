//*************************************
// All rights reserved
// filename:CommodityMapping
// description:this is a class file
// created by kikao
// created at 2014/9/7 12:01:51
// version 1.0
//*************************************

using AccountBook.Model;
using FluentNHibernate.Mapping;

namespace AccountBook.Config.Mapping
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;

    public class CommodityMapping:ClassMap<Commodity>
    {
        public CommodityMapping()
        {
            Table("Commodities");
            Not.LazyLoad();
            Id(x => x.Id).GeneratedBy.Assigned();
            Map(x => x.Name);
            Map(x => x.Price);
            Map(x => x.Describe);
            Map(x => x.RecordTime);
            Map(x => x.Creater);
        }
    }
}
