using Spg.Fachtheorie.Aufgabe1.Infrastructure;
using Spg.Fachtheorie.Aufgabe1.Test.Helpers;

namespace Spg.Fachtheorie.Aufgabe1.Test
{
    public class CreateTests
    {
        [Fact]
        public void CreateInnolabUser()
        {
            // Arrange
            InnoLabContext db = DatabaseUtilities.GetDatabase();
            DatabaseUtilities.InitializeDatabase(db);

            // Act

            // Assert
            Assert.True(false);
        }
    }
}