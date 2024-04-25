using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Spg.Fachtheorie.Aufgabe1.Model
{
    // TODO: Rich DomainModel implementieren
    public class Room : ReservableItem
    {



        [Required]
        public string Building { get; set; }
        [Required]

        public string Floor { get; set; }

        [Required]
        public string RoomNumber { get; set; }  

        private List<WorkPlace> _workPlaces;

        public IReadOnlyList<WorkPlace>  WorkPlaces => _workPlaces;

        public Room(string name,string building, string floor, string roomNumber) : base(name)
        {
            Building = building;
            Floor = floor;
            RoomNumber = roomNumber;
            _workPlaces = new List<WorkPlace>();
        }

        public void AddWorkplace(WorkPlace place)
        {
            _workPlaces.Add(place);
        }
    }
}
