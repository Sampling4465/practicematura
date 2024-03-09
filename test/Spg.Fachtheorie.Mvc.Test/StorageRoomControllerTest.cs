using Microsoft.Extensions.DependencyInjection;
using Spg.Fachtheorie.Domain.Model;
using Spg.Fachtheorie.Test.Core;

namespace Spg.Fachtheorie.Mvc.Test
{
    public class StorageRoomControllerTest : IClassFixture<CustomWebApplicationFactory<Program>>
    {
        private readonly CustomWebApplicationFactory<Program> _factory;

        public StorageRoomControllerTest(CustomWebApplicationFactory<Program> factory)
        {
            _factory = factory;
        }

        /// <summary>
        /// Beispiel für einen Integration Test einer Controller-Methode für einen GET-Request.
        /// </summary>
        /// <returns>async void = Task</returns>
        [Fact]
        public async Task GET_StorageRoom_ReturnsSuccess_And_HTML()
        {
            // Arrange
            using (var scope = _factory.Services.CreateScope())
            {
                var scopedServices = scope.ServiceProvider;
                var db = scopedServices.GetRequiredService<RoomCt>();

                DatabaseUtilities.ReinitializeDbForTests(db);
            }
            HttpClient client = _factory.CreateClient();

            // Act
            HttpResponseMessage response = await client
                .GetAsync("/StorageRoom/Index");
            // Hier der Response als string, falls du damit arbeiten möchtest.
            string jsonResult = new StreamReader(response.Content.ReadAsStream())
                .ReadToEnd();

            //TODO: Assert. Je mehr und detaillierter, desto besser.
            // Assert (Tipp: Du kannst Databaseutilities verwenden um mit dem manuellen Seeding zu vergleichen
            //         Achtung! Wenn du 2 Objekte (Dto's) vergleichst, wird nur die Speicheradresse verglichen.
            //         Finde für dieses Problem eine Lösung.
            Assert.True(true);
        }
    }
}