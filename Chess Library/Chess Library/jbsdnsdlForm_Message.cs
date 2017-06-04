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

namespace Chess_Library
{
    public partial class Form_Message : Office2007RibbonForm
    {
        public static bool Continue_Show_Message = true;

        public Form_Message()
        {
            InitializeComponent();
        }

        public Form_Message(string Message, System.Globalization.CultureInfo Language)
        {
            InitializeComponent();

            label_Result.Text = Message;

            //Change Language
            Assembly a = Assembly.Load("Chess Library");
            ResourceManager rm = new ResourceManager("Chess_Library.Resources.Lang.Langres", a);

            this.Text = rm.GetString("Form_Message", Language);
            checkbox_continue_message.Text = rm.GetString("checkbox_continue_message", Language);
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            Continue_Show_Message = !checkbox_continue_message.Checked;
            this.Dispose();
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            this.Dispose();
        }
    }
}
