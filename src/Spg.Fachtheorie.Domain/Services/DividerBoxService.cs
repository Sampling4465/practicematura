using Spg.Fachtheorie.Domain.DTOs;
using Spg.Fachtheorie.Domain.Model;




    
    
namespace Spg.Fachtheorie.Domain.Services
{
    //TODO: Tennung mittels Interface. Diese sind im dafür vorbereiteten Namespace (in diesem Projekt) zu implementieren.
    //TODO: Trennung in Read/Write-Interfaces
    public class DividerBoxService
    {
        private readonly RoomCt _db;

        public DividerBoxService(RoomCt db)
        {
            _db = db;
        }
        public List<DividerBoxDto> GetAll()
        {
            return _db.DividerBoxes.Select(a=> new DividerBoxDto(a.Id,a.Name,a.NumberOfDeviders)).ToList();
        }

        public DividerBoxDto GetSingle(int Id)
        {
            return _db.DividerBoxes.Where(a => a.Id == Id).Select(a => new DividerBoxDto(a.Id, a.Name, a.NumberOfDeviders)).FirstOrDefault();
        }
        //TODO: Ergänze gegebenenfalls notwendige Parameter
        public DividerBoxDto Create(DividerBoxPostDto dto)
        {
            if (string.IsNullOrEmpty(dto.Name) || dto.NumberOfDeviders < 0) return null;

            var s = new DividerBox() {Name= dto.Name, NumberOfDeviders  = dto.NumberOfDeviders };

            var a = _db.DividerBoxes.Add(s);
            _db.SaveChanges();

            return GetSingle(s.Id);

        }

        public void Delete(int Id)
        {
            var a = _db.DividerBoxes.FirstOrDefault(a => a.Id == Id);

            if (a == null) throw new ArgumentException();

            _db.DividerBoxes.Remove(a);
            _db.SaveChanges();
        }
    }
}
