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
    public class DividerBoxLocationControllerTest
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
                var service = new DeviderBoxLocationService(db);
                var controller = new DividerBoxLocationController(service, db);

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
                var service = new DeviderBoxLocationService(db);
                var controller = new DividerBoxLocationController(service, db);

                var count = db.DividerBoxLocations.Count();

                var divider = db.DividerBoxes.First();

                var result = controller.CreateOne(new CreateDividerBoxLocationDto() { byWhom = "alex", from = DateTime.Now, to = DateTime.Now.AddDays(1), DividerBoxId = divider.Id, notes = "" }
 ) as OkObjectResult;
                Assert.NotNull(result);

                Assert.True(count + 1 == db.DividerBoxLocations.Count());

            }
        }

        [Fact]
        public void GetFromDivider()
        {

            using (RoomCt db = new RoomCt(DatabaseUtilities.GetDbOptions()))
            {
                // Arrange
                DatabaseUtilities.InitializeDatabase(db);
                var service = new DeviderBoxLocationService(db);
                var controller = new DividerBoxLocationController(service, db);

                var divider = db.DividerBoxLocations.First().DividerBoxNavigation.Id;

                var result = controller.GettAllFromDevider(divider) as OkObjectResult;
                

                Assert.NotNull(result);

                var res = result.Value as IEnumerable<DividerBoxLocationDto>;

                Assert.True(res.Count() == 4 );

            }
        }
        [Fact]
        public void GetFromStorageRoom()
        {

            using (RoomCt db = new RoomCt(DatabaseUtilities.GetDbOptions()))
            {
                // Arrange
                DatabaseUtilities.InitializeDatabase(db);
                var service = new DeviderBoxLocationService(db);
                var controller = new DividerBoxLocationController(service, db);

                var divider = db.DividerBoxLocations.First().StorageRoomNavigation.Id;

                var result = controller.GettAllFromStorageRoom(divider) as OkObjectResult;


                Assert.NotNull(result);

                var res = result.Value as IEnumerable<DividerBoxLocationDto>;

                Assert.True(res.Count() == 4);

            }
        }
    }
}
