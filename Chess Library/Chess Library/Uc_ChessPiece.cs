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

namespace Chess_Library
{
    public partial class Uc_ChessPiece : UserControl
    {
        #region Declare variables
        eChessSide _side;
        eChessPieceType _type;
        eChessPieceStyle _style;

        Point _position;
        int _cellSize;
        int _pieceSize;

        Bitmap _image;

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

        public eChessPieceStyle Style
        {
            get
            {
                return _style;
            }

            set
            {
                _style = value;
            }
        }

        public Point Position
        {
            get
            {
                return _position;
            }

            set
            {
                _position = value;
            }
        }

        public int CellSize
        {
            get
            {
                return _cellSize;
            }

            set
            {
                _cellSize = value;
            }
        }

        public int PieceSize
        {
            get
            {
                return _pieceSize;
            }

            set
            {
                _pieceSize = value;
            }
        }

        public Bitmap Image
        {
            get
            {
                return _image;
            }

            set
            {
                _image = value;
                this._image = value;
                Image.GetThumbnailImageAbort callback = null;
                IntPtr callbackdata = new IntPtr();
                this._image = (Bitmap)_image.GetThumbnailImage(_pieceSize, _pieceSize, callback, callbackdata);
                this.UpdateStyles();
            }
        }

        #endregion

        #region Constructor
        public Uc_ChessPiece()
        {
            InitializeComponent();
        }

        public Uc_ChessPiece(eChessSide side, eChessPieceType type,eChessPieceStyle style,int cellSize, int piecesize)
        {
            InitializeComponent();

            this._side = side;
            this._type = type;
            this._style = style;
            _cellSize = cellSize;
            _pieceSize = piecesize;
            _image = Read_Image_From_Resources.GetChessPieceBitMap(_side, _type, _style);

            //UserControl Size
            this.Size = new Size(this._pieceSize, this._pieceSize);
        }

        public Uc_ChessPiece(eChessSide side, eChessPieceType type, eChessPieceStyle style, int cellSize, int pieceSize, Point position)
        {
            InitializeComponent();

            this._side = side;
            this._type = type;
            this._style = style;
            _cellSize = cellSize;
            _pieceSize = pieceSize;
            _image = Read_Image_From_Resources.GetChessPieceBitMap(_side, _type, _style);
            _position = new Point(position.X, position.Y);

            //UserControl Size
            this.Size = new Size(this._pieceSize, this._pieceSize);
        }

        public Uc_ChessPiece(Bitmap bmpImage, int cellSize, int pieceSize)
        {
            InitializeComponent();

            this._image = bmpImage;
            this._pieceSize = pieceSize;
            this._cellSize = cellSize;
            this.Size = new Size(this._pieceSize, this._pieceSize);
        }

        #endregion

        private void Uc_ChessPiece_Click(object sender, EventArgs e)
        {
            // if we are in capturing Mode then exit
            if (Uc_ChessBoard._isCapturingMode)
                return;

            //Get the present Uc_ChessBoard
            Uc_ChessBoard uc_chessboard = (Uc_ChessBoard)this.Parent;
            
            //If this cell is clicked and highlighted => will be eated by uc_chessboard.PositionChoosen cell
            if (uc_chessboard.PositionChoosen.X != 0 && uc_chessboard.PositionChoosen.Y != 0)
            {
                //if choose this position again -> remove choose 
                if (uc_chessboard.PositionChoosen.X == this.Position.X && uc_chessboard.PositionChoosen.Y == this.Position.Y)
                {
                    uc_chessboard.UnHighLightMoves();
                    uc_chessboard.HighLightWhoCheckAndKingChecked();
                    uc_chessboard.PositionChoosen = new Point(0, 0);
                    return;
                }

                foreach (ChessMove p in uc_chessboard.arrCanMove)
                    if (this._position.X == p.MoveTo.X && this._position.Y == p.MoveTo.Y)
                    {
                        uc_chessboard.DoMove(p);
                        uc_chessboard.PositionChoosen = new Point(0, 0); //this cell was eated so there's no Position Choosen 

                        //Computer's move
                        if (uc_chessboard.GameMode == eGameMode.VsComputer)
                        {
                            uc_chessboard.IsThinking = true;
                            if (uc_chessboard.GameStatus == eGameStatus.Playing)
                            {
                                uc_chessboard.Computer_Move();
                            }
                        }
                        return;
                    }

                //If this Point wasn't eated => reset PositionChoosen and Unhighlight
                uc_chessboard.UnHighLightMoves();
                uc_chessboard.PositionChoosen = new Point(0, 0); 

                //Make this Point -> Position Choosen
                uc_chessboard.arrCanMove.Clear();

                //if this point = position choosen -> return 

                if ((uc_chessboard.OwnSide == this._side || uc_chessboard.GameMode == eGameMode.VsHuman)
                     && uc_chessboard.GameStatus == eGameStatus.Playing)
                   {
                      if ((uc_chessboard.WhoTurn == eChessSide.White && this._side == eChessSide.White)
                         || (uc_chessboard.WhoTurn == eChessSide.Black && this._side == eChessSide.Black))
                        {
                            uc_chessboard.arrCanMove  = Chess_Engine.FindAllPosibleMoves(uc_chessboard.arrState, this._position, uc_chessboard.OwnSide);

                            uc_chessboard.PositionChoosen = new Point(_position.X, _position.Y);
                            uc_chessboard.UnHighLightWhoCheckAndKingChecked();
                            uc_chessboard.UnHighLightLastMove();
                            uc_chessboard.HighLightAllPosibleMoves();
                        }
                  }
            }
            else
            {
                //If this Point isn't highlighted 

                //Make this Point -> Position Choosen
                uc_chessboard.arrCanMove.Clear();

                //if this point = position choosen -> return 

                if ((uc_chessboard.OwnSide == this._side || uc_chessboard.GameMode == eGameMode.VsHuman)
                     && uc_chessboard.GameStatus == eGameStatus.Playing)
                {
                    if ((uc_chessboard.WhoTurn == eChessSide.White && this._side == eChessSide.White)
                       || (uc_chessboard.WhoTurn == eChessSide.Black && this._side == eChessSide.Black))
                    {
                        uc_chessboard.arrCanMove = Chess_Engine.FindAllPosibleMoves(uc_chessboard.arrState, this._position, uc_chessboard.OwnSide);

                        uc_chessboard.PositionChoosen = new Point(_position.X, _position.Y);
                        uc_chessboard.UnHighLightWhoCheckAndKingChecked();
                        uc_chessboard.UnHighLightLastMove();
                        uc_chessboard.HighLightAllPosibleMoves();
                    }
                }
            }  
        }

        public void Moved()
        {
            this.UpdateStyles();
        }

        private void Uc_ChessPiece_Paint(object sender, PaintEventArgs e)
        {
            Graphics g = e.Graphics;
            g.DrawImage(_image, new Rectangle(0, 0, _image.Width, _image.Height), 0, 0, _image.Width, _image.Height, GraphicsUnit.Pixel);
        }

        private void Uc_ChessPiece_Load(object sender, EventArgs e)
        {
            SetStyle(ControlStyles.UserPaint, true);
            SetStyle(ControlStyles.AllPaintingInWmPaint, true);
            SetStyle(ControlStyles.DoubleBuffer, true);
            SetStyle(ControlStyles.OptimizedDoubleBuffer, true);
            SetStyle(ControlStyles.SupportsTransparentBackColor, true);
            BackColor = Color.Transparent;

            Image.GetThumbnailImageAbort callback = null;
            IntPtr callbackdata = new IntPtr();
            this._image = (Bitmap)_image.GetThumbnailImage(_pieceSize, _pieceSize, callback, callbackdata);
            this.UpdateStyles();
        }
    }
}
