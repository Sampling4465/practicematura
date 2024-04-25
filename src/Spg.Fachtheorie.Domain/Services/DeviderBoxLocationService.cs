using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Internal;
using Spg.Fachtheorie.Domain.DTOs;
using Spg.Fachtheorie.Domain.DTOss;
using Spg.Fachtheorie.Domain.Model;

namespace Spg.Fachtheorie.Domain.Services;

public class CreateDividerBoxLocationDto
{
    public DateTime from { get; set; }
    public DateTime? to { get; set; }
    public string byWhom { get; set; }
    public string notes { get; set; }
    public int DividerBoxId { get; set; }
    public int? StorageRoomId { get; set; }

}
public record DividerBoxLocationDto(int Id, DateTime from, DateTime? to, string byWhom, string notes, int DividerBoxId, int StorageRoomId);



// TODO: Tennung mittels Interface. Diese sind im dafür vorbereiteten Namespace (in diesem Projekt) zu implementieren.
// TODO: Trennung in Read/Write-Interfaces
public class DeviderBoxLocationService
{
    private readonly RoomCt _db;

    public DeviderBoxLocationService(RoomCt db)
    {
        _db = db;
    }
    public List<DividerBoxLocationDto> GetAll()
    {
        return _db.DividerBoxLocations.Select(a => new DividerBoxLocationDto(a.Id, a.From, a.Until, a.ByWhoom, a.Notes, a.DividerBoxNavigation.Id, a.StorageRoomNavigation.Id)).ToList();

    }
    public DividerBoxLocationDto GetSingle(int Id)
    {
        return _db.DividerBoxLocations.Where(a => a.Id == Id).Select(a => new DividerBoxLocationDto(a.Id, a.From, a.Until, a.ByWhoom, a.Notes, a.DividerBoxNavigation.Id, a.StorageRoomNavigation.Id)).FirstOrDefault();
    }


    public DividerBoxLocationDto Create(CreateDividerBoxLocationDto dto)
    {
        if (_db.DividerBoxes.FirstOrDefault(a => a.Id == dto.DividerBoxId) == null || string.IsNullOrEmpty(dto.byWhom) || dto.from == null)
        {
            return null;
        }

        var overlay = _db.DividerBoxLocations.FirstOrDefault(a => a.From == dto.from && a.DividerBoxNavigation.Id == dto.DividerBoxId);
        if (overlay != null)
        {
            dto.from = overlay.Until;
            dto.to = dto.from.AddDays(1);
        }

        DividerBox d;
        StorageRoom sr = _db.StorageRooms.First(); // otherwise error it is not nullable 


        if (dto.StorageRoomId != null)
        {
            sr = _db.StorageRooms.FirstOrDefault(a => a.Id == dto.StorageRoomId);
        }
        d = _db.DividerBoxes.FirstOrDefault(a => a.Id == dto.DividerBoxId);

        var value = new DividerBoxLocation() { From = dto.from, Until = dto.to ?? dto.from.AddDays(1), Notes = "", ByWhoom = dto.byWhom, StorageRoomNavigation = sr, DividerBoxNavigation = d };



        _db.Add(value);
        _db.SaveChanges();
        return GetSingle(value.Id);
    }


    //TODO: Ergänze gegebenenfalls notwendige Parameter
    public void Delete(int Id)
    {
        var a = _db.DividerBoxLocations.FirstOrDefault(a => a.Id == Id);

        if (a == null) throw new ArgumentException();

        _db.DividerBoxLocations.Remove(a);
        _db.SaveChanges();

    }
}


