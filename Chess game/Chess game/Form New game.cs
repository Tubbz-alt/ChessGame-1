using System;
using DevComponents.DotNetBar;
using System.Reflection;
using System.Resources;
using Chess_Library;

namespace Chess_game
{
    public partial class Form_New_game : Office2007RibbonForm
    {
        #region Constructor
        public Form_New_game()
        {
            InitializeComponent();
        }

        /// <summary>
        /// Constructor with Language
        /// </summary>
        /// <param name="Language"></param>
        public Form_New_game(System.Globalization.CultureInfo Language)
        {
            InitializeComponent();
            
            Assembly a = Assembly.Load("Chess game");
            ResourceManager rm = new ResourceManager("Chess_game.Resources.Lang.Langres", a);

            //Change Language 
            this.Text = rm.GetString("Form_New_game", Language);
            lbl_ChooseSide.Text = rm.GetString("lbl_ChooseSide", Language);
            lbl_ExtraTime.Text = rm.GetString("lbl_ExtraTime", Language);
            lbl_Form_Newgame.Text = rm.GetString("lbl_Form_Newgame", Language);
            lbl_GameMode.Text = rm.GetString("lbl_GameMode", Language);
            lbl_Level.Text = rm.GetString("lbl_Level", Language);
            lbl_Minute.Text = rm.GetString("lbl_Minute", Language);
            lbl_Second.Text = rm.GetString("lbl_Second", Language);
            lbl_TimeMax.Text = rm.GetString("lbl_TimeMax", Language);
            radiobtn_Black.Text = rm.GetString("radiobtn_Black", Language);
            radiobtn_Easy.Text = rm.GetString("radiobtn_Easy", Language);
            radiobtn_Hard.Text = rm.GetString("radiobtn_Hard", Language);
            radiobtn_Medium.Text = rm.GetString("radiobtn_Medium", Language);
            radiobtn_White.Text = rm.GetString("radiobtn_White", Language);
            btn_Start.Text =  rm.GetString("btn_Start", Language);
            combobox_Game_Mode.Text = rm.GetString("combobox_Game_Mode", Language);
            combobox_GameMode_itemvsCom.Text = rm.GetString("combobox_GameMode_itemvsCom", Language);
            combobox_GameMode_itemvsPlayer.Text = rm.GetString("combobox_GameMode_itemvsPlayer", Language);
        }
        #endregion

        public eChessSide _ownSide;
        public eGameMode _gameMode;
        public eGameDifficulty _gameDifficulty;
        public short _timeLimit = 1;
        public short _timeBonus = 0;

        private void btn_Start_Click(object sender, EventArgs e)
        {
            if (combobox_Game_Mode.SelectedIndex == 0 || combobox_Game_Mode.SelectedIndex == -1)
                _gameMode = eGameMode.VsComputer;
            else if (combobox_Game_Mode.SelectedIndex == 1)
                _gameMode = eGameMode.VsHuman;
            else _gameMode = eGameMode.ComVsCom;

            if (radiobtn_Black.Checked)
                _ownSide = eChessSide.Black;
            else _ownSide = eChessSide.White;

            if (radiobtn_Easy.Checked)
                _gameDifficulty = eGameDifficulty.Easy;
            else if (radiobtn_Medium.Checked)
                _gameDifficulty = eGameDifficulty.Normal;
            else _gameDifficulty = eGameDifficulty.Hard;

            _timeLimit = (short)integerInput_TimeLimit.Value;
            _timeBonus = (short)integerInput_TimeBonus.Value;
        }

        private void combobox_Game_Mode_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (combobox_Game_Mode.SelectedIndex == 1)
                groupPanel2.Enabled = false;
            else groupPanel2.Enabled = true;
        }
    }
}
