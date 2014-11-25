//*************************************
// All rights reserved
// filename:AccountBookDomainRepository
// description:this is a class file
// created by kikao
// created at 2014/8/26 23:14:42
// version 1.0
//*************************************

using Apworks.Repositories;

namespace AccountBook.Infrastructure
{
    using Apworks.Bus;
    using Apworks.Events.Storage;
    using Apworks.Snapshots.Providers;
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading;
    using System.Threading.Tasks;

    public class AccountBookDomainRepository:EventSourcedDomainRepository
    {
        public AccountBookDomainRepository(IDomainEventStorage domainEventStorage, IEventBus eventBus, ISnapshotProvider snapshotProvider)
            : base(domainEventStorage, eventBus, snapshotProvider) { }

        protected override void DoCommit()
        {
            try
            {
                base.DoCommit();
            }
            catch
            {
                EventBus.Clear();
                throw;
            }
            // TODO: Add the commit notification to the sych service
            Thread.Sleep(6000);
        }

    }
}
