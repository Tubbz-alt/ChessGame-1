using System;
using System.Collections;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Chess_Library
{
    class Chess_Engine
    {
        #region Declare variables
        const int _lowestScore = -30000;
        static int _maxDepth = 5;
        static ChessMove _myBestMove = null;
        static int _myBestScore = _lowestScore;
        static eChessSide _mySide = eChessSide.Black;
        static eChessSide _ownSide = eChessSide.White;
        static eChessSide _opSide = eChessSide.White;
        #endregion

        #region Game Logic 
        /// <summary>
        /// Find all Possible Moves of a King of a side
        /// </summary>
        /// <param name="side"></param>
        /// <returns></returns>
        public static bool[,] FindAllKingCanMove(ChessState[,] arrState, eChessSide side, eChessSide ownside)
        {
            bool[,] Result = new bool[10, 10];
            ArrayList cantMoves = new ArrayList();
            int i, j;

            //Init Result
            for (i = 1; i < 9; i++)
                for (j = 1; j < 9; j++)
                    Result[i, j] = true;
            for (i = 0; i <= 9; i++)
            {
                Result[0, i] = false;
                Result[i, 0] = false;
                Result[9, i] = false;
                Result[i, 9] = false;
            }

            for (i = 1; i < 9; i++)
                for (j = 1; j < 9; j++)
                    if (arrState[i, j].Side != side)
                    {
                        if (arrState[i, j].Type == eChessPieceType.Bishop)
                            cantMoves = ChessPiece_Bishop.FindAllImposibleMoves(arrState, new Point(i, j));
                        else if (arrState[i, j].Type == eChessPieceType.King)
                            cantMoves = ChessPiece_King.FindAllImposibleMoves(arrState, new Point(i, j));
                        else if (arrState[i, j].Type == eChessPieceType.Knight)
                            cantMoves = ChessPiece_Knight.FindAllImposibleMoves(arrState, new Point(i, j));
                        else if (arrState[i, j].Type == eChessPieceType.Pawn)
                            cantMoves = ChessPiece_Pawn.FindAllImposibleMoves(arrState, new Point(i, j), ownside);
                        else if (arrState[i, j].Type == eChessPieceType.Queen)
                            cantMoves = ChessPiece_Queen.FindAllImposibleMoves(arrState, new Point(i, j));
                        else if (arrState[i, j].Type == eChessPieceType.Rook)
                            cantMoves = ChessPiece_Rook.FindAllImposibleMoves(arrState, new Point(i, j));

                        foreach (ChessMove p in cantMoves)
                            Result[p.MoveTo.X, p.MoveTo.Y] = false;
                    }

            return Result;
        }

        /// <summary>
        /// Check Is that one side is checked?
        /// </summary>
        /// <param name="arrState"></param>
        /// <param name="side"></param>
        /// <returns></returns>
        public static bool Checked(ChessState[,] arrState, eChessSide side, eChessSide ownside)
        {
            int i, j;
            ArrayList cantMoves = new ArrayList();

            for (i = 1; i < 9; i++)
                for (j = 1; j < 9; j++)
                    if (arrState[i, j].Side != side)
                    {
                        if (arrState[i, j].Type == eChessPieceType.Bishop)
                            cantMoves = ChessPiece_Bishop.FindAllPosibleMoves(arrState, new Point(i, j));
                        else if (arrState[i, j].Type == eChessPieceType.King)
                            cantMoves = ChessPiece_King.FindAllPosibleMoves(arrState, new Point(i, j), ownside);
                        else if (arrState[i, j].Type == eChessPieceType.Knight)
                            cantMoves = ChessPiece_Knight.FindAllPosibleMoves(arrState, new Point(i, j));
                        else if (arrState[i, j].Type == eChessPieceType.Pawn)
                            cantMoves = ChessPiece_Pawn.FindAllPosibleMoves(arrState, new Point(i, j), ownside);
                        else if (arrState[i, j].Type == eChessPieceType.Queen)
                            cantMoves = ChessPiece_Queen.FindAllPosibleMoves(arrState, new Point(i, j));
                        else if (arrState[i, j].Type == eChessPieceType.Rook)
                            cantMoves = ChessPiece_Rook.FindAllPosibleMoves(arrState, new Point(i, j));

                        foreach (ChessMove p in cantMoves)
                            if (arrState[p.MoveTo.X, p.MoveTo.Y].Side == side && arrState[p.MoveTo.X, p.MoveTo.Y].Type == eChessPieceType.King)
                                return true;
                    }

            return false;
        }

        public static ArrayList FindWhoCheckAndKingPosition(ChessState[,] arrState, eChessSide side, eChessSide ownside)
        {
            ArrayList WhoCheck = new ArrayList();
            ArrayList cantMoves = new ArrayList();
            int i, j;

            for (i = 1; i < 9; i++)
                for (j = 1; j < 9; j++)
                    if (arrState[i, j].Side != side)
                    {
                        if (arrState[i, j].Type == eChessPieceType.Bishop)
                            cantMoves = ChessPiece_Bishop.FindAllPosibleMoves(arrState, new Point(i, j));
                        else if (arrState[i, j].Type == eChessPieceType.King)
                            cantMoves = ChessPiece_King.FindAllPosibleMoves(arrState, new Point(i, j), ownside);
                        else if (arrState[i, j].Type == eChessPieceType.Knight)
                            cantMoves = ChessPiece_Knight.FindAllPosibleMoves(arrState, new Point(i, j));
                        else if (arrState[i, j].Type == eChessPieceType.Pawn)
                            cantMoves = ChessPiece_Pawn.FindAllPosibleMoves(arrState, new Point(i, j), ownside);
                        else if (arrState[i, j].Type == eChessPieceType.Queen)
                            cantMoves = ChessPiece_Queen.FindAllPosibleMoves(arrState, new Point(i, j));
                        else if (arrState[i, j].Type == eChessPieceType.Rook)
                            cantMoves = ChessPiece_Rook.FindAllPosibleMoves(arrState, new Point(i, j));

                        foreach (ChessMove p in cantMoves)
                            if (arrState[p.MoveTo.X, p.MoveTo.Y].Side == side && arrState[p.MoveTo.X, p.MoveTo.Y].Type == eChessPieceType.King)
                            {
                                WhoCheck.Add(p);
                                break;
                            }
                    }
 
            return WhoCheck;
        }

        /// <summary>
        /// Predict a move - return ChessState[,]
        /// </summary>
        /// <param name="State"></param>
        /// <param name="m"></param>
        /// <returns></returns>
        public static void PredictMove(ChessState[,] A, ChessMove m)
        {
            if (m.ChessPieceEated != eChessPieceType.Null)
            {
                A[m.MoveEated.X, m.MoveEated.Y].Type = eChessPieceType.Null;
            }

            A[m.MoveTo.X, m.MoveTo.Y].Side = A[m.MoveFrom.X, m.MoveFrom.Y].Side;
            A[m.MoveTo.X, m.MoveTo.Y].Type = A[m.MoveFrom.X, m.MoveFrom.Y].Type;
            A[m.MoveTo.X, m.MoveTo.Y].Moves = A[m.MoveFrom.X, m.MoveFrom.Y].Moves + 1;
            A[m.MoveFrom.X, m.MoveFrom.Y].Type = eChessPieceType.Null;

            if (m.HowMove == eMove.Castling)
            {
                if (m.MoveFrom.X  == m.MoveTo.X)
                {
                    if (m.MoveFrom.Y < m.MoveTo.Y)
                    {
                        //King side castling
                        A[m.MoveTo.X, 6].Side = A[m.MoveFrom.X, 8].Side;
                        A[m.MoveTo.X, 6].Type = A[m.MoveFrom.X, 8].Type;
                        A[m.MoveTo.X, 6].Moves = A[m.MoveFrom.X, 8].Moves + 1;

                        A[m.MoveTo.X, 8].Type = eChessPieceType.Null;
                    }
                    else
                    {
                        //Queen side castling
                        A[m.MoveTo.X, 4].Side = A[m.MoveFrom.X, 1].Side;
                        A[m.MoveTo.X, 4].Type = A[m.MoveFrom.X, 1].Type;
                        A[m.MoveTo.X, 4].Moves = A[m.MoveFrom.X, 1].Moves + 1;

                        A[m.MoveTo.X, 1].Type = eChessPieceType.Null;
                    }
                }
                else
                {
                    //promotion side castling 
                    if (m.MoveFrom.X == 1)
                    {
                        //Black
                        A[2, 5].Side = A[8, 5].Side;
                        A[2, 5].Type = A[8, 5].Type;
                        A[2, 5].Moves = A[8, 5].Moves + 1;
                        A[8, 5].Type = eChessPieceType.Null;
                    }
                    else
                    {
                        //White
                        A[7, 5].Side = A[1, 5].Side;
                        A[7, 5].Type = A[1, 5].Type;
                        A[7, 5].Moves = A[1, 5].Moves + 1;
                        A[1, 5].Type = eChessPieceType.Null;
                    }
                }
            }
            else if (m.HowMove == eMove.Promotion)
            {
                A[m.MoveTo.X, m.MoveTo.Y].Type = eChessPieceType.Queen;
                A[m.MoveTo.X, m.MoveTo.Y].Moves = 0;
            }
        }

        /// <summary>
        /// Unpredict a move - return a ChessState[,]
        /// </summary>
        /// <param name="A"></param>
        /// <param name="m"></param>
        /// <returns></returns>
        public static void UnPredictMove(ChessState[,] A, ChessMove m)
        {
            A[m.MoveFrom.X, m.MoveFrom.Y].Side = A[m.MoveTo.X, m.MoveTo.Y].Side;
            A[m.MoveFrom.X, m.MoveFrom.Y].Type = A[m.MoveTo.X, m.MoveTo.Y].Type;
            A[m.MoveFrom.X, m.MoveFrom.Y].Moves = m.FromMoves;
            A[m.MoveTo.X, m.MoveTo.Y].Type = eChessPieceType.Null;

            if (m.ChessPieceEated != eChessPieceType.Null)
            {
                A[m.MoveEated.X, m.MoveEated.Y].Side = eChessSide.Black;
                if (A[m.MoveFrom.X, m.MoveFrom.Y].Side == eChessSide.Black)
                    A[m.MoveEated.X, m.MoveEated.Y].Side = eChessSide.White;
                A[m.MoveEated.X, m.MoveEated.Y].Type = m.ChessPieceEated;
                A[m.MoveEated.X, m.MoveEated.Y].Moves = m.Moves;
            }

            if (m.HowMove == eMove.Castling)
            {
                if (m.MoveFrom.X == m.MoveTo.X)
                {
                    if (m.MoveFrom.Y < m.MoveTo.Y)
                    {
                        //King side castling
                        A[m.MoveFrom.X, 8].Side = A[m.MoveTo.X, 6].Side;
                        A[m.MoveFrom.X, 8].Type = A[m.MoveTo.X, 6].Type;
                        A[m.MoveFrom.X, 8].Moves= A[m.MoveTo.X, 6].Moves - 1;

                        A[m.MoveTo.X, 6].Type = eChessPieceType.Null;
                    }
                    else
                    {
                        //Queen side castling
                        A[m.MoveFrom.X, 1].Side = A[m.MoveTo.X, 4].Side;
                        A[m.MoveFrom.X, 1].Type = A[m.MoveTo.X, 4].Type;
                        A[m.MoveFrom.X, 1].Moves = A[m.MoveTo.X, 4].Moves - 1;

                        A[m.MoveTo.X, 4].Type = eChessPieceType.Null;
                    }
                }
                else
                {
                    //promotion side castling 
                    if (m.MoveFrom.X == 1)
                    {
                        //Black
                        A[8, 5].Side = A[2, 5].Side;
                        A[8, 5].Type = A[2, 5].Type;
                        A[8, 5].Moves = A[2, 5].Moves - 1;
                        A[2, 5].Type = eChessPieceType.Null;
                    }
                    else
                    {
                        //White
                        A[1, 5].Side = A[7, 5].Side;
                        A[1, 5].Type = A[7, 5].Type;
                        A[1, 5].Moves = A[7, 5].Moves - 1;
                        A[7, 5].Type = eChessPieceType.Null;
                    }
                }
            }
            else if (m.HowMove == eMove.Promotion)
            {
                A[m.MoveFrom.X, m.MoveFrom.Y].Type = eChessPieceType.Pawn;
            }
        }
        /// <summary>
        /// Find all possible Moves of a Chesspiece in position of a State
        /// </summary>
        /// <param name="arrState"></param>
        /// <param name="pos"></param>
        /// <returns></returns>
        public static ArrayList FindAllPosibleMoves(ChessState[,] arrState, Point pos, eChessSide ownside)
        {
            ArrayList arrMove = new ArrayList();

            switch (arrState[pos.X, pos.Y].Type)
            {
                case eChessPieceType.Bishop:
                    arrMove = ChessPiece_Bishop.FindAllPosibleMoves(arrState, pos);
                    break;
                case eChessPieceType.King:
                    arrMove = ChessPiece_King.FindAllPosibleMoves(arrState, pos, ownside);
                    break;
                case eChessPieceType.Knight:
                    arrMove = ChessPiece_Knight.FindAllPosibleMoves(arrState, pos);
                    break;
                case eChessPieceType.Pawn:
                    arrMove = ChessPiece_Pawn.FindAllPosibleMoves(arrState, pos, ownside);
                    break;
                case eChessPieceType.Queen:
                    arrMove = ChessPiece_Queen.FindAllPosibleMoves(arrState, pos);
                    break;
                case eChessPieceType.Rook:
                    arrMove = ChessPiece_Rook.FindAllPosibleMoves(arrState, pos);
                    break;
            }

            if (arrMove.Count == 0)
                return arrMove;

            ArrayList arr_CanMoves = new ArrayList();

            ChessState[,] NewState = new ChessState[10, 10];
            for (int i = 0; i <= 9; i++)
                for (int j = 0; j <= 9; j++)
                    NewState[i, j] = new ChessState(arrState[i, j].Type, arrState[i, j].Side, arrState[i, j].Moves);

            foreach (ChessMove m in arrMove)
            {
                //If one move that makes king will be checked -> remove 
                PredictMove(NewState, m);
                if (Checked(NewState, arrState[pos.X, pos.Y].Side, ownside) == false)
                    arr_CanMoves.Add(m);
                UnPredictMove(NewState, m);
            }

            return arr_CanMoves;
        }

        /// <summary>
        /// Find all possible Moves of a Chesspiece in position of a State but not check the Chess Rule 
        /// </summary>
        /// <param name="arrState"></param>
        /// <param name="pos"></param>
        /// <returns></returns>
        public static ArrayList FindAllPosibleMovesNotRule(ChessState[,] arrState, Point pos, eChessSide ownside)
        {
            ArrayList arrMove = new ArrayList();

            switch (arrState[pos.X, pos.Y].Type)
            {
                case eChessPieceType.Bishop:
                    arrMove = ChessPiece_Bishop.FindAllPosibleMoves(arrState, pos);
                    break;
                case eChessPieceType.King:
                    arrMove = ChessPiece_King.FindAllPosibleMoves(arrState, pos, ownside);
                    break;
                case eChessPieceType.Knight:
                    arrMove = ChessPiece_Knight.FindAllPosibleMoves(arrState, pos);
                    break;
                case eChessPieceType.Pawn:
                    arrMove = ChessPiece_Pawn.FindAllPosibleMoves(arrState, pos, ownside);
                    break;
                case eChessPieceType.Queen:
                    arrMove = ChessPiece_Queen.FindAllPosibleMoves(arrState, pos);
                    break;
                case eChessPieceType.Rook:
                    arrMove = ChessPiece_Rook.FindAllPosibleMoves(arrState, pos);
                    break;
            }

            
            return arrMove;
        }

        /// <summary>
        /// Find all Possible Moves of a side in a ChessState
        /// </summary>
        /// <param name="arrState"></param>
        /// <param name="side"></param>
        /// <returns></returns>
        public static ArrayList FindAllPosibleMoves(ChessState[,] arrState, eChessSide side, eChessSide ownside)
        {
            int i, j;
            ArrayList arrCanMoves = new ArrayList();
            ArrayList arrCanMovesTemp = new ArrayList();

            for (i = 1; i<=8; i++)
                for (j = 1; j<= 8; j++)
                    if (arrState[i,j].Type > 0 && arrState[i,j].Side == side)
                    {
                        arrCanMovesTemp = FindAllPosibleMoves(arrState, new Point(i, j), ownside);

                        foreach (ChessMove m in arrCanMovesTemp)
                            arrCanMoves.Add(m);
                    }

            return arrCanMoves;
        }

        /// <summary>
        ///  Find all possible Moves of a Chesspiece in position of a State but not check the Chess Rule
        /// </summary>
        /// <param name="arrState"></param>
        /// <param name="side"></param>
        /// <returns></returns>
        public static ArrayList FindAllPosibleMovesNotRule(ChessState[,] arrState, eChessSide side, eChessSide ownside)
        {
            int i, j;
            ArrayList arrCanMoves = new ArrayList();
            ArrayList arrCanMovesTemp = new ArrayList();

            for (i = 1; i <= 8; i++)
                for (j = 1; j <= 8; j++)
                    if (arrState[i, j].Type > 0 && arrState[i, j].Side == side)
                    {
                        arrCanMovesTemp = FindAllPosibleMovesNotRule(arrState, new Point(i, j), ownside);

                        foreach (ChessMove m in arrCanMovesTemp)
                            arrCanMoves.Add(m);
                    }

            return arrCanMoves;
        }

        /// <summary>
        /// Return a string representation position of a State
        /// </summary>
        /// <param name="arrState"></param>
        /// <returns></returns>
        public static string MakePosition(ChessState[,] arrState)
        {
            string res = "";
            int i, j;
            int count = 0;

            for (i = 1; i <= 8; i++)
                for (j = 1; j <= 8; j++)
                    if (arrState[i, j].Type > 0)
                    {
                        res += count.ToString();
                        count = 0;

                        char h = 'b';
                        switch (arrState[i, j].Type)
                        {
                            case eChessPieceType.Bishop:
                                h = 'b';
                                break;
                            case eChessPieceType.King:
                                h = 'k';
                                break;
                            case eChessPieceType.Knight:
                                h = 'n';
                                break;
                            case eChessPieceType.Pawn:
                                h = 'p';
                                break;
                            case eChessPieceType.Queen:
                                h = 'q';
                                break;
                            case eChessPieceType.Rook:
                                h = 'r';
                                break;
                        }

                        if (arrState[i, j].Side == eChessSide.White) h = (char)((int)h - 32);
                        res += h;
                    }
                    else count++;

            return res + count.ToString();
        }

        /// <summary>
        /// Check status of a this game before this side playing
        /// </summary>
        /// <param name="arrState"></param>
        /// <param name="side"></param>
        /// <returns></returns>
        public static GameStatus CheckGameStatus(ChessState[,] arrState, eChessSide side, Dictionary<string,int> arrPosition, eChessSide ownside)
        {
            //Draw because of similarity force
            int count_ChessMan = 0;
            int count_BiShop_Knight = 0;
            int i, j;

            for (i = 1; i <= 8; i++)
                for (j = 1; j<= 8; j++)
                    if (arrState[i,j].Type > 0)
                    {
                        count_ChessMan++;
                        if (arrState[i, j].Type == eChessPieceType.Bishop || arrState[i, j].Type == eChessPieceType.Knight)
                            count_BiShop_Knight++;
                    }
            if (count_ChessMan == 2 || (count_ChessMan == 3 && count_BiShop_Knight == 1))
                return new GameStatus(eGameStatus.Draw, eGameEndReason.DrawCantCheckmate);


            //Check that a position is repeated 3 times -> draw
            string h = MakePosition(arrState);

            if (arrPosition.Count > 0 && arrPosition[h] >= 3)
                return new GameStatus(eGameStatus.Draw, eGameEndReason.Draw3TimesRepeat);


            //Check Check and Checkmate 
            int Count_All_Possible_move_of_all_Piece = 0;
            for (i = 1; i <= 8; i++)
                for (j = 1; j <= 8; j++)
                    if (arrState[i, j].Side == side && arrState[i, j].Type > 0)
                        Count_All_Possible_move_of_all_Piece += FindAllPosibleMoves(arrState, new Point(i, j), ownside).Count;

            if (Checked(arrState, side, ownside) == true)
            {
                if (Count_All_Possible_move_of_all_Piece == 0)
                {
                    if (side == eChessSide.Black) return new GameStatus(eGameStatus.WhiteWin, eGameEndReason.WinCheckmate);
                    else return new GameStatus(eGameStatus.BlackWin, eGameEndReason.WinCheckmate);
                }
                else
                    return new GameStatus(eGameStatus.Playing, eGameEndReason.PlayingCheck);
            }
            else
            {
                if (Count_All_Possible_move_of_all_Piece == 0)
                    return new GameStatus(eGameStatus.Draw, eGameEndReason.DrawOutOfMove);
            }
            
            return new GameStatus(eGameStatus.Playing, eGameEndReason.Playing);
        }
        #endregion

        #region Game AI

        /// <summary>
        /// Value of each ChessPiece
        /// </summary>
        private enum PieceValue
        {
            Pawn = 100,
            Bishop = 330,
            Knight = 320,
            Rook = 500,
            Queen = 900,
            King = 40000
        }

        /* 
        * Speelman considers that endgames are positions in which each player has 13
        * or fewer points in material (not counting the king)- wikipedia
        * 
        * Khi giá trị quân cờ của mỗi đối thủ nhỏ hơn hoặc bằng 13(khoảng 1350 điểm)=>EndGame
        */
        /// <summary>
        /// Check that the game is gonna be ended
        /// </summary>
        /// <param name="arrState"></param>
        /// <param name="side"></param>
        /// <returns></returns>
        private static bool IsEndGame(ChessState[,] arrState, eChessSide side)
        {
            int myScore = 0;
            int opScore = 0;
            int i, j;

            for (i = 0; i<=8; i++)
                for (j = 0; j<=8; j++)
                    if (arrState[i,j].Type > 0)
                    {
                        if (arrState[i, j].Side == side)
                        {
                            switch (arrState[i,j].Type)
                            {
                                case eChessPieceType.Bishop: myScore += (int)PieceValue.Bishop; break;
                                case eChessPieceType.Knight: myScore += (int)PieceValue.Knight; break;
                                case eChessPieceType.Pawn  : myScore += (int)PieceValue.Pawn; break;
                                case eChessPieceType.Queen : myScore += (int)PieceValue.Queen; break;
                                case eChessPieceType.Rook  : myScore += (int)PieceValue.Rook; break;
                            }
                        }
                        else
                        {
                            switch (arrState[i, j].Type)
                            {
                                case eChessPieceType.Bishop: opScore += (int)PieceValue.Bishop; break;
                                case eChessPieceType.Knight: opScore += (int)PieceValue.Knight; break;
                                case eChessPieceType.Pawn  : opScore += (int)PieceValue.Pawn; break;
                                case eChessPieceType.Queen : opScore += (int)PieceValue.Queen; break;
                                case eChessPieceType.Rook  : opScore += (int)PieceValue.Rook; break;
                            }
                        }
                    }

            return myScore <= 1350 && opScore <= 1350;
        }

        /// <summary>
        /// Evaluate value of ChessBoard for a side
        /// </summary>
        /// <param name="arrState"></param>
        /// <param name="myside"></param>
        /// <returns></returns>
        private static int EvaluateChessBoard(ChessState[,] arrState, eChessSide myside)
        {
            int value = 0;
            eChessSide opSide = eChessSide.Black;
            if (myside == eChessSide.Black) opSide = eChessSide.White;

            bool isGonnaDraw = true;
            bool isEndGame = IsEndGame(arrState, myside);
            int countMyKnight = 0;
            int countOpKnight = 0;

            bool myWhiteBishopAvailable = false;
            bool myBlackBishopAvailable = false;
            bool opWhiteBishopAvailable = false;
            bool opBlackBishopAvailable = false;

            int i, j;
            for (i= 1; i<=8; i++)
                for (j = 1; j<= 8; j++)
                    if (arrState[i,j].Type > 0)
                    {
                        if (arrState[i, j].Side == myside)
                        {
                            switch (arrState[i, j].Type)
                            {
                                case eChessPieceType.Bishop:
                                    value += (int)PieceValue.Bishop;
                                    value += ChessPiece_Bishop.GetPositionValue(new Point(i,j), myside, _ownSide);
                                    if ((i + j) % 2 == 0) myBlackBishopAvailable = true;
                                    else myWhiteBishopAvailable = true;
                                    break;
                                case eChessPieceType.Knight:
                                    value += (int)PieceValue.Knight;
                                    value += ChessPiece_Knight.GetPositionValue(new Point(i, j), myside, _ownSide);
                                    countMyKnight += 1;
                                    break;
                                case eChessPieceType.Pawn:
                                    value += (int)PieceValue.Pawn;
                                    value += ChessPiece_Pawn.GetPositionValue(new Point(i, j), myside, _ownSide);
                                    isGonnaDraw = false;
                                    break;
                                case eChessPieceType.Queen:
                                    value += (int)PieceValue.Queen;
                                    value += ChessPiece_Queen.GetPositionValue(new Point(i, j), myside, _ownSide);
                                    isGonnaDraw = false;
                                    break;
                                case eChessPieceType.Rook:
                                    value += (int)PieceValue.Rook;
                                    value += ChessPiece_Rook.GetPositionValue(new Point(i, j), myside, _ownSide);
                                    isGonnaDraw = false;
                                    break;
                                case eChessPieceType.King:
                                    value += (int)PieceValue.King;
                                    value += ChessPiece_King.GetPositionValue(new Point(i, j), myside, isEndGame, _ownSide);
                                    break;
                            }
                        }
                        else
                        {
                            switch (arrState[i, j].Type)
                            {
                                case eChessPieceType.Bishop:
                                    value -= (int)PieceValue.Bishop;
                                    value -= ChessPiece_Bishop.GetPositionValue(new Point(i, j), opSide, _ownSide);
                                    if ((i + j) % 2 == 0) opBlackBishopAvailable = true;
                                    else opWhiteBishopAvailable = true;
                                    break;
                                case eChessPieceType.Knight:
                                    value -= (int)PieceValue.Knight;
                                    value -= ChessPiece_Knight.GetPositionValue(new Point(i, j), opSide, _ownSide);
                                    countOpKnight += 1;
                                    break;
                                case eChessPieceType.Pawn:
                                    value -= (int)PieceValue.Pawn;
                                    value -= ChessPiece_Pawn.GetPositionValue(new Point(i, j), opSide, _ownSide);
                                    isGonnaDraw = false;
                                    break;
                                case eChessPieceType.Queen:
                                    value -= (int)PieceValue.Queen;
                                    value -= ChessPiece_Queen.GetPositionValue(new Point(i, j), opSide, _ownSide);
                                    isGonnaDraw = false;
                                    break;
                                case eChessPieceType.Rook:
                                    value -= (int)PieceValue.Rook;
                                    value -= ChessPiece_Rook.GetPositionValue(new Point(i, j), opSide, _ownSide);
                                    isGonnaDraw = false;
                                    break;
                                case eChessPieceType.King:
                                    value -= (int)PieceValue.King;
                                    value -= ChessPiece_King.GetPositionValue(new Point(i, j), opSide, isEndGame, _ownSide);
                                    break;
                            }
                        }
                    }

            /* 2 Bishop is useful for us 
               Bishop is more useful than knight in the end

               The game is not draw when 
               - 1 of each player has Pawn or Rook or Queen
               - 1 of each player has 2 Knight or 2 Bishop in different color 
               - 1 of each player has 1 Knight and 1 Bishop
            */

            if (countMyKnight > 1 || countOpKnight > 1)
                isGonnaDraw = false;
            if ((countMyKnight >= 1 && (myBlackBishopAvailable || myWhiteBishopAvailable)) || (countOpKnight >= 1 && (opBlackBishopAvailable || opWhiteBishopAvailable)))
                isGonnaDraw = false;
            if (myBlackBishopAvailable && myWhiteBishopAvailable)
            {
                value += 10;
                isGonnaDraw = false;
            }

            if (opWhiteBishopAvailable && opBlackBishopAvailable)
            {
                value -= 10;
                isGonnaDraw = false;
            }

            if ((opBlackBishopAvailable && myWhiteBishopAvailable) || (opWhiteBishopAvailable && myBlackBishopAvailable))
                isGonnaDraw = false;

            if (isGonnaDraw)
                return 0;

            if (isEndGame)
            {
                if (countMyKnight > 1)
                    value -= 10;
                if (countOpKnight > 1)
                    value += 10;

                if (myBlackBishopAvailable || myWhiteBishopAvailable)
                    value += 10;
                if (opBlackBishopAvailable || opWhiteBishopAvailable)
                    value -= 10;
            }

            return value;
        }

        #region Sort
        public struct Score
        {
            public int value;
            public int position;
        };

        /// <summary>
        /// Sort arrCanMoves to make Alpha Beta more faster
        /// </summary>
        /// <param name="arrState"></param>
        /// <param name="arrcanmoves"></param>
        /// <param name="side"></param>
        public static ArrayList SortChessMoves(ChessState[,] arrState, ArrayList arrcanmoves, eChessSide side)
        {
            int i;
            ArrayList arrSort = new ArrayList();
            if (arrcanmoves.Count == 0)
                return arrSort;

            Score[] score = new Score[arrcanmoves.Count];

            for(i = 0; i < arrcanmoves.Count; i++)
            {
                ChessMove m = (ChessMove)arrcanmoves[i];
                score[i].value = (int)m.ChessPieceEated;
                score[i].position = i;
            }

            Array.Sort(score, (x, y) => x.value.CompareTo(y.value));

            for (i = 0; i < arrcanmoves.Count; i++)
                arrSort.Add((ChessMove)arrcanmoves[score[i].position]);

            return arrSort;
        }
        #endregion

        /// <summary>
        /// Alpha beta fail hard version
        /// </summary>
        /// <param name="arrState"></param>
        /// <param name="arrposition"></param>
        /// <param name="depth"></param>
        /// <param name="side"></param>
        /// <param name="alpha"></param>
        /// <param name="beta"></param>
        /// <returns></returns>
        public static int AlphaBeta(ChessState[,] arrState, Dictionary<string, int> arrposition, int depth, eChessSide side, int alpha, int beta)
        {
            int bestScore = EvaluateChessBoard(arrState, side);
            if (depth == 0) return bestScore;
            if (bestScore < _lowestScore) return bestScore;

            bestScore = alpha;
            ChessMove bestMove = null;

            //Find all possible moves of this side => sort this to make alpha beta be faster 
            ArrayList arrCanMoves = new ArrayList();
            if (depth > 1) arrCanMoves = SortChessMoves(arrState, FindAllPosibleMovesNotRule(arrState, side, _ownSide), side);
            else arrCanMoves = FindAllPosibleMovesNotRule(arrState, side, _ownSide);

            //If no more moves 
            if (arrCanMoves.Count == 0)
            {
                //opSide win 
                if (Checked(arrState, _mySide, _ownSide) == true)
                {
                    if (side == _mySide)
                        return _lowestScore;
                    else
                        return -_lowestScore;
                }
                   
                //mySide win
                if (Checked(arrState, _opSide, _ownSide) == true)
                {
                    if (side == _mySide)
                        return -_lowestScore;
                    else
                        return _lowestScore;
                }

                //Draw
                return 0;
            }

            while (arrCanMoves.Count > 0 && bestScore < beta)
            {
                //Pop a ChessMove
                ChessMove m = (ChessMove)arrCanMoves[arrCanMoves.Count - 1];
                arrCanMoves.RemoveAt(arrCanMoves.Count - 1);

                //Compute new State after move
                PredictMove(arrState, m);

                //Add this Position 
                string newPosition = MakePosition(arrState);
                if (arrposition.ContainsKey(newPosition))
                    arrposition[newPosition]++;
                else arrposition.Add(newPosition, 1);

                //Another side's move
                eChessSide newSide = eChessSide.Black;
                if (newSide == side) newSide = eChessSide.White;

                //Next move genneration 
                int value = 0;
                if (arrposition[newPosition] < 3)
                    value = -AlphaBeta(arrState, arrposition, depth - 1, newSide, -beta, -alpha);

                UnPredictMove(arrState, m);

                //Undo this Position 
                if (arrposition[newPosition] > 1)
                    arrposition[newPosition] -= 1;
                else
                    arrposition.Remove(newPosition);

           
                //Update best
                if (value > bestScore)
                {
                    bestScore = value;
                    bestMove = m;

                    if (depth == _maxDepth)
                    {
                        if (_myBestScore < bestScore)
                        {
                            _myBestScore = bestScore;
                            _myBestMove = bestMove;
                        }   
                    }

                    if (value > alpha)
                        alpha = value;
                    if (value >= beta)
                    {
                        bestScore = beta;
                        beta = bestScore - 1;
                    }
                }
            }
            //_myBestMove = bestMove;
            return bestScore;
        }

        /// <summary>
        /// Make a random move
        /// </summary>
        /// <param name="arrState"></param>
        /// <param name="side"></param>
        /// <returns></returns>
        public static ChessMove RandomMove(ChessState[,] arrState, eChessSide side, eChessSide ownside)
        {
            ArrayList arrCanMoves = FindAllPosibleMoves(arrState, side, ownside);

            if (arrCanMoves.Count == 0)
                return null;

            Random rd = new Random(arrCanMoves.Count);

            return (ChessMove)arrCanMoves[rd.Next(arrCanMoves.Count)];
        }

        public static ChessMove MakeAComputerMove(ChessState[,] arrState, eChessSide side, Dictionary<string,int> arrPosition, eGameDifficulty difficult, eChessSide ownside)
        {
            _myBestMove = null;
            _myBestScore = _lowestScore;

            if (difficult == eGameDifficulty.Hard)
                _maxDepth = 5;
            else if (difficult == eGameDifficulty.Normal)
                _maxDepth = 4;
            else _maxDepth = 3;

            _mySide = side;
            _opSide = eChessSide.Black;
            if (_mySide == eChessSide.Black)
                _opSide = eChessSide.White;
            _ownSide = ownside;

            if (FindAllPosibleMoves(arrState, _mySide, _ownSide).Count + FindAllPosibleMoves(arrState, _opSide, _ownSide).Count < 30)
                _maxDepth = 5;

            ChessState[,] NewState = new ChessState[10,10];
            for (int i = 0; i <= 9; i++)
                for (int j = 0; j <= 9; j++)
                    NewState[i, j] = new ChessState(arrState[i, j].Type, arrState[i, j].Side, arrState[i, j].Moves);

            AlphaBeta(NewState, arrPosition, _maxDepth, _mySide, _lowestScore, -_lowestScore);

            /*
            PredictMove(NewState, _myBestMove);
            if (Checked(NewState, _mySide) == false)
                return _myBestMove;
            
            return RandomMove(State,side);*/
            return _myBestMove;
        }
        #endregion
    }
}
