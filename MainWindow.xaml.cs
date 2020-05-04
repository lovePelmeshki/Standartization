using System;
using System.Collections.Generic;
using System.Windows;

namespace Standartization
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>

    public partial class MainWindow : Window
    {
        public List<Employee> db = new List<Employee>();

        public MainWindow()
        {
            InitializeComponent();
            FillData();
            middleExpTextBox.Text = MiddleExpirience().ToString();


        }
        public void FillData()
        {
            db.Add(new Employee()
            {
                SecondName = "Василий",
                BirthdayDate = DateTime.Parse("01.01.01"),
                Position = "Инженер",
                Expirience = 5,
                Education = "Высшее"
            });
            db.Add(new Employee()
            {
                SecondName = "Анатоле",
                BirthdayDate = DateTime.Parse("01.01.01"),
                Position = "Рабочий",
                Expirience = 100,
                Education = "Среднее"
            });
            _dataGrid.ItemsSource = db;

        }


        public double MiddleExpirience()
        {
            double result =0;
            foreach (var e in db)
            {
                result += e.Expirience;
            }
            result /= db.Count;
            return result;
        }
        private void MainAddButton_Click(object sender, RoutedEventArgs e)
        {
            AddUserWindow addUserWindow = new AddUserWindow();
            addUserWindow.ShowDialog();
        }

        private void button_Click(object sender, RoutedEventArgs e)
        {
            _dataGrid.ItemsSource = null;
            _dataGrid.ItemsSource = db;
        }

        private void Window_Activated(object sender, EventArgs e)
        {

        }
    }
}
