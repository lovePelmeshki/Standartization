using System;
using System.Collections.Generic;
using System.Data.Entity;
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

namespace Standartization
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            FillData();

    }
    public void FillData()
    {
            DataContext db = new DataContext();
            db.Employees.Add(new Employee()
            {
                 SecondName = "Василий",
                 BirthdayDate = DateTime.Parse("01.01.01"),
                 Position = "Инженер",
                 Expirience = 5,
                 Education = "Высшее"
            });
            db.Employees.Add(new Employee()
            {
                SecondName = "Анатоле",
                BirthdayDate = DateTime.Parse("01.01.01"),
                Position = "Рабочий",
                Expirience = 100,
                Education = "Среднее"
            });
            db.SaveChanges();
            _dataGrid.ItemsSource = db.Employees.ToList();
        }



        private void MainAddButton_Click(object sender, RoutedEventArgs e)
        {
            AddUserWindow addUserWindow = new AddUserWindow();
            addUserWindow.ShowDialog();
        }
    }
}
