//*************************************
// All rights reserved
// filename:AccountSnapshot
// description:this is a class file
// created by kikao
// created at 2014/8/24 20:29:04
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
    public class AccountSnapshot : Snapshot
    {
        public Guid Id { get; set; }
        public string LoginName { get; set; }
        public string Password { set; get; }
        public string UserName { set; get; }
    }
}
