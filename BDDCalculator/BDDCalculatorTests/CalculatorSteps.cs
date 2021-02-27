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

        [Given(@"a user has a calculator")]
        public void GivenAUserHasACalculator() => _calculator = new Calculator();

        [Given(@"the user enters any first input number (.*) into the calculator")]
        public void GivenTheUserEntersAnyFirstInputNumberIntoTheCalculator(double input)
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

        [Given(@"the user enters any second input number (.*) into the calculator")]
        public void GivenTheUserEntersAnySecondInputNumberIntoTheCalculator(double input)
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

        [When(@"the user presses add")]
        public void WhenTheUserPressesAdd()
        {
            _result = _calculator.Add();
        }

        [When(@"the user presses subtract")]
        public void WhenTheUserPressesSubtract()
        {
            _result = _calculator.Subtract();
        }

        [When(@"the user presses multiply")]
        public void WhenTheUserPressesMultiply()
        {
            _result = _calculator.Multiply();
        }

        [When(@"the user presses divide")]
        public void WhenTheUserPressesDivide()
        {
            _result = _calculator.Divide();
        }

        [When(@"the user presses modulo")]
        public void WhenTheUserPressesModulo()
        {
            _result = _calculator.Modulo();
        }

        [When(@"the user presses reciprocal")]
        public void WhenTheUserPressesReciprocal()
        {
            _result = _calculator.Reciprocal();
        }

        [When(@"the user presses exponent")]
        public void WhenTheUserPressesExponent()
        {
            _result = _calculator.Exponent();
        }

        [When(@"the user presses squareroot")]
        public void WhenTheUserPressesSquareroot()
        {
            _result = _calculator.SquareRoot();
        }

        [When(@"I iterate through the list to select all even numbers")]
        public void WhenIIterateThroughTheListToSelectAllEvenNumbers()
        {
            _calculator.IterateAndSelectEvenNumbers();
        }

        [When(@"I iterate through the list to select all odd numbers")]
        public void WhenIIterateThroughTheListToSelectAllOddNumbers()
        {
            _calculator.IterateAndSelectOddNumbers();
        }

        [When(@"I add the selected numbers of the list together")]
        public void WhenIAddTheSelectedNumbersOfTheListTogether()
        {
            _result = _calculator.SumOfSelectedNumbers();
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

        [Then(@"the calculator should display a result should be equal to (.*)")]
        public void ThenTheCalculatorShouldDisplayAResultShouldBeEqualTo(double expected)
        {
            Assert.That(_result, Is.EqualTo(expected));
        }
    }
}
