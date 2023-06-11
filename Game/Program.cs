namespace Game;
public static class Game
{
    //List for storing game moves
    private static List<string> _moves = new();
    // variable to store input to check whether user wants to continue playing
    private static string _conditionOfMenu = "n";
    private static int _userMove;
    
    public static void Main(string[] args)
    {
        if (args.Length != 0)
        {
            // when game is started with arguments, args array elements are assigned to _moves list
            _moves = args.ToList();
            WriteLine(_moves.Count);
        }
        else
        {
            // when game is started without arguments, user is asked to enter moves
            GetGameMoves(); 
        }
        do
        {
            if (GameRules.CheckNumberOfMoves(_moves.Count))
            {
                WriteLine("Number of moves should be greater than or equal to 3");
                GetInputForConditionOfMenu();
                if (_conditionOfMenu == "y")
                {
                    GetGameMoves();
                    continue;
                }

                break;
            }

            if (GameRules.CheckNumberOfMovesIsOdd(_moves.Count))
            {
                WriteLine("Number of moves should be odd number");
                GetInputForConditionOfMenu();
                if (_conditionOfMenu == "y")
                {
                    GetGameMoves();
                    continue;
                }

                break;
            }

            if (GameRules.CheckRepetition(_moves))
            {
                WriteLine("Moves should be unique");
                GetInputForConditionOfMenu();
                if (_conditionOfMenu == "y")
                {
                    GetGameMoves();
                    continue;
                }

                break;
            }
            
            //printing the menu
            WriteLine("Available moves");
            do
            {
                //generating computer move
                CalculatingHmac.ComputerMove = _moves.Count;
                PrintHmacOfComputerMove();
                for (var index = 0; index < _moves.Count; index++)
                {
                    WriteLine($"{index + 1} - {_moves[index]}");
                }
                WriteLine("0 - exit");
                Write("Enter your move:");
                var userMove = ReadLine()!;
                
                if (int.TryParse(userMove, out var userMoveInt))
                {
                    _userMove = userMoveInt;
                }
                
                if (_userMove == 0)
                {
                    return;
                }

                if (_userMove < 0 ||  _userMove > _moves.Count)
                {
                    WriteLine("Invalid input");
                }
                else
                {
                    GameRules.DetermineWinner(_moves, _userMove - 1);
                    GetInputForConditionOfMenu();
                }
            } while(_userMove < 0 ||  _userMove > _moves.Count);
        } while (_conditionOfMenu == "y");
    }
    
    /// <summary>
    /// Gets the moves of the game from the user and stores them in _moves list
    /// </summary>
    private static void GetGameMoves()
    {
        Write("Enter the moves of the game separated by a space(rock paper scissors):");
        var moves = ReadLine()!;
        _moves.Clear();
        _moves = moves.Split(' ').ToList();
    }
    
    /// <summary>
    /// asks user whether he/she wants to continue playing and stores the input in _conditionOfMenu variable
    /// </summary>
    private static void GetInputForConditionOfMenu()
    {
        Write("Do you want to continue playing? (y/n):");
        _conditionOfMenu = ReadLine()!;
    }
    
    /// <summary>
    /// Prints HMAC value of computer move
    /// </summary>
    private static void PrintHmacOfComputerMove()
    {
        WriteLine(CalculatingHmac.HmacValue);
    }
}