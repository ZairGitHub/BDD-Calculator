Feature: Calculator
	Simple BDD calculator for performing simple arithmetic with two numbers

Background:
	Given I have a calculator

Scenario Outline: Addition
	And I enter <input1> and <input2> into the calculator
	When I press add
	Then the result should be <result>
	Examples:
	| input1 | input2 | result |
	| 0      | -1     | -1     |
	| 0      | 0      | 0      |
	| 0		 | 1      | 1      |

Scenario Outline: Subtract
	And I enter <input1> and <input2> into the calculator
	When I press subtract
	Then the result should be <result>
	Examples:
	| input1 | input2 | result |
	| 0      | -1     | 1      |
	| 0      | 0      | 0      |
	| 0		 | 1      | -1     |

Scenario Outline: Multiply
	And I enter <input1> and <input2> into the calculator
	When I press multiply
	Then the result should be <result>
	Examples:
	| input1 | input2 | result |
	| 0      | -1     | 0      |
	| 0      | 0      | 0      |
	| 0		 | 1      | 0      |

Scenario Outline: Divide: DivideByZeroError
	And I enter <input1> and <input2> into the calculator
	And the second input is equal to zero
	When I press divide
	Then the result should display an error message
	Examples:
	| input1 | input2 |
	| -1     | 0      |
	| 0      | 0      |
	| 1      | 0      |

Scenario Outline: Divide
	And I enter <input1> and <input2> into the calculator
	And the second input is not equal to zero
	When I press divide
	Then the result should be <result>
	Examples:
	| input1 | input2 | result |
	| 0      | -1     | 0      |
	| 0      | 1      | 0      |

Scenario Outline: Modulo: DivideByZeroError
	And I enter <input1> and <input2> into the calculator
	And the second input is equal to zero
	When I press modulo
	Then the result should display an error message
	Examples:
	| input1 | input2 |
	| -1     | 0      |
	| 0      | 0      |
	| 1      | 0      |

Scenario Outline: Modulo
	And I enter <input1> and <input2> into the calculator
	And the second input is not equal to zero
	When I press modulo
	Then the result should be <result>
	Examples:
	| input1 | input2 | result |
	| 0      | -1     | 0      |
	| 0      | 1      | 0      |

Scenario: Reciprocal: DivideByZeroError
	And I enter a first input number of zero 0 into the calculator
	When I press reciprocal
	Then the result should display an error message

Scenario Outline: Reciprocal
	And I enter a first input number that is not zero <input> into the calculator
	And the first input is not equal to zero
	When I press reciprocal
	Then the result should be <result>
	Examples:
	| input  | result |
	| 1      | 1      |
	| 2      | 0.5    |
	| 4      | 0.25	  |

Scenario Outline: Exponent
	And I enter <input1> and <input2> into the calculator
	When I press exponent
	Then the result should be <result>
	Examples:
	| input1 | input2 | result |
	| 1      | 2      | 1      |
	| 2      | 2      | 4      |
	| 3      | 2      | 9      |

Scenario Outline: SumOfEvenNumbers
	And I enter the numbers below into a list
	| numbers |
	| 1       |
	| 2       |
	| 3       |
	| 4       |
	| 5       |
	When I iterate through the list to select all even numbers
	And I add them together
	Then the result should be 6
