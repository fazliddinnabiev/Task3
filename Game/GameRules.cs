namespace Game;
public static class GameRules
{
    /// <summary>
    /// checks whether the number of moves passed to the program is odd number
    /// </summary>
    /// <param name="numberOfGameMoves">int type</param>
    /// <returns>true if number of arguments is not odd number otherwise false</returns>
    internal static bool CheckNumberOfMovesIsOdd(int numberOfGameMoves)
    {
        if (numberOfGameMoves % 2 == 0)
        {
            return true;
        }
        
        return false;
    }
    
    /// <summary>
    /// checks whether the number of moves passed to the program is greater than or equal 3
    /// </summary>
    /// <param name="numberOfGameMoves"> int type</param>
    /// <returns>true if number of moves is less than 3, otherwise false</returns>
    internal static bool CheckNumberOfMoves(int numberOfGameMoves)
    {
        if (numberOfGameMoves < 3)
        {
            return true;
        }
        
        return false;
    }
    
    /// <summary>
    /// checks whether the arguments passed to the program are unique
    /// </summary>
    /// <param name="gameMoves">list of strings</param>
    /// <returns>true if arguments are not unique otherwise false</returns>
    internal static bool CheckRepetition(List<string> gameMoves)
    {
        for (var index = 0; index < gameMoves.Count; index++)
        {
            for (var j = index + 1; j < gameMoves.Count; j++)
            {
                if (gameMoves[index] == gameMoves[j])
                {
                    return true;
                }
            }
        }

        return false;
    }
    
    /// <summary>
    /// Determines winner of the game
    /// </summary>
    /// <param name="movesOfGame">list of string</param>
    /// <param name="userMove">int type</param>
    internal static void DetermineWinner(List<string> movesOfGame,int userMove)
    {
        var computerMove = CalculatingHmac.ComputerMove;
        var key = CalculatingHmac.Key;
        var halfOfMoves = movesOfGame.Count / 2;
        if (userMove == computerMove)
        {
            WriteLine($"Your move: {movesOfGame[userMove]}");
            WriteLine($"Computer move: {movesOfGame[computerMove]}");
            WriteLine($"HMAC key: {key}");
            WriteLine("Draw");
        }
        else if (userMove > computerMove)
        {
            if (userMove - computerMove <= halfOfMoves)
            {
                WriteLine($"Your move: {movesOfGame[userMove]}");
                WriteLine($"Computer move: {movesOfGame[computerMove]}");
                WriteLine($"HMAC key: {key}");
                WriteLine("You win");
            }
            else
            {
                WriteLine($"Your move: {movesOfGame[userMove]}");
                WriteLine($"Computer move: {movesOfGame[computerMove]}");
                WriteLine($"HMAC key: {key}");
                WriteLine("You lose");
            }
        }
        else
        {
            if (computerMove - userMove <= halfOfMoves)
            {
                WriteLine($"Your move: {movesOfGame[userMove]}");
                WriteLine($"Computer move: {movesOfGame[computerMove]}");
                WriteLine($"HMAC key: {key}");
                WriteLine("You lose");
            }
            else
            {
                WriteLine($"Your move: {movesOfGame[userMove]}");
                WriteLine($"Computer move: {movesOfGame[computerMove]}");
                WriteLine($"HMAC key: {key}");
                WriteLine("You win");
            }
        }
    }
}