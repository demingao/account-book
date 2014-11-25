using System;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Collections.Generic;
using System.Threading;
using AccountBook.Commands.Account;
using Apworks.Bus;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Apworks.Commands;
using Apworks.Application;

namespace AccountBook.Test
{
    /// <summary>
    /// AccountBookEventsTest 的摘要说明
    /// </summary>
    [TestClass]
    public class AccountBookEventsTest
    {
        public AccountBookEventsTest()
        {
           Config.AccountBook.AccountBookStart();
        }

        private TestContext testContextInstance;

        /// <summary>
        ///获取或设置测试上下文，该上下文提供
        ///有关当前测试运行及其功能的信息。
        ///</summary>
        public TestContext TestContext
        {
            get
            {
                return testContextInstance;
            }
            set
            {
                testContextInstance = value;
            }
        }

        private void CommitCommand(ICommand command)
        {
            try
            {
                using (ICommandBus commandBus = AppRuntime
                    .Instance
                    .CurrentApplication
                    .ObjectContainer
                    .GetService<ICommandBus>())
                {
                    commandBus.Publish(command);
                    commandBus.Commit();
                }
            }
            catch (Exception ex)
            {
                throw;
            }
        }

        #region 附加测试特性
        //
        // 编写测试时，可以使用以下附加特性: 
        //
        // 在运行类中的第一个测试之前使用 ClassInitialize 运行代码
        // [ClassInitialize()]
        // public static void MyClassInitialize(TestContext testContext) { }
        //
        // 在类中的所有测试都已运行之后使用 ClassCleanup 运行代码
        // [ClassCleanup()]
        // public static void MyClassCleanup() { }
        //
        // 在运行每个测试之前，使用 TestInitialize 来运行代码
        // [TestInitialize()]
        // public void MyTestInitialize() { }
        //
        // 在每个测试运行完之后，使用 TestCleanup 来运行代码
        // [TestCleanup()]
        // public void MyTestCleanup() { }
        //
        #endregion

        //[TestMethod]
        //public void RegisterAccount()
        //{
        //    AccountRegisterCommand command = new AccountRegisterCommand
        //    {
        //        Id=Guid.NewGuid(),
        //        LoginName = "kikao",
        //        UserName = "高琦",
        //        Password = "123456"
        //    };
        //    this.CommitCommand(command);
        //}

        [TestMethod]
        public void FindAll()
        {
            for (int i = 0; i < 10; i++)
            {
                Thread n=new Thread(() =>
                {
                   var res=  AccountBook.Service.QueryService.CommodityQueryService.Pages(1, 20);
                });
                n.Start();
            }
        }
    }
}
