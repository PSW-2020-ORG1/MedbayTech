using Model.Rooms;
using Moq;
using Repository.RoomRepository;
using Service.RoomService;
using Shouldly;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Xunit;

namespace MedbayTechUnitTests
{
    public class EquipmentTests
    {
        [Theory]
        [MemberData(nameof(EquipmentQueries))]
        public void Equipment_search ( string query, bool isEmpty )
        {
            HospitalEquipmentService hospitalEquipmentService = new HospitalEquipmentService(CreateRepositoryStub());
            List<HospitalEquipment> hospitalEquipment = hospitalEquipmentService.GetHospitalEquipmentsByNameOrId(query);

            bool empty = !hospitalEquipment.Any();
            empty.ShouldBe(isEmpty);
        }

        public static IEnumerable<object[]> EquipmentQueries ( )
        {
            var retVal = new List<object[]>();
            retVal.Add(new object[] { "4", false });
            return retVal;
        }

        public IHospitalEquipmentRepository CreateRepositoryStub ( )
        {
            var stubRepository = new Mock<IHospitalEquipmentRepository>();
            var equipment = GetEquipment();
            stubRepository.Setup(m => m.GetAll()).Returns(equipment);
            return stubRepository.Object;
        }

        private static IEnumerable<HospitalEquipment> GetEquipment ( )
        {
            var h1 = new HospitalEquipment { Id = 1, QuantityInRoom = 1, QuantityInStorage = 8, RoomId = 1003, EquipmentTypeId = 9 };
            var h2 = new HospitalEquipment { Id = 2, QuantityInRoom = 1, QuantityInStorage = 8, RoomId = 1003, EquipmentTypeId = 10 };
            var h3 = new HospitalEquipment { Id = 3, QuantityInRoom = 1, QuantityInStorage = 5, RoomId = 1003, EquipmentTypeId = 17 };
            var h4 = new HospitalEquipment { Id = 4, QuantityInRoom = 20, QuantityInStorage = 100, RoomId = 1003, EquipmentTypeId = 18 };
            var h5 = new HospitalEquipment { Id = 5, QuantityInRoom = 20, QuantityInStorage = 100, RoomId = 1003, EquipmentTypeId = 19 };
            var h6 = new HospitalEquipment { Id = 6, QuantityInRoom = 2, QuantityInStorage = 9, RoomId = 1003, EquipmentTypeId = 22 };
            var hospitalEquipment = new List<HospitalEquipment>();
            hospitalEquipment.Add(h1);
            hospitalEquipment.Add(h2);
            hospitalEquipment.Add(h3);
            hospitalEquipment.Add(h4);
            hospitalEquipment.Add(h5);
            hospitalEquipment.Add(h6);
            return hospitalEquipment;
        }
    }
}