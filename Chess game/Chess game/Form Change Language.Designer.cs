namespace Chess_game
{
    partial class Form_Change_Language
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form_Change_Language));
            this.lbl_VietNamese = new DevComponents.DotNetBar.LabelX();
            this.lbl_English = new DevComponents.DotNetBar.LabelX();
            this.picBox_EngLish = new System.Windows.Forms.PictureBox();
            this.picBox_VietNamese = new System.Windows.Forms.PictureBox();
            this.ribbonControl1 = new DevComponents.DotNetBar.RibbonControl();
            this.styleManager1 = new DevComponents.DotNetBar.StyleManager(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.picBox_EngLish)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.picBox_VietNamese)).BeginInit();
            this.SuspendLayout();
            // 
            // lbl_VietNamese
            // 
            this.lbl_VietNamese.BackColor = System.Drawing.Color.Transparent;
            // 
            // 
            // 
            this.lbl_VietNamese.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.lbl_VietNamese.Font = new System.Drawing.Font("Segoe UI", 11F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbl_VietNamese.ForeColor = System.Drawing.Color.DarkRed;
            this.lbl_VietNamese.Location = new System.Drawing.Point(57, 146);
            this.lbl_VietNamese.Name = "lbl_VietNamese";
            this.lbl_VietNamese.Size = new System.Drawing.Size(75, 23);
            this.lbl_VietNamese.TabIndex = 8;
            this.lbl_VietNamese.Text = "Tiếng Việt";
            // 
            // lbl_English
            // 
            this.lbl_English.BackColor = System.Drawing.Color.Transparent;
            // 
            // 
            // 
            this.lbl_English.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.lbl_English.Font = new System.Drawing.Font("Segoe UI", 11F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbl_English.ForeColor = System.Drawing.Color.MediumBlue;
            this.lbl_English.Location = new System.Drawing.Point(208, 146);
            this.lbl_English.Name = "lbl_English";
            this.lbl_English.Size = new System.Drawing.Size(75, 23);
            this.lbl_English.TabIndex = 9;
            this.lbl_English.Text = "English";
            // 
            // picBox_EngLish
            // 
            this.picBox_EngLish.BackColor = System.Drawing.Color.Transparent;
            this.picBox_EngLish.ForeColor = System.Drawing.Color.Black;
            this.picBox_EngLish.Image = global::Chess_game.Properties.Resources.United_kingdom_icon;
            this.picBox_EngLish.Location = new System.Drawing.Point(208, 56);
            this.picBox_EngLish.Name = "picBox_EngLish";
            this.picBox_EngLish.Size = new System.Drawing.Size(68, 63);
            this.picBox_EngLish.TabIndex = 7;
            this.picBox_EngLish.TabStop = false;
            this.picBox_EngLish.Click += new System.EventHandler(this.picBox_EngLish_Click);
            // 
            // picBox_VietNamese
            // 
            this.picBox_VietNamese.BackColor = System.Drawing.Color.Transparent;
            this.picBox_VietNamese.ForeColor = System.Drawing.Color.Black;
            this.picBox_VietNamese.Image = global::Chess_game.Properties.Resources.Vietnam_icon;
            this.picBox_VietNamese.Location = new System.Drawing.Point(64, 56);
            this.picBox_VietNamese.Name = "picBox_VietNamese";
            this.picBox_VietNamese.Size = new System.Drawing.Size(68, 63);
            this.picBox_VietNamese.TabIndex = 6;
            this.picBox_VietNamese.TabStop = false;
            this.picBox_VietNamese.Click += new System.EventHandler(this.picBox_VietNamese_Click);
            // 
            // ribbonControl1
            // 
            // 
            // 
            // 
            this.ribbonControl1.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.ribbonControl1.CaptionVisible = true;
            this.ribbonControl1.Dock = System.Windows.Forms.DockStyle.Top;
            this.ribbonControl1.KeyTipsFont = new System.Drawing.Font("Tahoma", 7F);
            this.ribbonControl1.Location = new System.Drawing.Point(5, 1);
            this.ribbonControl1.Name = "ribbonControl1";
            this.ribbonControl1.Padding = new System.Windows.Forms.Padding(0, 0, 0, 3);
            this.ribbonControl1.Size = new System.Drawing.Size(330, 30);
            this.ribbonControl1.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.ribbonControl1.SystemText.MaximizeRibbonText = "&Maximize the Ribbon";
            this.ribbonControl1.SystemText.MinimizeRibbonText = "Mi&nimize the Ribbon";
            this.ribbonControl1.SystemText.QatAddItemText = "&Add to Quick Access Toolbar";
            this.ribbonControl1.SystemText.QatCustomizeMenuLabel = "<b>Customize Quick Access Toolbar</b>";
            this.ribbonControl1.SystemText.QatCustomizeText = "&Customize Quick Access Toolbar...";
            this.ribbonControl1.SystemText.QatDialogAddButton = "&Add >>";
            this.ribbonControl1.SystemText.QatDialogCancelButton = "Cancel";
            this.ribbonControl1.SystemText.QatDialogCaption = "Customize Quick Access Toolbar";
            this.ribbonControl1.SystemText.QatDialogCategoriesLabel = "&Choose commands from:";
            this.ribbonControl1.SystemText.QatDialogOkButton = "OK";
            this.ribbonControl1.SystemText.QatDialogPlacementCheckbox = "&Place Quick Access Toolbar below the Ribbon";
            this.ribbonControl1.SystemText.QatDialogRemoveButton = "&Remove";
            this.ribbonControl1.SystemText.QatPlaceAboveRibbonText = "&Place Quick Access Toolbar above the Ribbon";
            this.ribbonControl1.SystemText.QatPlaceBelowRibbonText = "&Place Quick Access Toolbar below the Ribbon";
            this.ribbonControl1.SystemText.QatRemoveItemText = "&Remove from Quick Access Toolbar";
            this.ribbonControl1.TabGroupHeight = 14;
            this.ribbonControl1.TabIndex = 10;
            this.ribbonControl1.Text = "ribbonControl1";
            // 
            // styleManager1
            // 
            //this.styleManager1.ManagerStyle = DevComponents.DotNetBar.eStyle.Office2010Blue;
            //this.styleManager1.MetroColorParameters = new DevComponents.DotNetBar.Metro.ColorTables.MetroColorGeneratorParameters(System.Drawing.Color.White, System.Drawing.Color.FromArgb(((int)(((byte)(43)))), ((int)(((byte)(87)))), ((int)(((byte)(154))))));
            // 
            // Form_Change_Language
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(340, 212);
            this.Controls.Add(this.ribbonControl1);
            this.Controls.Add(this.lbl_English);
            this.Controls.Add(this.lbl_VietNamese);
            this.Controls.Add(this.picBox_EngLish);
            this.Controls.Add(this.picBox_VietNamese);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.Name = "Form_Change_Language";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Chọn ngôn ngữ ";
            ((System.ComponentModel.ISupportInitialize)(this.picBox_EngLish)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.picBox_VietNamese)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.PictureBox picBox_VietNamese;
        private System.Windows.Forms.PictureBox picBox_EngLish;
        private DevComponents.DotNetBar.LabelX lbl_VietNamese;
        private DevComponents.DotNetBar.LabelX lbl_English;
        private DevComponents.DotNetBar.RibbonControl ribbonControl1;
        private DevComponents.DotNetBar.StyleManager styleManager1;
    }
}