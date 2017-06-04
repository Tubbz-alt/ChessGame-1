using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Chess_Library;
using System.Windows.Forms;
using System.IO;
using System.Data;

namespace Chess_game
{
    public class Options
    {
        private int _CellSize;
        private int _PieceSize;
        private bool _PlaySound;
        private eChessPieceStyle _PieceStyle;
        private eChessBoardStyle _BoardStyle;
        private string path = Application.StartupPath + "\\Config.xml";

        public Options()
        {
            this._CellSize = 80;
            this._PieceSize = 64;
            this._PieceStyle = eChessPieceStyle.Classic1;
            this._BoardStyle = eChessBoardStyle.Metal;
            this.PlaySound = true;

            LoadOptions();
        }

        public void LoadOptions()
        {
            if (File.Exists(path) == false)
            {
                XML_Processing.CreateNewOptions(path);
                SaveOptions();
            }
            else
            {
                DataTable tbl = XML_Processing.GetTable(path);
                DataRow r = tbl.Rows[0];
                this._CellSize = Convert.ToInt32(r["CELLSIZE"]);
                this._PieceSize = Convert.ToInt32(r["PIECESIZE"]);
                this._BoardStyle = (eChessBoardStyle)Convert.ToInt32(r["BOARDSTYLE"]);
                this._PieceStyle = (eChessPieceStyle)Convert.ToInt32(r["PIECESTYLE"]);
                this._PlaySound = Convert.ToBoolean(r["PLAYSOUND"]);
            }

        }

        public void SaveOptions()
        {
            DataTable tbl = XML_Processing.GetTable(path);
            DataRow r = tbl.Rows[0];
            r["CELLSIZE"] = this._CellSize;
            r["PIECESIZE"] = this._PieceSize;
            r["BOARDSTYLE"] = (int)this._BoardStyle;
            r["PIECESTYLE"] = (int)this._PieceStyle;
            r["PLAYSOUND"] = this._PlaySound;

            tbl.WriteXml(path);

        }
        public int CellSize
        {
            get
            {
                return this._CellSize;
            }
            set
            {
                this._CellSize = value;
            }
        }

        public int PieceSize
        {
            get
            {
                return this._PieceSize;
            }
            set
            {
                this._PieceSize = value;
            }
        }

        public eChessBoardStyle BoardStyle
        {
            get
            {
                return this._BoardStyle;
            }
            set
            {
                this._BoardStyle = value;
            }
        }

        public eChessPieceStyle PieceStyle
        {
            get
            {
                return this._PieceStyle;
            }
            set
            {
                this._PieceStyle = value;
            }
        }

        public bool PlaySound
        {
            get
            {
                return this._PlaySound;
            }
            set
            {
                this._PlaySound = value;
            }
        }



    }
}
