using System;
using System.Collections;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Chess_Library
{
    public interface ChessPiece_Inteface
    {
        /// <summary>
        /// Find all posible Moves for a ChessPiece 
        /// </summary>
        /// <param name="arrState"></param>
        /// <param name="position"></param>
        /// <returns></returns>
        ArrayList FindAllPosibleMoves(ChessState[,] arrState, Point position);

        /// <summary>
        /// Find All Impossible Moves for a King from an opponent 's Chesspice
        /// </summary>
        /// <param name="arrState"></param>
        /// <param name="position"></param>
        /// <returns></returns>
        ArrayList FindAllImposibleMoves(ChessState[,] arrState, Point position);
    }
}
