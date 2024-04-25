using Spg.Fachtheorie.Domain.Model;
using Spg.Fachtheorie.Domain.Services;
using Spg.Fachtheorie.Domain.Test.Helpers;

public class DeviderBoxLocationService_Test
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
            var service = new DeviderBoxLocationService(db);

            var divider = db.DividerBoxes.First();

            var ret = service.Create(new CreateDividerBoxLocationDto() { byWhom = "alex",from = DateTime.Now, to = DateTime.Now.AddDays(1),DividerBoxId=divider.Id,notes = ""});

            Assert.True(ret != null);
        }

    }

    [Fact]
    public void FailureCreateTest()
    {


        using (RoomCt db = new RoomCt(DatabaseUtilities.GetDbOptions()))
        {
            // Arrange
            DatabaseUtilities.InitializeDatabase(db);
            var service = new DeviderBoxLocationService(db);

            var divider = db.DividerBoxes.First();

            var ret = service.Create(new CreateDividerBoxLocationDto() { byWhom = "alex", from = DateTime.Now, to = DateTime.Now.AddDays(1), notes = "" });

            Assert.True(ret == null);
        }

    }

    [Fact]
    public void OverlapTest()
    {


        using (RoomCt db = new RoomCt(DatabaseUtilities.GetDbOptions()))
        {
            // Arrange
            DatabaseUtilities.InitializeDatabase(db);
            var service = new DeviderBoxLocationService(db);

            var location1 = db.DividerBoxLocations.First();


            var ret = service.Create(new CreateDividerBoxLocationDto() { byWhom = "alex", from = location1.From, to = location1.From.AddDays(1), notes = "", DividerBoxId = location1.DividerBoxNavigation.Id });

            var res = db.DividerBoxLocations.FirstOrDefault(a => a.Id == ret.Id);

            Assert.True(res.From == location1.Until);
        }
    }

        [Fact]
    public void DeleateTest()
    {


        using (RoomCt db = new RoomCt(DatabaseUtilities.GetDbOptions()))
        {
            // Arrange
            DatabaseUtilities.InitializeDatabase(db);

            var count = db.DividerBoxLocations.Count();
            var service = new DeviderBoxLocationService(db);
            var id = db.DividerBoxLocations.First().Id;

            service.Delete(id);

            Assert.True(db.DividerBoxLocations.Count() == count - 1);
        }

    }

    [Fact]
    public void GetAll()
    {


        using (RoomCt db = new RoomCt(DatabaseUtilities.GetDbOptions()))
        {
            // Arrange
            DatabaseUtilities.InitializeDatabase(db);
            var service = new DeviderBoxLocationService(db);
            var res = service.GetAll();

            Assert.True(res.Count() == db.DividerBoxLocations.Count());
        }

    }


}
