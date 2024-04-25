using Spg.Fachtheorie.Domain.DTOss;
using Spg.Fachtheorie.Domain.Model;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory.Database;

namespace Spg.Fachtheorie.Domain.Services
{

    public record StorageRoomReturnDto(int Id, string building, string floor, string roomNumber);

    //TODO: Tennung mittels Interface. Diese sind im dafür vorbereiteten Namespace (in diesem Projekt) zu implementieren.
    //TODO: Trennung in Read/Write-Interfaces
    public class StorageRoomService
    {
        //TODO: DBContext mittels DependencyInjection aktivieren
        private readonly RoomCt _db;

        public StorageRoomService(RoomCt db)
        {
            _db = db;
        }

        //TODO: Ergänze gegebenenfalls notwendige Parameter UND korrigiere den Rückgabetyp
        public List<StorageRoomReturnDto> GetAll()
        {
            return _db.StorageRooms.Select(a => new StorageRoomReturnDto(a.Id, a.Building, a.Floor, a.RoomNumber)).ToList();

        }

        public StorageRoomReturnDto GetSingle(int Id)
        {
            //TODO: Implemnentierung lt. Angabe
            return _db.StorageRooms.Where(a => a.Id == Id).Select(a => new StorageRoomReturnDto(a.Id, a.Building, a.Floor, a.RoomNumber)).FirstOrDefault();
        }

        //TODO: Ergänze gegebenenfalls notwendige Parameter
        public StorageRoomReturnDto Create(StorageRoomCreateDto dto)
        {
            if (dto.building == null || dto.floor == null || dto.roomNumber == null) return null; 


            StorageRoom storageRoom = new StorageRoom()
            {
                Building = dto.building,
                Floor = dto.floor,
                RoomNumber = dto.roomNumber
            };
      
            _db.StorageRooms.Add(storageRoom);
            _db.SaveChanges();
            return GetSingle(storageRoom.Id);


        }

        //TODO: Ergänze gegebenenfalls notwendige Parameter
        public void Delete(int Id)
        {
            var a = _db.StorageRooms.FirstOrDefault(a => a.Id == Id);

            if (a == null) throw new ArgumentException();

            _db.StorageRooms.Remove(a);
            _db.SaveChanges();

        }
    }
}



