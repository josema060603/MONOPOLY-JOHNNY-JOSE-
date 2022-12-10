using Monopoly;


var players = new Player[] { new Player("Carlos"), default, default, default, default };
var board = new Board(players, "../properties.csv");
Console.WriteLine(board.GetBoardAsString(players, 0));




