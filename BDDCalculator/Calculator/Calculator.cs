using System;
using System.Collections.Generic;
using System.Linq;
using TechTalk.SpecFlow;

namespace CalculatorLibrary
{
    public class Calculator
    {
        private List<double> _numbersList = new List<double>();

        public double Number1 { get; set; }

        public double Number2 { get; set; }

        public Exception Exception { get; private set; }

        public double Add() => Number1 + Number2;

        public double Subtract() => Number1 - Number2;

        public double Multiply() => Number1 * Number2;

        public double Divide()
        {
            if (Number2 == 0)
            {
                Exception = new DivideByZeroException("Cannot divide by zero.");
                return double.NaN;
            }
            return Number1 / Number2;
        }

        public double Modulo()
        {
            if (Number2 == 0)
            {
                Exception = new DivideByZeroException("Cannot divide by zero.");
                return double.NaN;
            }
            return Number1 % Number2;
        }

        public double Reciprocal()
        {
            if (Number1 == 0)
            {
                Exception = new DivideByZeroException("Cannot divide by zero.");
                return double.NaN;
            }
            return 1 / Number1;
        }

        public double Exponent() => Math.Pow(Number1, Number2);

        public void AddNumbersToList(Table table)
        {
            _numbersList = table.Rows
                .Select(row => double.Parse(row["numbers"])).ToList();
        }

        public void IterateAndSelectEvenNumbers()
        {
            _numbersList = _numbersList.Where(i => i % 2 == 0).ToList();
        }

        public double SumOfEvenNumbers() => _numbersList.Sum();
    }
}
