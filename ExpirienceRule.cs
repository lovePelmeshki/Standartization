using System.Globalization;
using System.Windows.Controls;

namespace Standartization
{
    public class ExpirienceRule : ValidationRule
    {
        private double _min = 0;
        private double _max = 100;
        public double Min
        {
            get => _min;
            set => _min = value;
        }
        public double Max
        {
            get => _max;
            set => _max = value;
        }
        public override ValidationResult Validate(object value, CultureInfo cultureInfo)
        {
            double expirience = 0;
            try
            {
                expirience = double.Parse((string)value);
            }
            catch
            {
                return new ValidationResult(false, "Поле \"Стаж работы\" может содержать только числа");
            }
            if ((expirience < Min) || (expirience > Max))
            {
                return new ValidationResult(false, $"Опыт не входит в диапазон от {Min} до {Max}");
            } else
            return new ValidationResult(true, null);
        }
    }
}
