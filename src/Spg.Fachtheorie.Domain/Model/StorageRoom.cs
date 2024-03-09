using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Spg.Fachtheorie.Domain.Model
{
    public class StorageRoom
    {
        public int Id { get; set; }
        public string Building { get; set; }
        public string Floor { get; set; }
        public string RoomNumber { get; set; }
        public List<DividerBoxLocation> DividerBoxLocations { get; set; } = new();
    }
}
