//*************************************
// All rights reserved
// filename:AccountMapping
// description:this is a class file
// created by kikao
// created at 2014/9/7 12:01:25
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

    public class AccountMapping : ClassMap<Account>
    {
        public AccountMapping()
        {
            Table("Accounts");
            Not.LazyLoad();
            Id(x => x.Id).GeneratedBy.Assigned();
            Map(x => x.LoginName).Nullable();
            Map(x => x.UserName);
            Map(x => x.Password);
        }
    }
}
