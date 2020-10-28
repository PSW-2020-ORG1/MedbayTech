using Model.Users;
using SimsProjekat;
using System;
using System.Collections.Generic;
using System.Text;

namespace TestApplication
{
    class Program
    {

        public static Application app = new Application();
        static void Main(string[] args)
        {
            var randomController = app.addressController;
            randomController.CreateAddress(new Model.Users.Address("rand", 1, 1, 1, new City("novi sad", new State("srbija"))));
        }
    }
}
