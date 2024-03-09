using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Spg.Fachtheorie.Domain.Model
{
    public class DividerBox
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int NumberOfDeviders { get; set; }
        public List<DividerBoxLocation> DividerBoxLocations { get; set; } = new();
    }
}
