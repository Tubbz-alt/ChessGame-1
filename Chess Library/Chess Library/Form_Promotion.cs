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
    public partial class Form_Promotion : Office2007RibbonForm
    {
        private static eChessPieceType _type;

        public static eChessPieceType Type
        {
            get
            {
                return _type;
            }

            set
            {
                _type = value;
            }
        }

        #region Constructor
        public Form_Promotion()
        {
            InitializeComponent();
        }

        public Form_Promotion(eChessSide side, eChessPieceStyle style, System.Globalization.CultureInfo language)
        {
            InitializeComponent();

            //Initalize 
            pictureBox1.Image = Read_Image_From_Resources.GetChessPieceBitMap(side, eChessPieceType.Queen, style);
            pictureBox2.Image = Read_Image_From_Resources.GetChessPieceBitMap(side, eChessPieceType.Rook, style);
            pictureBox3.Image = Read_Image_From_Resources.GetChessPieceBitMap(side, eChessPieceType.Knight, style);
            pictureBox4.Image = Read_Image_From_Resources.GetChessPieceBitMap(side, eChessPieceType.Bishop, style);

            //Change Language
            Assembly a = Assembly.Load("Chess Library");
            ResourceManager rm = new ResourceManager("Chess_Library.Resources.Lang.Langres", a);

            this.Text = rm.GetString("Form_Promotion", language);
            labelX_form_promotion.Text = rm.GetString("labelX_form_promotion", language);
        }
        #endregion

        private void Form_Promotion_Load(object sender, EventArgs e)
        {
            Type = eChessPieceType.Queen;
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            Type = eChessPieceType.Queen;
            this.Close();
        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {
            Type = eChessPieceType.Rook;
            this.Close();
        }

        private void pictureBox3_Click(object sender, EventArgs e)
        {
            Type = eChessPieceType.Knight;
            this.Close();
        }

        private void pictureBox4_Click(object sender, EventArgs e)
        {
            Type = eChessPieceType.Bishop;
            this.Close();
        }
    }
}
