using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Spg.Fachtheorie.Domain.Model
{
    public class DividerBoxLocation
    {
        public int Id { get; set; }
        public DateTime From { get; set; }
        public DateTime Until { get; set; }
        public string ByWhoom { get; set; }
        public string Notes { get; set; }
        public StorageRoom StorageRoomNavigation { get; set; } = default!;
        public DividerBox DividerBoxNavigation { get; set; } = default!;
    }
}
