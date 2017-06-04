using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using DevComponents.DotNetBar;
using System.Resources;
using System.Reflection;
using Chess_Library;
using System.Globalization;

namespace Chess_game
{
    public partial class Form_Options : Office2007RibbonForm
    {
        #region Constructor 
        public Form_Options()
        {
            InitializeComponent();
        }

        public Form_Options(CultureInfo language)
        {
            InitializeComponent();

            Assembly a = Assembly.Load("Chess game");
            ResourceManager rm = new ResourceManager("Chess_game.Resources.Lang.Langres", a);

            //Change Language 
            lbl_Form_Option.Text = rm.GetString("lbl_Form_Option", language);
            lbl_CellSize.Text = rm.GetString("lbl_CellSize", language);
            lbl_ChessPieceSize.Text = rm.GetString("lbl_ChessPieceSize", language);
            lbl_BoardStyle.Text = rm.GetString("lbl_BoardStyle", language);
            lbl_ChessPieceStyle.Text = rm.GetString("lbl_ChessPieceStyle", language);
            ckb_Sound.Text = rm.GetString("ckb_Sound", language);
            btn_Save.Text = rm.GetString("btn_Save", language);
            btn_Cancel.Text = rm.GetString("btn_Cancel", language);
            grp_Style.Text = rm.GetString("grp_Style", language);
            this.Text = rm.GetString("Form_Options", language);
        }
        #endregion

        Options obj;

        private void btn_Cancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void Form_Options_Load(object sender, EventArgs e)
        {
            obj = new Options();
            Load_Options();
        }

        private void Load_Options()
        {
            int_CellSize.Value = obj.CellSize;
            int_ChessPieceSize.Value = obj.PieceSize;

            cboBoardStyle.SelectedIndex = ((int)obj.BoardStyle) - 1;
            cboChessPieceStyle.SelectedIndex = ((int)obj.PieceStyle) - 1;

            ckb_Sound.Checked = obj.PlaySound; 

            try
            {
                Uc_ChessBoard board = new Uc_ChessBoard(obj.BoardStyle, obj.PieceStyle, eChessSide.White, eGameMode.VsNetWorkPlayer, 48, 48, false, new CultureInfo("vi"));
                pictureBox1.Image = board.TakePicture(pictureBox1.Width, pictureBox1.Height);
                board.Dispose();
            }
            catch
            {

            }
        }

        private void btn_Save_Click(object sender, EventArgs e)
        {
            obj.CellSize = (int)int_CellSize.Value;
            obj.PieceSize = (int)int_ChessPieceSize.Value;

            obj.BoardStyle = (eChessBoardStyle)(cboBoardStyle.SelectedIndex + 1);
            obj.PieceStyle = (eChessPieceStyle)(cboChessPieceStyle.SelectedIndex + 1);

            obj.PlaySound = ckb_Sound.Checked;
            obj.SaveOptions();
            this.Close();
        }

        private void int_CellSize_ValueChanged(object sender, EventArgs e)
        {
            if (int_ChessPieceSize.Value > int_CellSize.Value)
                int_ChessPieceSize.Value = int_CellSize.Value;
        }

        private void int_ChessPieceSize_ValueChanged(object sender, EventArgs e)
        {
            if (int_ChessPieceSize.Value > int_CellSize.Value)
                int_ChessPieceSize.Value = int_CellSize.Value;
        }

        private void cboBoardStyle_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cboBoardStyle.SelectedIndex == -1 || cboChessPieceStyle.SelectedIndex == -1)
                return;

            try
            {
                eChessBoardStyle BoardStyle = (eChessBoardStyle)(cboBoardStyle.SelectedIndex + 1);
                eChessPieceStyle PieceStyle = (eChessPieceStyle)(cboChessPieceStyle.SelectedIndex + 1);

                Uc_ChessBoard board = new Uc_ChessBoard(BoardStyle, PieceStyle, eChessSide.White, eGameMode.VsNetWorkPlayer, 48, 48, false, new CultureInfo("vi"));

                pictureBox1.Image = board.TakePicture(pictureBox1.Width, pictureBox1.Height);
                board.Dispose();
            }
            catch
            {

            }
        }
    }
}
