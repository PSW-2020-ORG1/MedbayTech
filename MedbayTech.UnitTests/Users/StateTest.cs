using Backend.Users.Repository.MySqlRepository;
using Backend.Users.WebApiService;
using Model.Users;
using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Xunit;
using Shouldly;

namespace MedbayTechUnitTests.Users
{
    public class StateTest
    {
        [Fact]
        public void Exists_by_id()
        {
            var stubRepository = CreateStubRepository();
            StateService cityService = new StateService(stubRepository);
            var state = CreateStateExists();

            var createdCity = cityService.CheckIfExists(state);

            createdCity.ShouldNotBeNull();
        }

        [Fact]
        public void Does_not_exists_by_id()
        {
            var stubRepository = CreateStubRepository();
            StateService cityService = new StateService(stubRepository);
            var state = CreateStateDoesNotExists();

            var createdCity = cityService.CheckIfExists(state);

            createdCity.ShouldBeNull();
        }
        [Fact]
        public void Save_state()
        {
            var stubRepository = CreateStubRepository();
            StateService cityService = new StateService(stubRepository);
            var state = CreateStateExists();

            var createdCity = cityService.Save(state);

            createdCity.ShouldNotBeNull();
        }
        public static IStateRepository CreateStubRepository()
        {
            var stubRepository = new Mock<IStateRepository>();
            var states = CreateListOfStates();
            var state = CreateStateExists();

            stubRepository.Setup(p => p.GetAll()).Returns(states);
            stubRepository.Setup(p => p.Create(state)).Returns(state);

            return stubRepository.Object;
        }

        public static State CreateStateExists()
        {
            State state = new State { Id = 1, Name = "Srbija" };
            return state;
        }

        public static State CreateStateDoesNotExists()
        {
            State state = new State { Id = 3, Name = "Makedonija" };
            return state;
        }
        private static List<State> CreateListOfStates()
        {
            List<State> states = new List<State>();

            State state1 = new State { Id = 1, Name = "Srbija" };
            State state2 = new State { Id = 2, Name = "Hrvatska" };
            states.Add(state1);
            states.Add(state2);

            return states;
        }
    }
}
