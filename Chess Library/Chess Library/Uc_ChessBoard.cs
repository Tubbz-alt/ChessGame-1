using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Collections;
using System.Threading;
using System.Reflection;
using System.Resources;
using System.Globalization;
using System.Media;

namespace Chess_Library
{
    #region Declare enum
    public enum eChessSide
    {
        Black = 1,
        White = 2
    }

    public enum eGameDifficulty
    {
        Easy = 1,
        Normal = 2,
        Hard = 3
    }

    public enum eChessPieceType // ChessMan
    {
        CantMove = -1, // Rìa bàn cờ
        Null = 0, // Không có quân cờ 
        Pawn = 1, //Tốt
        Bishop = 2, //Tượng 
        Knight = 3, //Mã 
        Rook = 4, //Xe
        Queen = 5, //Hậu
        King = 6 // Vua
    }

    public enum eChessPieceStyle //ChessMan
    {
        Classic1 = 1,
        Classic2 = 2,
        Wooden3D = 3,
        Plastic = 4
    }

    public enum eChessBoardStyle
    {
        BoardEdge = 1,
        Wooden = 2,
        Metal = 3,
        BlueMarble = 4,
        TanMarble = 5,
        GreenMarble = 6,
        Granite = 7,
        Brick = 8
    }

    public enum eGameMode
    {
        VsHuman = 1,
        VsComputer = 2,
        VsNetWorkPlayer = 3,
        ComVsCom = 4
    }

    public enum eGameStatus
    {
        Playing = 0,
        BlackWin = 1,
        WhiteWin = 2,
        Draw = 3 // Hòa
    }

    public enum eMove
    {
        Eating,
        Moving,
        EnPassant,
        Castling,
        Promotion
    }

    public enum eGameEndReason
    {
        //WIn
        WinCheckmate, // When king can't escape 
        WinOutOfTime, // When a player runs out of Time
        WinGiveUp, //When a player give up
        //Draw
        DrawOutOfMove, //When no check and a player can't move
        DrawAcceptDraw, //Opponent accept to draw
        DrawCantCheckmate, // when only have (king - king ) or (king + knight - king) or (king + bishop - king)
        Draw3TimesRepeat, //When 3 times chessboard repeat
        //Draw50MovesPawnNoMoveAndNoeating, //When 50 Moves and there 's  no chessPiece was eated and no Pawn moves
        //Playing
        Playing,
        PlayingCheck,
    }
    #endregion

    public partial class Uc_ChessBoard : UserControl
    {
        #region Declare variables
        private CultureInfo _language = new CultureInfo("vi");
        Bitmap bmpBackImage;
        private Bitmap _blackCellBitmap;
        private Bitmap _whiteCellBitmap;
        private int _cellSize, _pieceSize;
        private eChessPieceStyle _pieceStyle;
        private eChessSide _ownSide = eChessSide.White;
        private eChessSide _opSide = eChessSide.Black;
        private eChessBoardStyle _boardStyle = eChessBoardStyle.Wooden;
        private eGameMode _gameMode;
        private eGameStatus _gameStatus = eGameStatus.Playing;
        private eGameEndReason _gameStatusReason = eGameEndReason.Playing;
        private eGameDifficulty _gameDifficulty = eGameDifficulty.Normal;

        private bool _playSound = true;
        public static bool _isCapturingMode = false;
        private eChessSide _whoTurn = eChessSide.White;
        private bool alreadyMakeMove = false;
        private Bitmap _boardBitmap;

        public ArrayList arrCanMove = new ArrayList();
        public ArrayList arrWhoCheck = new ArrayList();

        public Stack<ChessMove> stkUndo = new Stack<ChessMove>();
        public Stack<ChessMove> stkRedo = new Stack<ChessMove>();
        public Stack<Bitmap_Side_ChessPieceEated> stkChessPieceEated = new Stack<Bitmap_Side_ChessPieceEated>();
        public Stack<string> stkChessMoveString = new Stack<string>();
        public bool clear_Stack_Redo = true;

        public ChessState[,] arrState = new ChessState[10, 10]; //Save state of ChessBoard 
        public Uc_ChessCell[,] arrChessCell = new Uc_ChessCell[9, 9]; //Array of Chess cells 

        private Point _positionChoosen = new Point(0, 0); // position of Chess cell is choosing 
        private static Point _positionLastMove = new Point(0, 0); //position of Chess cell last Move From 
        public Dictionary<string, int> arrPosition = new Dictionary<string, int>(); // Save each ChessBoard position
        SoundPlayer _capturedSound = new SoundPlayer(Properties.Resources.Capture);
        SoundPlayer _movedSound = new SoundPlayer(Properties.Resources.Move);


        //Property
        public eChessBoardStyle BoardStyle
        {
            get
            {
                return _boardStyle;
            }

            set
            {
                _boardStyle = value;
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

        public eGameStatus GameStatus
        {
            get
            {
                return _gameStatus;
            }

            set
            {
                _gameStatus = value;
            }
        }



        public eChessPieceStyle PieceStyle
        {
            get
            {
                return _pieceStyle;
            }

            set
            {
                _pieceStyle = value;
            }
        }

        public bool PlaySound
        {
            get
            {
                return _playSound;
            }

            set
            {
                _playSound = value;
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

        public Point PositionChoosen
        {
            get
            {
                return _positionChoosen;
            }

            set
            {
                _positionChoosen = value;
            }
        }

        public Bitmap BoardBitmap
        {
            get
            {
                return _boardBitmap;
            }

            set
            {
                _boardBitmap = value;
            }
        }

        public static Point PositionLastMove
        {
            get
            {
                return _positionLastMove;
            }

            set
            {
                _positionLastMove = value;
            }
        }

        public eChessSide WhoTurn
        {
            get
            {
                return _whoTurn;
            }

            set
            {
                _whoTurn = value;
            }
        }

        public eGameEndReason GameStatusReason
        {
            get
            {
                return _gameStatusReason;
            }

            set
            {
                _gameStatusReason = value;
            }
        }

        public CultureInfo Language
        {
            get
            {
                return _language;
            }

            set
            {
                _language = value;
            }
        }

        public eChessSide OpSide
        {
            get
            {
                return _opSide;
            }

            set
            {
                _opSide = value;
            }
        }

        public bool AlreadyMakeMove
        {
            get
            {
                return alreadyMakeMove;
            }

            set
            {
                alreadyMakeMove = value;
            }
        }
        #endregion

        #region Constructor 
        public Uc_ChessBoard()
        {
            InitializeComponent();
        }

        public Uc_ChessBoard(eChessBoardStyle boardstyle, eChessPieceStyle piecestyle, eChessSide ownside, eGameMode gamemode, 
                             int cellsize, int piecesize, bool playsound, CultureInfo language)
        {
            InitializeComponent();

            this.Size = new Size(cellsize * 8, cellsize * 8);
            this._blackCellBitmap = Read_Image_From_Resources.GetChessBoardBitMap(eChessSide.Black, boardstyle);
            this._whiteCellBitmap = Read_Image_From_Resources.GetChessBoardBitMap(eChessSide.White, boardstyle);

            this._cellSize = cellsize;
            this._pieceSize = piecesize;
            this._pieceStyle = piecestyle;
            this._boardStyle = boardstyle;
            this._playSound = playsound;
            this._ownSide = ownside;
            this._opSide = eChessSide.Black;
            if (this._ownSide == eChessSide.Black)
                this._opSide = eChessSide.White;
            this._gameMode = gamemode;
            this.Language = language;

            CreateChessBoard();
            AddChessPiece(this._pieceStyle, this.arrState);

            WhoTurn = eChessSide.White;
            if (this._ownSide != WhoTurn && this.GameMode == eGameMode.VsComputer)
                Computer_Move();
        }

        public Uc_ChessBoard(eChessBoardStyle boardStyle, eChessPieceStyle piecestyle, eChessSide ownside, eGameMode gamemode,
                             int cellsize, int piecesize, bool playsound, CultureInfo language, ChessState[,] State)
        {
            InitializeComponent();

            this.Size = new Size(cellsize * 8, cellsize * 8);
            this._blackCellBitmap = Read_Image_From_Resources.GetChessBoardBitMap(eChessSide.Black, boardStyle);
            this._whiteCellBitmap = Read_Image_From_Resources.GetChessBoardBitMap(eChessSide.White, boardStyle);

            this._cellSize = cellsize;
            this._pieceSize = piecesize;
            this._pieceStyle = piecestyle;
            this._boardStyle = boardStyle;
            this._playSound = playsound;
            this._ownSide = ownside;
            this._opSide = eChessSide.Black;
            if (this._ownSide == eChessSide.Black)
                this._opSide = eChessSide.White;
            this._gameMode = gamemode;
            this.Language = language;

            CreateChessBoard(State);
            AddChessPiece(this._pieceStyle, this.arrState);

            WhoTurn = eChessSide.White;
        }

        public Uc_ChessBoard(eChessBoardStyle boardstyle, eChessPieceStyle piecestyle, eChessSide ownside, eGameMode gamemode,
                             eGameDifficulty GameDifficulty, int CellSize, int PieceSize, bool PlaySound, CultureInfo Language)
        {
            InitializeComponent();

            this.Size = new Size(CellSize * 8, CellSize * 8);
            this._blackCellBitmap = Read_Image_From_Resources.GetChessBoardBitMap(eChessSide.Black, boardstyle);
            this._whiteCellBitmap = Read_Image_From_Resources.GetChessBoardBitMap(eChessSide.White, boardstyle);

            this._cellSize = CellSize;
            this._pieceSize = PieceSize;
            this._pieceStyle = piecestyle;
            this._boardStyle = boardstyle;
            this._playSound = PlaySound;
            this._ownSide = ownside;
            this._opSide = eChessSide.Black;
            if (this._ownSide == eChessSide.Black)
                this._opSide = eChessSide.White;
            this._gameMode = gamemode;
            this._gameDifficulty = GameDifficulty;
            this.Language = Language;

            CreateChessBoard();
            AddChessPiece(this._pieceStyle, this.arrState);

            if (this.OwnSide == eChessSide.Black)
                OpSide = eChessSide.White;

            WhoTurn = eChessSide.White;
            if (this._ownSide != WhoTurn && this.GameMode == eGameMode.VsComputer)
                Computer_Move();
        }

        public Uc_ChessBoard(eChessBoardStyle boardstyle, eChessPieceStyle piecestyle, eChessSide ownside, eGameMode gamemode,
                             eGameDifficulty gamesifficulty, int cellsize, int piecesize, bool playsound, CultureInfo language, ChessState[,] State)
        {
            InitializeComponent();

            this.Size = new Size(cellsize * 8, cellsize * 8);
            this._blackCellBitmap = Read_Image_From_Resources.GetChessBoardBitMap(eChessSide.Black, boardstyle);
            this._whiteCellBitmap = Read_Image_From_Resources.GetChessBoardBitMap(eChessSide.White, boardstyle);

            this._cellSize = cellsize;
            this._pieceSize = piecesize;
            this._pieceStyle = piecestyle;
            this._boardStyle = boardstyle;
            this._playSound = playsound;
            this._ownSide = ownside;
            this._opSide = eChessSide.Black;
            if (this._ownSide == eChessSide.Black)
                this._opSide = eChessSide.White;
            this._gameMode = gamemode;
            this._gameDifficulty = gamesifficulty;
            this.Language = language;

            CreateChessBoard(State);
            AddChessPiece(this._pieceStyle, this.arrState);

            if (this.OwnSide == eChessSide.Black)
                OpSide = eChessSide.White;

            WhoTurn = eChessSide.White;
        }

        public void CreateChessBoard()
        {
            int i, j;
            Uc_ChessCell Cell;

            for (i = 1; i < 9; i++)
            {
                for (j = 1; j < 9; j++)
                {
                    if ((i + j) % 2 == 0) // White Cell
                        Cell = new Uc_ChessCell(new Point(i, j), this._whiteCellBitmap, eChessSide.White, this._boardStyle);
                    else
                        Cell = new Uc_ChessCell(new Point(i, j), this._blackCellBitmap, eChessSide.Black, this._boardStyle);

                    Cell.Size = new Size(this._cellSize, this._cellSize);

                    Cell.Name = Convert.ToChar(64 + i).ToString() + (9 - j);

                    Cell.Location = new Point((j - 1) * this._cellSize, (i - 1) * this._cellSize);

                    arrChessCell[i, j] = Cell;

                    this.Controls.Add(Cell);
                }
            }
            InitBoardState();
        }

        public void CreateChessBoard(ChessState[,] State)
        {
            int i, j;
            Uc_ChessCell Cell;

            for (i = 1; i < 9; i++)
            {
                for (j = 1; j < 9; j++)
                {
                    if ((i + j) % 2 == 0) // White Cell
                        Cell = new Uc_ChessCell(new Point(i, j), this._whiteCellBitmap, eChessSide.White, this._boardStyle);
                    else
                        Cell = new Uc_ChessCell(new Point(i, j), this._blackCellBitmap, eChessSide.Black, this._boardStyle);

                    Cell.Size = new Size(this._cellSize, this._cellSize);

                    Cell.Name = Convert.ToChar(64 + i).ToString() + (9 - j);

                    Cell.Location = new Point((j - 1) * this._cellSize, (i - 1) * this._cellSize);

                    arrChessCell[i, j] = Cell;

                    this.Controls.Add(Cell);
                }
            }
            InitBoardState(State);
        }

        public void AddChessPiece(eChessPieceStyle PieceStyle, ChessState[,] State)
        {
            if (this._pieceSize == 0)
            {
                this._pieceSize = this._cellSize;
            }

            for (int i = 1; i <= 8; i++)
                for (int j = 1; j <= 8; j++)
                    if (State[i,j].Type != eChessPieceType.Null)
                    arrChessCell[i, j].ChessPiece = new Uc_ChessPiece(State[i, j].Side, State[i, j].Type, PieceStyle,
                                                                      this._cellSize, this._pieceSize, new Point(i, j));
        }


        /// <summary>
        /// Initalize Start Board State
        /// </summary>
        public void InitBoardState()
        {
            int i, j;

            for (i = 0; i < 10; i++)
                for (j = 0; j < 10; j++)
                {
                    arrState[i, j] = new ChessState(eChessPieceType.Null, eChessSide.Black);
                }
                    

            //the edge of the board 
            for (i = 0; i < 10; i++)
            {
                arrState[i, 0].Type = eChessPieceType.CantMove;
                arrState[i, 9].Type = eChessPieceType.CantMove;
                arrState[0, i].Type = eChessPieceType.CantMove;
                arrState[9, i].Type = eChessPieceType.CantMove;
            }

            if (this._ownSide == eChessSide.White)
            {
                //Black Pawn 
                for (i = 1; i < 9; i++)
                {
                    arrState[2, i].Type = eChessPieceType.Pawn;
                    arrState[2, i].Side = eChessSide.Black;
                }

                //White Pawn 
                for (i = 1; i < 9; i++)
                {
                    arrState[7, i].Type = eChessPieceType.Pawn;
                    arrState[7, i].Side = eChessSide.White;
                }

                //Black Rook 
                arrState[1, 1].Type = eChessPieceType.Rook;
                arrState[1, 1].Side = eChessSide.Black;
                arrState[1, 8].Type = eChessPieceType.Rook;
                arrState[1, 8].Side = eChessSide.Black;

                //White Rook 
                arrState[8, 1].Type = eChessPieceType.Rook;
                arrState[8, 1].Side = eChessSide.White;
                arrState[8, 8].Type = eChessPieceType.Rook;
                arrState[8, 8].Side = eChessSide.White;

                //Black Knight
                arrState[1, 2].Type = eChessPieceType.Knight;
                arrState[1, 2].Side = eChessSide.Black;
                arrState[1, 7].Type = eChessPieceType.Knight;
                arrState[1, 7].Side = eChessSide.Black;

                //White Knight
                arrState[8, 2].Type = eChessPieceType.Knight;
                arrState[8, 2].Side = eChessSide.White;
                arrState[8, 7].Type = eChessPieceType.Knight;
                arrState[8, 7].Side = eChessSide.White;

                //Black Bishop
                arrState[1, 3].Type = eChessPieceType.Bishop;
                arrState[1, 3].Side = eChessSide.Black;
                arrState[1, 6].Type = eChessPieceType.Bishop;
                arrState[1, 6].Side = eChessSide.Black;

                //White Bishop
                arrState[8, 3].Type = eChessPieceType.Bishop;
                arrState[8, 3].Side = eChessSide.White;
                arrState[8, 6].Type = eChessPieceType.Bishop;
                arrState[8, 6].Side = eChessSide.White;

                //Black King 
                arrState[1, 5].Type = eChessPieceType.King;
                arrState[1, 5].Side = eChessSide.Black;

                //White King 
                arrState[8, 5].Type = eChessPieceType.King;
                arrState[8, 5].Side = eChessSide.White;

                //Black Queen 
                arrState[1, 4].Type = eChessPieceType.Queen;
                arrState[1, 4].Side = eChessSide.Black;

                //White Queen 
                arrState[8, 4].Type = eChessPieceType.Queen;
                arrState[8, 4].Side = eChessSide.White;
            }
            else
            {
                //White Pawn 
                for (i = 1; i < 9; i++)
                {
                    arrState[2, i].Type = eChessPieceType.Pawn;
                    arrState[2, i].Side = eChessSide.White;
                }

                //Black Pawn 
                for (i = 1; i < 9; i++)
                {
                    arrState[7, i].Type = eChessPieceType.Pawn;
                    arrState[7, i].Side = eChessSide.Black;
                }

                //White Rook 
                arrState[1, 1].Type = eChessPieceType.Rook;
                arrState[1, 1].Side = eChessSide.White;
                arrState[1, 8].Type = eChessPieceType.Rook;
                arrState[1, 8].Side = eChessSide.White;

                //Black Rook 
                arrState[8, 1].Type = eChessPieceType.Rook;
                arrState[8, 1].Side = eChessSide.Black;
                arrState[8, 8].Type = eChessPieceType.Rook;
                arrState[8, 8].Side = eChessSide.Black;

                //White Knight
                arrState[1, 2].Type = eChessPieceType.Knight;
                arrState[1, 2].Side = eChessSide.White;
                arrState[1, 7].Type = eChessPieceType.Knight;
                arrState[1, 7].Side = eChessSide.White;

                //Black Knight
                arrState[8, 2].Type = eChessPieceType.Knight;
                arrState[8, 2].Side = eChessSide.Black;
                arrState[8, 7].Type = eChessPieceType.Knight;
                arrState[8, 7].Side = eChessSide.Black;

                //White Bishop
                arrState[1, 3].Type = eChessPieceType.Bishop;
                arrState[1, 3].Side = eChessSide.White;
                arrState[1, 6].Type = eChessPieceType.Bishop;
                arrState[1, 6].Side = eChessSide.White;

                //Black Bishop
                arrState[8, 3].Type = eChessPieceType.Bishop;
                arrState[8, 3].Side = eChessSide.Black;
                arrState[8, 6].Type = eChessPieceType.Bishop;
                arrState[8, 6].Side = eChessSide.Black;

                //White King 
                arrState[1, 5].Type = eChessPieceType.King;
                arrState[1, 5].Side = eChessSide.White;

                //Black King 
                arrState[8, 5].Type = eChessPieceType.King;
                arrState[8, 5].Side = eChessSide.Black;

                //White Queen 
                arrState[1, 4].Type = eChessPieceType.Queen;
                arrState[1, 4].Side = eChessSide.White;

                //Black Queen 
                arrState[8, 4].Type = eChessPieceType.Queen;
                arrState[8, 4].Side = eChessSide.Black;
            }
        }

        public void InitBoardState(ChessState[,] State)
        {
            int i, j;

            for (i = 0; i < 10; i++)
                for (j = 0; j < 10; j++)
                {
                    arrState[i, j] = new ChessState(State[i,j].Type, State[i,j].Side, State[i,j].Moves);
                }
        }
        #endregion


        #region event 
        #region Event Move
        public delegate void MoveMakedHandler(object sender, EventArgs e);
        public event MoveMakedHandler MoveMaked;
        protected virtual void OnMoveMaked(EventArgs e)
        {
            if (MoveMaked != null)
                MoveMaked(this, e);
        }
        #endregion

        #region Event A ChessPiece Eated 
        public delegate void PieceEatedHandler(object sender, EventArgs e);
        public event PieceEatedHandler PieceEated;
        protected virtual void OnPieceCaptured(EventArgs e)
        {
            if (PieceEated != null)
                PieceEated(this, e);
        }
        #endregion
        #endregion

        #region Highlight And UnHighlight Moves
        public void UnHighLightMoves()
        {
            if (arrCanMove.Count == 0)
            {
                //If there's no possible move -> red this choosen point 
                if (PositionChoosen.X != 0 && PositionChoosen.Y != 0)
                    arrChessCell[PositionChoosen.X, PositionChoosen.Y].UnHighlightMove();
            }     
            else
            {
                //UnHighLight All possible moves
                foreach (ChessMove p in arrCanMove)
                    arrChessCell[p.MoveTo.X, p.MoveTo.Y].UnHighlightMove();

                //UnHighLight this choosen Point
                if (PositionChoosen.X != 0 && PositionChoosen.Y != 0)
                    arrChessCell[PositionChoosen.X, PositionChoosen.Y].UnHighlightMove();
            }  

            this.DrawToBitmap(bmpBackImage, new Rectangle(0, 0, this.Width, this.Height));
            this.SetBackGround();
        }

        public void HighLightWhoCheckAndKingChecked()
        {
            if (arrWhoCheck.Count == 0 || _gameStatusReason != eGameEndReason.PlayingCheck)
                return;

            foreach (ChessMove p in arrWhoCheck)
            {
                arrChessCell[p.MoveFrom.X, p.MoveFrom.Y].HighLightImpossibleMove();
                arrChessCell[p.MoveTo.X, p.MoveTo.Y].HighLightImpossibleMove();
            }

            this.DrawToBitmap(bmpBackImage, new Rectangle(0, 0, this.Width, this.Height));
            this.SetBackGround();
        }

        public void UnHighLightWhoCheckAndKingChecked()
        {
            if (arrWhoCheck.Count == 0)
                return;

            foreach (ChessMove p in arrWhoCheck)
            {
                arrChessCell[p.MoveFrom.X, p.MoveFrom.Y].UnHighlightMove();
                arrChessCell[p.MoveTo.X, p.MoveTo.Y].UnHighlightMove();
            }

            this.DrawToBitmap(bmpBackImage, new Rectangle(0, 0, this.Width, this.Height));
            this.SetBackGround();
        }

        public void HighLightAllPosibleMoves()
        {
            if (arrCanMove.Count == 0)
            {
                if (PositionChoosen.X != 0 && PositionChoosen.Y != 0)
                    arrChessCell[PositionChoosen.X, PositionChoosen.Y].HighLightImpossibleMove();
            }
            else
            {
                //HighLight All possible moves
                foreach (ChessMove p in arrCanMove)
                    arrChessCell[p.MoveTo.X, p.MoveTo.Y].HighLightPosibleMove();

                //HighLight this choosen Point
                if (PositionChoosen.X != 0 && PositionChoosen.Y != 0)
                    arrChessCell[PositionChoosen.X, PositionChoosen.Y].HighLightPosibleMove();
            }

            this.DrawToBitmap(bmpBackImage, new Rectangle(0, 0, this.Width, this.Height));
            this.SetBackGround();

        }

        public void HighLightLastMove()
        {
            if (stkUndo.Count == 0)
                return;

            ChessMove m = stkUndo.Pop();
            arrChessCell[m.MoveFrom.X, m.MoveFrom.Y].HighLightPosibleMove();
            arrChessCell[m.MoveTo.X, m.MoveTo.Y].HighLightPosibleMove();

            stkUndo.Push(m);

            this.DrawToBitmap(bmpBackImage, new Rectangle(0, 0, this.Width, this.Height));
            this.SetBackGround();
        }

        public void UnHighLightLastMove()
        {
            if (stkUndo.Count == 0)
                return;

            ChessMove m = stkUndo.Pop();
            arrChessCell[m.MoveFrom.X, m.MoveFrom.Y].UnHighlightMove();
            arrChessCell[m.MoveTo.X, m.MoveTo.Y].UnHighlightMove();

            stkUndo.Push(m);

            this.DrawToBitmap(bmpBackImage, new Rectangle(0, 0, this.Width, this.Height));
            this.SetBackGround();
        }

        void SetBackGround()
        {
            this.BackgroundImage = bmpBackImage;
            this.UpdateStyles();

        }

        void SetDefaultBackground()
        {
            this.BackgroundImage = BoardBitmap;
            this.UpdateStyles();
        }

        #endregion

        public Bitmap TakePicture(int w, int h)
        {
            Bitmap bmp = new Bitmap(w, h);
            _isCapturingMode = true;

            for (int x = 1; x <= 8; x++)
            {
                for (int y = 1; y <= 8; y++)
                {
                    Uc_ChessPiece p = arrChessCell[x, y].ChessPiece;
                    if (p != null)
                    {
                        this.Controls.Remove(p);
                        arrChessCell[x, y].ChessPiece = p;
                    }
                }
            }
            this.DrawToBitmap(bmp, new Rectangle(0, 0, this.Width, this.Height));
            _isCapturingMode = false;
            for (int x = 1; x <= 8; x++)
            {
                for (int y = 1; y <= 8; y++)
                {
                    Uc_ChessPiece p = arrChessCell[x, y].ChessPiece;
                    if (p != null)
                    {
                        arrChessCell[x, y].Controls.Remove(p);
                        arrChessCell[x, y].ChessPiece = p;
                    }
                }
            }
            return bmp;
        }

        private void Uc_ChessBoard_Load(object sender, EventArgs e)
        {
            SetStyle(ControlStyles.UserPaint, true);
            SetStyle(ControlStyles.AllPaintingInWmPaint, true);
            SetStyle(ControlStyles.DoubleBuffer, true);
            SetStyle(ControlStyles.OptimizedDoubleBuffer, true);

            CheckForIllegalCrossThreadCalls = false;

            bmpBackImage = new Bitmap(this.Width, this.Height);
        }

        #region Moves

        /// <summary>
        /// UndoMove Player vs Player 
        /// </summary>
        public void UndoMove_PlayervsPlayer()
        {
            if (stkUndo.Count == 0 || (this.GameMode == eGameMode.VsComputer && this.OwnSide == eChessSide.Black && stkUndo.Count == 1))
                return;

            //when undo Move -> remove this status from arrPosition
            string status = Chess_Engine.MakePosition(arrState);
            if (arrPosition[status] > 1)
                arrPosition[status] -= 1;
            else
                arrPosition.Remove(status);


            UnHighLightLastMove();
            ChessMove m = stkUndo.Pop();
            stkChessMoveString.Pop();

            //Push this move to stkRedo
            stkRedo.Push(m);

            //Replace ChessPiece from m.MoveTo -> m.MoveFrom (opposite move)
            arrChessCell[m.MoveFrom.X, m.MoveFrom.Y].ChessPiece = arrChessCell[m.MoveTo.X, m.MoveTo.Y].ChessPiece;
            arrChessCell[m.MoveFrom.X, m.MoveFrom.Y]._chessPiece.Position = new Point(m.MoveFrom.X, m.MoveFrom.Y);
            arrChessCell[m.MoveTo.X, m.MoveTo.Y]._chessPiece = null;

            arrState[m.MoveFrom.X, m.MoveFrom.Y].Side = arrState[m.MoveTo.X, m.MoveTo.Y].Side;
            arrState[m.MoveFrom.X, m.MoveFrom.Y].Type = arrState[m.MoveTo.X, m.MoveTo.Y].Type;
            arrState[m.MoveFrom.X, m.MoveFrom.Y].Moves = m.FromMoves;
            arrState[m.MoveTo.X, m.MoveTo.Y].Type = eChessPieceType.Null;

            //Update Position Last move 
            if (stkUndo.Count == 0)
                _positionLastMove = new Point(0, 0);
            else
            {
                ChessMove p = stkUndo.Pop();
                _positionLastMove = new Point(p.MoveFrom.X, p.MoveFrom.Y);
                stkUndo.Push(p);
            }

            //No PositionChoosen after this Undo
            this._positionChoosen = new Point(0, 0);

            //Push the ChessPiece was eated to this position 
            if (m.ChessPieceEated != eChessPieceType.Null)
            {
                arrState[m.MoveEated.X, m.MoveEated.Y].Type = m.ChessPieceEated;
                arrState[m.MoveEated.X, m.MoveEated.Y].Side = eChessSide.Black;
                if (arrState[m.MoveFrom.X, m.MoveFrom.Y].Side == eChessSide.Black)
                    arrState[m.MoveEated.X, m.MoveEated.Y].Side = eChessSide.White;
                arrState[m.MoveEated.X, m.MoveEated.Y].Moves = m.Moves;
                arrChessCell[m.MoveEated.X, m.MoveEated.Y].ChessPiece = new Uc_ChessPiece(arrState[m.MoveEated.X, m.MoveEated.Y].Side, arrState[m.MoveEated.X, m.MoveEated.Y].Type, 
                                                                           this._pieceStyle,this._cellSize, this._pieceSize, new Point(m.MoveEated.X, m.MoveEated.Y));
                arrChessCell[m.MoveEated.X, m.MoveEated.Y].ChessPiece.Moved();

                stkChessPieceEated.Pop();
            }

            if (m.HowMove == eMove.Castling)
            {
                //King was unmoved -> unMove Rook

                if (m.MoveTo.X == m.MoveFrom.X)
                {
                    if (m.MoveFrom.Y < m.MoveTo.Y)
                    {
                        //King side castling 
                        arrChessCell[m.MoveTo.X, 8].ChessPiece = arrChessCell[m.MoveTo.X, 6].ChessPiece ;                   
                        arrChessCell[m.MoveTo.X, 8].ChessPiece.Position = new Point(m.MoveTo.X, 8);
                        arrChessCell[m.MoveTo.X, 6]._chessPiece = null;

                        arrState[m.MoveTo.X, 8].Side = arrState[m.MoveFrom.X, 6].Side;
                        arrState[m.MoveTo.X, 8].Type = arrState[m.MoveFrom.X, 6].Type;
                        arrState[m.MoveTo.X, 8].Moves = arrState[m.MoveFrom.X, 6].Moves - 1;
                        arrState[m.MoveTo.X, 6].Type = eChessPieceType.Null;

                        //Repaint New ChessPiece 
                        arrChessCell[m.MoveTo.X, 8].ChessPiece.Moved();
                    }
                    else
                    {
                        //Queen side castling 
                        arrChessCell[m.MoveTo.X, 1].ChessPiece = arrChessCell[m.MoveTo.X, 4].ChessPiece;  
                        arrChessCell[m.MoveTo.X, 1].ChessPiece.Position = new Point(m.MoveTo.X, 1);
                        arrChessCell[m.MoveTo.X, 4]._chessPiece = null;

                        arrState[m.MoveTo.X, 1].Side = arrState[m.MoveFrom.X, 4].Side;
                        arrState[m.MoveTo.X, 1].Type = arrState[m.MoveFrom.X, 4].Type;
                        arrState[m.MoveTo.X, 1].Moves = arrState[m.MoveFrom.X, 4].Moves - 1;
                        arrState[m.MoveTo.X, 4].Type = eChessPieceType.Null;

                        //Repaint New ChessPiece 
                        arrChessCell[m.MoveTo.X, 1].ChessPiece.Moved();
                    }
                }
                else
                {
                    //Promotion side castling 
                    if (m.MoveFrom.X == 1)
                    {
                        //Replace Black Rook at (8,5) -> (2,5)
                        arrChessCell[8, 5].ChessPiece = arrChessCell[2, 5].ChessPiece;
                        arrChessCell[2, 5]._chessPiece = null;
                        arrChessCell[8, 5].ChessPiece.Position = new Point(8, 5);

                        arrState[8, 5].Side = arrState[2, 5].Side;
                        arrState[8, 5].Type = arrState[2, 5].Type;
                        arrState[8, 5].Moves = arrState[2, 5].Moves - 1;
                        arrState[2, 5].Type = eChessPieceType.Null;

                        //Repaint New ChessPiece 
                        arrChessCell[8, 5].ChessPiece.Moved();
                    }
                    else
                    {
                        //Replace White Rook at (1,5) -> (7,5)
                        arrChessCell[1, 5].ChessPiece = arrChessCell[7, 5].ChessPiece;
                        arrChessCell[7, 5]._chessPiece = null;
                        arrChessCell[1, 5].ChessPiece.Position = new Point(1, 5);
                        arrState[1, 5].Side = arrState[7, 5].Side;
                        arrState[1, 5].Type = arrState[7, 5].Type;
                        arrState[1, 5].Moves = arrState[7, 5].Moves - 1;
                        arrState[7, 5].Type = eChessPieceType.Null;

                        //Repaint New ChessPiece 
                        arrChessCell[1, 5].ChessPiece.Moved();
                    }
                }
            }
            else if (m.HowMove == eMove.Promotion)
            {
                Uc_ChessPiece UcPawn = arrChessCell[m.MoveFrom.X, m.MoveFrom.Y].ChessPiece;
                UcPawn.Type = eChessPieceType.Pawn;
                UcPawn.Image = Read_Image_From_Resources.GetChessPieceBitMap(UcPawn.Side, UcPawn.Type, UcPawn.Style);
                arrState[m.MoveFrom.X, m.MoveFrom.Y].Type = UcPawn.Type;
                UcPawn.Moved();
            }

            //UnHighLightMoves 
            UnHighLightMoves();

            //Change turn to the opponent 
            if (WhoTurn == eChessSide.White)
                WhoTurn = eChessSide.Black;
            else
                WhoTurn = eChessSide.White;


            //After undo -> check game status
            CheckGameStatus();
        }

        /// <summary>
        /// Redo Move Player vs Player
        /// </summary>
        public void RedoMove_PlayervsPlayer()
        {
            if (stkRedo.Count == 0)
                return;

            ChessMove m = stkRedo.Pop();
            clear_Stack_Redo = false;
            DoMove(m);
        }

        private void RemoveChessPieceEated(ChessMove m)
        {
            if (m.ChessPieceEated != eChessPieceType.Null)
            {
                this.Controls.Remove(arrChessCell[m.MoveEated.X, m.MoveEated.Y].ChessPiece);
                arrChessCell[m.MoveEated.X, m.MoveEated.Y]._chessPiece = null;
                arrState[m.MoveEated.X, m.MoveEated.Y].Type = eChessPieceType.Null;
            }
        }

        private void ReplaceChessPiece(ChessMove m)
        {
            //Remove this ChessPiece from Controls
            this.Controls.Remove(arrChessCell[m.MoveTo.X, m.MoveTo.Y].ChessPiece);

            //Replace ChessPiece from m.MoveFrom -> m.MoveTo
            arrChessCell[m.MoveTo.X, m.MoveTo.Y].ChessPiece = arrChessCell[m.MoveFrom.X, m.MoveFrom.Y].ChessPiece;
            arrChessCell[m.MoveTo.X, m.MoveTo.Y]._chessPiece.Position = new Point(m.MoveTo.X, m.MoveTo.Y);
            arrChessCell[m.MoveFrom.X, m.MoveFrom.Y]._chessPiece = null;

            arrState[m.MoveTo.X, m.MoveTo.Y].Side = arrState[m.MoveFrom.X, m.MoveFrom.Y].Side;
            arrState[m.MoveTo.X, m.MoveTo.Y].Type = arrState[m.MoveFrom.X, m.MoveFrom.Y].Type;
            arrState[m.MoveTo.X, m.MoveTo.Y].Moves = arrState[m.MoveFrom.X, m.MoveFrom.Y].Moves + 1;
            arrState[m.MoveFrom.X, m.MoveFrom.Y].Type = eChessPieceType.Null;

            //Repaint New ChessPiece 
            arrChessCell[m.MoveTo.X, m.MoveTo.Y].ChessPiece.Moved();
        } 

        private void DoCastling(ChessMove m)
        {
            //King was moved, move Rook 
            if (m.MoveTo.X == m.MoveFrom.X)
            {
                if (m.MoveFrom.Y < m.MoveTo.Y)
                {
                    //King side castling 
                    arrChessCell[m.MoveTo.X, 6].ChessPiece = arrChessCell[m.MoveTo.X, 8].ChessPiece;
                    arrChessCell[m.MoveTo.X, 6].ChessPiece.Position = new Point(m.MoveTo.X, 6);
                    arrChessCell[m.MoveTo.X, 8]._chessPiece = null;

                    arrState[m.MoveTo.X, 6].Side = arrState[m.MoveFrom.X, 8].Side;
                    arrState[m.MoveTo.X, 6].Type = arrState[m.MoveFrom.X, 8].Type;
                    arrState[m.MoveTo.X, 6].Moves = arrState[m.MoveFrom.X, 8].Moves + 1;
                    arrState[m.MoveTo.X, 8].Type = eChessPieceType.Null;

                    //Repaint New ChessPiece 
                    arrChessCell[m.MoveTo.X, 6].ChessPiece.Moved();
                }
                else
                {
                    //Queen side castling 
                    arrChessCell[m.MoveTo.X, 4].ChessPiece = arrChessCell[m.MoveTo.X, 1].ChessPiece;
                    arrChessCell[m.MoveTo.X, 4].ChessPiece.Position = new Point(m.MoveTo.X, 4);
                    arrChessCell[m.MoveTo.X, 1]._chessPiece = null;

                    arrState[m.MoveTo.X, 4].Side = arrState[m.MoveFrom.X, 1].Side;
                    arrState[m.MoveTo.X, 4].Type = arrState[m.MoveFrom.X, 1].Type;
                    arrState[m.MoveTo.X, 4].Moves = arrState[m.MoveFrom.X, 1].Moves + 1;
                    arrState[m.MoveTo.X, 1].Type = eChessPieceType.Null;

                    //Repaint New ChessPiece 
                    arrChessCell[m.MoveTo.X, 4].ChessPiece.Moved();
                }
            }
            else
            {
                //Promotion side castling 
                if (m.MoveFrom.X == 1)
                {
                    //Black
                    //Replace Black Rook at (8,5) -> (2,5)
                    arrChessCell[2, 5].ChessPiece = arrChessCell[8, 5].ChessPiece;
                    arrChessCell[2, 5].ChessPiece.Position = new Point(2, 5);
                    arrChessCell[8, 5]._chessPiece = null;

                    arrState[2, 5].Side = arrState[8, 5].Side;
                    arrState[2, 5].Type = arrState[8, 5].Type;
                    arrState[2, 5].Moves = arrState[8, 5].Moves + 1;
                    arrState[8, 5].Type = eChessPieceType.Null;

                    //Repaint New ChessPiece 
                    arrChessCell[2, 5].ChessPiece.Moved();
                }
                else
                {
                    //White
                    //Replace White Rook at (1,5) -> (7,5)
                    arrChessCell[7, 5].ChessPiece = arrChessCell[1, 5].ChessPiece;
                    arrChessCell[1, 5]._chessPiece = null;
                    arrChessCell[7, 5].ChessPiece.Position = new Point(7, 5);

                    arrState[7, 5].Side = arrState[1, 5].Side;
                    arrState[7, 5].Type = arrState[1, 5].Type;
                    arrState[7, 5].Moves = arrState[1, 5].Moves + 1;
                    arrState[1, 5].Type = eChessPieceType.Null;

                    //Repaint New ChessPiece 
                    arrChessCell[7, 5].ChessPiece.Moved();
                }
            }
        }

        private void DoPromotion(ChessMove m)
        {
            if ((this.GameMode == eGameMode.VsComputer && this._ownSide == WhoTurn) || this.GameMode == eGameMode.VsHuman)
            {
                //Human move 
                ChessPiece_Pawn.Promotion(arrChessCell[m.MoveTo.X, m.MoveTo.Y]._chessPiece, eChessPieceType.Null, Language);
                arrState[m.MoveTo.X, m.MoveTo.Y].Type = arrChessCell[m.MoveTo.X, m.MoveTo.Y]._chessPiece.Type;
            }
            else
            {
                //Computer Move
                ChessPiece_Pawn.Promotion(arrChessCell[m.MoveTo.X, m.MoveTo.Y]._chessPiece, eChessPieceType.Queen, Language);

                arrState[m.MoveTo.X, m.MoveTo.Y].Type = eChessPieceType.Queen;
            }

            //New ChessPiece 
            arrState[m.MoveTo.X, m.MoveTo.Y].Moves = 0;
        }
        /// <summary>
        /// Make a move 
        /// </summary>
        /// <param name="m"></param>
        public void DoMove(ChessMove m)
        {
            if (clear_Stack_Redo == true)
            {
                //stkRedo = Empty 
                stkRedo.Clear();
                stkRedo = new Stack<ChessMove>();
            }

            //PlaySound
            if (m.ChessPieceEated == eChessPieceType.Null)
                PlayMusic(_movedSound);
            else
            {
                OnPieceCaptured(EventArgs.Empty); //event when a ChessPiece was Eated 
                PlayMusic(_capturedSound);
                stkChessPieceEated.Push(new Bitmap_Side_ChessPieceEated(arrChessCell[m.MoveEated.X, m.MoveEated.Y].ChessPiece.Side,arrChessCell[m.MoveEated.X, m.MoveEated.Y].ChessPiece.Image));
            }


            UnHighLightWhoCheckAndKingChecked();
            UnHighLightLastMove();
            //Push this move to stkUndo
            stkUndo.Push(m);
            //Push this move's string to stkChessMoveString
            stkChessMoveString.Push(MakeAStringOfAMove(m));

            //Remove the chess was eated 
            RemoveChessPieceEated(m);

            ReplaceChessPiece(m);

            //Update Position Last move 
            _positionLastMove = new Point(m.MoveFrom.X, m.MoveFrom.Y);

            //No PositionChoosen after this Move 
            this._positionChoosen = new Point(0, 0);

            if (m.HowMove == eMove.Castling) DoCastling(m);
            else if (m.HowMove == eMove.Promotion) DoPromotion(m);

            //UnHighLightMoves 
            UnHighLightMoves();

            //Change turn to the opponent 
            if (WhoTurn == eChessSide.White)
                WhoTurn = eChessSide.Black;
            else
                WhoTurn = eChessSide.White;

            HighLightLastMove();
            clear_Stack_Redo = true;

            //After do a move, push that position to arrPosition and check the status of this game
            string status = Chess_Engine.MakePosition(arrState);
            if (arrPosition.ContainsKey(status))
                arrPosition[status] ++;
            else
                arrPosition.Add(status, 1);

            CheckGameStatus();
            OnMoveMaked(EventArgs.Empty);
        }

        public string MakeAStringOfAMove(ChessMove m)
        {
            string res = "";

            if (this._ownSide == eChessSide.White)
            {
                res += (char)(m.MoveFrom.Y + 64);
                res += 9 - m.MoveFrom.X;
            }
            else
            {
                res += (char)(9 - m.MoveFrom.Y + 64);
                res += m.MoveFrom.X;
            }

            if (m.ChessPieceEated != eChessPieceType.Null && m.HowMove != eMove.EnPassant)
                res += "x";
            else
                res += "-";

            if (this._ownSide == eChessSide.White)
            {
                res += (char)(m.MoveTo.Y + 64);
                res += 9 - m.MoveTo.X;
            }
            else
            {
                res += (char)(9 - m.MoveTo.Y + 64);
                res += m.MoveTo.X;
            }

            return res;
        }
        public string Hint()
        {
            ChessMove MyMove = Chess_Engine.MakeAComputerMove(this.arrState, this.OwnSide, this.arrPosition, this._gameDifficulty, this._ownSide);

            return MakeAStringOfAMove(MyMove);
        }
        #endregion

        public void PlayMusic(SoundPlayer sound)
        {
            if (this.PlaySound == true)
            {
                sound.Play();
            }
        }

        public void CheckGameStatus()
        {
            Assembly a = Assembly.Load("Chess Library");
            ResourceManager rm = new ResourceManager("Chess_Library.Resources.Lang.Langres", a);
            
            GameStatus status = Chess_Engine.CheckGameStatus(arrState, _whoTurn, arrPosition, this._ownSide);
            string res = "";
            _gameStatus = status.Status;
            _gameStatusReason = status.Reason;

            if (GameMode == eGameMode.VsHuman)
            {
                if (status.Status == eGameStatus.BlackWin)
                {
                    res += rm.GetString("Result_BlackWin", Language);

                    if (status.Reason == eGameEndReason.WinCheckmate)
                        res += " - " + rm.GetString("Result_Checkmate", Language);
                    else if (status.Reason == eGameEndReason.WinOutOfTime)
                        res += " - " + rm.GetString("Result_WhiteOutOfTime", Language);
                }
                else if (status.Status == eGameStatus.WhiteWin)
                {
                    res += rm.GetString("Result_WhiteWin", Language);

                    if (status.Reason == eGameEndReason.WinCheckmate)
                        res += " - " + rm.GetString("Result_Checkmate", Language);
                    else if (status.Reason == eGameEndReason.WinOutOfTime)
                        res += " - " + rm.GetString("Result_BlackOutOfTime", Language);
                }    
                else if (status.Status == eGameStatus.Draw)
                {
                    res += rm.GetString("Result_Draw", Language);

                    if (status.Reason == eGameEndReason.Draw3TimesRepeat)
                        res += " - " + rm.GetString("Result_3timesrepeat", Language);
                    else if (status.Reason == eGameEndReason.DrawCantCheckmate)
                        res += " - " + rm.GetString("Result_DrawCantCheckmate", Language);
                    else if (status.Reason == eGameEndReason.DrawOutOfMove)
                    {
                        if (_whoTurn == eChessSide.Black)
                            res += " - " + rm.GetString("Result_BlackNoMoreMove", Language);
                        else
                            res += " - " + rm.GetString("Result_WhiteNoMoreMove", Language);
                    }
                }
                else if (status.Status == eGameStatus.Playing)
                {
                    if (status.Reason == eGameEndReason.PlayingCheck)
                    {
                        //res += rm.GetString("Result_Check", Language);
                        arrWhoCheck = Chess_Engine.FindWhoCheckAndKingPosition(arrState, WhoTurn, this._ownSide);
                        HighLightWhoCheckAndKingChecked();
                    }
                }
            }
            else if (GameMode == eGameMode.VsComputer)
            {
                if (status.Status == eGameStatus.BlackWin)
                {
                    if (_ownSide == eChessSide.Black)
                    {
                        res += rm.GetString("Result_HumanWin", Language);
                        if (status.Reason == eGameEndReason.WinCheckmate)
                            res += " - " + rm.GetString("Result_Checkmate", Language);
                        else if (status.Reason == eGameEndReason.WinOutOfTime)
                            res += " - " + rm.GetString("Result_ComputerOutOfTime", Language);
                    }  
                    else
                    {
                        res += rm.GetString("Result_ComputerWin", Language);
                        if (status.Reason == eGameEndReason.WinCheckmate)
                            res += " - " + rm.GetString("Result_Checkmate", Language);
                        else if (status.Reason == eGameEndReason.WinOutOfTime)
                            res += " - " + rm.GetString("Result_HumanOutOfTime", Language);
                    }
                }
                else if (status.Status == eGameStatus.WhiteWin)
                {
                    if (_ownSide == eChessSide.White)
                    {
                        res += rm.GetString("Result_HumanWin", Language);
                        if (status.Reason == eGameEndReason.WinCheckmate)
                            res += " - " + rm.GetString("Result_Checkmate", Language);
                        else if (status.Reason == eGameEndReason.WinOutOfTime)
                            res += " - " + rm.GetString("Result_ComputerOutOfTime", Language);
                    }
                    else
                    {
                        res += rm.GetString("Result_ComputerWin", Language);
                        if (status.Reason == eGameEndReason.WinCheckmate)
                            res += " - " + rm.GetString("Result_Checkmate", Language);
                        else if (status.Reason == eGameEndReason.WinOutOfTime)
                            res += " - " + rm.GetString("Result_HumanOutOfTime", Language);
                    }
                }
                else if (status.Status == eGameStatus.Draw)
                {
                    res += rm.GetString("Result_Draw", Language);

                    if (status.Reason == eGameEndReason.Draw3TimesRepeat)
                        res += " - " + rm.GetString("Result_3timesrepeat", Language);
                    else if (status.Reason == eGameEndReason.DrawCantCheckmate)
                        res += " - " + rm.GetString("Result_DrawCantCheckmate", Language);
                    else if (status.Reason == eGameEndReason.DrawOutOfMove)
                    {
                        if (_ownSide == eChessSide.Black)
                            res += " - " + rm.GetString("Result_HumanNoMoreMove", Language);
                        else
                            res += " - " + rm.GetString("Result_ComputerNoMoreMove", Language);
                    }
                }
                else if (status.Status == eGameStatus.Playing)
                {
                    if (status.Reason == eGameEndReason.PlayingCheck)
                    {
                        //res += rm.GetString("Result_Check", Language);
                        arrWhoCheck = Chess_Engine.FindWhoCheckAndKingPosition(arrState, WhoTurn, this._ownSide);
                        HighLightWhoCheckAndKingChecked();
                    }
                }
            }

            if (res != "")
                DisplayMessage(res);
        }

        #region Computer Move
        ChessMove MyMove = null;
        public bool IsThinking = false;
        public bool IsCancelThinking = false;

        public void Computer_Move()
        {
            backgroundWorker1.RunWorkerAsync();
        }

        public void CancelThinking()
        {
            if (backgroundWorker1.IsBusy == true)
                backgroundWorker1.CancelAsync();
            IsCancelThinking = true;
        }
        private void backgroundWorker1_DoWork(object sender, DoWorkEventArgs e)
        {
                IsThinking = true;

                if (IsCancelThinking == true)
                {
                    IsCancelThinking = false;
                    return;
                }

                MyMove = Chess_Engine.MakeAComputerMove(this.arrState, this.OpSide, this.arrPosition, this._gameDifficulty, this._ownSide);
        }

        private void backgroundWorker1_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            if (IsCancelThinking == true)
                return;

            IsCancelThinking = false;
            IsThinking = false;

            DoMove(MyMove);
        }
        #endregion
        public void DisplayMessage(string message)
        {
            if (Form_Message.Continue_Show_Message == true)
            {
                Form_Message form_temp = new Form_Message(message, Language);

                form_temp.Show();
            }
        }
    }
}
