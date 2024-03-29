﻿using MiniChessLogic.Moves;

namespace MiniChessLogic.Pieces
{
    public class Queen : Piece
    {
        public override PieceType Type => PieceType.Queen;
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
        public Queen(Player color)
        {
            Color = color;
        }
        public override Piece Copy()
        {
            Queen copy = new Queen(Color);
            copy.HasMoved = HasMoved;
            return copy;
        }

        public override IEnumerable<Move> GetMoves(Position from, Board board)
        {
            return MovePositionsInDirs(from, board, dirs ).Select(to=>new NormalMove(from, to));
        }
    }
}
