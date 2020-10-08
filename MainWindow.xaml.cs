using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace HRIS_KIT506
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private const string STAFF_LIST_KEY = "StaffList";
        private const string UNIT_LIST_KEY = "UnitList";
        private StaffController StaffController;
        private UnitController UnitController;
        public MainWindow()
        {
            InitializeComponent();
            StaffController = (StaffController)(Application.Current.FindResource(STAFF_LIST_KEY) as ObjectDataProvider).ObjectInstance;
            UnitController = (UnitController)(Application.Current.FindResource(UNIT_LIST_KEY) as ObjectDataProvider).ObjectInstance;
        }

        private void unitListBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (e.AddedItems.Count > 0)
            {
                unitDetailsPanel.DataContext = e.AddedItems[0];
            }
        }

        private void staffListBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (e.AddedItems.Count > 0)
            {
                staffDetailsPanel.DataContext = e.AddedItems[0];
            }
        }

        private void TabControl_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }

        private void staffComboBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            //The if prevents taking any action when the *first* item is selected, which is done on start up.
            if (e.RemovedItems.Count > 0)
            {
                MessageBox.Show("Dropdown list used to select: " + e.AddedItems[0]);
            }
            //Consider assigning genders to the Employee objects populated from the HRIS database (which do not have a gender),
            //then use code similar to that in MainWindow to gain access to the Boss object and request that it filter
            //the list by the selected Gender.
        }
    }
}
