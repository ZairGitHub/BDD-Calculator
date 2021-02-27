Feature: Calculator
	Simple BDD calculator for handling arithmetic operations with one or two input numbers

Background:
	Given a user has a calculator

Scenario Outline: Addition
	And the user enters any first input number <input1> into the calculator
	And the user enters any second input number <input2> into the calculator
	When the user presses add
	Then the calculator should display a result should be equal to <result>
	Examples:
	| input1 | input2 | result |
	| 1      | -1     | 0      |
	| 1      | 0      | 1      |
	| 1		 | 1      | 2      |

Scenario Outline: Subtract
	And the user enters any first input number <input1> into the calculator
	And the user enters any second input number <input2> into the calculator
	When the user presses subtract
	Then the calculator should display a result should be equal to <result>
	Examples:
	| input1 | input2 | result |
	| 1      | -1     | 2      |
	| 1      | 0      | 1      |
	| 1		 | 1      | 0      |

Scenario Outline: Multiply
	And the user enters any first input number <input1> into the calculator
	And the user enters any second input number <input2> into the calculator
	When the user presses multiply
	Then the calculator should display a result should be equal to <result>
	Examples:
	| input1 | input2 | result |
	| 1      | -1     | -1     |
	| 1      | 0      | 0      |
	| 1		 | 1      | 1      |

Scenario Outline: Divide
	And the user enters any first input number <input1> into the calculator
	And the user enters a second input number that is not zero <input2> into the calculator
	When the user presses divide
	Then the calculator should display a result should be equal to <result>
	Examples:
	| input1 | input2 | result |
	| 1      | -1     | -1     |
	| 1      | 1      | 1      |
	
Scenario Outline: Modulo
	And the user enters any first input number <input1> into the calculator
	And the user enters a second input number that is not zero <input2> into the calculator
	When the user presses modulo
	Then the calculator should display a result should be equal to <result>
	Examples:
	| input1 | input2 | result |
	| 1      | -1     | 0      |
	| 1      | 1      | 0      |

Scenario Outline: Reciprocal
	And the user enters a first input number that is not zero <input> into the calculator
	When the user presses reciprocal
	Then the calculator should display a result should be equal to <result>
	Examples:
	| input  | result |
	| 1      | 1      |
	| 2      | 0.5    |
	| -2     | -0.5	  |

Scenario Outline: Exponent
	And the user enters any first input number <input1> into the calculator
	And the user enters any second input number <exponent> into the calculator
	When the user presses exponent
	Then the calculator should display a result should be equal to <result>
	Examples:
	| input1 | exponent | result |
	| 1      | 2        | 1      |
	| 2      | 2        | 4      |
	| 3      | 2        | 9      |

Scenario Outline: SquareRoot
	And the user enters a first input number that is zero or positive <input> into the calculator
	When the user presses squareroot
	Then the calculator should display a result should be equal to <result>
	Examples:
	| input | result |
	| 0     | 0		 |
	| 1     | 1		 |
	| 9     | 3		 |

Scenario: Divide cannot divide by zero error message
	And the user enters a second input number of zero into the calculator
	When the user presses divide
	Then the calculator should display a division error message

Scenario: Modulo cannot divide by zero error message
	And the user enters a second input number of zero into the calculator
	When the user presses modulo
	Then the calculator should display a division error message

Scenario: Reciprocal cannot divide by zero error message
	And I enter a first input number of zero into the calculator
	When the user presses reciprocal
	Then the calculator should display a division error message

Scenario: SquareRoot cannot accept negative numbers error message
	And I enter a first input number that is negative -1 into the calculator
	When the user presses squareroot
	Then the calculator should display an argument error message

Scenario: Divide cannot divide by zero error result
	And the user enters a second input number of zero into the calculator
	When the user presses divide
	Then the calculator should display a result that is not a valid number

Scenario: Modulo cannot divide by zero error result
	And the user enters a second input number of zero into the calculator
	When the user presses modulo
	Then the calculator should display a result that is not a valid number

Scenario: Reciprocal cannot divide by zero error result
	And I enter a first input number of zero into the calculator
	When the user presses reciprocal
	Then the calculator should display a result that is not a valid number

Scenario: SquareRoot cannot accept negative numbers error result
	And I enter a first input number that is negative -1 into the calculator
	When the user presses squareroot
	Then the calculator should display a result that is not a valid number

Scenario: SumOfEvenNumbers
	And I enter the numbers below into a list
	| numbers |
	| 1       |
	| 2       |
	| 3       |
	| 4       |
	| 5       |
	When I iterate through the list to select all even numbers
	And I add the selected numbers of the list together
	Then the calculator should display a result should be equal to 6

Scenario: SumOfOddNumbers
	And I enter the numbers below into a list
	| numbers |
	| 1       |
	| 2       |
	| 3       |
	| 4       |
	| 5       |
	When I iterate through the list to select all odd numbers
	And I add the selected numbers of the list together
	Then the calculator should display a result should be equal to 9
