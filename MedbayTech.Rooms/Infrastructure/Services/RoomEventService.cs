using MedbayTech.Rooms.Application.Common.Interfaces.Persistance;
using MedbayTech.Rooms.Application.Common.Interfaces.Service;
using MedbayTech.Rooms.Domain;
using MedbayTech.Rooms.Domain.Events;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MedbayTech.Rooms.Infrastructure.Services
{
    public class RoomEventService : IRoomEventService
    {
        private readonly IRoomEventRepository _roomEventRepository;
        private readonly IRoomRepository _roomRepository;

        public RoomEventService(IRoomEventRepository roomEventRepository, IRoomRepository roomRepository)
        {
            _roomEventRepository = roomEventRepository;
            _roomRepository = roomRepository;
        }

        public Room GetMostEnteredRoom()
        {
            int numberOfDays = 3;
            List<RoomEvent> roomEvents = _roomEventRepository.GetAll();
            List<RoomEvent> mostEnteredRooms = new List<RoomEvent>();
            foreach (RoomEvent re in roomEvents)
            {
                if (re.Timestamp.Day <= DateTime.Now.Day && re.Timestamp.Day >= DateTime.Now.Day - numberOfDays && re.RoomId != 0 && re.RoomId != -1)
                {
                    mostEnteredRooms.Add(re);
                }
            }

            int mostEnteredRoomId = mostEnteredRooms.GroupBy(x => x.RoomId)
            .Select(group => new { RoomEventID = group.Key, Count = group.Count() })
            .OrderByDescending(x => x.Count).First().RoomEventID;


            return _roomRepository.GetBy(mostEnteredRoomId);
        }

        public RoomEvent SaveNewRoomEvent(RoomEvent roomEvent)
        {          
            return _roomEventRepository.Create(roomEvent);
        }
    }
}
