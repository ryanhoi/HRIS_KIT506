using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HRIS_KIT506
{
    public enum Campus { Launceston, Hobart};
    public class staff
    {
        public int ID { get; set; }
        public string Title { get; set; }
        public string Name { get; set; }
        public Campus Campus { get; set; }
        public string Phone { get; set; }
        public string Room { get; set; }
        public string Email { get; set; }
        public List<Roster> WorkTimes { get; set; }
        public List<Class> Classes { get; set; }
    }
}
