using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Chess_Library
{
    [Serializable]
    /// <summary>
    /// Save One Move 
    /// </summary>
    public class ChessMove
    {
        #region Declare variables
        private Point _moveFrom;
        private Point _moveTo;
        private Point _moveEated;
        private eMove _howMove;
        private int _moves = 0;
        private int _fromMoves = 0;
        private eChessPieceType _chessPieceEated;
        #endregion

        public Point MoveFrom
        {
            get
            {
                return _moveFrom;
            }

            set
            {
                _moveFrom = value;
            }
        }

        public Point MoveTo
        {
            get
            {
                return _moveTo;
            }

            set
            {
                _moveTo = value;
            }
        }

        public eMove HowMove
        {
            get
            {
                return _howMove;
            }

            set
            {
                _howMove = value;
            }
        }

        public int Moves
        {
            get
            {
                return _moves;
            }

            set
            {
                _moves = value;
            }
        }

        public eChessPieceType ChessPieceEated
        {
            get
            {
                return _chessPieceEated;
            }

            set
            {
                _chessPieceEated = value;
            }
        }

        public Point MoveEated
        {
            get
            {
                return _moveEated;
            }

            set
            {
                _moveEated = value;
            }
        }

        public int FromMoves
        {
            get
            {
                return _fromMoves;
            }

            set
            {
                _fromMoves = value;
            }
        }

        public ChessMove(Point x1, Point x2, eMove m, int fromMoves)
        {
            this._moveFrom.X = x1.X;
            this._moveFrom.Y = x1.Y;

            this._moveTo.X = x2.X;
            this._moveTo.Y = x2.Y;

            this._moveEated.X = 0;
            this._moveEated.Y = 0;

            this._howMove = m;
            this.ChessPieceEated = eChessPieceType.Null;
            this._moves = 0;
            this._fromMoves = fromMoves;
        }

        public ChessMove(Point x1, Point x2, eMove m, Point eated, eChessPieceType pieceType, int moves, int fromMoves)
        {
            this._moveFrom.X = x1.X;
            this._moveFrom.Y = x1.Y;

            this._moveTo.X = x2.X;
            this._moveTo.Y = x2.Y;

            this._moveEated.X = eated.X;
            this._moveEated.Y = eated.Y;

            this._howMove = m;
            this.ChessPieceEated = pieceType;
            this._moves = moves;
            this._fromMoves = fromMoves;
        }
    }
}
