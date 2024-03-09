using Spg.Fachtheorie.Domain.Model;

namespace Spg.Fachtheorie.Domain.Services
{
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
        public List<object> GetAll()
        {
            //TODO: Implemnentierung lt. Angabe
            throw new NotImplementedException();
        }

        //TODO: Ergänze gegebenenfalls notwendige Parameter
        public StorageRoom GetSingle()
        {
            //TODO: Implemnentierung lt. Angabe
            throw new NotImplementedException();
        }

        //TODO: Ergänze gegebenenfalls notwendige Parameter
        public void Create()
        {
            //TODO: Implemnentierung lt. Angabe
            throw new NotImplementedException();
        }

        //TODO: Ergänze gegebenenfalls notwendige Parameter
        public void Delete()
        {
            //TODO: Implemnentierung lt. Angabe
            throw new NotImplementedException();
        }
    }
}
