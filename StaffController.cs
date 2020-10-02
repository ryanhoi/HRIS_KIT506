using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HRIS_KIT506
{

    class StaffController
    {
        //The example shown here follows the pattern discussed in the Module 7 summary slides,
        //maintaining two collections, a master and a 'viewable' one (which is the 'view model'
        //in Microsoft's Model-View-ViewModel approach to Model-View-Controller)
        private List<Staff> Staff;
        public List<Staff> Workers { get { return Staff; } set { } }

        private ObservableCollection<Staff> ViewableStaff;
        public ObservableCollection<Staff> VisibleWorkers { get { return ViewableStaff; } set { } }
        public StaffController()
        {
            Staff = DbAdapter.LoadAllStaff();
            ViewableStaff = new ObservableCollection<Staff>(Staff);

            foreach (Staff e in Staff)
            {
                e.WorkTimes = DbAdapter.LoadConsultationItems(e.ID);
                e.Class = DbAdapter.LoadStaffClasses(e.ID);
            }
        }
        public ObservableCollection<Staff> GetViewableList()
        {
            return VisibleWorkers;
        }
    }
}
