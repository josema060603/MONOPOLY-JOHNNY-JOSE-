Read Me file with a description of the overall proyect.

Our project:
Our project is going to be a monopoly. The reason of this, is because it implements different concepts we used in class and the lab in a whole game. Furthermore, we both like the game and were wondering how easy it would be to make the game with simple implementations

Our goal:
As a person who forgets stuff, I want to create a game that people can play anywhere without the need of a leaderboard, so that anyone who usually loose the pieces of their monopoly or does not take care of the physical board game, do not have to worry about carrying every single part of the game to have fun with their friends.  People often times hardly take care of board games. They are tricky and if you have many pieces lost, the game experience goes down. Nonetheless, by making it a digital game, it would make playing monopoly anything anyone can do at anywhere with a smart device.







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


SCOPE:

Implementation of the game:
class Board:
1. Interfae named GameBoard that contains a get and a set.
2. The class board will have as parameter a string which will refer to the properties.csv. The class will create new instances of the class: parkingLot, jail, startingPoint and incomingTax. Using those instances and the interface, we create the spaces in which the players can fall into. Once they are done, we create the instance of the rest of types of spaces with are property, railroad, utilities, CommunityChest, Chance, and ...
3. GetBoardAsString takes an array of players, and an int which represents which player (index) from the array of players is going to play. This function returns the Board as a string with the updated player´s tokens, and also a small text that explains the possible movements of the player that has the current turn. 
4. RollDices generate random numbers that represent the output of a dice, then, they add the sum of them into the player´s current position.
5. PlayerIsHere is a function that displays the player´s token in the correct place in the string of the board. It takes an array of players and the current position of the player.

class Chance: (Inherits from Ispacing and IRandomCard)
1. DoAThing creates a possibility that the player that is passed by reference gets money or loses it. 
2. Operator overloading allows the user to check if 2 chances have the same id (==, !=).

class CommunityChest (inherits from ISpacing and IRandomCard)
1. DoAThing has a high chance to send a player to jail or to add more money to the player.
2. Opeator overloading allows the user to check if 2 Community Chests have the same id (==, !=).

class ExtensionMethod 
1. HasPlayerLost receives a reference to a player, and if the player has more money to pay than money, they lose.
2. IsInJail takes a refernce to player and returns a boolean that represents if the player is currently in jail.
3. SetNewOwner has as arguments a property, a new owner, old owner, and a price. The property is removed from the old owner´s IEnumerable of properties and added to the new owner´s properties, the price is taken from the new player and added to the new player. If there´s not enough money, it returns an exception
4. SetOwner changes the properties of owner and property to make the property their own.

class FreeParkingLot (inherits from Ispacing)
1. Free Parking has as parameters the reference of a player and it´s main function is to keep the player´s money the same.

class GetID (Inherits from GoToJail)
1. GetId gets the id of the GoToJail class using generic datatype.

class GoToJail (Inherits from ISpacing)
1. PlayerGoesToJail sets the player´s current possition to 10 and sets wasSentInJail equals true.
2. Calls PlayerGoesToJail through Action.

class IncomingTax (inherits from ISpacing)
1. Adds 100 to the player´s money through action.

class Jail (inherits ISpacing)
1. if the player was sent to jail, the player will pay 300 and the property wasSentInJail will be set to false through action

class Player 
1. the class Player will receive a string array that will contain the values for the properties.
2. The player will have theese properties: token, wasSentInJail, moneyToPay, CurrentPosition, Name, Money and properties.
3. An enum that contains greek words that will be used as tokens for in the board to represent each player.

class Property
1. The class Property will receive a string array that will contain the values for it´s properties.
2. Each property will have these properties: Id, Name, Price, Rent, RentWithColorSets, GreenHouseRentIncrement1, GreenHouseRentIncrement2, GreenHouseIncrement3, GreenHouseIncrement4, HotelRentIncrement, color.
3. AddGreenHouse depending of how many houses it currently has, adds another green house or returns an exception.
4. AddHotel adds 1 hotel if there are more tan 3 greenhouses and less than 2 hotels, else, it throws an exception
5. Operator overload compares 2 propertie´s IDs if they are the same or nor (== and !=).
6.ExchangeProperty allows 2 players to exchange properties using a ref to the players.
6. Action makes a player buy the current property. If it is already taken, the player will pay rent.
7. PayRent makes the player pay the owner of the property the cost of the rent property from the property.
8. Operator overload + allows adding a property to a group of properties.
9. Operator overalod - allows taking out a property from a grou of properties.
10. enum that contains the colors of the properties which allows the players to build a set of colors.

class Railroad (inherits from Property and ISpacing)
1. the class Railroad contains Id, Name, Price, Rent
2. Operator Overload compares if the id from 2 Railroads is the same. (== and !=).
3. Action triggers the function setOwner to the current player, and if it is occupied, it uses the function PayRent.
4. IncreaseRent has as parameters a railroad and multiplies the rent by 2.

Interface IRandomCard (inherits from ISpacing)
1. All random cards uses this interface to do their function

Interface ISpacing
1. All spacings use this interface to do their function.

class StartingPoint (inherits from ISpacing)
1. Has a property named Id that is 0 

class Utilities
1. Receives a string array containing the values of the properties.
2. Contains an override function named SetCharacteristics that sets the Id, Name, Price, Rent and Rent2 according to the string array in the parameters.