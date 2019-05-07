using APBD_TEST1.DAL;
using APBD_TEST1.Models;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
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

namespace APBD_TEST1
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private EFdbConn context;
        public MainWindow()
        {
            InitializeComponent();
            context = new EFdbConn();
            LoadEmps();
        }
        private void LoadEmps()
        {
            var source = new ObservableCollection<EMP>();
            foreach(EMP em in context.GetEMPs())
            {
                source.Add(em);
            }
            EMPGrid.ItemsSource = source;
        }

        private void SearchBtn_Click(object sender, RoutedEventArgs e)
        {
            var input = SearchTxtBox.Text;
            if (!string.IsNullOrWhiteSpace(input))
            {
                var result = EMPGrid.ItemsSource as ObservableCollection<EMP>;
                EMPGrid.ItemsSource = result.Where(emp => emp.ENAME == input);
            }
        }
        private bool ValidateInput(string input)
        {
            if (string.IsNullOrWhiteSpace(input)) return false;
            if (input.Any(c => char.IsDigit(c))) return false;
            return true;
        }

        private void AddBtn_Click(object sender, RoutedEventArgs e)
        {
            var name = EnameTxtBox.Text;
            var job = JobTxtBox.Text;
            var dname = DnameTxtBox.Text;

            if(ValidateInput(name) && ValidateInput(job) && ValidateInput(dname))
            {
                var emp = new EMP { ENAME = name, JOB = job };
                context.AddEmpToDB(emp);

            }
            else
            {
                MessageBox.Show("Nieprawidłowe dane");
            }

        }

        private void ShowAllBtn_Click(object sender, RoutedEventArgs e)
        {
            LoadEmps();
        }
    }
}
