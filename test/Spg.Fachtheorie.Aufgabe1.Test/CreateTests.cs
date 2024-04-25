using System.Runtime.InteropServices.ComTypes;
using Microsoft.EntityFrameworkCore;
using Bogus;
using Microsoft.EntityFrameworkCore.Storage;
using Microsoft.Data.Sqlite;
using Microsoft.EntityFrameworkCore.Sqlite;
using Microsoft.EntityFrameworkCore.InMemory;
using Spg.Fachtheorie.Aufgabe1.Infrastructure;
using Spg.Fachtheorie.Aufgabe1.Test.Helpers;
using Spg.Fachtheorie.Aufgabe1.Repositories;
using Spg.Fachtheorie.Aufgabe1.Model;


namespace Spg.Fachtheorie.Aufgabe1.Test
{
    public class CreateTests
    {
        [Fact]
        public void EnsureCreated()
        {

            using (var context = DatabaseUtilities.GetDatabase())
            {
                Assert.True(context.Database.EnsureCreated());
                context.Database.EnsureDeleted();
            }
        }
        [Fact]
        public void CreateUserTest()
        {

            using (var context = DatabaseUtilities.GetDatabase())
            {
                context.Database.EnsureCreated();

                Repository<InnolabUser, int> repository = new Repository<InnolabUser, int>(context);

                var user = new InnolabUser("g.g@gmcom", "jaa", "doe");
                repository.Create(user);

                Assert.True(repository.Read(user.Id) != null);
                context.Database.EnsureDeleted();


            }

        }

        [Fact]
        public void CreateWorkplace()
        {

            using (var context = DatabaseUtilities.GetDatabase())
            {
                context.Database.EnsureCreated();

                Repository<WorkPlace, int> repository = new Repository<WorkPlace, int>(context);

                var w = new WorkPlace("D3.11");
                repository.Create(w);

                Assert.True(repository.Read(w.Id) != null);
                context.Database.EnsureDeleted();
            }

        }

        [Fact]
        public void CreateEquipment()
        {

            using (var context = DatabaseUtilities.GetDatabase())
            {
                context.Database.EnsureCreated();

                Repository<Equipment, int> repository = new Repository<Equipment, int>(context);

                var e = new Equipment("name", EquipmentTypes.SOLDERING_STATION);
                repository.Create(e);

                Assert.True(repository.Read(e.Id) != null);
                context.Database.EnsureDeleted();
            }

        }

        [Fact]
        public void CreateRoom()
        {

            using (var context = DatabaseUtilities.GetDatabase())
            {
                context.Database.EnsureCreated();

                Repository<Room, int> repository = new Repository<Room, int>(context);

                var e = new Room("name", "b", "f", "1");
                repository.Create(e);

                Assert.True(repository.Read(e.Id) != null);
                context.Database.EnsureDeleted();
            }

        }

        [Fact]
        public void CreateReservation()
        {

            using (var context = DatabaseUtilities.GetDatabase())
            {
                context.Database.EnsureCreated();

                Repository<Reservation, int> repository = new Repository<Reservation, int>(context);

                var e = new Reservation(new InnolabUser("email", "name", "name"), DateTime.Now, DateTime.MaxValue);

                var a = new ReservationItem();
                a.Reservation = e;
                a.Reservable = new WorkPlace("hane");

                e.Items.Add(a);
                repository.Create(e);

                Assert.True(repository.Read(e.Id) != null);
                context.Database.EnsureDeleted();
            }

        }
        [Fact]
        public void TestUnique()
        {

            using (var context = DatabaseUtilities.GetDatabase())
            {
                {
                    context.Database.EnsureCreated();

                    Repository<InnolabUser, int> repository = new Repository<InnolabUser, int>(context);

                    var user = new InnolabUser("g.g@gmcom", "jaa", "doe");
                    repository.Create(user);

                    var user2 = new InnolabUser("g.g@gmcom", "aa", "aaa");

                    Assert.Throws<DbUpdateException>(() => repository.Create(user2));

                    context.Database.EnsureDeleted();
                }

            }

        }
    }
}