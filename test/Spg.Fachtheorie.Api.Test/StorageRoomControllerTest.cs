using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.DependencyInjection;
using Spg.Fachtheorie.Aufgabe2.Api.Controllers;
using Spg.Fachtheorie.Domain.Model;
using Spg.Fachtheorie.Domain.Services;
using Spg.Fachtheorie.Domain.Test.Helpers;
using System.ComponentModel;


namespace Spg.Fachtheorie.Api.Test
{
    [Collection("Sequential")]
    public class StorageRoomControllerTest 
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
        public void GetTest() {

            using (RoomCt db = new RoomCt(DatabaseUtilities.GetDbOptions()))
            {
                // Arrange
                DatabaseUtilities.InitializeDatabase(db);
                var service = new StorageRoomService(db);
                var controller = new StorageRoomController(service);

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
                var service = new StorageRoomService(db);
                var controller = new StorageRoomController(service);

                var count = db.StorageRooms.Count();

                var result = controller.CreateOne(new Domain.DTOss.StorageRoomCreateDto("a", "b","1")) as OkObjectResult;
                Assert.NotNull(result);

                Assert.True(count+1 == db.StorageRooms.Count());

            }
        }


    }
}
