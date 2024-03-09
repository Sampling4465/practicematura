using Microsoft.Data.Sqlite;
using Microsoft.EntityFrameworkCore;
using Spg.Fachtheorie.Aufgabe1.Infrastructure;
using Spg.Fachtheorie.Aufgabe1.Model;

namespace Spg.Fachtheorie.Aufgabe1.Test.Helpers
{
    public static class DatabaseUtilities 
    {
        public static InnoLabContext GetDatabase()
        {
            return new InnoLabContext(GetDbOptions());
        }

        /// <summary>
        /// Es wird eine SQLite-InMemory-Datenbank f�r die UnitTests verwendet.
        /// </summary>
        /// <returns></returns>
        public static DbContextOptions GetDbOptions()
        {
            SqliteConnection connection = new SqliteConnection("Data Source=:memory:");
            connection.Open();

            return new DbContextOptionsBuilder()
                .UseSqlite(connection)
                .Options;
        }

        //TODO: Achtung, diese Methode muss angepasst werden.
        public static void InitializeDatabase(InnoLabContext db)
        {
            db.Database.EnsureCreated();

            //TODO: Seeding f�r alle Entities...
            //db.InnolabUsers.AddRange(GetSeedingInnolabUsers());
            db.SaveChanges();

            //TODO: Seeding f�r alle Entities...
        }

        private static List<InnolabUser> GetSeedingInnolabUsers()
        {
            return new List<InnolabUser>()
            {
                //TODO: InnolabUser's f�r die UnitTests hier seeden.
                //new InnolabUser() ...,
            };
        }
    }
}
