using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Beamore.Contracts.DataTransferObjects;
using Beamore.Contracts.DataTransferObjects.Event;
using Beamore.DAL.Repositories;
using Beamore.DAL.Contents.Models;
using System.Transactions;
using System.Threading.Tasks;
using Beamore.API.BusinessLogics.Notification;
using Microsoft.Azure.NotificationHubs;

namespace Beamore.API.BusinessLogics.UnitOfWorks
{
    public class EventService : IEventService
    {
        private IRepository<Event> _evntRepo;
        private IRepository<Location> _locationRepo;
        private IRepository<User> _userRepo;
        private IRepository<EventSubcriber> _eventSubscribeRepo;

        public EventService(IRepository<Event> evntRepo, IRepository<Location> locationRepo, IRepository<User> userRepo, IRepository<EventSubcriber> eventSubscribeRepo)
        {
            _evntRepo = evntRepo;
            _locationRepo = locationRepo;
            _userRepo = userRepo;
            _eventSubscribeRepo = eventSubscribeRepo;
        }

        public bool CreateNewEvent(NewEventDTO evnt, string email)
        {
            using (TransactionScope scope = new TransactionScope())
            {
                var User = _userRepo.FindByExpBySingle(p => p.Email == email);
                if (User != null)
                {
                    Location locat = new Location
                    {
                        Latitude = evnt.Locaiton.Latitude,
                        Longitude = evnt.Locaiton.Longitude,
                        Address = evnt.Locaiton.Address,
                        Note = evnt.Locaiton.Note
                    };

                    Location addedLocation = _locationRepo.add(locat);

                    Event newEvnt = new Event
                    {
                        EventName = evnt.EventName,
                        EventEmail = evnt.EventEmail,
                        EventStartDate = evnt.StartDate,
                        EventFinishDate = evnt.FinishDate,
                        EventStartTime = evnt.StartTime,
                        IsActive = evnt.IsActive,
                        LogoUrl = evnt.LogoUrl,
                        LocationId = addedLocation.Id,
                        UserId = User.Id,
                        CategoryId = 5

                    };
                    Event addedEvent = _evntRepo.add(newEvnt);
                    _locationRepo.Save();
                    _evntRepo.Save();
                    scope.Complete();
                    
                    return true;
                }
            }
            return false;

        }

        public List<EventDTO> getAllEvents()
        {

            List<EventDTO> evnt = new List<EventDTO>();
            var events = _evntRepo.FindByExxpression(p => p.IsActive == true);
            for (int x = 0; x < events.Count; x++)
            {
                var re = _locationRepo.FindById(events[x].LocationId);
                LocationDTO lo = new LocationDTO
                {
                    Address = re.Address,
                    Latitude = re.Latitude,
                    Longitude = re.Longitude
                };

                EventDTO newEvnt = new EventDTO
                {
                    EventName = events[x].EventName,
                    EventDate = events[x].EventStartDate,
                    EventStartTime = events[x].EventStartTime,
                    EventEmail = events[x].EventEmail,
                    EventID = events[x].Id,
                    Location = lo,
                    LogoUrl = events[x].LogoUrl
                };
                evnt.Add(newEvnt);
            }
            return evnt;

        }

        public List<EventDTO> getMyEvent(string email)
        {
            var User = _userRepo.FindByExpBySingle(p => p.Email == email);
            List<EventDTO> evnt = new List<EventDTO>();
            var events = _evntRepo.FindByExxpression(p => p.UserId == User.Id);
            for (int x = 0; x < events.Count; x++)
            {
                var re = _locationRepo.FindById(events[x].LocationId);
                LocationDTO lo = new LocationDTO
                {
                    Address = re.Address,
                    Latitude = re.Latitude,
                    Longitude = re.Longitude
                };

                EventDTO newEvnt = new EventDTO
                {
                    EventName = events[x].EventName,
                    EventDate = events[x].EventStartDate,
                    EventEmail = events[x].EventEmail,
                    EventStartTime = events[x].EventStartTime,
                    EventID = events[x].Id,
                    Location = lo,
                    LogoUrl = events[x].LogoUrl
                };
                evnt.Add(newEvnt);
            }
            return evnt;

        }
        public List<EventDTO> GetUserEvent(string email)
        {
            var User = _userRepo.FindByExpBySingle(p => p.Email == email);
            var evntResult = _eventSubscribeRepo.FindByExxpression(p => p.UserId == User.Id && p.IsActive == true);

            List<EventDTO> evnt = new List<EventDTO>();

            for (int a = 0; a < evntResult.Count; a++)
            {
                var events = _evntRepo.FindById(evntResult[a].EventId);
                var re = _locationRepo.FindById(events.LocationId);
                LocationDTO lo = new LocationDTO
                {
                    Address = re.Address,
                    Latitude = re.Latitude,
                    Longitude = re.Longitude
                };

                EventDTO newEvnt = new EventDTO
                {
                    EventName = events.EventName,
                    EventDate = events.EventStartDate,
                    EventEmail = events.EventEmail,
                    EventStartTime = events.EventStartTime,
                    EventID = events.Id,
                    Location = lo,
                    LogoUrl = events.LogoUrl
                };
                evnt.Add(newEvnt);

            }
            return evnt;

        }

        /// <summary>
        /// Bir event detayına gitmek için
        /// </summary>
        /// <param name="id"></param>
        /// <param name="email"></param>
        /// <returns></returns>
        public EventDTO getMyEventForOne(int id, string email)
        {
            var User = _userRepo.FindByExpBySingle(p => p.Email == email);
            var events = _evntRepo.FindByExpBySingle(p => p.UserId == User.Id && p.Id == id);
            if (events != null)
            {
                var re = _locationRepo.FindById(events.LocationId);
                LocationDTO lo = new LocationDTO
                {
                    Address = re.Address,
                    Latitude = re.Latitude,
                    Longitude = re.Longitude
                };
                EventDTO returnEvent = new EventDTO
                {
                    EventID = events.Id,
                    EventDate = events.CreatedDate,
                    EventStartTime = events.EventStartTime,
                    EventEmail = events.EventEmail,
                    EventName = events.EventName,
                    Location = lo,
                    LogoUrl = events.LogoUrl
                };

                return returnEvent;
            }
            return null;
        }

        public EventReturnDTO SubscribeEvent(string email, int eventID)
        {
            using (TransactionScope scope = new TransactionScope())
            {
                EventReturnDTO result = new EventReturnDTO
                {
                    IsSuccess = true,
                    Message = "Event başarıyla kayıt oldunuz"
                };

                var User = _userRepo.FindByExpBySingle(p => p.Email == email);
                var IsExist = _eventSubscribeRepo.FindByExpBySingle(p => p.EventId == eventID && p.UserId == User.Id);

                if (IsExist != null)
                {
                    result.IsSuccess = false;
                    result.Message = "Daha once bu event kayıt oldunuz";
                    return result;
                }

                EventSubcriber newSubEvent = new EventSubcriber
                {
                    EventId = eventID,
                    UserId = User.Id,
                    IsActive = true
                };

                var subResult = _eventSubscribeRepo.add(newSubEvent);
                _eventSubscribeRepo.Save();
                scope.Complete();

                return result;
            }

        }

        public EventReturnDTO UnSubscribeEvent(string email, int eventID)
        {
            using (TransactionScope scope = new TransactionScope())
            {
                EventReturnDTO result = new EventReturnDTO
                {
                    IsSuccess = true,
                    Message = "Event' ten başarıyla çıktınız"
                };

                var User = _userRepo.FindByExpBySingle(p => p.Email == email);
                var IsExist = _eventSubscribeRepo.FindByExpBySingle(p => p.EventId == eventID && p.UserId == User.Id);                                                                                                    

                if (IsExist == null)
                {
                    result.IsSuccess = false;
                    result.Message = "Valla sağlam logic hatası var bakmak lazım. Subscribe table da olmayan bir event i silmeye çalıştın.";
                    return result;
                }
                //IsExist.IsActive = false;

                _eventSubscribeRepo.update(IsExist);
                var resultDelete = _eventSubscribeRepo.Delete(IsExist);
                _eventSubscribeRepo.Save();
                scope.Complete();
               // return result;
                if(resultDelete)
                {
                    return result;
                }
                else
                {
                    result.IsSuccess = false;
                    result.Message = "Hata oldu. Lutfen tekrar deneyin";
                    return result;
                }




            }

        }

        public int ParticipantNumber(string email, int EventId)
        {
            var User = _userRepo.FindByExpBySingle(p => p.Email == email);
            var IsExist = _eventSubscribeRepo.FindByExxpression(p => p.EventId == EventId);
            return IsExist.Count;
        }



        public List<EventDTO> GetAllEventForChatbot()
        {

            List<EventDTO> evnt = new List<EventDTO>();
            var events = _evntRepo.FindByExxpression(p => p.IsActive == true);
            for (int x = 0; x < events.Count; x++)
            {
                var re = _locationRepo.FindById(events[x].LocationId);
                LocationDTO lo = new LocationDTO
                {
                    Address = re.Address,
                    Latitude = re.Latitude,
                    Longitude = re.Longitude
                };

                EventDTO newEvnt = new EventDTO
                {
                    EventName = events[x].EventName,
                    EventDate = events[x].EventStartDate,
                    EventStartTime = events[x].EventStartTime,
                    EventEmail = events[x].EventEmail,
                    EventID = events[x].Id,
                    Location = lo,
                    LogoUrl = events[x].LogoUrl
                };
                evnt.Add(newEvnt);
            }
            return evnt;

        }
    }
}