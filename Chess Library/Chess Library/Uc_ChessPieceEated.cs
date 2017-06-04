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
    public partial class Uc_ChessPieceEated : UserControl
    {
        #region Constructor and Variables
        eChessSide _side;
        PictureBox[] arrPic = new PictureBox[16];
        eChessSide _ownSide;
        public Uc_ChessPieceEated()
        {
            InitializeComponent();
        }

        public Uc_ChessPieceEated(eChessSide ownside)
        {
            InitializeComponent();
            this._ownSide = ownside;
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
        #endregion


        public void LoadChessPieces(Stack<Bitmap_Side_ChessPieceEated> stkChessPieceEadted)
        {
            int i;
            for (i = 0; i < 16; i++)
                arrPic[i].Image = null;

            i = 0;
            foreach (Bitmap_Side_ChessPieceEated piece in stkChessPieceEadted)
            {
                if (piece.Side == this._side)
                    //Pic[i++].Image = Read_Image_From_Resources.GetChessPieceBitMap(_side, piece.Type, piece.Style);
                    arrPic[i++].Image = piece.Image;
            }
        }

        void Initial()
        {
            int width = this.Width / 2;
            int height = this.Height / 8;

            for (int i = 0; i < 16; i++)
            {
                arrPic[i] = new PictureBox();
                arrPic[i].SizeMode = PictureBoxSizeMode.StretchImage;
                arrPic[i].Size = new Size(width, height);
                if (Side == this._ownSide)
                    arrPic[i].Location = new Point((i % 2) * width, (i / 2) * height);
                else
                    arrPic[i].Location = new Point(((16-i) % 2) * width, ((15 - i) / 2) * height);
                this.Controls.Add(arrPic[i]);
            }
        }

        private void Uc_ChessPieceEated_Load(object sender, EventArgs e)
        {
            Initial();
        }
    }
}
