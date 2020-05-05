using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;

namespace Standartization
{
    public class BirhdayDateRule : ValidationRule
    {

        private string _max = DateTime.Now.ToShortDateString();

        public string Max
        {
            get => _max;
            set => _max = value;
        }
        public override ValidationResult Validate(object value, CultureInfo cultureInfo)
        {
            string birthdayDate;
            try
            {
                birthdayDate = DateTime.Parse((string)value).ToString(); ;
            }
            catch
            {
                return new ValidationResult(false, "Неверный формат даты. Введите дату в формате (ДД.ММ.ГГГГ).");
            }
            if (DateTime.Parse(birthdayDate) > DateTime.Parse(Max))
            {
                return new ValidationResult(false, "Дата рождения должна быть раньше, чем сегодня");
            }
            else
                return new ValidationResult(true, null);
        }
    }
}
