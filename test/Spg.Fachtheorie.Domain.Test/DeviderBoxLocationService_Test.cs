using Spg.Fachtheorie.Domain.Model;
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

            // Act

            // Assert
            Assert.True(false);
        }
    }

    //TODO: weitere UnitTests (TDD)
}
