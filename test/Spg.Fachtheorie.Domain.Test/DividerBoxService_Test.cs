using Spg.Fachtheorie.Domain.Model;
using Spg.Fachtheorie.Domain.Services;
using Spg.Fachtheorie.Domain.Test.Helpers;

public class DividerBoxService_Test
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
            var service = new DividerBoxService(db);

            var ret = service.Create(new Spg.Fachtheorie.Domain.DTOs.DividerBoxPostDto("jane",12));

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

            var count = db.DividerBoxes.Count();
            var service = new DividerBoxService(db);
            var id = db.DividerBoxes.First().Id;

            service.Delete(id);

            Assert.True(db.DividerBoxes.Count() == count - 1);
        }

    }

    [Fact]
    public void GetAll()
    {


        using (RoomCt db = new RoomCt(DatabaseUtilities.GetDbOptions()))
        {
            // Arrange
            DatabaseUtilities.InitializeDatabase(db);
            var service = new DividerBoxService(db);
            var res = service.GetAll();

            Assert.True(res.Count() == db.DividerBoxes.Count());
        }

    }

}
