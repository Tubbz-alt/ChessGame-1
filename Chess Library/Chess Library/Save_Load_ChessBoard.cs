using System;
using System.Collections;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Runtime.Serialization.Formatters.Binary;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml.Serialization;

namespace Chess_Library
{
    [System.Serializable]
    public class Save_Load_ChessBoard
    {
        #region Declare variables
        private bool loaded = true;
        public ChessState[,] SaveThisState;
        private eGameStatus gameStatus;
        private eGameEndReason gameStatusReason;
        private eChessSide whoTurn;
        public ArrayList arrWhoCheck;
        public Stack<ChessMove> stkUndo;
        public Stack<ChessMove> stkRedo;
        public Stack<String> stkChessMoveString;
        public Stack<Bitmap_Side_ChessPieceEated> stkChessPieceEated;
        private bool clear_Stack_Redo;
        private Point positionLastMove;
        private Point positionChoosen;
        public Dictionary<string, int> arrPosition;
        private eChessSide _ownSide;
        private eGameMode _gameMode;
        private eGameDifficulty _gameDifficulty;
        private short _min1;
        private short _min2;
        private short _sec1;
        private short _sec2;

        public eGameStatus GameStatus
        {
            get
            {
                return gameStatus;
            }

            set
            {
                gameStatus = value;
            }
        }

        public eGameEndReason GameStatusReason
        {
            get
            {
                return gameStatusReason;
            }

            set
            {
                gameStatusReason = value;
            }
        }

        public eChessSide WhoTurn
        {
            get
            {
                return whoTurn;
            }

            set
            {
                whoTurn = value;
            }
        }

        public Point PositionChoosen
        {
            get
            {
                return positionChoosen;
            }

            set
            {
                positionChoosen = value;
            }
        }

        public bool Clear_Stack_Redo
        {
            get
            {
                return clear_Stack_Redo;
            }

            set
            {
                clear_Stack_Redo = value;
            }
        }

        public Point PositionLastMove
        {
            get
            {
                return positionLastMove;
            }

            set
            {
                positionLastMove = value;
            }
        }

        public eChessSide OwnSide
        {
            get
            {
                return _ownSide;
            }

            set
            {
                _ownSide = value;
            }
        }

        public eGameMode GameMode
        {
            get
            {
                return _gameMode;
            }

            set
            {
                _gameMode = value;
            }
        }

        public eGameDifficulty GameDifficulty
        {
            get
            {
                return _gameDifficulty;
            }

            set
            {
                _gameDifficulty = value;
            }
        }

        public bool Loaded
        {
            get
            {
                return loaded;
            }

            set
            {
                loaded = value;
            }
        }

        public short Min1
        {
            get
            {
                return _min1;
            }

            set
            {
                _min1 = value;
            }
        }

        public short Min2
        {
            get
            {
                return _min2;
            }

            set
            {
                _min2 = value;
            }
        }

        public short Sec1
        {
            get
            {
                return _sec1;
            }

            set
            {
                _sec1 = value;
            }
        }

        public short Sec2
        {
            get
            {
                return _sec2;
            }

            set
            {
                _sec2 = value;
            }
        }
        #endregion

        #region Constructor
        public Save_Load_ChessBoard()
        {

        }

        public Save_Load_ChessBoard(Uc_ChessBoard board, Uc_CountDownTimer timer1, Uc_CountDownTimer timer2)
        {
            //Save Chess Board
            this.SaveThisState = new ChessState[10, 10];

            int i, j;
            for (i = 0; i < 10; i++)
                for (j = 0; j < 10; j++)
                    SaveThisState[i, j] = new ChessState(board.arrState[i, j].Type, board.arrState[i, j].Side, board.arrState[i, j].Moves);

            this.GameStatus = board.GameStatus;
            this.GameStatusReason = board.GameStatusReason;
            this.WhoTurn = board.WhoTurn;
            this.arrWhoCheck = board.arrWhoCheck;
            this.stkUndo = board.stkUndo;
            this.stkRedo = board.stkRedo;
            this.stkChessMoveString = board.stkChessMoveString;
            this.stkChessPieceEated = board.stkChessPieceEated;
            this.clear_Stack_Redo = board.clear_Stack_Redo;
            this.PositionLastMove = new Point(Uc_ChessBoard.PositionLastMove.X, Uc_ChessBoard.PositionLastMove.Y);
            this.PositionChoosen = new Point(board.PositionChoosen.X, board.PositionChoosen.Y);
            this.arrPosition = board.arrPosition;
            this.OwnSide = board.OwnSide;
            this.GameMode = board.GameMode;
            this.GameDifficulty = board.GameDifficulty;

            //Save Timer
            this.Min1 = timer1.Min;
            this.Sec1 = timer1.Sec;
            this.Min2 = timer2.Min;
            this.Sec2 = timer2.Sec;
        }
        #endregion

        public void Save()
        {
            SaveFileDialog dialog = new SaveFileDialog();
            dialog.Filter = "DAT-File | *.dat";
            string path;

            try
            {
                if (dialog.ShowDialog() == DialogResult.OK)
                {
                    path = dialog.FileName;
                    //path = path.Substring(0, path.LastIndexOf('\\'));

                    using (Stream stream = File.Open(path, FileMode.Append))
                    {
                        var binaryFormatter = new BinaryFormatter();
                        binaryFormatter.Serialize(stream, this);
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        public Save_Load_ChessBoard Load()
        {
            try
            {
                OpenFileDialog dialog = new OpenFileDialog();
                dialog.Filter = "DAT-File | *.dat";
                string path;

                if (dialog.ShowDialog() == DialogResult.OK)
                {
                    path = dialog.FileName;

                    using (Stream stream = File.Open(path, FileMode.Open))
                    {
                        var binaryFormatter = new BinaryFormatter();
                        return (Save_Load_ChessBoard)binaryFormatter.Deserialize(stream);
                    }
                }
            }
            catch (Exception ex)
            {
                //MessageBox.Show(ex.Message);
            }

            this.Loaded = false;
            return this;
        }
    }
}
