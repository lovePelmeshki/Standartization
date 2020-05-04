using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Runtime.CompilerServices;
using System.Data.Entity;

namespace Standartization
{
    public class Employee : INotifyPropertyChanged
    {
        private string _secondName;
        private DateTime _birthdayDate;
        private string _position;
        private double _expirience;
        private string _education;
        public string SecondName
        {
            get => _secondName;
            set
            {
                _secondName = value;
                OnPropertyChanged("SecondName");
            }
        }



        public DateTime BirthdayDate
        {
            get => _birthdayDate;
            set
            {
                _birthdayDate = value;
                OnPropertyChanged("BirthdayDate");
            }
        }
        public string Position
        {
            get => _position;
            set
            {
                _position = value;
                OnPropertyChanged("Position");
            }
        }
        public double Expirience
        {
            get => _expirience;
            set
            {
                _expirience = value;
                OnPropertyChanged("Expirience");
            }
        }
        public string Education
        {
            get => _education;
            set
            {
                _education = value;
                OnPropertyChanged("Education");
            }
        }

        public event PropertyChangedEventHandler PropertyChanged;
        private void OnPropertyChanged([CallerMemberName]string prop = "")
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(prop));
        }
    }


}
