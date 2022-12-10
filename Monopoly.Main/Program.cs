using Monopoly;

// Console.Clear();
var players = new Player[] { new Player("Carlos"), new Player("Julio"), new Player("Jose"), new Player("Esteban"), new Player("Esteban") };
// for (int i = 0; i < 5; i++)
// {
    // Console.Clear();
    var board = new Board( "../properties.csv");
    Console.WriteLine(board.GetBoardAsString(players, 0));
    ConsoleKey key= ConsoleKey.R;
    switch(key)
    {
        case ConsoleKey.R:
        {
            Board.RollDices(ref players[0]);
            board.GameBoard[players[0].CurrentPosition].Action(ref players[0]);
            break;
        }
        case ConsoleKey.C:
        {
            break;
        }
        case ConsoleKey.H:
        {
            break;
        }
        case ConsoleKey.S:
        {
            break;
        }
        case ConsoleKey.E:
        {
            break;
        }
        default:
        {   
            break;
        }
    }
    Thread.Sleep(2000);
    // Console.Clear();
    Console.WriteLine(board.GetBoardAsString(players, 1));
// }



