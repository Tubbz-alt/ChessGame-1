using System;
using System.Collections;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Chess_Library
{
    class ChessPiece_Rook 
    {
        private static int[,] RookTable = new int[,]
       {
          //9  8   7   6   5   4   3   2   1  0
           {0,   0,  0,  0,  0,  0,  0,  0,  0,   0}, //0

           {0,  0,  0,  0,  0,  0,  0,  0,  0,   0},
           {0,  5,  15, 15, 15, 15, 15, 15, 5,   0},
           {0, -5,  0,  0,  0,  0,  0,  0, -5,   0},
           {0, -5,  0,  0,  0,  0,  0,  0, -5,   0},
           {0, -5,  0,  0,  0,  0,  0,  0, -5,   0},
           {0, -5,  0,  0,  0,  0,  0,  0, -5,   0},
           {0, -5,  0,  0,  0,  0,  0,  0, -5,   0},
           {0,  0,  5,  0,  5,  5,  0,  0,  0,   0},

           {0,   0,  0,  0,  0,  0,  0, 0,  0,  0}  //9
       };

        public static int GetPositionValue(Point pos, eChessSide eSide, eChessSide ownSide)
        {
            if (eSide == ownSide)
            {
                return RookTable[pos.X, pos.Y];
            }
            else
            {
                return RookTable[9 - pos.X, 9 - pos.Y];
            }
        }

        public static ArrayList FindAllPosibleMoves(ChessState[,] arrState, Point pos)
        {
            ArrayList arrMove = new ArrayList();
            eChessSide side = arrState[pos.X, pos.Y].Side;
            Point[] How_To_Move = new Point[] { new Point(1, 0), new Point(0, 1), new Point(-1, 0), new Point(0, -1) };
           
            for (int i = 0; i<How_To_Move.Length; i++)
            {
                Point pos_temp = new Point(pos.X + How_To_Move[i].X, pos.Y + How_To_Move[i].Y);

                while (arrState[pos_temp.X, pos_temp.Y].Type == eChessPieceType.Null)
                {
                    arrMove.Add(new ChessMove(new Point(pos.X, pos.Y), new Point(pos_temp.X, pos_temp.Y), eMove.Moving, arrState[pos.X, pos.Y].Moves));
                    pos_temp.X += How_To_Move[i].X;
                    pos_temp.Y += How_To_Move[i].Y;
                }
                //Eating
                if (arrState[pos_temp.X, pos_temp.Y].Side != side && arrState[pos_temp.X, pos_temp.Y].Type > 0)
                    arrMove.Add(new ChessMove(new Point(pos.X, pos.Y), new Point(pos_temp.X, pos_temp.Y), eMove.Eating, new Point(pos_temp.X, pos_temp.Y), arrState[pos_temp.X, pos_temp.Y].Type, arrState[pos_temp.X, pos_temp.Y].Moves, arrState[pos.X, pos.Y].Moves));
            }

            return arrMove;
        }

        public static ArrayList FindAllImposibleMoves(ChessState[,] arrState, Point pos)
        {
            ArrayList arrMove = new ArrayList();
            eChessSide side = arrState[pos.X, pos.Y].Side;
            Point[] How_To_Move = new Point[] { new Point(1, 0), new Point(0, 1), new Point(-1, 0), new Point(0, -1) };

            for (int i = 0; i < How_To_Move.Length; i++)
            {
                Point pos_temp = new Point(pos.X + How_To_Move[i].X, pos.Y + How_To_Move[i].Y);

                while (arrState[pos_temp.X, pos_temp.Y].Type == eChessPieceType.Null)
                {
                    arrMove.Add(new ChessMove(new Point(pos.X, pos.Y), new Point(pos_temp.X, pos_temp.Y), eMove.Moving, arrState[pos.X, pos.Y].Moves));
                    pos_temp.X += How_To_Move[i].X;
                    pos_temp.Y += How_To_Move[i].Y;
                }
                //Eating
                if (arrState[pos_temp.X, pos_temp.Y].Side == side && arrState[pos_temp.X, pos_temp.Y].Type > 0)
                    arrMove.Add(new ChessMove(new Point(pos.X, pos.Y), new Point(pos_temp.X, pos_temp.Y), eMove.Eating, new Point(pos_temp.X, pos_temp.Y), arrState[pos_temp.X, pos_temp.Y].Type, arrState[pos_temp.X, pos_temp.Y].Moves, arrState[pos.X, pos.Y].Moves));
            }

            return arrMove;
        }
    }
}
