using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Chess_Library
{
    public partial class Uc_ChessCell : UserControl
    {
        #region Declare Variables
        Point _position;
        Bitmap _backImage;
        eChessSide _side;
        eChessBoardStyle _boardStyle;
        public Uc_ChessPiece _chessPiece;

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

        public Bitmap BackImage
        {
            get
            {
                return _backImage;
            }

            set
            {
                _backImage = value;
                this.UpdateStyles();
            }
        }

        public Uc_ChessPiece ChessPiece
        {
            get
            {
                return _chessPiece;
            }

            set
            {
                if (value != null) // = null not a chesspiece
                {
                    this._chessPiece = value;

                    int x = (int)(this.Size.Width - this._chessPiece.Width) / 2;
                    int y = (int)(this.Size.Height - this._chessPiece.Height) / 2;
                    if (Uc_ChessBoard._isCapturingMode == true)
                    {
                        this._chessPiece.Location = new Point(x, y);
                        this.Controls.Add(this._chessPiece);
                    }
                    else
                    {
                        this._chessPiece.Location = new Point(this.Location.X + x, this.Location.Y + y);
                        this.Parent.Controls.Add(this._chessPiece);
                    }
                    this._chessPiece.BringToFront();
                }
                else
                {
                    this._chessPiece = null;
                }
            }
        }
        #endregion

        #region constructor
        public Uc_ChessCell()
        {
            InitializeComponent();
        }

        public Uc_ChessCell(Point Position, eChessSide Side, eChessBoardStyle BoardStyle)
        {
            InitializeComponent();

            this._position.X = Position.X;
            this._position.Y = Position.Y;
            this._side = Side;
            this._boardStyle = BoardStyle;
            this._backImage = Read_Image_From_Resources.GetChessBoardBitMap(this._side, this._boardStyle);
            this.BackImage = _backImage; //Update backimage
        }

        public Uc_ChessCell(Point Position, Bitmap BackImage, eChessSide Side, eChessBoardStyle Style)
        {
            InitializeComponent();

            this._position.X = Position.X;
            this._position.Y = Position.Y;
            this._side = Side;
            this._boardStyle = Style;

            this._backImage = BackImage; //Update backimage
        }
        #endregion

        private void Uc_ChessCell_Load(object sender, EventArgs e)
        {
            SetStyle(ControlStyles.UserPaint, true);
            SetStyle(ControlStyles.AllPaintingInWmPaint, true);
            SetStyle(ControlStyles.DoubleBuffer, true);
            SetStyle(ControlStyles.OptimizedDoubleBuffer, true);

            this.UpdateStyles();
        }

        private void Uc_ChessCell_Paint(object sender, PaintEventArgs e)
        {
            Graphics g = e.Graphics;

            g.DrawImage(_backImage, new Rectangle(0, 0, this.Width, this.Height), new Rectangle(this._position.Y * 5, this._position.X * 5, this.Width, this.Height), GraphicsUnit.Pixel);
        }

        public void HighLightPosibleMove()
        {
            this.BackImage = Read_Image_From_Resources.GetChessBoardBitMap(this._side, this._boardStyle, "Possible");
        }

        public void UnHighlightMove()
        {
            this.BackImage = Read_Image_From_Resources.GetChessBoardBitMap(this._side, this._boardStyle);
        }

        public void HighLightImpossibleMove()
        {
            this.BackImage = Read_Image_From_Resources.GetChessBoardBitMap(this._side, this._boardStyle, "Last");
        }

        private void Uc_ChessCell_Click(object sender, EventArgs e)
        {
            // if we are in capturing Mode then exit
            if (Uc_ChessBoard._isCapturingMode)
                return;

            //Get the present Uc_ChessBoard
            Uc_ChessBoard uc_chessboard = (Uc_ChessBoard)this.Parent;

            //If this cell is clicked and highlighted => will be eated by uc_chessboard.PositionChoosen cell
            if (uc_chessboard.PositionChoosen.X != 0 && uc_chessboard.PositionChoosen.Y != 0)
            {
                foreach (ChessMove p in uc_chessboard.arrCanMove)
                    if (this._position.X == p.MoveTo.X && this._position.Y == p.MoveTo.Y)
                    {
                        uc_chessboard.DoMove(p);
                        uc_chessboard.PositionChoosen = new Point(0, 0); //this cell was eated so there's no Position Choosen 

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
                uc_chessboard.HighLightWhoCheckAndKingChecked();
                uc_chessboard.PositionChoosen = new Point(0, 0);
            }
        }

    }
}
