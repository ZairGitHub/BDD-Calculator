using System;
using CalculatorLibrary;
using NUnit.Framework;
using TechTalk.SpecFlow;

namespace BDDCalculator
{
    [Binding]
    public class CalculatorSteps
    {
        private double _result;
        private Calculator _calculator;

        [Given(@"I have a calculator")]
        public void GivenIHaveACalculator() => _calculator = new Calculator();

        [Given(@"I enter any first input number (.*) into the calculator")]
        public void GivenIEnterAnyFirstInputNumberIntoTheCalculator(double input)
        {
            _calculator.Input1 = input;
        }

        [Given(@"I enter a first input number of zero into the calculator")]
        public void GivenIEnterAFirstInputNumberOfZeroIntoTheCalculator()
        {
            _calculator.Input1 = 0;
        }

        [Given(@"I enter a first input number that is not zero (.*) into the calculator")]
        public void GivenIEnterAFirstInputNumberThatIsNotZeroIntoTheCalculator(double input)
        {
            _calculator.Input1 = input;
        }

        [Given(@"I enter a first input number that is negative (.*) into the calculator")]
        public void GivenIEnterAFirstInputNumberThatIsNegativeIntoTheCalculator(double input)
        {
            _calculator.Input1 = input;
        }

        [Given(@"I enter a first input number that is zero or positive (.*) into the calculator")]
        public void GivenIEnterAFirstInputNumberThatIsZeroOrPositiveIntoTheCalculator(double input)
        {
            _calculator.Input1 = input;
        }

        [Given(@"I enter any second input number (.*) into the calculator")]
        public void GivenIEnterAnySecondInputNumberIntoTheCalculator(double input)
        {
            _calculator.Input2 = input;
        }

        [Given(@"I enter a second input number of zero into the calculator")]
        public void GivenIEnterASecondInputNumberOfZeroIntoTheCalculator()
        {
            _calculator.Input2 = 0;
        }

        [Given(@"I enter a second input number that is not zero (.*) into the calculator")]
        public void GivenIEnterASecondInputNumberThatIsNotZeroIntoTheCalculator(int input)
        {
            _calculator.Input2 = input;
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

        [When(@"I press modulo")]
        public void WhenIPressModulo() => _result = _calculator.Modulo();

        [When(@"I press reciprocal")]
        public void WhenIPressReciprocal() => _result = _calculator.Reciprocal();

        [When(@"I press exponent")]
        public void WhenIPressExponent() => _result = _calculator.Exponent();

        [When(@"I press squareroot")]
        public void WhenIPressSquareroot() => _result = _calculator.SquareRoot();

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

        [Then(@"the result should display a division error message")]
        public void ThenTheResultShouldDisplayADivisionErrorMessage()
        {
            Assert.That(_calculator.Exception, Is.TypeOf<DivideByZeroException>()
                .With.Message.EqualTo("Cannot divide by zero."));
        }

        [Then(@"the result should display an argument error message")]
        public void ThenTheResultShouldDisplayAnArgumentErrorMessage()
        {
            Assert.That(_calculator.Exception, Is.TypeOf<ArgumentException>()
                .With.Message.EqualTo("Cannot square root negative numbers"));
        }

        [Then(@"the result should not display a valid number")]
        public void ThenTheResultShouldNotDisplayAValidNumber()
        {
            Assert.That(_result, Is.NaN);
        }

        [Then(@"the result should be (.*)")]
        public void ThenTheResultShouldBe(double expected)
        {
            Assert.That(_result, Is.EqualTo(expected));
        }
    }
}
