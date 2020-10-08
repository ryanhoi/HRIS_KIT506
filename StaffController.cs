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
        private List<Staff> StaffMasterList;
        public List<Staff> Workers { get { return StaffMasterList; } set { } }

        private ObservableCollection<Staff> ViewableStaff;
        public ObservableCollection<Staff> VisibleWorkers { get { return ViewableStaff; } set { } }
        public StaffController()
        {
            StaffMasterList = DbAdapter.LoadAllStaff();
            ViewableStaff = new ObservableCollection<Staff>(StaffMasterList);

            foreach (Staff e in StaffMasterList)
            {
                e.WorkTime = DbAdapter.LoadConsultationItems(e.ID);
                e.Class = DbAdapter.LoadStaffClasses(e.ID);
            }
        }
        public ObservableCollection<Staff> GetViewableList()
        {
            return VisibleWorkers;
        }

        public void Filter(Category category)
        {
            var selected = from Staff e in StaffMasterList
                           where category == Category.Any || e.Category == category
                           select e;
            ViewableStaff.Clear();
            //Converts the result of the LINQ expression to a List and then calls viewableStaff.Add with each element of that list in turn
            selected.ToList().ForEach( ViewableStaff.Add);
        }
    }
}
