Read Me file with a description of the overall proyect.

"# Monopoly-Johnny-Jose" 
"# Monopoly-Johnny-Jose" 
1. Write down the properties we will create, their prices, and everything to make the game balanced. Furthermore, stablish how much money each one will have at the beggining of the game. The random cards that appear throughout the game logistic
2. Design the board for the game in string implementation
3. Create the class for properties
4. Create the class for random cards in board
5. Create the board class with its fields and methods
6. Create the player class, with its caracteristics and methods to determine whether it has lost or not. 
7. Methods to buy or sell. Methods to pay rent.
8. Main driver
Plan for fulfilling the  requirements:
1.	a class definition= class for board
2.	a second class definition= Class for property
3.	a third class definition= class for player
4.	a struct definition= tentative change of jail and freeparking lot to struct
5.	an enumerated type= enum for the default names if name is not chosen
6.	inheritance= properties to buy
7.	polymorphism= override function of do this for each randomized card
8.	a second example of polymorphism= overloading tostring function for each ISpacing item
9.	throwing an exception and properly catching it= when rolling dice, if the player rolls the same number trice throw an exception and go to jail
10.	definition of your own generic datatype= we have not found a way to use it
11.	properties= data fields for every class
12.	a static member function= roll dice function
13.	an interface= interface for each spacing from the board
14.	a second interface= Interfaces for randomized cards such as the community chest and the chance.
15.	use of at least two of the built-in generic collection types (not two uses of the same type)= IEnumerable for the properties of the player and a array of tupples of int and ISpacings

Notes:
We started with the creation of everything in order to create tests. This tests failed and we did this in order check the implementation of everything later. We also defined the  main rules of our game.