﻿using System;
using CalculatorLibrary;
using NUnit.Framework;
using TechTalk.SpecFlow;

namespace BDDCalculator
{
    [Binding]
    public class CalculatorSteps
    {
        private int _result;
        private Calculator _calculator;

        [Given(@"I have a calculator")]
        public void GivenIHaveACalculator() => _calculator = new Calculator();
        
        [Given(@"I enter (.*) and (.*) into the calculator")]
        public void GivenIEnterInput1AndInput2IntoTheCalculator(int input1, int input2)
        {
            _calculator.Number1 = input1;
            _calculator.Number2 = input2;
        }

        [Given(@"the second input is equal to zero")]
        public void GivenTheSecondInputIsEqualToZero()
        {
            Assert.That(_calculator.Number2, Is.Zero);
        }

        [Given(@"the second input is not equal to zero")]
        public void GivenTheSecondInputIsNotEqualToZero()
        {
            Assert.That(_calculator.Number2, Is.Not.Zero);
        }

        [Given(@"I enter the numbers below into a list")]
        public void GivenIEnterTheNumbersBelowIntoAList(Table table)
        {
            _calculator.AddNumbersToList(table);
        }

        [When(@"I press add")]
        public void WhenIPressAdd() => _result = _calculator.Add();

        [When(@"I press subtract")]
        public void WhenIPressSubtract() => _result = _calculator.Subtract();

        [When(@"I press multiply")]
        public void WhenIPressMultiply() => _result = _calculator.Multiply();

        [When(@"I press divide")]
        public void WhenIPressDivide() => _result = _calculator.Divide();

        [When(@"I iterate through the list to select all even numbers")]
        public void WhenIIterateThroughTheListToSelectAllEvenNumbers()
        {
            _calculator.IterateAndSelectEvenNumbers();
        }

        [When(@"I add them together")]
        public void WhenIAddThemTogether()
        {
            _result = _calculator.SumOfEvenNumbers();
        }

        [Then(@"the result should display an error message")]
        public void ThenTheResultShouldDisplayAnErrorMessage()
        {
            Assert.That(_calculator.Exception, Is.TypeOf<DivideByZeroException>()
                .With.Message.EqualTo("Cannot divide by zero."));
        }

        [Then(@"the result should be (.*)")]
        public void ThenTheResultShouldBe(int expected)
        {
            Assert.That(_result, Is.EqualTo(expected));
        }
    }
}
