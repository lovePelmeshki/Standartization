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
using System.Windows.Shapes;
using Standartization;

namespace Standartization
{
    /// <summary>
    /// Interaction logic for AddUserWindow.xaml
    /// </summary>
    public partial class AddUserWindow : Window
    {
        public AddUserWindow()
        {
            InitializeComponent();
        }

        private void AddButton_Click(object sender, RoutedEventArgs e)
        {
            MainWindow mainWindow = (MainWindow)Application.Current.MainWindow;
            List<Employee> db = mainWindow.db;
            db.Add(new Employee
            {
                SecondName = TextBox_SecondName.Text,
                BirthdayDate = (DateTime)DatePicker_Birthday.SelectedDate,
                Position = ComboBox_Position.Text,
                Expirience = Double.Parse(TextBox_Expirience.Text),
                Education = ComboBox_Education.Text
            }) ;
            mainWindow.db = db;
            mainWindow._dataGrid.ItemsSource = null;
            mainWindow._dataGrid.ItemsSource = mainWindow.db;
            
        }
    }
}
