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
using System.Reflection;
using System.Resources;

namespace Chess_game
{
    public partial class Form_Change_Language : Office2007RibbonForm
    {
        public Form_Change_Language()
        {
            InitializeComponent();
        }

        public Form_Change_Language(System.Globalization.CultureInfo language)
        {
            InitializeComponent();
            Assembly a = Assembly.Load("Chess game");
            ResourceManager rm = new ResourceManager("Chess_game.Resources.Lang.Langres", a);

            //Change Language
            this.Text = rm.GetString("Form_Change_Language", language);
        }

        private void picBox_VietNamese_Click(object sender, EventArgs e)
        {
            (Application.OpenForms["Form_Main"] as Form_Main).Change_Language_to_VietNamese();
            this.Close();
        }

        private void picBox_EngLish_Click(object sender, EventArgs e)
        {
            (Application.OpenForms["Form_Main"] as Form_Main).Change_Language_to_English();
            this.Close();
        }
    }
}
