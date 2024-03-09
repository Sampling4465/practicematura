using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Spg.Fachtheorie.Domain.Model
{
    public class RoomCt : DbContext
    {
        public DbSet<StorageRoom> StorageRooms => Set<StorageRoom>();
        public DbSet<DividerBoxLocation> DividerBoxLocations => Set<DividerBoxLocation>();
        public DbSet<DividerBox> DividerBoxes => Set<DividerBox>();

        public RoomCt()
        { }

        public RoomCt(DbContextOptions options)
            : base(options)
        { }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {

        }

        public void Seed()
        {
            StorageRooms.AddRange(GetSeedingStorageRoom());
            SaveChanges();
            DividerBoxes.AddRange(GetSeedingDividerBox());
            SaveChanges();
            DividerBoxLocations.AddRange(GetSeedingDividerBoxLocation(StorageRooms.Single(s => s.Id == 1), DividerBoxes.Single(s => s.Id == 1)));
            DividerBoxLocations.AddRange(GetSeedingDividerBoxLocation(StorageRooms.Single(s => s.Id == 2), DividerBoxes.Single(s => s.Id == 2)));
            DividerBoxLocations.AddRange(GetSeedingDividerBoxLocation(StorageRooms.Single(s => s.Id == 3), DividerBoxes.Single(s => s.Id == 3)));
            SaveChanges();
        }

        private static List<StorageRoom> GetSeedingStorageRoom()
        {
            return new List<StorageRoom>()
            {
                new StorageRoom(){ Floor="Floor1", RoomNumber="123-1", Building="A" },
                new StorageRoom(){ Floor="Floor2", RoomNumber="123-2", Building="B" },
                new StorageRoom(){ Floor="Floor3", RoomNumber="123-3", Building="C" },
            };
        }

        private List<DividerBox> GetSeedingDividerBox()
        {
            return new List<DividerBox>()
            {
                new DividerBox() { Name="Name1", NumberOfDeviders=122 },
                new DividerBox() { Name="Name2", NumberOfDeviders=123 },
                new DividerBox() { Name="Name3", NumberOfDeviders=124 },
                new DividerBox() { Name="Name4", NumberOfDeviders=125 },
            };
        }

        private List<DividerBoxLocation> GetSeedingDividerBoxLocation(StorageRoom storageRoom, DividerBox dividerBox)
        {
            return new List<DividerBoxLocation>()
            {
                new DividerBoxLocation(){ Notes="Notes 1", ByWhoom="User1", From=new DateTime(2023, 01, 01), Until=new DateTime(2023, 01, 01), StorageRoomNavigation=storageRoom, DividerBoxNavigation=dividerBox },
                new DividerBoxLocation(){ Notes="Notes 2", ByWhoom="User2", From=new DateTime(2023, 01, 01), Until=new DateTime(2023, 01, 01), StorageRoomNavigation=storageRoom, DividerBoxNavigation=dividerBox },
                new DividerBoxLocation(){ Notes="Notes 3", ByWhoom="User3", From=new DateTime(2023, 01, 01), Until=new DateTime(2023, 01, 01), StorageRoomNavigation=storageRoom, DividerBoxNavigation=dividerBox },
                new DividerBoxLocation(){ Notes="Notes 4", ByWhoom="User4", From=new DateTime(2023, 01, 01), Until=new DateTime(2023, 01, 01), StorageRoomNavigation=storageRoom, DividerBoxNavigation=dividerBox },
            };
        }
    }
}