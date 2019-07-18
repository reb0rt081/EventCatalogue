using System;
using System.Collections.Generic;
using System.Linq;
using EventCatalogue.Application;
using EventCatalogue.Shared.Classes;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace EventCatalogue.Test.U
{
    [TestClass]
    public class EventCatalogueManagerTest
    {
        private EventCatalogueManager manager; 

        [TestInitialize]
        public void Initialize()
        {
            manager = new EventCatalogueManager();
            manager.Start();
        }

        /// <summary>
        /// This tests ensures that events can be added and then retrieved with full query.
        /// </summary>
        [TestMethod]
        public void AddAndFilterForEventTest()
        {
            string dummyLocation = "TestLocation";
            string dummyDescription = "TestDescription";
            DateTime dateTime = DateTime.Today;
            manager.AddEvent(new EventInfo() { Location = dummyLocation, Description = dummyDescription}, dateTime);
            List<EventInfo> result = manager.FindEvents(dummyLocation, dateTime, true);
            Assert.AreEqual(dummyLocation, result.SingleOrDefault().Location);
        }

        /// <summary>
        /// This tests ensures that events can be added and then retrieved with the location.
        /// </summary>
        [TestMethod]
        public void AddAndFilterForEventLocationTest()
        {
            string dummyLocation = "TestLocation";
            string dummyDescription = "TestDescription";
            DateTime dateTime = DateTime.Today;
            manager.AddEvent(new EventInfo() { Location = dummyLocation, Description = dummyDescription }, dateTime);
            List<EventInfo> result = manager.FindEvents(dummyLocation, null, false);
            Assert.AreEqual(dummyLocation, result.SingleOrDefault().Location);
        }

        /// <summary>
        /// This tests ensures that events can be added and then retrieved with the date.
        /// </summary>
        [TestMethod]
        public void AddAndFilterForEventDaeTest()
        {
            string dummyLocation = "TestLocation";
            string dummyDescription = "TestDescription";
            DateTime dateTime = DateTime.Today;
            manager.AddEvent(new EventInfo() { Location = dummyLocation, Description = dummyDescription }, dateTime);
            List<EventInfo> result = manager.FindEvents(null, dateTime, false);
            Assert.AreEqual(dummyLocation, result.SingleOrDefault().Location);
        }

        /// <summary>
        /// This tests ensures that events can be added and then deleted.
        /// </summary>
        [TestMethod]
        public void AddAndFilterAndDeleteTest()
        {
            string dummyLocation = "TestLocation";
            string dummyDescription = "TestDescription";
            DateTime dateTime = DateTime.Today;
            manager.AddEvent(new EventInfo() { Location = dummyLocation, Description = dummyDescription }, dateTime);
            List<EventInfo> result = manager.FindEvents(null, dateTime, false);
            Assert.AreEqual(dummyLocation, result.SingleOrDefault().Location);

            manager.DeleteEvent(result.SingleOrDefault().Id);

            Assert.IsTrue(!manager.FindEvents(null, dateTime, false).Any());
        }

        /// <summary>
        /// This tests ensures that events can be added and then updated.
        /// </summary>
        [TestMethod]
        public void AddAndFilterAnUpdateTest()
        {
            string dummyLocation = "TestLocation";
            string dummyDescription = "TestDescription";
            DateTime dateTime = DateTime.Today;
            manager.AddEvent(new EventInfo() { Location = dummyLocation, Description = dummyDescription }, dateTime);
            EventInfo result = manager.FindEvents(null, dateTime, false).SingleOrDefault();

            Assert.AreEqual(dummyLocation, result.Location);
            result.Location = dummyDescription;
            manager.UpdateEvent(result);

            Assert.AreEqual(dummyDescription, result.Location);

        }
    }
}
