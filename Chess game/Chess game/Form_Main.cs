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
using DevComponents.DotNetBar.Metro.ColorTables;
using System.Reflection;
using System.Resources;
using System.Globalization;
using System.IO;
using Chess_Library;
using System.Collections;
using System.Drawing.Imaging;

namespace Chess_game
{
    public partial class Form_Main : Office2007RibbonForm
    {
        #region Declare variables
        CultureInfo _language = new CultureInfo("vi");

        short _timeLimit = 1;
        short _timeBonus = 0;
        Uc_ChessBoard board;
        eGameMode _gameMode;
        eGameDifficulty _gameDifficulty;
        eChessSide _ownSide;

        Label[] lblNotation = new Label[36];
        int _notationSize;
        bool _computerMoving = false;
        Uc_CountDownTimer ucCountDownTimer1, ucCountDownTimer2;
        Uc_ChessPieceEated ucChessPieceEated1, ucChessPieceEated2;
        #endregion

        public Form_Main()
        {
            InitializeComponent();
        }

        #region Change display
        private void buttonItem2_Click(object sender, EventArgs e)
        {
            styleManager1.ManagerStyle = eStyle.Office2010Blue;
            _base_Color = styleManager1.ManagerColorTint;
        }

        private void buttonItem3_Click(object sender, EventArgs e)
        {
            styleManager1.ManagerStyle = eStyle.Office2010Black;
            _base_Color = styleManager1.ManagerColorTint;
        }

        private void buttonItem4_Click(object sender, EventArgs e)
        {
            styleManager1.ManagerStyle = eStyle.Office2010Silver;
            _base_Color = styleManager1.ManagerColorTint;
        }

        private void buttonItem5_Click(object sender, EventArgs e)
        {
            styleManager1.ManagerStyle = eStyle.Office2007Black;
            _base_Color = styleManager1.ManagerColorTint;
        }

        private void buttonItem6_Click(object sender, EventArgs e)
        {
            styleManager1.ManagerStyle = eStyle.Office2007VistaGlass;
            _base_Color = styleManager1.ManagerColorTint;
        }

        private void buttonItem7_Click(object sender, EventArgs e)
        {
            styleManager1.ManagerStyle = eStyle.Windows7Blue;
            _base_Color = styleManager1.ManagerColorTint;

        }

        private Color _base_Color = Color.Blue;
        private bool _color_Selected = false;

        private void colorPickerDropDown1_SelectedColorChanged(object sender, EventArgs e)
        {
            _color_Selected = true;
            _base_Color = colorPickerDropDown1.SelectedColor;
        }

        private void colorPickerDropDown1_ExpandChange(object sender, EventArgs e)
        {
            if (_color_Selected)
            {
                _base_Color = colorPickerDropDown1.SelectedColor;
                
            }

            styleManager1.ManagerColorTint = _base_Color;
            styleManager1.MetroColorParameters = new MetroColorGeneratorParameters(_base_Color, _base_Color);
            _color_Selected = false;
        }

        private void colorPickerDropDown1_ColorPreview(object sender, ColorPreviewEventArgs e)
        {
            styleManager1.MetroColorParameters = new MetroColorGeneratorParameters(e.Color, e.Color);
            styleManager1.ManagerColorTint = e.Color;
        }
        #endregion

        #region Change Language
        private void btn_Language_Click(object sender, EventArgs e)
        {
            Form_Change_Language Form_temp = new Form_Change_Language(_language);
            
            if (Form_temp.ShowDialog() == DialogResult.OK)
            {

            }
            Form_temp.Dispose();
        }

        private void GetRes(CultureInfo Language)
        {
            Assembly a = Assembly.Load("Chess game");
            ResourceManager rm = new ResourceManager("Chess_game.Resources.Lang.Langres", a);

            //Change Language
            btn_Author.Text = rm.GetString("btn_Author", Language);
            btn_Capture.Text = rm.GetString("btn_Capture", Language);
            btn_Chessrule.Text = rm.GetString("btn_Chessrule", Language);
            btn_Exit.Text = rm.GetString("btn_Exit", Language);
            btn_Hint.Text = rm.GetString("btn_Hint", Language);
            btn_Language.Text = rm.GetString("btn_Language", Language);
            btn_Loadgame.Text = rm.GetString("btn_Loadgame", Language);
            btn_Newgame.Text = rm.GetString("btn_Newgame", Language);
            btn_Redo.Text = rm.GetString("btn_Redo", Language);
            btn_Savegame.Text = rm.GetString("btn_Savegame", Language);
            btn_Savemoved.Text = rm.GetString("btn_Savemoved", Language);
            btn_Undo.Text = rm.GetString("btn_Undo", Language);
            buttonItem1.Text = rm.GetString("buttonItem1", Language);
            this.Text = rm.GetString("Form_Main", Language);
            ribbonTabItem_Home.Text = rm.GetString("ribbonTabItem_Home", Language);
            ribbonTabItem_Help.Text = rm.GetString("ribbonTabItem_Help", Language);
            ribbonTabItem_Auxiliaryfunction.Text = rm.GetString("ribbonTabItem_Auxiliaryfunction", Language);
            btn_Options.Text = rm.GetString("btn_Options", Language);
        }
        public void Change_Language_to_VietNamese()
        {
            this.btn_Language.Image = global::Chess_game.Properties.Resources.Vietnam_icon;
            _language = new CultureInfo("vi");
            if (board!=null)
                board.Language = _language;
            GetRes(_language);
        }

        public void Change_Language_to_English()
        {
            this.btn_Language.Image = global::Chess_game.Properties.Resources.United_kingdom_icon;
            _language = new CultureInfo("en-US");
            if (board != null)
                board.Language = _language;
            GetRes(_language);
        }
        #endregion

     
        #region Player vs Player
        //Play with Player 
        private void CreateChessBoard(eChessSide ownside, eGameMode gamemode)
        {
            if (board != null)
            {
                board.CancelThinking();
                board.Dispose();

                ucCountDownTimer1.StopTimer();
                ucCountDownTimer2.StopTimer();

                ucCountDownTimer1.Min = _timeLimit;
                ucCountDownTimer2.Min = _timeLimit;
                ucCountDownTimer1.Sec = 0;
                ucCountDownTimer2.Sec = 0;
            }
            else
            {
                ucChessPieceEated1 = new Uc_ChessPieceEated(ownside);
                ucChessPieceEated2 = new Uc_ChessPieceEated(ownside);

                ucCountDownTimer1 = new Uc_CountDownTimer();
                ucCountDownTimer2 = new Uc_CountDownTimer();
                ucCountDownTimer1.StopTimer();
                ucCountDownTimer2.StopTimer();

                ucCountDownTimer1.Min = _timeLimit;
                ucCountDownTimer2.Min = _timeLimit;
                ucCountDownTimer1.Sec = 1;
                ucCountDownTimer2.Sec = 1;

                ucCountDownTimer1.TimeOut += new Uc_CountDownTimer.TimeOutHandler(UcCountDownTimer_TimeOut);
                ucCountDownTimer2.TimeOut += new Uc_CountDownTimer.TimeOutHandler(UcCountDownTimer_TimeOut);
            }

            this.SuspendLayout();
            btn_Undo.Enabled = true;
            btn_Redo.Enabled = true;
            btn_Savegame.Enabled = true;
            btn_Savemoved.Enabled = true;
            panel1.Visible = true;
            panel1.Controls.Clear();

            pnlTimerLeft.Controls.Clear();
            pnlTimerRight.Controls.Clear();
            pnlTimerRight.Visible = true;
            pnlTimerLeft.Visible = true;
            pnlTimerLeft.Controls.Add(this.ucCountDownTimer1);
            pnlTimerRight.Controls.Add(this.ucCountDownTimer2);
            ucCountDownTimer1.Size = new Size(110, 35);
            ucCountDownTimer2.Size = new Size(110, 35);
            ucCountDownTimer1.Location = new Point(8, 8);
            ucCountDownTimer2.Location = new Point(8, 8);
            pnlTimerLeft.Size = new Size(ucCountDownTimer1.Width + 16, ucCountDownTimer1.Height + 16);
            pnlTimerRight.Size = pnlTimerLeft.Size;

            Options obj = new Options();

            board = new Uc_ChessBoard(obj.BoardStyle, obj.PieceStyle, ownside, gamemode, obj.CellSize, obj.PieceSize, obj.PlaySound, _language);

            board.MoveMaked += new Uc_ChessBoard.MoveMakedHandler(MoveMaked);
            if (board.GameMode == eGameMode.VsComputer)
                btn_Hint.Enabled = true;
            else
                btn_Hint.Enabled = false;

            Bitmap bmpBackImage = new Bitmap(board.Width, board.Height);
            board.DrawToBitmap(bmpBackImage, board.Bounds);
            board.BackgroundImage = bmpBackImage;
            board.BoardBitmap = bmpBackImage;

            _notationSize = (int)((obj.CellSize * 38) / 100);

            AddNotation(obj.CellSize, ownside);
            board.Location = new Point(_notationSize, _notationSize);
            this.panel1.ClientSize = new Size(obj.CellSize * 8 + _notationSize * 2, obj.CellSize * 8 + _notationSize * 2);
            this.panel1.Controls.Add(board);

            this.MinimumSize = new Size(1000, 230 + obj.CellSize * 8);

            pnlTimerLeft.Location = new Point(8, 161);
            panel1.Location = new Point(pnlTimerLeft.Location.X + 2 + pnlTimerLeft.Width, 161);
            pnlTimerRight.Location = new Point(panel1.Location.X + 2 + panel1.Width, panel1.Location.Y + panel1.Height - pnlTimerRight.Height);


            //ChessPieceEated 
            pnlChessPieceEated1.Controls.Clear();
            pnlChessPieceEated2.Controls.Clear();
            pnlChessPieceEated1.Visible = true;
            pnlChessPieceEated2.Visible = true;
        
            if (board.OwnSide == eChessSide.White)
            {
                ucChessPieceEated1.Side = eChessSide.White;
                pnlChessPieceEated1.BackColor = Color.White;
                ucChessPieceEated2.Side = eChessSide.Black;
                pnlChessPieceEated2.BackColor = Color.DimGray;
            }
            else
            {
                ucChessPieceEated1.Side = eChessSide.Black;
                pnlChessPieceEated1.BackColor = Color.DimGray;
                ucChessPieceEated2.Side = eChessSide.White;
                pnlChessPieceEated2.BackColor = Color.White;
            }

            pnlChessPieceEated1.Size = new Size(pnlTimerLeft.Size.Width - 45, (pnlTimerLeft.Width - 30) * 4);
            pnlChessPieceEated2.Size = new Size(pnlTimerRight.Size.Width - 45, (pnlTimerRight.Width - 30) * 4);
            pnlChessPieceEated1.Location = new Point(pnlTimerLeft.Location.X + pnlTimerLeft.Width - pnlChessPieceEated1.Width , pnlTimerLeft.Location.Y + pnlTimerLeft.Height + 10);
            pnlChessPieceEated2.Location = new Point(pnlTimerRight.Location.X, pnlTimerRight.Location.Y - pnlChessPieceEated2.Height - 10);
            ucChessPieceEated1.Size = new Size(pnlChessPieceEated1.Size.Width , pnlChessPieceEated1.Size.Height);
            ucChessPieceEated2.Size = new Size(pnlChessPieceEated2.Size.Width , pnlChessPieceEated2.Size.Height);
            pnlChessPieceEated1.Controls.Add(ucChessPieceEated1);
            pnlChessPieceEated2.Controls.Add(ucChessPieceEated2);
            ucChessPieceEated1.LoadChessPieces(board.stkChessPieceEated);
            ucChessPieceEated2.LoadChessPieces(board.stkChessPieceEated);

            //panel1.Location = new Point(0,0);
            if (board.OwnSide == eChessSide.White)
                ucCountDownTimer2.StartTimer();
            else
                ucCountDownTimer1.StartTimer();
            this.ResumeLayout();
        }

        /// <summary>
        /// When a player run out of time 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void UcCountDownTimer_TimeOut(object sender, EventArgs e)
        {
            if (board == null)
                return;
            btn_Savegame.Enabled = false;
            btn_Hint.Enabled = false;
            btn_Undo.Enabled = false;
            btn_Redo.Enabled = false;
            btn_Savemoved.Enabled = false;
            board.Enabled = false;

            Assembly a = Assembly.Load("Chess Library");
            ResourceManager rm = new ResourceManager("Chess_Library.Resources.Lang.Langres", a);
            string res = "";

            if (board.GameMode == eGameMode.VsHuman)
            {
                if (board.WhoTurn == eChessSide.White)
                    res += rm.GetString("Result_BlackWin", _language) + " - " + rm.GetString("Result_WhiteOutOfTime", _language);
                else
                    res += rm.GetString("Result_WhiteWin", _language) + " - " + rm.GetString("Result_BlackOutOfTime", _language);
            }
            else
            {
                if (board.OwnSide == eChessSide.White)
                {
                    if (board.WhoTurn == eChessSide.White)
                        res += rm.GetString("Result_ComputerWin", _language) + " - " + rm.GetString("Result_HumanOutOfTime", _language);
                    else
                        res += rm.GetString("Result_HumanWin", _language) + " - " + rm.GetString("Result_ComputerOutOfTime", _language);
                }
                else
                {
                    if (board.WhoTurn == eChessSide.Black)
                        res += rm.GetString("Result_ComputerWin", _language) + " - " + rm.GetString("Result_HumanOutOfTime", _language);
                    else
                        res += rm.GetString("Result_HumanWin", _language) + " - " + rm.GetString("Result_ComputerOutOfTime", _language);
                }
            }

            if (Form_Message.Continue_Show_Message == true)
            {
                Form_Message form_temp = new Form_Message(res, _language);

                form_temp.Show();
            }
        }

        /// <summary>
        /// Player vs Player given ChessState
        /// </summary>
        /// <param name="ownside"></param>
        /// <param name="gameMode"></param>
        private void CreateChessBoard(eChessSide ownside, eGameMode gameMode,ChessState[,] arrState)
        {
            if (board != null)
            {
                board.CancelThinking();
                board.Dispose();

                ucCountDownTimer1.StopTimer();
                ucCountDownTimer2.StopTimer();

                ucCountDownTimer1.Min = _timeLimit;
                ucCountDownTimer2.Min = _timeLimit;
                ucCountDownTimer1.Sec = 0;
                ucCountDownTimer2.Sec = 0;
            }
            else
            {
                ucChessPieceEated1 = new Uc_ChessPieceEated(ownside);
                ucChessPieceEated2 = new Uc_ChessPieceEated(ownside);

                ucCountDownTimer1 = new Uc_CountDownTimer();
                ucCountDownTimer2 = new Uc_CountDownTimer();
                ucCountDownTimer1.StopTimer();
                ucCountDownTimer2.StopTimer();

                ucCountDownTimer1.Min = _timeLimit;
                ucCountDownTimer2.Min = _timeLimit;
                ucCountDownTimer1.Sec = 1;
                ucCountDownTimer2.Sec = 1;

                ucCountDownTimer1.TimeOut += new Uc_CountDownTimer.TimeOutHandler(UcCountDownTimer_TimeOut);
                ucCountDownTimer2.TimeOut += new Uc_CountDownTimer.TimeOutHandler(UcCountDownTimer_TimeOut);
            }
            this.SuspendLayout();
            btn_Undo.Enabled = true;
            btn_Redo.Enabled = true;
            btn_Savegame.Enabled = true;
            btn_Savemoved.Enabled = true;
            panel1.Visible = true;
            panel1.Controls.Clear();

            pnlTimerLeft.Controls.Clear();
            pnlTimerRight.Controls.Clear();
            pnlTimerRight.Visible = true;
            pnlTimerLeft.Visible = true;
            pnlTimerLeft.Controls.Add(this.ucCountDownTimer1);
            pnlTimerRight.Controls.Add(this.ucCountDownTimer2);
            ucCountDownTimer1.Size = new Size(110, 35);
            ucCountDownTimer2.Size = new Size(110, 35);
            ucCountDownTimer1.Location = new Point(8, 8);
            ucCountDownTimer2.Location = new Point(8, 8);
            pnlTimerLeft.Size = new Size(ucCountDownTimer1.Width + 16, ucCountDownTimer1.Height + 16);
            pnlTimerRight.Size = pnlTimerLeft.Size;

            Options obj = new Options();

            board = new Uc_ChessBoard(obj.BoardStyle, obj.PieceStyle, ownside, gameMode, obj.CellSize, obj.PieceSize, obj.PlaySound, _language, arrState);

            board.MoveMaked += new Uc_ChessBoard.MoveMakedHandler(MoveMaked);
            if (board.GameMode == eGameMode.VsComputer)
                btn_Hint.Enabled = true;
            else
                btn_Hint.Enabled = false;

            Bitmap bmpBackImage = new Bitmap(board.Width, board.Height);
            board.DrawToBitmap(bmpBackImage, board.Bounds);
            board.BackgroundImage = bmpBackImage;
            board.BoardBitmap = bmpBackImage;

            _notationSize = (int)((obj.CellSize * 38) / 100);

            AddNotation(obj.CellSize, ownside);
            board.Location = new Point(_notationSize, _notationSize);
            this.panel1.ClientSize = new Size(obj.CellSize * 8 + _notationSize * 2, obj.CellSize * 8 + _notationSize * 2);
            this.panel1.Controls.Add(board);

            this.MinimumSize = new Size(1000, 230 + obj.CellSize * 8);

            pnlTimerLeft.Location = new Point(8, 161);
            panel1.Location = new Point(pnlTimerLeft.Location.X + 2 + pnlTimerLeft.Width, 161);
            pnlTimerRight.Location = new Point(panel1.Location.X + 2 + panel1.Width, panel1.Location.Y + panel1.Height - pnlTimerRight.Height);

            //ChessPieceEated 
            pnlChessPieceEated1.Controls.Clear();
            pnlChessPieceEated2.Controls.Clear();
            pnlChessPieceEated1.Visible = true;
            pnlChessPieceEated2.Visible = true;

            if (board.OwnSide == eChessSide.White)
            {
                ucChessPieceEated1.Side = eChessSide.White;
                pnlChessPieceEated1.BackColor = Color.White;
                ucChessPieceEated2.Side = eChessSide.Black;
                pnlChessPieceEated2.BackColor = Color.DimGray;
            }
            else
            {
                ucChessPieceEated1.Side = eChessSide.Black;
                pnlChessPieceEated1.BackColor = Color.DimGray;
                ucChessPieceEated2.Side = eChessSide.White;
                pnlChessPieceEated2.BackColor = Color.White;
            }

            pnlChessPieceEated1.Size = new Size(pnlTimerLeft.Size.Width - 45, (pnlTimerLeft.Width - 30) * 4);
            pnlChessPieceEated2.Size = new Size(pnlTimerRight.Size.Width - 45, (pnlTimerRight.Width - 30) * 4);
            pnlChessPieceEated1.Location = new Point(pnlTimerLeft.Location.X + pnlTimerLeft.Width - pnlChessPieceEated1.Width , pnlTimerLeft.Location.Y + pnlTimerLeft.Height + 10);
            pnlChessPieceEated2.Location = new Point(pnlTimerRight.Location.X, pnlTimerRight.Location.Y - pnlChessPieceEated2.Height - 10);
            ucChessPieceEated1.Size = new Size(pnlChessPieceEated1.Size.Width , pnlChessPieceEated1.Size.Height);
            ucChessPieceEated2.Size = new Size(pnlChessPieceEated2.Size.Width , pnlChessPieceEated2.Size.Height);
            pnlChessPieceEated1.Controls.Add(ucChessPieceEated1);
            pnlChessPieceEated2.Controls.Add(ucChessPieceEated2);
            ucChessPieceEated1.LoadChessPieces(board.stkChessPieceEated);
            ucChessPieceEated2.LoadChessPieces(board.stkChessPieceEated);

            //panel1.Location = new Point(0,0);
            if (board.OwnSide == eChessSide.White)
                ucCountDownTimer2.StartTimer();
            else
                ucCountDownTimer1.StartTimer();
            this.ResumeLayout();
        }
        #endregion

        /// <summary>
        /// Add A,B,C,D,..., 1 2 3 4 to Chess Board
        /// </summary>
        /// <param name="intcellsize"></param>
        /// <param name="eownside"></param>
        void AddNotation(int intcellsize, eChessSide eownside)
        {

            for (int i = 0; i < 36; i++)
            {
                lblNotation[i] = new Label();
                lblNotation[i].Height = intcellsize;
                lblNotation[i].Width = intcellsize;
                lblNotation[i].Image = Read_Image_From_Resources.GetChessBoardBitMap(eChessSide.Black, eChessBoardStyle.BoardEdge);

                lblNotation[i].TextAlign = ContentAlignment.MiddleCenter;
                lblNotation[i].Font = new Font(FontFamily.GenericSansSerif, 14.0f);
                lblNotation[i].ImageAlign = ContentAlignment.MiddleCenter;
                lblNotation[i].ForeColor = Color.White;
            }

            lblNotation[0].Height = _notationSize;
            lblNotation[0].Width = _notationSize;
            lblNotation[0].Location = new Point();
            lblNotation[0].BackColor = Color.Blue;
            panel1.Controls.Add(lblNotation[0]);

            for (int i = 1; i <= 8; i++)
            {
                lblNotation[i].Height = _notationSize;
                if (eownside == eChessSide.White)
                {
                    lblNotation[i].Text = Convert.ToChar(64 + i).ToString();
                }
                else
                {
                    lblNotation[i].Text = Convert.ToChar(73 - i).ToString();
                }
                lblNotation[i].Location = new Point(intcellsize * (i - 1) + _notationSize, 0);
                panel1.Controls.Add(lblNotation[i]);
            }
            lblNotation[9].Height = _notationSize;
            lblNotation[9].Width = _notationSize;
            lblNotation[9].BackColor = Color.Blue;
            lblNotation[9].Location = new Point(0, _notationSize + intcellsize * 8);
            panel1.Controls.Add(lblNotation[9]);

            for (int i = 1; i <= 8; i++)
            {
                lblNotation[9 + i].Height = _notationSize;
                if (eownside == eChessSide.White)
                {
                    lblNotation[9 + i].Text = Convert.ToChar(64 + i).ToString();
                }
                else
                {
                    lblNotation[9 + i].Text = Convert.ToChar(73 - i).ToString();
                }
                lblNotation[9 + i].Location = new Point(intcellsize * (i - 1) + _notationSize, _notationSize + intcellsize * 8);
                panel1.Controls.Add(lblNotation[9 + i]);
            }
            lblNotation[18].Height = _notationSize;
            lblNotation[18].Width = _notationSize;
            lblNotation[18].BackColor = Color.Blue;
            lblNotation[18].Location = new Point(_notationSize + intcellsize * 8, 0);
            panel1.Controls.Add(lblNotation[18]);

            for (int i = 1; i <= 8; i++)
            {
                lblNotation[18 + i].Width = _notationSize;
                if (eownside == eChessSide.White)
                {
                    lblNotation[18 + i].Text = Convert.ToString(9 - i);
                }
                else
                {
                    lblNotation[18 + i].Text = Convert.ToString(i);
                }
                lblNotation[18 + i].Location = new Point(0, intcellsize * (i - 1) + _notationSize);
                panel1.Controls.Add(lblNotation[18 + i]);
            }

            lblNotation[27].Height = _notationSize;
            lblNotation[27].Width = _notationSize;
            lblNotation[27].BackColor = Color.Blue;
            lblNotation[27].Location = new Point(_notationSize + intcellsize * 8, _notationSize + intcellsize * 8);
            panel1.Controls.Add(lblNotation[27]);
            for (int i = 1; i <= 8; i++)
            {
                lblNotation[27 + i].Width = _notationSize;
                if (eownside == eChessSide.White)
                {
                    lblNotation[27 + i].Text = Convert.ToString(9 - i);
                }
                else
                {
                    lblNotation[27 + i].Text = Convert.ToString(i);
                }
                lblNotation[27 + i].Location = new Point(_notationSize + intcellsize * 8, intcellsize * (i - 1) + _notationSize);
                panel1.Controls.Add(lblNotation[27 + i]);
            }

        }


        /// <summary>
        /// Event Move Maked
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        void MoveMaked(object sender, EventArgs e)
        {
            if (board == null)
                return;

            ucCountDownTimer1.StopTimer();
            ucCountDownTimer2.StopTimer();
            if (board.WhoTurn == board.OwnSide)
                ucCountDownTimer1.TimeBonus(_timeBonus);
            else
                ucCountDownTimer2.TimeBonus(_timeBonus);

            if (board.GameMode == eGameMode.VsComputer)
            {
                board.Enabled = true;
                if (board.WhoTurn == board.OwnSide)
                {
                    btn_Savegame.Enabled = true;
                    btn_Hint.Enabled = true;
                    btn_Undo.Enabled = true;
                    btn_Redo.Enabled = true;
                    btn_Capture.Enabled = true;
                    btn_Savemoved.Enabled = true;
                    this._computerMoving = false;
                }
                else
                {
                    btn_Savegame.Enabled = false;
                    btn_Hint.Enabled = false;
                    btn_Undo.Enabled = false;
                    btn_Redo.Enabled = false;
                    btn_Capture.Enabled = false;
                    btn_Savemoved.Enabled = false;
                    this._computerMoving = true;
                }

                if (board.GameStatus != eGameStatus.Playing)
                    btn_Hint.Enabled = false;
            }
            else
            {
                board.Enabled = true;
                btn_Savegame.Enabled = true;
                btn_Undo.Enabled = true;
            }

            if (board.GameStatus != eGameStatus.Playing)
            {
                board.Enabled = false;
            }

            if (board.WhoTurn == board.OwnSide)
                ucCountDownTimer2.StartTimer();
            else
                ucCountDownTimer1.StartTimer();

            ucChessPieceEated1.LoadChessPieces(board.stkChessPieceEated);
            ucChessPieceEated2.LoadChessPieces(board.stkChessPieceEated);
        }

        #region Player vs Computer 
        //Play with Computer 
        private void CreateChessBoard(eChessSide ownside, eGameMode gamemode, eGameDifficulty gamedifficulty)
        {
            if (board != null)
            {
                board.CancelThinking();
                board.Dispose();

                ucCountDownTimer1.StopTimer();
                ucCountDownTimer2.StopTimer();

                ucCountDownTimer1.Min = _timeLimit;
                ucCountDownTimer2.Min = _timeLimit;
                ucCountDownTimer1.Sec = 0;
                ucCountDownTimer2.Sec = 0;
            }
            else
            {
                ucChessPieceEated1 = new Uc_ChessPieceEated(ownside);
                ucChessPieceEated2 = new Uc_ChessPieceEated(ownside);

                ucCountDownTimer1 = new Uc_CountDownTimer();
                ucCountDownTimer2 = new Uc_CountDownTimer();
                ucCountDownTimer1.StopTimer();
                ucCountDownTimer2.StopTimer();

                ucCountDownTimer1.Min = _timeLimit;
                ucCountDownTimer2.Min = _timeLimit;
                ucCountDownTimer1.Sec = 1;
                ucCountDownTimer2.Sec = 1;

                ucCountDownTimer1.TimeOut += new Uc_CountDownTimer.TimeOutHandler(UcCountDownTimer_TimeOut);
                ucCountDownTimer2.TimeOut += new Uc_CountDownTimer.TimeOutHandler(UcCountDownTimer_TimeOut);
            }
            this.SuspendLayout();
            btn_Undo.Enabled = true;
            btn_Redo.Enabled = true;
            btn_Savegame.Enabled = true;
            btn_Savemoved.Enabled = true;
            panel1.Visible = true;
            panel1.Controls.Clear();

            
            pnlTimerLeft.Controls.Clear();
            pnlTimerRight.Controls.Clear();
            pnlTimerRight.Visible = true;
            pnlTimerLeft.Visible = true;
            pnlTimerLeft.Controls.Add(this.ucCountDownTimer1);
            pnlTimerRight.Controls.Add(this.ucCountDownTimer2);
            ucCountDownTimer1.Size = new Size(110, 35);
            ucCountDownTimer2.Size = new Size(110, 35);
            ucCountDownTimer1.Location = new Point(8, 8);
            ucCountDownTimer2.Location = new Point(8, 8);
            pnlTimerLeft.Size = new Size(ucCountDownTimer1.Width + 16, ucCountDownTimer1.Height + 16);
            pnlTimerRight.Size = pnlTimerLeft.Size;

            Options obj = new Options();
            board = new Uc_ChessBoard(obj.BoardStyle, obj.PieceStyle, ownside, gamemode, gamedifficulty, obj.CellSize, obj.PieceSize, obj.PlaySound, _language);

            board.MoveMaked += new Uc_ChessBoard.MoveMakedHandler(MoveMaked);
            if (board.GameMode == eGameMode.VsComputer)
                btn_Hint.Enabled = true;
            else
                btn_Hint.Enabled = false;

            Bitmap bmpBackImage = new Bitmap(board.Width, board.Height);
            board.DrawToBitmap(bmpBackImage, board.Bounds);
            board.BackgroundImage = bmpBackImage;
            board.BoardBitmap = bmpBackImage;

            _notationSize = (int)((obj.CellSize * 38) / 100);
            this._gameMode = gamemode;
            this._ownSide = ownside;

            AddNotation(obj.CellSize, ownside);
            board.Location = new Point(_notationSize, _notationSize);
            
            this.panel1.ClientSize = new Size(obj.CellSize * 8 + _notationSize * 2, obj.CellSize * 8 + _notationSize * 2);
            this.panel1.Controls.Add(board);
            this.MinimumSize = new Size(1000, 230 + obj.CellSize * 8);

            pnlTimerLeft.Location = new Point(8, 161);
            panel1.Location = new Point(pnlTimerLeft.Location.X + 2 + pnlTimerLeft.Width, 161);
            pnlTimerRight.Location = new Point(panel1.Location.X + 2 + panel1.Width, panel1.Location.Y + panel1.Height - pnlTimerRight.Height);

            //ChessPieceEated 
            pnlChessPieceEated1.Controls.Clear();
            pnlChessPieceEated2.Controls.Clear();
            pnlChessPieceEated1.Visible = true;
            pnlChessPieceEated2.Visible = true;

            if (board.OwnSide == eChessSide.White)
            {
                ucChessPieceEated1.Side = eChessSide.White;
                pnlChessPieceEated1.BackColor = Color.White;
                ucChessPieceEated2.Side = eChessSide.Black;
                pnlChessPieceEated2.BackColor = Color.DimGray;
            }
            else
            {
                ucChessPieceEated1.Side = eChessSide.Black;
                pnlChessPieceEated1.BackColor = Color.DimGray;
                ucChessPieceEated2.Side = eChessSide.White;
                pnlChessPieceEated2.BackColor = Color.White;
            }

            pnlChessPieceEated1.Size = new Size(pnlTimerLeft.Size.Width - 45, (pnlTimerLeft.Width - 30) * 4);
            pnlChessPieceEated2.Size = new Size(pnlTimerRight.Size.Width - 45, (pnlTimerRight.Width - 30) * 4);
            pnlChessPieceEated1.Location = new Point(pnlTimerLeft.Location.X + pnlTimerLeft.Width - pnlChessPieceEated1.Width, pnlTimerLeft.Location.Y + pnlTimerLeft.Height + 10);
            pnlChessPieceEated2.Location = new Point(pnlTimerRight.Location.X, pnlTimerRight.Location.Y - pnlChessPieceEated2.Height - 10);
            ucChessPieceEated1.Size = new Size(pnlChessPieceEated1.Size.Width , pnlChessPieceEated1.Size.Height);
            ucChessPieceEated2.Size = new Size(pnlChessPieceEated2.Size.Width , pnlChessPieceEated2.Size.Height);
            pnlChessPieceEated1.Controls.Add(ucChessPieceEated1);
            pnlChessPieceEated2.Controls.Add(ucChessPieceEated2);
            ucChessPieceEated1.LoadChessPieces(board.stkChessPieceEated);
            ucChessPieceEated2.LoadChessPieces(board.stkChessPieceEated);

            if (board.OwnSide == eChessSide.White)
                ucCountDownTimer2.StartTimer();
            else
                ucCountDownTimer1.StartTimer();
            this.ResumeLayout();
        }

        /// <summary>
        /// Play with computer given State
        /// </summary>
        /// <param name="ownside"></param>
        /// <param name="gamemode"></param>
        /// <param name="gamedifficulty"></param>
        /// <param name="arrState"></param>
        private void CreateChessBoard(eChessSide ownside, eGameMode gamemode, eGameDifficulty gamedifficulty, ChessState[,] arrState)
        {
            if (board != null)
            {
                board.CancelThinking();
                board.Dispose();

                ucCountDownTimer1.StopTimer();
                ucCountDownTimer2.StopTimer();

                ucCountDownTimer1.Min = _timeLimit;
                ucCountDownTimer2.Min = _timeLimit;
                ucCountDownTimer1.Sec = 0;
                ucCountDownTimer2.Sec = 0;
            }
            else
            {
                ucChessPieceEated1 = new Uc_ChessPieceEated(ownside);
                ucChessPieceEated2 = new Uc_ChessPieceEated(ownside);

                ucCountDownTimer1 = new Uc_CountDownTimer();
                ucCountDownTimer2 = new Uc_CountDownTimer();
                ucCountDownTimer1.StopTimer();
                ucCountDownTimer2.StopTimer();

                ucCountDownTimer1.Min = _timeLimit;
                ucCountDownTimer2.Min = _timeLimit;
                ucCountDownTimer1.Sec = 1;
                ucCountDownTimer2.Sec = 1;

                ucCountDownTimer1.TimeOut += new Uc_CountDownTimer.TimeOutHandler(UcCountDownTimer_TimeOut);
                ucCountDownTimer2.TimeOut += new Uc_CountDownTimer.TimeOutHandler(UcCountDownTimer_TimeOut);
            }

            this.SuspendLayout();
            btn_Undo.Enabled = true;
            btn_Redo.Enabled = true;
            btn_Savegame.Enabled = true;
            btn_Savemoved.Enabled = true;
            panel1.Visible = true;
            panel1.Controls.Clear();

            pnlTimerLeft.Controls.Clear();
            pnlTimerRight.Controls.Clear();
            pnlTimerRight.Visible = true;
            pnlTimerLeft.Visible = true;
            pnlTimerLeft.Controls.Add(this.ucCountDownTimer1);
            pnlTimerRight.Controls.Add(this.ucCountDownTimer2);
            ucCountDownTimer1.Size = new Size(110, 35);
            ucCountDownTimer2.Size = new Size(110, 35);
            ucCountDownTimer1.Location = new Point(8, 8);
            ucCountDownTimer2.Location = new Point(8, 8);
            pnlTimerLeft.Size = new Size(ucCountDownTimer1.Width + 16, ucCountDownTimer1.Height + 16);
            pnlTimerRight.Size = pnlTimerLeft.Size;

            Options obj = new Options();
            board = new Uc_ChessBoard(obj.BoardStyle, obj.PieceStyle, ownside, gamemode, gamedifficulty, obj.CellSize, obj.PieceSize, obj.PlaySound, _language, arrState);

            board.MoveMaked += new Uc_ChessBoard.MoveMakedHandler(MoveMaked);
            if (board.GameMode == eGameMode.VsComputer)
                btn_Hint.Enabled = true;
            else
                btn_Hint.Enabled = false;

            Bitmap bmpBackImage = new Bitmap(board.Width, board.Height);
            board.DrawToBitmap(bmpBackImage, board.Bounds);
            board.BackgroundImage = bmpBackImage;
            board.BoardBitmap = bmpBackImage;

            _notationSize = (int)((obj.CellSize * 38) / 100);
            this._gameMode = gamemode;
            this._ownSide = ownside;

            AddNotation(obj.CellSize, ownside);
            board.Location = new Point(_notationSize, _notationSize);
            
            this.panel1.ClientSize = new Size(obj.CellSize * 8 + _notationSize * 2, obj.CellSize * 8 + _notationSize * 2);
            this.panel1.Controls.Add(board);
            this.MinimumSize = new Size(1000, 230 + obj.CellSize * 8);

            pnlTimerLeft.Location = new Point(8, 161);
            panel1.Location = new Point(pnlTimerLeft.Location.X + 2 + pnlTimerLeft.Width, 161);
            pnlTimerRight.Location = new Point(panel1.Location.X + 2 + panel1.Width, panel1.Location.Y + panel1.Height - pnlTimerRight.Height);

            //ChessPieceEated 
            pnlChessPieceEated1.Controls.Clear();
            pnlChessPieceEated2.Controls.Clear();
            pnlChessPieceEated1.Visible = true;
            pnlChessPieceEated2.Visible = true;

            if (board.OwnSide == eChessSide.White)
            {
                ucChessPieceEated1.Side = eChessSide.White;
                pnlChessPieceEated1.BackColor = Color.White;
                ucChessPieceEated2.Side = eChessSide.Black;
                pnlChessPieceEated2.BackColor = Color.DimGray;
            }
            else
            {
                ucChessPieceEated1.Side = eChessSide.Black;
                pnlChessPieceEated1.BackColor = Color.DimGray;
                ucChessPieceEated2.Side = eChessSide.White;
                pnlChessPieceEated2.BackColor = Color.White;
            }

            pnlChessPieceEated1.Size = new Size(pnlTimerLeft.Size.Width - 45, (pnlTimerLeft.Width - 30) * 4);
            pnlChessPieceEated2.Size = new Size(pnlTimerRight.Size.Width - 45, (pnlTimerRight.Width - 30) * 4);
            pnlChessPieceEated1.Location = new Point(pnlTimerLeft.Location.X + pnlTimerLeft.Width - pnlChessPieceEated1.Width, pnlTimerLeft.Location.Y + pnlTimerLeft.Height + 10);
            pnlChessPieceEated2.Location = new Point(pnlTimerRight.Location.X, pnlTimerRight.Location.Y - pnlChessPieceEated2.Height - 10);
            ucChessPieceEated1.Size = new Size(pnlChessPieceEated1.Size.Width , pnlChessPieceEated1.Size.Height);
            ucChessPieceEated2.Size = new Size(pnlChessPieceEated2.Size.Width , pnlChessPieceEated2.Size.Height);
            pnlChessPieceEated1.Controls.Add(ucChessPieceEated1);
            pnlChessPieceEated2.Controls.Add(ucChessPieceEated2);
            ucChessPieceEated1.LoadChessPieces(board.stkChessPieceEated);
            ucChessPieceEated2.LoadChessPieces(board.stkChessPieceEated);

            if (board.OwnSide == eChessSide.White)
                ucCountDownTimer2.StartTimer();
            else
                ucCountDownTimer1.StartTimer();
            this.ResumeLayout();
        }
        #endregion
        
        private void btn_Exit_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btn_Newgame_Click(object sender, EventArgs e)
        {
            Form_New_game form_temp = new Form_New_game(_language);
            
            if (form_temp.ShowDialog() == DialogResult.OK)
            {
                _ownSide = form_temp._ownSide;
                _gameMode = form_temp._gameMode;
                _gameDifficulty = form_temp._gameDifficulty;
                this._timeLimit = form_temp._timeLimit;
                this._timeBonus = form_temp._timeBonus;

                if (_gameMode == eGameMode.VsHuman)
                    CreateChessBoard(_ownSide, _gameMode);
                else if (_gameMode == eGameMode.VsComputer)
                    CreateChessBoard(_ownSide, _gameMode, _gameDifficulty);
            }

            form_temp.Dispose();
        }

        private void btn_Author_Click(object sender, EventArgs e)
        {
            About_Box about_temp = new About_Box(_language);

            if (about_temp.ShowDialog() == DialogResult.OK)
            {

            }
            about_temp.Dispose();
        }

        private void btn_Chessrule_Click(object sender, EventArgs e)
        {
            Help.ShowHelp(this, Application.StartupPath + "\\ChessRule.chm", HelpNavigator.TableOfContents);
        }

        private void btn_Undo_Click(object sender, EventArgs e)
        {
            if (_gameMode == eGameMode.VsHuman)
            {
                board.UndoMove_PlayervsPlayer();
            }
            else if (_gameMode == eGameMode.VsComputer)
            {
                board.UndoMove_PlayervsPlayer();
                board.UndoMove_PlayervsPlayer();
            }
            ucChessPieceEated1.LoadChessPieces(board.stkChessPieceEated);
            ucChessPieceEated2.LoadChessPieces(board.stkChessPieceEated);
        }

        private void btn_Redo_Click(object sender, EventArgs e)
        {
            if (_gameMode == eGameMode.VsHuman)
            {
                board.RedoMove_PlayervsPlayer();
            }
            else if (_gameMode == eGameMode.VsComputer)
            {
                board.RedoMove_PlayervsPlayer();
                board.RedoMove_PlayervsPlayer();
            }
            ucChessPieceEated1.LoadChessPieces(board.stkChessPieceEated);
            ucChessPieceEated2.LoadChessPieces(board.stkChessPieceEated);
        }

        private void btn_Options_Click(object sender, EventArgs e)
        {
            if (this._computerMoving == true) return;

            Form_Options form_temp = new Form_Options(this._language);
            if (form_temp.ShowDialog() == DialogResult.OK && board!= null)
            {
                //Save this game 

                ChessState[,] SaveThisState = new ChessState[10, 10];
                
                int i, j;
                for (i = 0; i < 10; i++)
                    for (j = 0; j < 10; j++)
                        SaveThisState[i, j] = new ChessState(board.arrState[i, j].Type, board.arrState[i, j].Side, board.arrState[i, j].Moves);

                eGameStatus gameStatus = board.GameStatus;
                eGameEndReason gameStatusReason = board.GameStatusReason;
                eChessSide whoTurn = board.WhoTurn;
                ArrayList arrWhoCheck = board.arrWhoCheck;
                Stack<ChessMove> stkUndo = board.stkUndo;
                Stack<ChessMove> stkRedo = board.stkRedo;
                Stack<String> stkChessMoveString = board.stkChessMoveString;
                Stack<Bitmap_Side_ChessPieceEated> stkChessPieceEated = board.stkChessPieceEated;
                bool clearStackRedo = board.clear_Stack_Redo;
                Point positionLastMove = new Point(Uc_ChessBoard.PositionLastMove.X, Uc_ChessBoard.PositionLastMove.Y);
                Point positionChoosen = new Point(board.PositionChoosen.X, board.PositionChoosen.Y);
                Dictionary<string, int> arrPosition = board.arrPosition;

                if (this._gameMode == eGameMode.VsComputer)
                    CreateChessBoard(this._ownSide, this._gameMode, this._gameDifficulty, SaveThisState);
                else
                    CreateChessBoard(this._ownSide, this._gameMode, SaveThisState);
                
                //Unload this game 
                board.GameStatus = gameStatus;
                board.GameStatusReason = gameStatusReason;
                board.WhoTurn = whoTurn;
                board.arrWhoCheck = arrWhoCheck;
                board.stkUndo = stkUndo;
                board.stkRedo = stkRedo;
                board.stkChessMoveString = stkChessMoveString;
                board.clear_Stack_Redo = clearStackRedo;
                Uc_ChessBoard.PositionLastMove = new Point(positionLastMove.X, positionLastMove.Y);
                board.PositionChoosen = new Point(positionChoosen.X, positionChoosen.Y);
                board.arrPosition = arrPosition;
                board.stkChessPieceEated = stkChessPieceEated;
                ucChessPieceEated1.LoadChessPieces(board.stkChessPieceEated);
                ucChessPieceEated2.LoadChessPieces(board.stkChessPieceEated);
            }

        }


        private void btn_Savegame_Click(object sender, EventArgs e)
        {
            if (board != null)
            {
                Save_Load_ChessBoard sBoard = new Save_Load_ChessBoard(this.board, this.ucCountDownTimer1, this.ucCountDownTimer2);
                sBoard.Save();
            }
        }

        private void btn_Loadgame_Click(object sender, EventArgs e)
        {
            Save_Load_ChessBoard sBoard = new Save_Load_ChessBoard();
            Save_Load_ChessBoard saved = sBoard.Load();

            if (saved.Loaded == true)
            {

                //Load ChessBoard
                if (saved.GameMode == eGameMode.VsComputer)
                    CreateChessBoard(saved.OwnSide, saved.GameMode, saved.GameDifficulty, saved.SaveThisState);
                else
                    CreateChessBoard(saved.OwnSide, saved.GameMode, saved.SaveThisState);

                board.GameStatus = saved.GameStatus;
                board.GameStatusReason = saved.GameStatusReason;
                board.WhoTurn = saved.WhoTurn;
                board.arrWhoCheck = saved.arrWhoCheck;
                board.stkUndo = saved.stkUndo;
                board.stkRedo = saved.stkRedo;
                board.stkChessMoveString = saved.stkChessMoveString;
                board.clear_Stack_Redo = saved.Clear_Stack_Redo;
                Uc_ChessBoard.PositionLastMove = new Point(saved.PositionLastMove.X, saved.PositionLastMove.Y);
                board.PositionChoosen = new Point(saved.PositionChoosen.X, saved.PositionChoosen.Y);
                board.arrPosition = saved.arrPosition;
                board.stkChessPieceEated = saved.stkChessPieceEated;
                ucChessPieceEated1.LoadChessPieces(board.stkChessPieceEated);
                ucChessPieceEated2.LoadChessPieces(board.stkChessPieceEated);

                //Load Timer 
                ucCountDownTimer1.Min = saved.Min1;
                ucCountDownTimer1.Sec = saved.Sec1;
                ucCountDownTimer1.TimeBonus(0);
                ucCountDownTimer2.Min = saved.Min2;
                ucCountDownTimer2.Sec = saved.Sec2;
                ucCountDownTimer2.TimeBonus(0);
            }
        }

        private void btn_Savemoved_Click(object sender, EventArgs e)
        {
            SaveFileDialog dialog = new SaveFileDialog();
            dialog.Filter = "TEXT-File | *.txt";
            string path;

            try
            {
                if (dialog.ShowDialog() == DialogResult.OK)
                {
                    path = dialog.FileName;
                    //path = path.Substring(0, path.LastIndexOf('\\'));

                    using (StreamWriter writer = new StreamWriter(path))
                    {
                        foreach(string s in board.stkChessMoveString)
                            writer.WriteLine(s);
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void btn_Capture_Click(object sender, EventArgs e)
        {
            if (board != null)
            {
                try
                {
                    Bitmap bmp = board.TakePicture(board.Width, board.Height);

                    SaveFileDialog dialog = new SaveFileDialog();
                    dialog.Filter = "JPeg Image|*.jpg";
                    dialog.InitialDirectory = Environment.SpecialFolder.Desktop.ToString();
                    if (dialog.ShowDialog() == DialogResult.OK)
                    {
                        bmp.Save(dialog.FileName, ImageFormat.Jpeg);
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }
        }

        private void btn_Hint_Click(object sender, EventArgs e)
        {
            if (board != null)
            {
                MessageBox.Show(board.Hint());
            }
        }
    }
}
