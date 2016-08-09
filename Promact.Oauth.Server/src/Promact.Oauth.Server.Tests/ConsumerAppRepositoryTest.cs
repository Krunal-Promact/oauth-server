﻿using Promact.Oauth.Server.Repository.ConsumerAppRepository;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.Extensions.DependencyInjection;
using Promact.Oauth.Server.Models;
using System;
using Promact.Oauth.Server.Data_Repository;
using Xunit;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace Promact.Oauth.Server.Tests
{
    public class ConsumerAppRepositoryTest : BaseProvider
    {
        private readonly IConsumerAppRepository _iConsumerAppRespository;
        private readonly IDataRepository<ConsumerApps> _iConsumerAppsContext;

        public ConsumerAppRepositoryTest() : base()
        {
            _iConsumerAppRespository = serviceProvider.GetService<IConsumerAppRepository>();
            _iConsumerAppsContext = serviceProvider.GetService<IDataRepository<ConsumerApps>>();

        }

        #region Test Case

        /// <summary>
        /// This test case for add Comnsumer Apps. -An
        /// </summary>
        [Fact]
        public void AddedConsumerApps()
        {
            ConsumerApps consumerApp = GetConsumerAppObject();
            consumerApp.Name = "Demo Name";
            int id = _iConsumerAppRespository.AddedConsumerApps(consumerApp);
            var consumerApps = _iConsumerAppsContext.FirstOrDefault(x => x.Id == id);
            Assert.NotNull(consumerApps);
        }

        /// <summary>
        /// This test case used for check consumer name is quniqe duplication not allow. -An
        /// </summary>
        [Fact]
        public void ConsumerAppNameUnique()
        {
            ConsumerApps consumerApp = GetConsumerAppObject();
            consumerApp.Name = "ABCEDF";
            int id = _iConsumerAppRespository.AddedConsumerApps(consumerApp);
            int newId = _iConsumerAppRespository.AddedConsumerApps(consumerApp);
            Assert.Same(0, newId);
        }

        [Fact]
        public void AddedConsumerAppsWithoutName()
        {
            var consumer = GetConsumerAppObject();
            consumer.Name = null;
            Assert.Throws(typeof(DbUpdateException), () =>
            {
                _iConsumerAppRespository.AddedConsumerApps(consumer);
            });

        }

        /// <summary>
        /// This test case used for check app details fetch by valid client id.-An
        /// </summary>
        [Fact]
        public void GetAppDetailsByClientId()
        {
            ConsumerApps consumerApp = GetConsumerAppObject();
            consumerApp.Name = "Demo2";
            int id = _iConsumerAppRespository.AddedConsumerApps(consumerApp);
            var consumerApps = _iConsumerAppsContext.FirstOrDefault(x => x.Id == id);
            var getApplication = _iConsumerAppRespository.GetAppDetails(consumerApps.AuthId);
            Assert.NotNull(getApplication);
        }

        /// <summary>
        /// This test case used for check app details not fetch by Invalid client id.
        /// </summary>
        [Fact]
        public void ApplicationDetailsFetchOnlyValidclientId()
        {
            ConsumerApps consumerApp = GetConsumerAppObject();
            consumerApp.Name = "Demo3";
            int id = _iConsumerAppRespository.AddedConsumerApps(consumerApp);
            var getApplication = _iConsumerAppRespository.GetAppDetails("ABEDNGdeMR1234568F");
            Assert.Null(getApplication);
        }


        /// <summary>
        /// This test case used for check consumer app details not fetch by primary key id.-An
        /// </summary>
        /// 
        [Fact]
        public void GetAppsObjectById()
        {
            ConsumerApps consumerApp = GetConsumerAppObject();
            consumerApp.Name = "Demo4";
            int id = _iConsumerAppRespository.AddedConsumerApps(consumerApp);
            var getApplication = _iConsumerAppRespository.GetAppsObjectById(id);
            Assert.NotNull(getApplication);
        }


        /// <summary>
        /// This test case used for check consumer app details not fetch by in valid primary key id. -An
        /// </summary>
        ///  
        [Fact]
        public void ConsumerAppObjectNotGetByWrongId()
        {
            ConsumerApps consumerApp = GetConsumerAppObject();
            consumerApp.Name = "Demo5";
            int id = _iConsumerAppRespository.AddedConsumerApps(consumerApp);
            var getApplication = _iConsumerAppRespository.GetAppsObjectById(2);
            Assert.Null(getApplication);
        }



        /// <summary>
        /// This test case used for check get list of apps. -An 
        /// </summary>
        [Fact]
        public void GetListOfApps()
        {
            ConsumerApps consumerApp = GetConsumerAppObject();
            consumerApp.Name = "Demo6";
            int id = _iConsumerAppRespository.AddedConsumerApps(consumerApp);
            List<ConsumerApps> listOfApps = _iConsumerAppRespository.GetListOfApps();
            Assert.NotEmpty(listOfApps);
        }

        /// <summary>
        /// This test case used for update consumer app. -An
        /// </summary>
        [Fact]
        public void updateConsumerApps()
        {
            ConsumerApps consumerApp = GetConsumerAppObject();
            consumerApp.Name = "Demo for Update";
            int id = _iConsumerAppRespository.AddedConsumerApps(consumerApp);
            consumerApp.Description = "XyzName";
            consumerApp.UpdatedDateTime = DateTime.Now;
            consumerApp.UpdatedBy = "Ankit";
            int newId = _iConsumerAppRespository.UpdateConsumerApps(consumerApp);
            Assert.NotSame(0, newId);
        }

        //[Fact]
        //public void CheckConsumerAppNameUnique()
        //{
        //    var consumer = GetConsumerAppObject();
        //    consumer.Name = "Twitter";
        //    _iConsumerAppRespository.AddedConsumerApps(consumer);
        //    consumer.Name = "Face Book";
        //    _iConsumerAppRespository.AddedConsumerApps(consumer);
        //    var oldConsumerApp =
        //    int newId = _iConsumerAppRespository.UpdateConsumerApps(consumer);
        //    Assert.Same(0, newId);
        //}

        #endregion


        #region "Private Method(s)"

        /// <summary>
        /// This method used for get valid object with data. -An
        /// </summary>
        /// <returns></returns>
        private ConsumerApps GetConsumerAppObject()
        {
            ConsumerApps comnsumerApp = new ConsumerApps();
            comnsumerApp.CallbackUrl = "https://promact.slack.com/messages/@roshni/";
            comnsumerApp.CreatedBy = "Roshni";
            comnsumerApp.Description = "This App is Demo App, Please don't used";
            comnsumerApp.CreatedDateTime = DateTime.Now;
            return comnsumerApp;
        }
        #endregion
    }
}
