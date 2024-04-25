using Spg.Fachtheorie.Domain.Model;
using Spg.Fachtheorie.Domain.Services;
using Spg.Fachtheorie.Domain.Test.Helpers;

public class StorageRoomService_Test
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
    public void CreateTest()
    {


        using (RoomCt db = new RoomCt(DatabaseUtilities.GetDbOptions()))
        {
            // Arrange
            DatabaseUtilities.InitializeDatabase(db);
            var service = new StorageRoomService(db);

            var ret = service.Create(new Spg.Fachtheorie.Domain.DTOss.StorageRoomCreateDto("abc", "abd", "avd"));

            Assert.True(ret != null);
        }

    }

    [Fact]
    public void DeleateTest()
    {


        using (RoomCt db = new RoomCt(DatabaseUtilities.GetDbOptions()))
        {
            // Arrange
            DatabaseUtilities.InitializeDatabase(db);

            var sr = new StorageRoom()
            {
                Floor = "a",
                Building = "b",
                RoomNumber = "c"
            };
            db.StorageRooms.Add(sr);
            db.SaveChanges();
            var count = db.StorageRooms.Count();
            var service = new StorageRoomService(db);

            service.Delete(sr.Id);

            Assert.True(db.StorageRooms.Count()==count-1);
        }

    }

    [Fact]
    public void GetAll()
    {


        using (RoomCt db = new RoomCt(DatabaseUtilities.GetDbOptions()))
        {
            // Arrange
            DatabaseUtilities.InitializeDatabase(db);
            var service = new StorageRoomService(db);
            var res = service.GetAll();

            Assert.True(res.Count() == 3);
        }

    }


    //TODO: weitere UnitTests (TDD)
}
