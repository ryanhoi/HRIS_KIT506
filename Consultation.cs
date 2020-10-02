using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HRIS_KIT506
{
    enum Day {Monday,Tuesday,Wednesday,Thursday,Friday,Saturday,Sunday };
    class Consultation
    {
        public int StaffID { get; set; }
        public Day day { get; set; }
        public TimeSpan start { get; set; }
        public TimeSpan end { get;set }

    }
}
