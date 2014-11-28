//*************************************
// All rights reserved
// filename:AccountBook
// description:this is a class file
// created by kikao
// created at 2014/8/26 23:20:49
// version 1.0
//*************************************

using System.Diagnostics;
using AccountBook.CommandHandlers.Account;
using AccountBook.CommandHandlers.Commodity;
using AccountBook.Commands.Account;
using AccountBook.Config.Mapping;
using AccountBook.EventHandlers;
using AccountBook.EventHandlers.Account;
using AccountBook.EventHandlers.Commodity;
using AccountBook.Events.Account;
using AccountBook.Infrastructure;
using AccountBook.Model;
using Apworks;
using Apworks.Bus;
using Apworks.Config.Fluent;
using Apworks.Events;
using Apworks.Events.Storage;
using Apworks.Repositories;
using Apworks.Repositories.NHibernate;
using Apworks.Snapshots.Providers;
using Apworks.Storage;
using FluentNHibernate.Cfg;
using NHibernate;
using NHibernate.Tool.hbm2ddl;

namespace AccountBook.Config
{
    using Apworks.Application;
    using Apworks.Config;
    using System;
    using System.Collections.Generic;
    using System.Configuration;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;
    using Microsoft.Practices.Unity;
    using Apworks.Bus.DirectBus;
    using Apworks.Events.Storage.General;


    public class AccountBook
    {
        public const string ApworksCQRSArchEventStoreConnectionString = @"Server=kikao-pc;Database=ApworksCQRSArchEventStore;Integrated Security=SSPI;User ID=sa;Password=p@ssw0rd;";
        public const string AoccountBookConnectionString = @"Data Source=kikao-pc;Initial Catalog=AoccountBook;Integrated Security=True;Pooling=False;MultipleActiveResultSets=True;User ID=sa;Password=p@ssw0rd;";
        public const string CQRSTestDB_Table_DomainEvents = @"DomainEvents";
        public const string CQRSTestDB_Table_Snapshots = @"Snapshots";
        public const string EventBus_MessageQueue = @"EventBusMQ";
        public const string CommandBus_MessageQueue = @"CommandBusMQ";
        private AccountBook()
        {
        }

        static AccountBook()
        {
        }

        public static ISessionFactory SessionFactory
        {
            get
            {
                var sessionFactory = Fluently.Configure()
                    .Mappings(m => m.FluentMappings.AddFromAssemblyOf<AccountMapping>())
                    // .ExposeConfiguration(x => new SchemaExport(x).Create(false, true))
                    .BuildSessionFactory();
                return sessionFactory;
            }
        }

        public static void AccountBookStart()
        {
            // RegularConfigSource config=new RegularConfigSource();
            //config.Application = typeof (App);
            //config.ObjectContainer = typeof (Apworks.ObjectContainers.Unity.UnityObjectContainer);

            var application = AppRuntime.Instance
               .ConfigureApworks()
               .WithDefaultSettings()
               .AddMessageHandler(HandlerKind.Command, HandlerSourceType.Assembly, "AccountBook.CommandHandlers")
               .AddMessageHandler(HandlerKind.Event, HandlerSourceType.Assembly, "AccountBook.EventHandlers")

               .UsingUnityContainer()
               .Create();
            application.Initialize += new EventHandler<AppInitEventArgs>(AccountBook_Initialize);
            application.Start();
            //IConfigSource appConfigSource = new AppConfigSource();
            //IApp application = AppRuntime.Create(appConfigSource);
            //application.Initialize += new EventHandler<AppInitEventArgs>(AccountBook_Initialize);
            //application.Start();
        }

        private static void AccountBook_Initialize(object sender, AppInitEventArgs e)
        {

            UnityContainer c = e.ObjectContainer.GetWrappedContainer<UnityContainer>();
            c.RegisterType<IStorageMappingResolver, XmlStorageMappingResolver>("DomainEventStorageMappingResolver",
                new InjectionConstructor("StorageMappings.xml"))
                .RegisterType<IDomainEventStorage, SqlDomainEventStorage>(
                    new InjectionConstructor(ApworksCQRSArchEventStoreConnectionString,
                        new ResolvedParameter<IStorageMappingResolver>("DomainEventStorageMappingResolver")))
                .RegisterType<IMessageDispatcher, MessageDispatcher>(new ContainerControlledLifetimeManager())
                .RegisterType<ICommandBus, DirectCommandBus>(new ContainerControlledLifetimeManager(),
                    new InjectionConstructor(new ResolvedParameter<IMessageDispatcher>()))
                .RegisterType<IEventBus, DirectEventBus>(new ContainerControlledLifetimeManager(),
                    new InjectionConstructor(new ResolvedParameter<IMessageDispatcher>()))
                .RegisterType<ISnapshotProvider, SuppressedSnapshotProvider>()
                .RegisterType<IDomainRepository, EventSourcedDomainRepository>(
                    new InjectionConstructor(new ResolvedParameter<IDomainEventStorage>(),
                        new ResolvedParameter<IEventBus>(), new ResolvedParameter<ISnapshotProvider>()))
                        .RegisterType<IRepositoryContext, NHibernateContext>(new ContainerControlledLifetimeManager(), new InjectionConstructor(SessionFactory))
                .RegisterType<IRepository<Account>, NHibernateRepository<Account>>(new ContainerControlledLifetimeManager())
                .RegisterType<IRepository<Commodity>, NHibernateRepository<Commodity>>(new ContainerControlledLifetimeManager());
            c.Resolve<IMessageDispatcher>().Register(new AccountRegisterCommandHandler());
            c.Resolve<IMessageDispatcher>().Register(new CommodityCreateCommandHandler());
            c.Resolve<IMessageDispatcher>().Register(new CommodityDeleteCommandHandler());
            c.Resolve<IMessageDispatcher>().Register(new CommodityModifyCommandHandler());
            c.Resolve<IMessageDispatcher>().Register(new AccountRegisterEventHandler());
            c.Resolve<IMessageDispatcher>().Register(new CommodityCreateEventHandler());
            c.Resolve<IMessageDispatcher>().Register(new CommodityDeleteEventHandler());
            c.Resolve<IMessageDispatcher>().Register(new CommodityModifyEventHandler());
        }

    }
}
