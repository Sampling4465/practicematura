using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Spg.Fachtheorie.Aufgabe2.Api.Controllers;
using Spg.Fachtheorie.Domain.DTOs;
using Spg.Fachtheorie.Domain.Model;
using Spg.Fachtheorie.Domain.Services;
using Spg.Fachtheorie.Domain.Test.Helpers;
using System.ComponentModel;
using System.Drawing;

namespace Spg.Fachtheorie.Aufgabe2.Api.Test
{
    public class DividerBoxControllerTest
    {

        [Fact]
        public void Create()
        {
            using (RoomCt db = new RoomCt(DatabaseUtilities.GetDbOptions()))
            {
                // Arrange
                DatabaseUtilities.InitializeDatabase(db);

                Assert.True(true);
            }
        }
        [Fact]
        public void GetTest()
        {

            using (RoomCt db = new RoomCt(DatabaseUtilities.GetDbOptions()))
            {
                // Arrange
                DatabaseUtilities.InitializeDatabase(db);
                var service = new DividerBoxService(db);
                var controller = new DividerBoxController(service,db);

                var result = controller.GetAll() as OkObjectResult;
                Assert.NotNull(result); // can also test count 

            }
        }

        [Fact]
        public void CreateTest()
        {

            using (RoomCt db = new RoomCt(DatabaseUtilities.GetDbOptions()))
            {
                // Arrange
                DatabaseUtilities.InitializeDatabase(db);
                var service = new DividerBoxService(db);
                var controller = new DividerBoxController(service, db);

                var count = db.DividerBoxes.Count();

                var result = controller.CreateOne(new DividerBoxPostDto("lala",12)) as OkObjectResult;
                Assert.NotNull(result);

                Assert.True(count + 1 == db.DividerBoxes.Count());

            }
        }
        [Fact]
        public void GetFloorsTest()
        {

            using (RoomCt db = new RoomCt(DatabaseUtilities.GetDbOptions()))
            {
                // Arrange
                DatabaseUtilities.InitializeDatabase(db);
                var service = new DividerBoxService(db);
                var controller = new DividerBoxController(service, db);

                var d = db.DividerBoxLocations.First().StorageRoomNavigation.Floor;


                var result = controller.GetFloors(d) as OkObjectResult;
                
                Assert.NotNull(result);

                var returns = result.Value as IEnumerable<DividerBoxDto>;
                Assert.True(returns.Count() == 1);
            }
        }
        [Fact]
        public void GetBuilding()
        {

            using (RoomCt db = new RoomCt(DatabaseUtilities.GetDbOptions()))
            {
                // Arrange
                DatabaseUtilities.InitializeDatabase(db);
                var service = new DividerBoxService(db);
                var controller = new DividerBoxController(service, db);

                var d = db.DividerBoxLocations.First().StorageRoomNavigation.Building;


                var result = controller.GetBuilding(d) as OkObjectResult;

                Assert.NotNull(result);

                var returns = result.Value as IEnumerable<DividerBoxDto>;
                Assert.True(returns.Count() == 1);
            }
        }

    }


}
