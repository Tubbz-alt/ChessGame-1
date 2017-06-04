using System;
using System.Collections;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Chess_Library
{
    class ChessPiece_Pawn
    {
        private static int[,] PawnTable = new int[,]
        {
          //9  8   7   6   5   4   3   2   1  0
           {0, 0,  0,  0,  0,  0,  0,  0,  0, 0}, //0
           {0, 50, 50, 50, 50, 50, 50, 50, 50, 0}, //1
           {0, 50, 50, 50, 50, 50, 50, 50, 50, 0},//2
           {0, 10, 10, 20, 30, 30, 20, 10, 10, 0},//3
           {0, 5,  5, 10, 27, 27, 10,  5,  5, 0}, //4
           {0,-5, -5,-10, 25, 25, -5, -5,  0, 0}, //5
           {0, 5, -5,-10,  0,  0,-10, -5,  5, 0}, //6
           {0, 6, 10, 10,-25,-25, 10, 10,  6, 0}, //7
           {0, 0,  0,  0,  0,  0,  0,  0,  0, 0}, //8
           {0, 0,  0,  0,  0,  0,  0,  0,  0, 0}  //9
		};
        public static int GetPositionValue(Point pos, eChessSide eSide, eChessSide ownSide)
        {
            int value = 0;
            if (eSide == ownSide)
            {

                value = PawnTable[pos.X, pos.Y];
                //Tốt cánh xe bị trừ 15% giá trị
                if (pos.Y == 8 || pos.Y == 1)
                    value -= 15;
            }
            else
            {

                value = PawnTable[9 - pos.X, 9 - pos.Y];
                if (pos.Y == 8 || pos.Y == 1)
                    value -= 15;
            }
            return value;
        }

        public static ArrayList FindAllPosibleMoves(ChessState[,] arrState, Point pos, eChessSide ownSide)
        {
            eChessSide side = arrState[pos.X, pos.Y].Side;
            ArrayList arrMove = new ArrayList();

            if  (side == ownSide)
            {
                //First Move 
                if (arrState[pos.X,pos.Y].Moves == 0)
                {
                    if (arrState[pos.X - 2, pos.Y].Type == eChessPieceType.Null && arrState[pos.X - 1, pos.Y].Type == eChessPieceType.Null)
                        arrMove.Add(new ChessMove(new Point(pos.X, pos.Y), new Point(pos.X - 2, pos.Y), eMove.Moving, arrState[pos.X, pos.Y].Moves));
                }
                //Move ahead
                if (arrState[pos.X - 1,pos.Y].Type == eChessPieceType.Null)
                {
                    if (pos.X == 2) arrMove.Add(new ChessMove(new Point(pos.X, pos.Y), new Point(pos.X - 1, pos.Y), eMove.Promotion, arrState[pos.X, pos.Y].Moves));
                    else arrMove.Add(new ChessMove(new Point(pos.X, pos.Y), new Point(pos.X - 1, pos.Y), eMove.Moving, arrState[pos.X, pos.Y].Moves));
                }

                //Eat diagonal 
                if (arrState[pos.X - 1, pos.Y - 1].Side != side && arrState[pos.X - 1,pos.Y - 1].Type > 0)
                {
                    if (pos.X == 2)
                        //Both Eating and Promotion
                        arrMove.Add(new ChessMove(new Point(pos.X, pos.Y), new Point(pos.X - 1, pos.Y - 1), eMove.Promotion, new Point(pos.X - 1, pos.Y - 1), arrState[pos.X - 1, pos.Y - 1].Type, arrState[pos.X - 1, pos.Y - 1].Moves, arrState[pos.X, pos.Y].Moves));
                    else
                        //Just Eating 
                        arrMove.Add(new ChessMove(new Point(pos.X, pos.Y), new Point(pos.X - 1, pos.Y - 1), eMove.Eating, new Point(pos.X - 1, pos.Y - 1), arrState[pos.X - 1, pos.Y - 1].Type, arrState[pos.X - 1, pos.Y - 1].Moves, arrState[pos.X, pos.Y].Moves));
                }
                if (arrState[pos.X - 1, pos.Y + 1].Side != side && arrState[pos.X - 1, pos.Y + 1].Type > 0)
                {
                    if (pos.X == 2)
                        //Both Eating and Promotion
                        arrMove.Add(new ChessMove(new Point(pos.X, pos.Y), new Point(pos.X - 1, pos.Y + 1), eMove.Promotion, new Point(pos.X - 1, pos.Y + 1), arrState[pos.X - 1, pos.Y + 1].Type, arrState[pos.X - 1, pos.Y + 1].Moves, arrState[pos.X, pos.Y].Moves));
                    else
                        //Just Eating 
                        arrMove.Add(new ChessMove(new Point(pos.X, pos.Y), new Point(pos.X - 1, pos.Y + 1), eMove.Eating, new Point(pos.X - 1, pos.Y + 1), arrState[pos.X - 1, pos.Y + 1].Type, arrState[pos.X - 1, pos.Y + 1].Moves, arrState[pos.X, pos.Y].Moves));
                }

                //En passant 
                if (pos.X == 4 && Uc_ChessBoard.PositionLastMove.X == 2)
                {
                    if (arrState[pos.X - 1, pos.Y - 1].Type == eChessPieceType.Null && arrState[pos.X, pos.Y - 1].Side != side && arrState[pos.X, pos.Y - 1].Type == eChessPieceType.Pawn)
                        arrMove.Add(new ChessMove(new Point(pos.X, pos.Y), new Point(pos.X - 1, pos.Y - 1), eMove.EnPassant, new Point(pos.X, pos.Y - 1), arrState[pos.X, pos.Y - 1].Type, arrState[pos.X, pos.Y - 1].Moves, arrState[pos.X, pos.Y].Moves));
                    if (arrState[pos.X - 1, pos.Y + 1].Type == eChessPieceType.Null && arrState[pos.X, pos.Y - 1].Side != side && arrState[pos.X, pos.Y + 1].Type == eChessPieceType.Pawn)
                        arrMove.Add(new ChessMove(new Point(pos.X, pos.Y), new Point(pos.X - 1, pos.Y + 1), eMove.EnPassant, new Point(pos.X, pos.Y + 1), arrState[pos.X, pos.Y + 1].Type, arrState[pos.X, pos.Y + 1].Moves, arrState[pos.X, pos.Y].Moves));
                }
            }
            else
            {
                //First Move 
                if (arrState[pos.X, pos.Y].Moves == 0)
                {
                    if (arrState[pos.X + 2, pos.Y].Type == eChessPieceType.Null && arrState[pos.X + 1, pos.Y].Type == eChessPieceType.Null)
                        arrMove.Add(new ChessMove(new Point(pos.X, pos.Y), new Point(pos.X + 2, pos.Y), eMove.Moving, arrState[pos.X, pos.Y].Moves));
                }

                //Move ahead
                if (arrState[pos.X + 1, pos.Y].Type == eChessPieceType.Null)
                {
                    if (pos.X == 7) arrMove.Add(new ChessMove(new Point(pos.X, pos.Y), new Point(pos.X + 1, pos.Y), eMove.Promotion, arrState[pos.X, pos.Y].Moves));
                    else arrMove.Add(new ChessMove(new Point(pos.X, pos.Y), new Point(pos.X + 1, pos.Y), eMove.Moving, arrState[pos.X, pos.Y].Moves));
                }

                //Eat diagonal 
                if (arrState[pos.X + 1, pos.Y - 1].Side != side && arrState[pos.X + 1, pos.Y - 1].Type > 0)
                {
                    if (pos.X == 7)
                        //Both Eating and Promotion
                        arrMove.Add(new ChessMove(new Point(pos.X, pos.Y), new Point(pos.X + 1, pos.Y - 1), eMove.Promotion, new Point(pos.X + 1, pos.Y - 1), arrState[pos.X + 1, pos.Y - 1].Type, arrState[pos.X + 1, pos.Y - 1].Moves, arrState[pos.X, pos.Y].Moves));
                    else
                        //Just Eating 
                        arrMove.Add(new ChessMove(new Point(pos.X, pos.Y), new Point(pos.X + 1, pos.Y - 1), eMove.Eating, new Point(pos.X + 1, pos.Y - 1), arrState[pos.X + 1, pos.Y - 1].Type, arrState[pos.X + 1, pos.Y - 1].Moves, arrState[pos.X, pos.Y].Moves));
                }

                if (arrState[pos.X + 1, pos.Y + 1].Side != side && arrState[pos.X + 1, pos.Y + 1].Type > 0)
                {
                    if (pos.X == 7)
                        //Both Eating and Promotion
                        arrMove.Add(new ChessMove(new Point(pos.X, pos.Y), new Point(pos.X + 1, pos.Y + 1), eMove.Promotion, new Point(pos.X + 1, pos.Y + 1), arrState[pos.X + 1, pos.Y + 1].Type, arrState[pos.X + 1, pos.Y + 1].Moves, arrState[pos.X, pos.Y].Moves));
                    else
                        //Just Eating 
                        arrMove.Add(new ChessMove(new Point(pos.X, pos.Y), new Point(pos.X + 1, pos.Y + 1), eMove.Eating, new Point(pos.X + 1, pos.Y + 1), arrState[pos.X + 1, pos.Y + 1].Type, arrState[pos.X + 1, pos.Y + 1].Moves, arrState[pos.X, pos.Y].Moves));
                }

                //En passant 
                if (pos.X == 5 && Uc_ChessBoard.PositionLastMove.X == 7)
                {
                    if (arrState[pos.X + 1, pos.Y - 1].Type == eChessPieceType.Null && arrState[pos.X, pos.Y - 1].Side != side && arrState[pos.X, pos.Y - 1].Type == eChessPieceType.Pawn)
                        arrMove.Add(new ChessMove(new Point(pos.X, pos.Y), new Point(pos.X + 1, pos.Y - 1), eMove.EnPassant, new Point(pos.X, pos.Y - 1), arrState[pos.X, pos.Y - 1].Type, arrState[pos.X, pos.Y - 1].Moves, arrState[pos.X, pos.Y].Moves));
                    if (arrState[pos.X + 1, pos.Y + 1].Type == eChessPieceType.Null && arrState[pos.X, pos.Y + 1].Side != side && arrState[pos.X, pos.Y + 1].Type == eChessPieceType.Pawn)
                        arrMove.Add(new ChessMove(new Point(pos.X, pos.Y), new Point(pos.X + 1, pos.Y + 1), eMove.EnPassant, new Point(pos.X, pos.Y + 1), arrState[pos.X, pos.Y + 1].Type, arrState[pos.X, pos.Y + 1].Moves, arrState[pos.X, pos.Y].Moves));
                }
            }
            return arrMove;
        }

        public static ArrayList FindAllImposibleMoves(ChessState[,] arrState, Point pos, eChessSide ownSide)
        {
            ArrayList arrMove = new ArrayList();
            eChessSide side = arrState[pos.X, pos.Y].Side;

            if (side == ownSide)
            {
                arrMove.Add(new ChessMove(new Point(pos.X, pos.Y), new Point(pos.X - 1, pos.Y - 1), eMove.Eating, new Point(pos.X - 1, pos.Y - 1), arrState[pos.X - 1, pos.Y - 1].Type, arrState[pos.X - 1, pos.Y - 1].Moves, arrState[pos.X, pos.Y].Moves));

                arrMove.Add(new ChessMove(new Point(pos.X, pos.Y), new Point(pos.X - 1, pos.Y + 1), eMove.Eating, new Point(pos.X - 1, pos.Y + 1), arrState[pos.X - 1, pos.Y + 1].Type, arrState[pos.X - 1, pos.Y + 1].Moves, arrState[pos.X, pos.Y].Moves));
            }
            else
            {
                arrMove.Add(new ChessMove(new Point(pos.X, pos.Y), new Point(pos.X + 1, pos.Y - 1), eMove.Eating, new Point(pos.X + 1, pos.Y - 1), arrState[pos.X + 1, pos.Y - 1].Type, arrState[pos.X + 1, pos.Y - 1].Moves, arrState[pos.X, pos.Y].Moves));

                arrMove.Add(new ChessMove(new Point(pos.X, pos.Y), new Point(pos.X + 1, pos.Y + 1), eMove.Eating, new Point(pos.X + 1, pos.Y + 1), arrState[pos.X + 1, pos.Y + 1].Type, arrState[pos.X + 1, pos.Y + 1].Moves, arrState[pos.X, pos.Y].Moves));
            }

            return arrMove;
        }

        public static void Promotion(Uc_ChessPiece UcPawn, eChessPieceType PromoteTo, System.Globalization.CultureInfo Language)
        {
            if (PromoteTo == eChessPieceType.Null)
            {
                Form_Promotion f = new Form_Promotion(UcPawn.Side, UcPawn.Style, Language);
                if (f.ShowDialog() == DialogResult.OK)
                {

                }
                f.Dispose();
                
                UcPawn.Type = Form_Promotion.Type;
            }
            else
            {
                UcPawn.Type = PromoteTo;
            }
            UcPawn.Image = Read_Image_From_Resources.GetChessPieceBitMap(UcPawn.Side, UcPawn.Type, UcPawn.Style);
        }
    }
}
