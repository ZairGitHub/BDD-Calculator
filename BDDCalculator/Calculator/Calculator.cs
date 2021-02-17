using System;
using System.Collections.Generic;
using System.Linq;
using TechTalk.SpecFlow;

namespace CalculatorLibrary
{
    public class Calculator
    {
        private List<int> _numbersList = new List<int>();

        public int Number1 { get; set; }

        public int Number2 { get; set; }

        public Exception Exception { get; private set; }

        public int Add() => Number1 + Number2;

        public int Subtract() => Number1 - Number2;

        public int Multiply() => Number1 * Number2;

        public int Divide()
        {
            if (Number2 == 0)
            {
                Exception = new DivideByZeroException("Cannot divide by zero.");
                return 0;
            }
            return Number1 / Number2;
        }

        public void AddNumbersToList(Table table)
        {
            _numbersList = table.Rows
                .Select(row => int.Parse(row["numbers"])).ToList();
        }

        public void IterateAndSelectEvenNumbers()
        {
            _numbersList = _numbersList.Where(i => i % 2 == 0).ToList();
        }

        public int SumOfEvenNumbers() => _numbersList.Sum();
    }
}
