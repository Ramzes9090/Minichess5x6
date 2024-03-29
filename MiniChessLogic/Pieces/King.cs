﻿using MiniChessLogic.Moves;

namespace MiniChessLogic.Pieces
{
    public class King : Piece
    {
        public override PieceType Type => PieceType.King;
        public override Player Color { get; }

        private static readonly Direction[] dirs = new Direction[]
        {
            Direction.Norh,
            Direction.South,
            Direction.West,
            Direction.East,
            Direction.SouthEast,
            Direction.SouthWest,
            Direction.NorthEast,
            Direction.NorthWest
        };
        public King(Player color)
        {
            Color = color;
        }
        public override IEnumerable<Move> GetMoves(Position from, Board board)
        {
            foreach (Position to in MovePositions(from, board))
            {
                yield return new NormalMove(from, to);
            }
        }
        private IEnumerable<Position> MovePositions(Position from, Board board)
        {
            foreach (Direction dir in dirs)
            {
                Position to = from + dir;
                if (!Board.IsInside(to))
                {
                    continue;
                }
                if (board.IsEmpty(to) || board[to].Color != Color)
                {
                    yield return to;
                }
            }
        }
        public override Piece Copy()
        {
            King copy = new King(Color);
            copy.HasMoved = HasMoved;
            return copy;
        }
    }
}
