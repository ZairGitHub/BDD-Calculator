using System;
using System.Collections.Generic;
using System.Linq;
using TechTalk.SpecFlow;

namespace CalculatorLibrary
{
    public class Calculator
    {
        private List<double> _numbersList = new List<double>();

        public double Input1 { get; set; }

        public double Input2 { get; set; }

        public Exception Exception { get; private set; }

        public double Add() => Input1 + Input2;

        public double Subtract() => Input1 - Input2;

        public double Multiply() => Input1 * Input2;

        public double Divide()
        {
            if (Input2 == 0)
            {
                Exception = new DivideByZeroException("Cannot divide by zero.");
                return double.NaN;
            }
            return Input1 / Input2;
        }

        public double Modulo()
        {
            if (Input2 == 0)
            {
                Exception = new DivideByZeroException("Cannot divide by zero.");
                return double.NaN;
            }
            return Input1 % Input2;
        }

        public double Reciprocal()
        {
            if (Input1 == 0)
            {
                Exception = new DivideByZeroException("Cannot divide by zero.");
                return double.NaN;
            }
            return 1 / Input1;
        }

        public double Exponent() => Math.Pow(Input1, Input2);

        public double SquareRoot()
        {
            if (Input1 < 0)
            {
                Exception = new ArgumentException("Cannot square root negative numbers");
                return double.NaN;
            }
            return Math.Sqrt(Input1);
        }

        public void AddNumbersToList(Table table)
        {
            _numbersList = table.Rows
                .Select(row => double.Parse(row["numbers"])).ToList();
        }

        public void IterateAndSelectEvenNumbers()
        {
            _numbersList = _numbersList.Where(i => i % 2 == 0).ToList();
        }

        public void IterateAndSelectOddNumbers()
        {
            _numbersList = _numbersList.Where(i => i % 2 != 0).ToList();
        }

        public double SumOfSelectedNumbers() => _numbersList.Sum();
    }
}
