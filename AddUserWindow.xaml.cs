using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;

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
            DataContext = employee;

            //Установка ограничения на выбор даты рождения
            DatePicker_Birthday.DisplayDateStart = new DateTime(1920, 1, 1);
            DatePicker_Birthday.DisplayDateEnd = DateTime.Now.AddYears(-18);

        }

        // Обработка события нажатия на кнопку Добавить
        private void AddButton_Click(object sender, RoutedEventArgs e)
        {
            MainWindow mainWindow = (MainWindow)Application.Current.MainWindow;
            List<Employee> employees = mainWindow.employees;
            employees.Add(new Employee
            {
                SecondName = TextBox_SecondName.Text,
                BirthdayDate = DateTime.Parse(DatePicker_Birthday.Text).ToShortDateString(),
                Position = ComboBox_Position.Text,
                Expirience = Double.Parse(TextBox_Expirience.Text),
                Education = ComboBox_Education.Text
            });
            mainWindow.employees = employees;
            mainWindow._dataGrid.ItemsSource = null;
            mainWindow._dataGrid.ItemsSource = mainWindow.employees;
            mainWindow.middleExpTextBox.Text = mainWindow.MiddleExpirience(employees.ToList()).ToString();
            Close();
        }

        // Сообщение об ошибке ввода в строку Стаж работы
        private void TextBox_Expirience_Error(object sender, ValidationErrorEventArgs e)
        {
            if (e.Action == ValidationErrorEventAction.Added)
                MessageBox.Show(e.Error.ErrorContent.ToString());
        }

        //Проверка, является ли ввод в строку Фамилия цифрой
        private void TextBox_SecondName_PreviewTextInput(object sender, TextCompositionEventArgs e)
        {
            if (Char.IsDigit(e.Text, 0))
                e.Handled = true;
        }

        private void TextBox_Expirience_PreviewTextInput(object sender, TextCompositionEventArgs e)
        {
            if (!Char.IsDigit(e.Text, 0))
                e.Handled = true;
        }
    }
}
