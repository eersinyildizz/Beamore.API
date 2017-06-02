using System.Collections.Generic;
using Beamore.Contracts.DataTransferObjects.Event.EventDetail;
using Beamore.DAL.Contents.Models;
using Beamore.DAL.Repositories;
using Beamore.Contracts.DataTransferObjects.Event;
using System.Transactions;
using Beamore.API.Models;

namespace Beamore.API.BusinessLogics.UnitOfWorks
{
    public class PortalEventService : IPortalEventService
    {
        private IRepository<User> _userRepo;
        private IRepository<Event> _evntRepo;
        private IRepository<Location> _locationRepo;
        private IRepository<EventFlow> _evntFlow;


        public PortalEventService(IRepository<User> user, IRepository<Event> evntRepo, IRepository<Location> locationRepo, IRepository<EventFlow> evntFlow)
        {
            _userRepo = user;
            _evntRepo = evntRepo;
            _locationRepo = locationRepo;
            _evntFlow = evntFlow;
        }


        public List<EventFlowDTO> GetMyEventDetail (string email, int EventID)
        {
            User User = _userRepo.FindByExpBySingle(p => p.Email == email);
            // User control isexist in the system
            if (User != null)
            {
                // User and Event id have to be in relationship. Otherwise Unauthorized access !!!!!
                Event Event = _evntRepo.FindByExpBySingle(p => p.UserId == User.Id && p.Id == EventID);
                if (Event != null)
                {

                    List<EventFlowDTO> EventFlow = new List<EventFlowDTO>();
                    var getEventFlow = _evntFlow.FindByExxpression(p => p.EventId == EventID);
                    for (int a = 0; a < getEventFlow.Count; a++)
                    {
                        EventFlowDTO evntFlow = new EventFlowDTO
                        {
                            FlowId = getEventFlow[a].Id,
                            FlowName = getEventFlow[a].FlowName,
                            FlowTime = getEventFlow[a].FlowTime,
                            IsDone = getEventFlow[a].IsDone,
                            CompanyName = getEventFlow[a].CompanyName,
                            Explain = getEventFlow[a].Explain,
                            Header = getEventFlow[a].Header
                        };
                        EventFlow.Add(evntFlow);

                    }

                    return EventFlow;
                }
                else
                {

                    return null;
                }
            }
            else
            {
                return null;
            }

        }

        public List<EventFlowDTO> GetMyEventDetailForendUser(string email, int EventID)
        {
            User User = _userRepo.FindByExpBySingle(p => p.Email == email);
            // User control isexist in the system
            if (User != null)
            {
                // User and Event id have to be in relationship. Otherwise Unauthorized access !!!!!
                Event Event = _evntRepo.FindByExpBySingle(p=>p.Id == EventID);
                if (Event != null)
                {

                    List<EventFlowDTO> EventFlow = new List<EventFlowDTO>();
                    var getEventFlow = _evntFlow.FindByExxpression(p => p.EventId == EventID);
                    for (int a = 0; a < getEventFlow.Count; a++)
                    {
                        EventFlowDTO evntFlow = new EventFlowDTO
                        {
                            FlowId = getEventFlow[a].Id,
                            FlowName = getEventFlow[a].FlowName,
                            FlowTime = getEventFlow[a].FlowTime,
                            IsDone = getEventFlow[a].IsDone,
                            CompanyName = getEventFlow[a].CompanyName,
                            Explain = getEventFlow[a].Explain,
                            Header = getEventFlow[a].Header
                        };
                        EventFlow.Add(evntFlow);

                    }

                    return EventFlow;
                }
                else
                {

                    return null;
                }
            }
            else
            {
                return null;
            }

        }

        public bool AddEventFlow(string email, List<FlowAddDTO> flows)
        {
            using (TransactionScope scope = new TransactionScope())
            {
                User User = _userRepo.FindByExpBySingle(p => p.Email == email);
                if (User != null)
                {
                    var isExist = _evntFlow.FindById(flows[0].EventId);
                    if (isExist == null)
                    {
                        foreach (var item in flows)
                        {
                            EventFlow ef = new EventFlow
                            {
                                EventId = item.EventId,
                                FlowName = item.FlowName,
                                FlowTime = item.FlowTime
                            };
                            EventFlow result = _evntFlow.add(ef);

                        }
                        _evntFlow.Save();
                        scope.Complete();
                        return true;
                    }
                    else
                    {
                        int a = flows[0].EventId;
                        var EFR = _evntFlow.FindByExxpression(p=>p.EventId == a);

                        for (int x = 0; x<EFR.Count;x++)
                        {
                            EFR[x].FlowName = flows[x].FlowName;
                            _evntFlow.update(EFR[x]);
                        }
                        _evntFlow.Save();
                        scope.Complete();
                    }

                    
                }
            }
                return false;
        }

        public bool AddEventFlowDetail(string email, EventFlowDetailModel flowDetail)
        {
            using (TransactionScope scope = new TransactionScope())
            {
                User User = _userRepo.FindByExpBySingle(p => p.Email == email);
                if (User != null)
                {
                    var EFR = _evntFlow.FindByExpBySingle(p => p.Id == flowDetail.FlowId && p.EventId == flowDetail.EventId);
                    if (EFR != null)
                    {
                        EFR.Header = flowDetail.Header;
                        EFR.Explain = flowDetail.Explain;
                        EFR.CompanyName = flowDetail.Company;
                        _evntFlow.Save();
                        scope.Complete();
                        return true;
                    }
                    return false;
                }
                return false;
            }
        }


        ///SILINECEK
        ///Chatbot için yazıldı
        ///
        public List<EventFlowDTO> GetMyEventDetailForBot(int EventID)
        {
          
           
                // User and Event id have to be in relationship. Otherwise Unauthorized access !!!!!
                Event Event = _evntRepo.FindByExpBySingle(p => p.Id == EventID);
                if (Event != null)
                {

                    List<EventFlowDTO> EventFlow = new List<EventFlowDTO>();
                    var getEventFlow = _evntFlow.FindByExxpression(p => p.EventId == EventID);
                    for (int a = 0; a < getEventFlow.Count; a++)
                    {
                        EventFlowDTO evntFlow = new EventFlowDTO
                        {
                            FlowId = getEventFlow[a].Id,
                            FlowName = getEventFlow[a].FlowName,
                            FlowTime = getEventFlow[a].FlowTime,
                            IsDone = getEventFlow[a].IsDone,
                            CompanyName = getEventFlow[a].CompanyName,
                            Explain = getEventFlow[a].Explain,
                            Header = getEventFlow[a].Header
                        };
                        EventFlow.Add(evntFlow);

                    }

                    return EventFlow;
                }
                else
                {

                    return null;
                }
            
        }
    }
}