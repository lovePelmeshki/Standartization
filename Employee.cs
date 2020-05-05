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
    public class Employee 
    {
        private string _secondName;
        private string _birthdayDate;
        private string _position;
        private double _expirience;
        private string _education;
        public string SecondName
        {
            get => _secondName;
            set
            {
                _secondName = value;
            }
        }

        public string BirthdayDate
        {
            get => _birthdayDate;
            set
            {
                _birthdayDate = value;
            }
        }
        public string Position
        {
            get => _position;
            set
            {
                _position = value;
            }
        }
        public double Expirience
        {
            get => _expirience;
            set
            {
                    _expirience = value;  
            }
        }
        public string Education
        {
            get => _education;
            set
            {
                _education = value;
            }
        }
    }
}
