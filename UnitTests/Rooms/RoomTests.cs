using Model.Rooms;
using Moq;
using System.Collections.Generic;
using Service.RoomService;
using Shouldly;
using Xunit;
using System.Linq;
using Repository.RoomRepository;

namespace MedbayTechUnitTests
{
    public class RoomTests
    {
        [Theory]
        [MemberData(nameof(RoomQueries))]
        public void Room_search ( string query, bool isEmpty )
        {
            RoomService roomService = new RoomService(CreateRepositoryStub());
            List<Room> rooms = roomService.GetRoomsByRoomLabelorRoomUse(query);

            bool empty = !rooms.Any();
            empty.ShouldBe(isEmpty);
        }

        public static IEnumerable<object[]> RoomQueries ( )
        {
            var retVal = new List<object[]>();
            retVal.Add(new object[] { "asd", false });
            retVal.Add(new object[] { "asdasdasdasdadasd", true });
            return retVal;
        }

        public IRoomRepository CreateRepositoryStub ( )
        {
            var stubRepository = new Mock<IRoomRepository>();
            var rooms = GetRooms();
            stubRepository.Setup(m => m.GetAll()).Returns(rooms);
            return stubRepository.Object;
        }

        private static IEnumerable<Room> GetRooms ( )
        {
            var r3 = new Room
            {
                Id = 1,
                RoomNumber = 4,
                RoomLabel = "asd",
                RoomUse = "Examination room",
                BedsCapacity = 4,
                BedsFree = 5,
                RoomType = RoomType.ExaminationRoom,
                DepartmentId = 5,
                Department = new Department(),
                HospitalEquipment = new System.Collections.Generic.List<HospitalEquipment>()
            };
            var r2 = new Room
            {
                Id = 3,
                RoomNumber = 4,
                RoomLabel = "Lalala",
                RoomUse = "Examination room",
                BedsCapacity = 4,
                BedsFree = 5,
                RoomType = RoomType.ExaminationRoom,
                DepartmentId = 5,
                Department = new Department(),
                HospitalEquipment = new System.Collections.Generic.List<HospitalEquipment>()
            };
            var r1 = new Room
            {
                Id = 2,
                RoomNumber = 8,
                RoomLabel = "Lalala",
                RoomUse = "Operation room",
                BedsCapacity = 4,
                BedsFree = 5,
                RoomType = RoomType.OperationRoom,
                DepartmentId = 5,
                Department = new Department(),
                HospitalEquipment = new System.Collections.Generic.List<HospitalEquipment>()
            };
            var Rooms = new List<Room>();
            Rooms.Add(r1);
            Rooms.Add(r2);
            Rooms.Add(r3);
            return Rooms;
        }
    }
}