using System;
using System.Collections;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Chess_Library
{
    class ChessPiece_King 
    {
        private static int[,] KingTable = new int[,]
        {
          //9  8   7   6   5   4   3   2   1  0
           {0,   0,  0,  0,  0,  0,  0,  0,  0,   0}, //0

           {0,  -30, -40, -40, -50, -50, -40, -40, -30  ,0},
           {0,  -30, -40, -40, -50, -50, -40, -40, -30  ,0},
           {0,  -30, -40, -40, -50, -50, -40, -40, -30  ,0},
           {0,  -30, -40, -40, -50, -50, -40, -40, -30  ,0},
           {0,  -20, -30, -30, -40, -40, -30, -30, -20  ,0},
           {0,  -10, -20, -20, -20, -20, -20, -20, -10  ,0},
           {0,   20,  20, -5,  -5,  -5,  -5,   20,  20  ,0},
           {0,   20,  30, 10,  0,   0,  10, 30,  20  ,0},

           {0,   0,  0,  0,  0,  0,  0,  0,  0,   0}  //9
		};

        private static int[,] KingTableEndGame = new int[,]
        {
          //9  8   7   6   5   4   3   2   1  0
           {0,   0,  0,  0,  0,  0,  0,  0,  0,   0}, //0
           {0,  -50,-40,-30,-20,-20,-30,-40,-50,  0},
           {0,  -30,-20,-10,  0,  0,-10,-20,-30,  0},
           {0,  -30,-10, 20, 30, 30, 20,-10,-30,  0},
           {0,  -30,-10, 30, 40, 40, 30,-10,-30,  0},
           {0,  -30,-10, 30, 40, 40, 30,-10,-30,  0},
           {0,  -30,-10, 20, 30, 30, 20,-10,-30,  0},
           {0,  -30,-30,  0,  0,  0,  0,-30,-30,  0},
           {0,  -50,-30,-30,-30,-30,-30,-30,-50,  0},

           {0,   0,  0,  0,  0,  0,  0,  0,  0,   0}  //9
		};

        public static int GetPositionValue(Point pos, eChessSide eSide, bool IsEndGame, eChessSide ownSide)
        {
            if (IsEndGame == false)
            {
                if (eSide == ownSide)
                {
                    return KingTable[pos.X, pos.Y];
                }
                else
                {
                    return KingTable[9 - pos.X, 9 - pos.Y];
                }
            }
            else
            {
                if (eSide == ownSide)
                {
                    return KingTableEndGame[pos.X, pos.Y];
                }
                else
                {
                    return KingTableEndGame[9 - pos.X, 9 - pos.Y];
                }
            }
        }

        public static ArrayList FindAllPosibleMoves(ChessState[,] arrState, Point pos, eChessSide ownSide)
        {
            ArrayList arrMove = new ArrayList();
            eChessSide side = arrState[pos.X, pos.Y].Side;
            Point[] How_To_Move = new Point[] { new Point(1, 1), new Point(1, -1), new Point(-1, 1), new Point(-1, -1), new Point(1, 0), new Point(0, 1), new Point(-1, 0), new Point(0, -1) };

            bool[,] can_Moves = Chess_Engine.FindAllKingCanMove(arrState, side, ownSide);

            for (int i = 0; i < How_To_Move.Length; i++)
            {
                Point pos_temp = new Point(pos.X + How_To_Move[i].X, pos.Y + How_To_Move[i].Y);

                if (can_Moves[pos_temp.X, pos_temp.Y] == true)
                {
                    if (arrState[pos_temp.X, pos_temp.Y].Type == eChessPieceType.Null)
                        arrMove.Add(new ChessMove(new Point(pos.X, pos.Y), new Point(pos_temp.X, pos_temp.Y), eMove.Moving, arrState[pos.X, pos.Y].Moves));
                
                    if (arrState[pos_temp.X, pos_temp.Y].Side != side && arrState[pos_temp.X, pos_temp.Y].Type > 0)
                        arrMove.Add(new ChessMove(new Point(pos.X, pos.Y), new Point(pos_temp.X, pos_temp.Y), eMove.Eating, new Point(pos_temp.X, pos_temp.Y), arrState[pos_temp.X, pos_temp.Y].Type, arrState[pos_temp.X, pos_temp.Y].Moves, arrState[pos.X, pos.Y].Moves));
                }     
            }
  
            if (arrState[pos.X, pos.Y].Moves == 0)
            {
                //King Side castling
                if (arrState[pos.X, 6].Type == eChessPieceType.Null && arrState[pos.X, 7].Type == eChessPieceType.Null
              && arrState[pos.X, 8].Type == eChessPieceType.Rook && can_Moves[pos.X, 6] && can_Moves[pos.X, 7] 
              && arrState[pos.X, 8].Moves == 0)
                    arrMove.Add(new ChessMove(new Point(pos.X, 5), new Point(pos.X, 7), eMove.Castling, arrState[pos.X, pos.Y].Moves));

                //Queen Side castling 
                if (arrState[pos.X, 4].Type == eChessPieceType.Null && arrState[pos.X, 3].Type == eChessPieceType.Null
              && arrState[pos.X, 2].Type == eChessPieceType.Null && arrState[pos.X, 1].Type == eChessPieceType.Rook 
              && can_Moves[pos.X, 4] && can_Moves[pos.X, 3] && arrState[pos.X, 1].Moves == 0)
                    arrMove.Add(new ChessMove(new Point(pos.X, 5), new Point(pos.X, 3), eMove.Castling, arrState[pos.X, pos.Y].Moves));

                //Promote Side castling 
                if (pos.X == 8 && arrState[7,5].Type == eChessPieceType.Null && arrState[6, 5].Type == eChessPieceType.Null
                               && arrState[5, 5].Type == eChessPieceType.Null && arrState[4, 5].Type == eChessPieceType.Null 
                               && arrState[3, 5].Type == eChessPieceType.Null && arrState[2, 5].Type == eChessPieceType.Null 
                               && arrState[1, 5].Type == eChessPieceType.Rook && can_Moves[7, 5] && can_Moves[6, 5] && arrState[1, 5].Moves == 0)
                    arrMove.Add(new ChessMove(new Point(8, 5), new Point(6, 5), eMove.Castling, arrState[pos.X, pos.Y].Moves));

                if (pos.X == 1 && arrState[7, 5].Type == eChessPieceType.Null && arrState[6, 5].Type == eChessPieceType.Null
                               && arrState[5, 5].Type == eChessPieceType.Null && arrState[4, 5].Type == eChessPieceType.Null
                               && arrState[3, 5].Type == eChessPieceType.Null && arrState[2, 5].Type == eChessPieceType.Null
                               && arrState[8, 5].Type == eChessPieceType.Rook && can_Moves[2, 5] && can_Moves[3, 5] && arrState[8, 5].Moves == 0)
                    arrMove.Add(new ChessMove(new Point(1, 5), new Point(3, 5), eMove.Castling, arrState[pos.X, pos.Y].Moves));
            }


 
            return arrMove;
        }

        public static ArrayList FindAllImposibleMoves(ChessState[,] arrState, Point pos)
        {
            ArrayList arrMove = new ArrayList();
            eChessSide side = arrState[pos.X, pos.Y].Side;

            Point[] How_To_Move = new Point[] { new Point(1, 1), new Point(1, -1), new Point(-1, 1), new Point(-1, -1), new Point(1, 0), new Point(0, 1), new Point(-1, 0), new Point(0, -1) };

            for (int i = 0; i < How_To_Move.Length; i++)
            {
                Point pos_temp = new Point(pos.X + How_To_Move[i].X, pos.Y + How_To_Move[i].Y);

                if (arrState[pos_temp.X, pos_temp.Y].Type == eChessPieceType.Null)
                    arrMove.Add(new ChessMove(new Point(pos.X, pos.Y), new Point(pos_temp.X, pos_temp.Y), eMove.Moving, arrState[pos.X, pos.Y].Moves));
                else
                if (arrState[pos_temp.X, pos_temp.Y].Side == side && arrState[pos_temp.X, pos_temp.Y].Type > 0)
                    arrMove.Add(new ChessMove(new Point(pos.X, pos.Y), new Point(pos_temp.X, pos_temp.Y), eMove.Eating, new Point(pos_temp.X, pos_temp.Y), arrState[pos_temp.X, pos_temp.Y].Type, arrState[pos_temp.X, pos_temp.Y].Moves, arrState[pos.X, pos.Y].Moves));
            }
            
            return arrMove;
        }
    }
}
