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
    public partial class About_Box : Office2007RibbonForm
    {
        public About_Box()
        {
            InitializeComponent();
        }
        /// <summary>
        /// Constructor with Language
        /// </summary>
        /// <param name="Language"></param>
        public About_Box(System.Globalization.CultureInfo Language)
        {
            InitializeComponent();

            Assembly a = Assembly.Load("Chess game");
            ResourceManager rm = new ResourceManager("Chess_game.Resources.Lang.Langres", a);

            //Change Language
            this.Text = rm.GetString("About_Box", Language);
            labelProductName.Text = rm.GetString("labelProductName", Language);
            labelVersion.Text = rm.GetString("labelVersion", Language);
            labelCopyright.Text = rm.GetString("labelCopyright", Language);
            labelCompanyName.Text = rm.GetString("labelCompanyName", Language);
            textBoxDescription.Text = rm.GetString("textBoxDescription", Language);
        }
    }
}
