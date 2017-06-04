using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Chess_Library
{
    [System.Serializable]
    /// <summary>
    /// State of Chess Board
    /// </summary>
    public class ChessState
    {
        #region Declare variables
        eChessPieceType _type;
        eChessSide _side;
        private int moves = 0;

        public eChessPieceType Type
        {
            get
            {
                return _type;
            }

            set
            {
                _type = value;
            }
        }

        public eChessSide Side
        {
            get
            {
                return _side;
            }

            set
            {
                _side = value;
            }
        }

        public int Moves
        {
            get
            {
                return moves;
            }

            set
            {
                moves = value;
            }
        }
        #endregion

        public ChessState(eChessPieceType Type, eChessSide side)
        {
            this._type = Type;
            this._side = side;
            this.moves = 0;
        }

        public ChessState(eChessPieceType Type, eChessSide side, int moves)
        {
            this._type = Type;
            this._side = side;
            this.moves = moves;
        }
    }
}
