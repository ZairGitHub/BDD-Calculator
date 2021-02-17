Feature: Calculator
	Simple BDD calculator for performing simple arithmetic with two numbers

Background:
	Given I have a calculator

Scenario Outline: Addition
	Given I have a calculator
	And then I enter <input1> and <input2> into the calculator
	When I press add
	Then the result should be <result>
	Examples:
	| input1 | input2 | result |
	| 0      | -1     | -1     |
	| 0      | 0      | 0      |
	| 0		 | 1      | 1      |

Scenario Outline: Subtract
	Given I have a calculator
	And then I enter <input1> and <input2> into the calculator
	When I press subtract
	Then the result should be <result>
	Examples:
	| input1 | input2 | result |
	| 0      | -1     | 1      |
	| 0      | 0      | 0      |
	| 0		 | 1      | -1     |

Scenario Outline: Multiply
	Given I have a calculator
	And then I enter <input1> and <input2> into the calculator
	When I press multiply
	Then the result should be <result>
	Examples:
	| input1 | input2 | result |
	| 0      | -1     | 0      |
	| 0      | 0      | 0      |
	| 0		 | 1      | 0      |

Scenario Outline: DivideByZeroError
	Given I have a calculator
	And then I enter <input1> and <input2> into the calculator
	And the second input is equal to zero
	When I press divide
	Then the result should display an error message
	Examples:
	| input1 | input2 |
	| -1     | 0      |
	| 0      | 0      |
	| 1      | 0      |

Scenario Outline: Divide
	Given I have a calculator
	And then I enter <input1> and <input2> into the calculator
	And the second input is not equal to zero
	When I press divide
	Then the result should be <result>
	Examples:
	| input1 | input2 | result |
	| 0      | -1     | 0      |
	| 0      | 1      | 0      |

Scenario Outline: SumOfEvenNumbers
	Given I have a calculator
	And then I enter the numbers below into a list
	| numbers |
	| 1       |
	| 2       |
	| 3       |
	| 4       |
	| 5       |
	When I iterate through the list to select all even numbers
	And I add them together
	Then the result should be 6
