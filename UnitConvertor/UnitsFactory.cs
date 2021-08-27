using System;
using System.Collections.Generic;
using System.Linq;
using UnitConvertor.Models;

namespace UnitConvertor
{
    public static class UnitsFactory
    {
        public static string Convertor(decimal number, string fromUnit, string toUnit)
        {
            decimal resultNumber = 0;

            var units = new List<ConversionData>();
            units.Add(new ConversionData { FromUnit = "°C", ToUnit = "°F", MathOperation = MathOperations.CtoF, Koeficient = 20 });
            units.Add(new ConversionData { FromUnit = "°F", ToUnit = "°C", MathOperation = MathOperations.FtoC, Koeficient = 20 });

            var selectedConversion = units.Where(u => u.FromUnit == fromUnit && u.ToUnit == toUnit).FirstOrDefault();

            var unitConvertor = new MathOperationsFormulas();
            var mathOperation = selectedConversion.MathOperation;

            switch (mathOperation)
            {
                case MathOperations.Add:
                    {
                        resultNumber = unitConvertor.Add(number, selectedConversion.Koeficient);
                        break;
                    }
                case MathOperations.CtoF:
                    {
                        resultNumber = unitConvertor.CtoF(number);
                        break;
                    }
                case MathOperations.FtoC:
                    {
                        resultNumber = unitConvertor.FtoC(number);
                        break;
                    }
                default:
                    {
                        break;
                    }
            }
            return resultNumber.ToString();
        }

        private static Dictionary<string, string> GetKnownUnits()
        {
            var knownUnits = new Dictionary<string, string>();
            knownUnits.Add("c", "°C");
            knownUnits.Add("°c", "°C");
            knownUnits.Add("C", "°C");
            knownUnits.Add("°C", "°C");
            knownUnits.Add("celsius", "°C");
            knownUnits.Add("cel", "°C");
            knownUnits.Add("f", "°F");
            knownUnits.Add("°f", "°F");
            knownUnits.Add("F", "°F");
            knownUnits.Add("°F", "°F");
            knownUnits.Add("far", "°F");
            knownUnits.Add("fahrenheit", "°F");
            return knownUnits;
        }

        public static bool IsNotKnownUnit(string unit, out string value)
        {
            var knownUnits = GetKnownUnits();
            value = "";
            var result = true;
            if (knownUnits.TryGetValue(unit, out value))
            {
                Console.WriteLine("For key = " + unit + ", value = {0}.", value);
                result = false;
            }
            else
            {
                Console.WriteLine("Key = " + unit + " is not found.");
            }
            return result;
        }
    }
}
