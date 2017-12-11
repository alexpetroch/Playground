using System.Collections.Generic;

#pragma warning disable CS0169

namespace Playground.OOD
{
    class GameSystem
    {
        public static IGame CreateGame(string gameName)
        {
            if(gameName.Equals("Chess"))
            {
                return new ChessGame();
            }

            return null;
        }
    }

    interface IGame
    {
        bool StartGame(Player[] players);

        bool MakeTurn(Move move);
    }

    public class ChessGame : IGame
    {
        public bool MakeTurn(Move move)
        {
            // Check turn. Better to create a class MoveResult
            bool isvalid = move.Figure.CheckMove(move.From, move.To);

            // check board -> no mate, no figures to block this move and so on
            return true;
        }

        public bool StartGame(Player[] players)
        {
            // validate players. assign first to white, second to black
            return true;
        }

        // TODO. CheckMate and so on
    }

    public class Board
    {
        Dictionary<Position, Figure> locations = new Dictionary<Position, Figure>();
        public Board()
        {
            for (int x = 0; x < 8; x++)
            {
                for (int y = 0; y < 8; y++)
                {
                    // here array should be initialized
                    Position pos = new Position() { X = x, Y = y, White = (x + y) % 2 == 0 };                   
                }
            }

            // Figures init. should be via existing array
            locations.Add(new Position() { X = 0, Y = 3, White = true }, new King());
        }

        public bool Move (Move move)
        {
            var figure = locations[move.From];

            // check figure, figure == move.Figure
            locations[move.To] = figure;
            locations[move.From] = null;
            return true;
        }
    }

    public abstract class Figure
    {
        public abstract bool CheckMove(Position from, Position to);
    }

    public class King : Figure
    {
        public override bool CheckMove(Position from, Position to)
        {
            return true;
        }
    }

    public class Player
    {
        string Name;
        int id; // to maintain player history in db
    }

    public class Move
    {
        public Position From;
        public Position To;
        public Figure Figure;
    }

    public class Position
    {
        public int X;
        public int Y;
        public bool White;
    }
}
