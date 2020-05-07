using System;
using System.Collections.Generic;
using System.Windows;
using System.Linq;

namespace Standartization
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>

    public partial class MainWindow : Window
    {
        public List<Employee> employees = new List<Employee>();

        public MainWindow()
        {
            InitializeComponent();
            FillData();
            middleExpTextBox.Text = MiddleExpirience(employees).ToString();
        }
        //заполнение таблицы начальными данными
        public void FillData()
        {
            employees.Add(new Employee()
            {
                SecondName = "Иванов",
                BirthdayDate = DateTime.Parse("02.11.01").ToShortDateString(),
                Position = "Инженер",
                Expirience = 5,
                Education = "Высшее"
            });
            employees.Add(new Employee()
            {
                SecondName = "Петров",
                BirthdayDate = DateTime.Parse("01.02.98").ToShortDateString(),
                Position = "Мастер",
                Expirience = 3,
                Education = "Высшее"
            });
            employees.Add(new Employee()
            {
                SecondName = "Сидоров",
                BirthdayDate = DateTime.Parse("18.02.90").ToShortDateString(),
                Position = "Рабочий",
                Expirience = 8,
                Education = "Среднее специальное"
            });
            employees.Add(new Employee()
            {
                SecondName = "Толстой",
                BirthdayDate = DateTime.Parse("13.05.71").ToShortDateString(),
                Position = "Мастер",
                Expirience = 12,
                Education = "Высшее"
            });
            employees.Add(new Employee()
            {
                SecondName = "Путин",
                BirthdayDate = DateTime.Parse("28.12.00").ToShortDateString(),
                Position = "Рабочий",
                Expirience = 30,
                Education = "Среднее"
            });
            employees.Add(new Employee()
            {
                SecondName = "Гоголь",
                BirthdayDate = DateTime.Parse("18.02.90").ToShortDateString(),
                Position = "Рабочий",
                Expirience = 5,
                Education = "Среднее"
            });
            employees.Add(new Employee()
            {
                SecondName = "Моголь",
                BirthdayDate = DateTime.Parse("13.05.71").ToShortDateString(),
                Position = "Инженер",
                Expirience = 3,
                Education = "Высшее"
            });
            employees.Add(new Employee()
            {
                SecondName = "Ли",
                BirthdayDate = DateTime.Parse("28.12.00").ToShortDateString(),
                Position = "Мастер",
                Expirience = 8,
                Education = "Высшее"
            });
            _dataGrid.ItemsSource = employees;

        }

        // Функция вычисления среднего опыта работы
        public double MiddleExpirience(List<Employee> data) 
        {
            double result =0;
            foreach (var e in data)
            {
                result += e.Expirience;
            }
            result /= data.Count;
            return result;
        }
        //обработка события на нажатие кнопки Добавить
        private void MainAddButton_Click(object sender, RoutedEventArgs e)
        {
            AddUserWindow addUserWindow = new AddUserWindow();
            addUserWindow.ShowDialog();
        }

        //обработка события на нажатие кнопки Refresh
        private void button_Click(object sender, RoutedEventArgs e)
        {
            _dataGrid.ItemsSource = null;
            _dataGrid.ItemsSource = employees;
            middleExpTextBox.Text = MiddleExpirience(employees.ToList()).ToString();
            EducationComboBox.Text = "";
            PositionComboBox.Text = "";
        }

        //обработка события закрытие EducationComboBox
        private void EducationComboBox_DropDownClosed(object sender, EventArgs e)
        {

            if (string.IsNullOrWhiteSpace(PositionComboBox.Text))
            {
                var emp = from c in employees
                          where (c.Education == EducationComboBox.Text)
                          select c;
                _dataGrid.ItemsSource = null;
                _dataGrid.ItemsSource = emp;
                middleExpTextBox.Text = MiddleExpirience(emp.ToList()).ToString();
            }
            else
            {
                var emp = from c in employees
                          where (c.Education == EducationComboBox.Text) && (c.Position == PositionComboBox.Text)
                          select c;
                _dataGrid.ItemsSource = null;
                _dataGrid.ItemsSource = emp;
                middleExpTextBox.Text = MiddleExpirience(emp.ToList()).ToString();
            }

        }

        //обработка события закрытие PositionComboBox
        private void PositionComboBox_DropDownClosed(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(EducationComboBox.Text))
            {
                var emp = from c in employees
                          where (c.Position == PositionComboBox.Text)
                          select c;
                _dataGrid.ItemsSource = null;
                _dataGrid.ItemsSource = emp;
                middleExpTextBox.Text = MiddleExpirience(emp.ToList()).ToString();
            }
            else
            {
                var emp = from c in employees
                          where (c.Education == EducationComboBox.Text) && (c.Position == PositionComboBox.Text)
                          select c;
                _dataGrid.ItemsSource = null;
                _dataGrid.ItemsSource = emp;
                middleExpTextBox.Text = MiddleExpirience(emp.ToList()).ToString();
            }



        }
    }
}
