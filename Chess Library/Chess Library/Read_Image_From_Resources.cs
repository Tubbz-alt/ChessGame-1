using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Reflection;
using System.Resources;

namespace Chess_Library
{
    public class Read_Image_From_Resources
    {
        /*
         * Hàm này trả về tên của hình ảnh quân cờ chứa trong resource
         * VD: Muon lay quan Mã màu Đen Style Classic
         * Bitmap img=GetChessPieceBitMap(ChessPieceSide.Black,eChessPieceType.Knight,eChessPieceStyle.Classic);
         * Hàm này lấy hình ảnh trong Resource có tên là "Black_K_1";
         */
        public static Bitmap GetChessPieceBitMap(eChessSide Side, eChessPieceType Type, eChessPieceStyle Style)
        {
            string strImg = "";

            switch (Side)
            {
                case eChessSide.Black:
                    strImg += "Black_";
                    break;
                case eChessSide.White:
                    strImg += "White_";
                    break;
            }

            switch (Type)
            {
                case eChessPieceType.Pawn:
                    strImg += "P_";
                    break;
                case eChessPieceType.Bishop:
                    strImg += "B_";
                    break;
                case eChessPieceType.Knight:
                    strImg += "N_";
                    break;
                case eChessPieceType.Rook:
                    strImg += "R_";
                    break;
                case eChessPieceType.Queen:
                    strImg += "Q_";
                    break;
                case eChessPieceType.King:
                    strImg += "K_";
                    break;
            }

            strImg += (int)Style;

            Bitmap img = (Bitmap)Properties.Resources.ResourceManager.GetObject(strImg);

            return img;
        }

        public static Bitmap GetChessBoardBitMap(eChessSide Side, eChessBoardStyle Style)
        {
            string strImg = "";

            switch (Side)
            {
                case eChessSide.Black:
                    strImg += "Black_C_";
                    break;
                case eChessSide.White:
                    strImg += "White_C_";
                    break;
            }

            strImg += (int)Style;

            Bitmap img = (Bitmap)Properties.Resources.ResourceManager.GetObject(strImg);

            return img;
        }
        public static Bitmap GetChessBoardBitMap(eChessSide Side, eChessBoardStyle Style, string Highlight)
        {
            string strImg = "";

            switch (Side)
            {
                case eChessSide.Black:
                    strImg += "Black_C_";
                    break;
                case eChessSide.White:
                    strImg += "White_C_";
                    break;
            }

            strImg += (int)Style;

            strImg += "_" + Highlight;


            Bitmap img = (Bitmap)Properties.Resources.ResourceManager.GetObject(strImg);

            return img;
        }

    }
}

