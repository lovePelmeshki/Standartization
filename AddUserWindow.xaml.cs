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
        Employee employee;
        public AddUserWindow()
        {
            InitializeComponent();
            employee = new Employee();
            this.DataContext = employee;

            DatePicker_Birthday.DisplayDateStart = new DateTime(1920, 1, 1); 
            DatePicker_Birthday.DisplayDateEnd =  DateTime.Now.AddYears(-18);
        }

        private void AddButton_Click(object sender, RoutedEventArgs e)
        {
            MainWindow mainWindow = (MainWindow)Application.Current.MainWindow;
            List<Employee> db = mainWindow.db;
            db.Add(new Employee
            {
                SecondName = TextBox_SecondName.Text,
                BirthdayDate = DateTime.Parse(DatePicker_Birthday.Text).ToShortDateString(),
                Position = ComboBox_Position.Text,
                Expirience = Double.Parse(TextBox_Expirience.Text),
                Education = ComboBox_Education.Text
            }) ;
            mainWindow.db = db;
            mainWindow._dataGrid.ItemsSource = null;
            mainWindow._dataGrid.ItemsSource = mainWindow.db;
            Close();

            
        }

        private void TextBox_Expirience_Error(object sender, ValidationErrorEventArgs e)
        {
            if (e.Action == ValidationErrorEventAction.Added)
                MessageBox.Show(e.Error.ErrorContent.ToString());
        }



        private void TextBox_SecondName_TextInput(object sender, TextCompositionEventArgs e)
        {
            char inp = e.Text[0];
            if (inp < 'А' || inp > 'Я')
                e.Handled = true;
        }

        private void TextBox_SecondName_KeyDown(object sender, KeyEventArgs e)
        {
            MessageBox.Show(e.Key.ToString());
        }
    }
}
