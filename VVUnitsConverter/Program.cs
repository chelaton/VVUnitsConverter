using System;
using System.Globalization;
using System.Text.RegularExpressions;
using UnitConvertor;

namespace TestConverter
{
    class Program
    {
        static void Main()
        {
            string result;
            string numberString, fromUnit, toUnit;
            decimal number;
            string fromUnitValue;
            string toUnitValue;

            bool numberStringIsNotOk = true;
            do
            {
                Console.WriteLine("Enter quantity to convert: ");
                numberString = Console.ReadLine();
                numberStringIsNotOk = ValidationNumber(numberString, out number);

            } while (numberStringIsNotOk);

            bool fromUnitIsNotKnown = true;
            do
            {
                Console.WriteLine("Enter conversion unit to convert: ");
                fromUnit = Console.ReadLine();
                fromUnitIsNotKnown = UnitsFactory.IsNotKnownUnit(fromUnit, out fromUnitValue);
                Console.WriteLine();
            } while (fromUnitIsNotKnown);

            bool toUnitIsNotKnown = true;
            do
            {
                Console.WriteLine("Enter conversion unit to: ");
                toUnit = Console.ReadLine();
                toUnitIsNotKnown = UnitsFactory.IsNotKnownUnit(toUnit, out toUnitValue);
                Console.WriteLine();
            } while (toUnitIsNotKnown);


            result = UnitsFactory.Convertor(number, fromUnitValue, toUnitValue);

            Console.WriteLine(number.ToString() + " " + fromUnitValue + " = " + result + " " + toUnitValue);

            Console.ReadLine();
        }

        private static bool ValidationNumber(string numberString, out decimal number)
        {
            var style = NumberStyles.Number;
            var cultureInfo = CultureInfo.InvariantCulture;
            var numberStringIsNotOk = true;
            if (Regex.IsMatch(numberString, @"^(:?[\d,]+\.)*\d+$"))
            {
                cultureInfo = new CultureInfo("en-US");
            }
            // if the second regex matches, the number string is in de culture
            else if (Regex.IsMatch(numberString, @"^(:?[\d.]+,)*\d+$"))
            {
                cultureInfo = new CultureInfo("de-DE");
            }

            if (Decimal.TryParse(numberString, style, cultureInfo, out number))
            {
                Console.WriteLine("Converted '{0}' to {1}.", numberString, number);
                numberStringIsNotOk = false;
            }
            else
            {
                Console.WriteLine("Unable to convert '{0}'.", numberString);
            }

            return numberStringIsNotOk;
        }
    }
}
