using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Transactions;
using Beamore.Contracts.DataTransferObjects.Event;
using Beamore.Contracts.DataTransferObjects;
using Beamore.API.Controllers;
using Beamore.API.BusinessLogics.UnitOfWorks;

namespace Beamore.Tests.Services
{
    [TestClass]
    public class EventUnitTest
    {
        [TestMethod]
        public void AddNewEvent()
        {
            using (TransactionScope scope = new TransactionScope())
            {
                
                NewEventDTO evnt = new NewEventDTO
                {
                    EventName = "Deneme",
                    EventEmail = "eventname@beamore.tech",
                    StartDate = DateTime.UtcNow,
                    FinishDate = DateTime.UtcNow,
                    IsActive =true,
                    Locaiton = new LocationDTO
                    {
                        Latitude = 12.5,
                        Longitude = 15.6,
                        Address = "Event Adress"
                    },
                    LogoUrl = "url adres gelcek"
                };
                //IEventService service = GenericProxy.GetService<IEventService>("eersinyildizz@gmail.com");
                var service = new EventController();
                var result = service.CreateNewEvent(evnt, "eersinyildizz@gmail.com");
                Assert.AreEqual(true,result);
                scope.Complete();
            }
                
        }
    }
}
