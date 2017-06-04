using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Chess_Library
{
    [System.Serializable]
    public class Bitmap_Side_ChessPieceEated
    {
        #region Declare Variables
        private eChessSide _side;
        private Bitmap _image;

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

        public Bitmap Image
        {
            get
            {
                return _image;
            }

            set
            {
                _image = value;
            }
        }
        #endregion

        public Bitmap_Side_ChessPieceEated(eChessSide side, Bitmap image)
        {
            this.Side = side;
            this.Image = image;
        }
    }
}
