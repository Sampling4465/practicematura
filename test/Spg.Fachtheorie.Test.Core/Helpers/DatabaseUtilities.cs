using Spg.Fachtheorie.Domain.Model;

namespace Spg.Fachtheorie.Test.Core
{
    public static class DatabaseUtilities 
    {
        public static void ReinitializeDbForTests(RoomCt db)
        {
            db.Database.EnsureDeleted();
            db.Database.EnsureCreated();
            InitializeDatabase(db);
        }

        //TODO: Achtung, diese Methode muss gegebenenfalls angepasst werden. Bitte überprüfe den Inhalt.
        public static void InitializeDatabase(RoomCt db)
        {
            db.StorageRooms.AddRange(GetSeedingStorageRoom());
            db.SaveChanges();

            db.DividerBoxes.AddRange(GetSeedingDividerBox());
            db.SaveChanges();

            //TODO: DividerBoxLocations in die Datenbank seeden
            db.DividerBoxLocations.AddRange(GetSeedingDividerBoxLocation(db.StorageRooms.Single(s => s.Id == 1), db.DividerBoxes.Single(s => s.Id == 1)));
            db.DividerBoxLocations.AddRange(GetSeedingDividerBoxLocation(db.StorageRooms.Single(s => s.Id == 2), db.DividerBoxes.Single(s => s.Id == 2)));
            db.DividerBoxLocations.AddRange(GetSeedingDividerBoxLocation(db.StorageRooms.Single(s => s.Id == 3), db.DividerBoxes.Single(s => s.Id == 3)));
            db.SaveChanges();
        }

        private static List<StorageRoom> GetSeedingStorageRoom()
        {
            return new List<StorageRoom>()
            {
                //TODO: StorageRoom's für die UnitTests hier seeden.
                //new StorageRoom() ...,

                new StorageRoom(){ Floor="Floor1", RoomNumber="123-1", Building="A" },
                new StorageRoom(){ Floor="Floor2", RoomNumber="123-2", Building="B" },
                new StorageRoom(){ Floor="Floor3", RoomNumber="123-3", Building="C" },
            };
        }

        private static List<DividerBox> GetSeedingDividerBox()
        {
            return new List<DividerBox>()
            {
                //TODO: DividerBox's für die UnitTests hier seeden.
                //new DividerBox() ...,

                new DividerBox() { Name="Name1", NumberOfDeviders=122 },
                new DividerBox() { Name="Name2", NumberOfDeviders=123 },
                new DividerBox() { Name="Name3", NumberOfDeviders=124 },
                new DividerBox() { Name="Name4", NumberOfDeviders=125 },
            };
        }

        private static List<DividerBoxLocation> GetSeedingDividerBoxLocation(StorageRoom storageRoom, DividerBox dividerBox)
        {
            return new List<DividerBoxLocation>()
            {
                //TODO: DividerBoxLocation's für die UnitTests hier seeden. Du benötigst hier MINDESTENS 2.
                //new DividerBoxLocation() ...,

                new DividerBoxLocation(){ Notes="Notes 1", ByWhoom="User1", From=new DateTime(2023, 01, 01), Until=new DateTime(2023, 01, 01), StorageRoomNavigation=storageRoom, DividerBoxNavigation=dividerBox },
                new DividerBoxLocation(){ Notes="Notes 2", ByWhoom="User2", From=new DateTime(2023, 01, 01), Until=new DateTime(2023, 01, 01), StorageRoomNavigation=storageRoom, DividerBoxNavigation=dividerBox },
                new DividerBoxLocation(){ Notes="Notes 3", ByWhoom="User3", From=new DateTime(2023, 01, 01), Until=new DateTime(2023, 01, 01), StorageRoomNavigation=storageRoom, DividerBoxNavigation=dividerBox },
                new DividerBoxLocation(){ Notes="Notes 4", ByWhoom="User4", From=new DateTime(2023, 01, 01), Until=new DateTime(2023, 01, 01), StorageRoomNavigation=storageRoom, DividerBoxNavigation=dividerBox },
            };
        }
    }
} 
