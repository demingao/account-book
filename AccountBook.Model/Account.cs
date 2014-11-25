//*************************************
// All rights reserved
// filename:Account
// description:this is a class file
// created by kikao
// created at 2014/8/24 20:22:31
// version 1.0
//*************************************

using AccountBook.Events.Account;
using AccountBook.Events.Commodity;
using AccountBook.Model.Snapshots;

namespace AccountBook.Model
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;
    using Apworks;

    public class Account : SourcedAggregateRoot
    {
        public virtual Guid Id { get; set; }
        public virtual string LoginName { get; set; }
        public virtual string Password { set; get; }
        public virtual string UserName { set; get; }

        public void AccountRegister()
        {
            this.RaiseEvent(new AccountRegisteredEvent
            {
                Id = this.Id,
                LoginName = this.LoginName,
                Password = this.Password,
                UserName = this.UserName
            });
        }

        protected override void DoBuildFromSnapshot(Apworks.Snapshots.ISnapshot snapshot)
        {
            var account = (AccountSnapshot)snapshot;
            this.Id = account.Id;
            this.LoginName = account.LoginName;
            this.Password = account.Password;
            this.UserName = account.UserName;
        }

        protected override Apworks.Snapshots.ISnapshot DoCreateSnapshot()
        {
            return new AccountSnapshot
            {
                Id = this.Id,
                LoginName = this.LoginName,
                Password = this.Password,
                UserName = this.UserName
            };
        }

        [Handles(typeof(AccountRegisteredEvent))]
        private void AccountRegisteredEventHandler(AccountRegisteredEvent @event)
        {
           
            this.LoginName = @event.LoginName;
            this.UserName = @event.UserName;
            this.Password = @event.Password;
            this.Id = @event.Id;
        }
    }
}
