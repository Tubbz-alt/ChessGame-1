namespace Chess_game
{
    partial class Form_New_game
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form_New_game));
            this.lbl_Form_Newgame = new DevComponents.DotNetBar.LabelX();
            this.groupPanel1 = new DevComponents.DotNetBar.Controls.GroupPanel();
            this.combobox_Game_Mode = new DevComponents.DotNetBar.Controls.ComboBoxEx();
            this.combobox_GameMode_itemvsCom = new DevComponents.Editors.ComboItem();
            this.combobox_GameMode_itemvsPlayer = new DevComponents.Editors.ComboItem();
            this.lbl_GameMode = new DevComponents.DotNetBar.LabelX();
            this.groupPanel2 = new DevComponents.DotNetBar.Controls.GroupPanel();
            this.radiobtn_Hard = new System.Windows.Forms.RadioButton();
            this.radiobtn_Medium = new System.Windows.Forms.RadioButton();
            this.radiobtn_Easy = new System.Windows.Forms.RadioButton();
            this.lbl_Level = new DevComponents.DotNetBar.LabelX();
            this.groupPanel3 = new DevComponents.DotNetBar.Controls.GroupPanel();
            this.radiobtn_Black = new System.Windows.Forms.RadioButton();
            this.radiobtn_White = new System.Windows.Forms.RadioButton();
            this.lbl_ChooseSide = new DevComponents.DotNetBar.LabelX();
            this.groupPanel4 = new DevComponents.DotNetBar.Controls.GroupPanel();
            this.integerInput_TimeBonus = new DevComponents.Editors.IntegerInput();
            this.integerInput_TimeLimit = new DevComponents.Editors.IntegerInput();
            this.lbl_Second = new DevComponents.DotNetBar.LabelX();
            this.lbl_Minute = new DevComponents.DotNetBar.LabelX();
            this.lbl_ExtraTime = new DevComponents.DotNetBar.LabelX();
            this.lbl_TimeMax = new DevComponents.DotNetBar.LabelX();
            this.btn_Start = new DevComponents.DotNetBar.ButtonX();
            this.ribbonControl1 = new DevComponents.DotNetBar.RibbonControl();
            this.styleManager1 = new DevComponents.DotNetBar.StyleManager(this.components);
            this.groupPanel1.SuspendLayout();
            this.groupPanel2.SuspendLayout();
            this.groupPanel3.SuspendLayout();
            this.groupPanel4.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.integerInput_TimeBonus)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.integerInput_TimeLimit)).BeginInit();
            this.SuspendLayout();
            // 
            // lbl_Form_Newgame
            // 
            this.lbl_Form_Newgame.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            // 
            // 
            // 
            this.lbl_Form_Newgame.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.lbl_Form_Newgame.Font = new System.Drawing.Font("Times New Roman", 16F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbl_Form_Newgame.ForeColor = System.Drawing.Color.Red;
            this.lbl_Form_Newgame.Location = new System.Drawing.Point(93, 54);
            this.lbl_Form_Newgame.Name = "lbl_Form_Newgame";
            this.lbl_Form_Newgame.Size = new System.Drawing.Size(207, 50);
            this.lbl_Form_Newgame.TabIndex = 1;
            this.lbl_Form_Newgame.Text = "Tùy Chọn Trò Chơi ";
            this.lbl_Form_Newgame.TextAlignment = System.Drawing.StringAlignment.Center;
            // 
            // groupPanel1
            // 
            this.groupPanel1.CanvasColor = System.Drawing.SystemColors.Control;
            this.groupPanel1.ColorSchemeStyle = DevComponents.DotNetBar.eDotNetBarStyle.Office2007;
            this.groupPanel1.Controls.Add(this.combobox_Game_Mode);
            this.groupPanel1.Controls.Add(this.lbl_GameMode);
            this.groupPanel1.DisabledBackColor = System.Drawing.Color.Empty;
            this.groupPanel1.Location = new System.Drawing.Point(12, 122);
            this.groupPanel1.Name = "groupPanel1";
            this.groupPanel1.Size = new System.Drawing.Size(354, 58);
            // 
            // 
            // 
            this.groupPanel1.Style.BackColor2SchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBackground2;
            this.groupPanel1.Style.BackColorGradientAngle = 90;
            this.groupPanel1.Style.BackColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBackground;
            this.groupPanel1.Style.BorderBottom = DevComponents.DotNetBar.eStyleBorderType.Solid;
            this.groupPanel1.Style.BorderBottomWidth = 1;
            this.groupPanel1.Style.BorderColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBorder;
            this.groupPanel1.Style.BorderLeft = DevComponents.DotNetBar.eStyleBorderType.Solid;
            this.groupPanel1.Style.BorderLeftWidth = 1;
            this.groupPanel1.Style.BorderRight = DevComponents.DotNetBar.eStyleBorderType.Solid;
            this.groupPanel1.Style.BorderRightWidth = 1;
            this.groupPanel1.Style.BorderTop = DevComponents.DotNetBar.eStyleBorderType.Solid;
            this.groupPanel1.Style.BorderTopWidth = 1;
            this.groupPanel1.Style.CornerDiameter = 4;
            this.groupPanel1.Style.CornerType = DevComponents.DotNetBar.eCornerType.Rounded;
            this.groupPanel1.Style.TextAlignment = DevComponents.DotNetBar.eStyleTextAlignment.Center;
            this.groupPanel1.Style.TextColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelText;
            this.groupPanel1.Style.TextLineAlignment = DevComponents.DotNetBar.eStyleTextAlignment.Near;
            // 
            // 
            // 
            this.groupPanel1.StyleMouseDown.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            // 
            // 
            // 
            this.groupPanel1.StyleMouseOver.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.groupPanel1.TabIndex = 2;
            // 
            // combobox_Game_Mode
            // 
            this.combobox_Game_Mode.DisplayMember = "Text";
            this.combobox_Game_Mode.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed;
            this.combobox_Game_Mode.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.combobox_Game_Mode.FormattingEnabled = true;
            this.combobox_Game_Mode.ItemHeight = 19;
            this.combobox_Game_Mode.Items.AddRange(new object[] {
            this.combobox_GameMode_itemvsCom,
            this.combobox_GameMode_itemvsPlayer});
            this.combobox_Game_Mode.Location = new System.Drawing.Point(134, 11);
            this.combobox_Game_Mode.Name = "combobox_Game_Mode";
            this.combobox_Game_Mode.Size = new System.Drawing.Size(175, 25);
            this.combobox_Game_Mode.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.combobox_Game_Mode.TabIndex = 16;
            this.combobox_Game_Mode.Text = "Chơi với Máy";
            this.combobox_Game_Mode.SelectedIndexChanged += new System.EventHandler(this.combobox_Game_Mode_SelectedIndexChanged);
            // 
            // combobox_GameMode_itemvsCom
            // 
            this.combobox_GameMode_itemvsCom.FontSize = 21F;
            this.combobox_GameMode_itemvsCom.Text = "Chơi với Máy";
            // 
            // combobox_GameMode_itemvsPlayer
            // 
            this.combobox_GameMode_itemvsPlayer.FontSize = 21F;
            this.combobox_GameMode_itemvsPlayer.Text = "Chơi 2 Người";
            // 
            // lbl_GameMode
            // 
            this.lbl_GameMode.AutoSize = true;
            this.lbl_GameMode.BackColor = System.Drawing.Color.Transparent;
            // 
            // 
            // 
            this.lbl_GameMode.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.lbl_GameMode.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbl_GameMode.Location = new System.Drawing.Point(3, 12);
            this.lbl_GameMode.Name = "lbl_GameMode";
            this.lbl_GameMode.Size = new System.Drawing.Size(130, 21);
            this.lbl_GameMode.TabIndex = 0;
            this.lbl_GameMode.Text = "Hình Thức Chơi : ";
            // 
            // groupPanel2
            // 
            this.groupPanel2.CanvasColor = System.Drawing.SystemColors.Control;
            this.groupPanel2.ColorSchemeStyle = DevComponents.DotNetBar.eDotNetBarStyle.Office2007;
            this.groupPanel2.Controls.Add(this.radiobtn_Hard);
            this.groupPanel2.Controls.Add(this.radiobtn_Medium);
            this.groupPanel2.Controls.Add(this.radiobtn_Easy);
            this.groupPanel2.Controls.Add(this.lbl_Level);
            this.groupPanel2.DisabledBackColor = System.Drawing.Color.Empty;
            this.groupPanel2.Location = new System.Drawing.Point(12, 197);
            this.groupPanel2.Name = "groupPanel2";
            this.groupPanel2.Size = new System.Drawing.Size(354, 58);
            // 
            // 
            // 
            this.groupPanel2.Style.BackColor2SchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBackground2;
            this.groupPanel2.Style.BackColorGradientAngle = 90;
            this.groupPanel2.Style.BackColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBackground;
            this.groupPanel2.Style.BorderBottom = DevComponents.DotNetBar.eStyleBorderType.Solid;
            this.groupPanel2.Style.BorderBottomWidth = 1;
            this.groupPanel2.Style.BorderColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBorder;
            this.groupPanel2.Style.BorderLeft = DevComponents.DotNetBar.eStyleBorderType.Solid;
            this.groupPanel2.Style.BorderLeftWidth = 1;
            this.groupPanel2.Style.BorderRight = DevComponents.DotNetBar.eStyleBorderType.Solid;
            this.groupPanel2.Style.BorderRightWidth = 1;
            this.groupPanel2.Style.BorderTop = DevComponents.DotNetBar.eStyleBorderType.Solid;
            this.groupPanel2.Style.BorderTopWidth = 1;
            this.groupPanel2.Style.CornerDiameter = 4;
            this.groupPanel2.Style.CornerType = DevComponents.DotNetBar.eCornerType.Rounded;
            this.groupPanel2.Style.TextAlignment = DevComponents.DotNetBar.eStyleTextAlignment.Center;
            this.groupPanel2.Style.TextColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelText;
            this.groupPanel2.Style.TextLineAlignment = DevComponents.DotNetBar.eStyleTextAlignment.Near;
            // 
            // 
            // 
            this.groupPanel2.StyleMouseDown.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            // 
            // 
            // 
            this.groupPanel2.StyleMouseOver.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.groupPanel2.TabIndex = 3;
            // 
            // radiobtn_Hard
            // 
            this.radiobtn_Hard.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.radiobtn_Hard.AutoSize = true;
            this.radiobtn_Hard.BackColor = System.Drawing.Color.Transparent;
            this.radiobtn_Hard.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.radiobtn_Hard.Location = new System.Drawing.Point(246, 12);
            this.radiobtn_Hard.Name = "radiobtn_Hard";
            this.radiobtn_Hard.Size = new System.Drawing.Size(53, 22);
            this.radiobtn_Hard.TabIndex = 3;
            this.radiobtn_Hard.Text = "Khó";
            this.radiobtn_Hard.UseVisualStyleBackColor = false;
            // 
            // radiobtn_Medium
            // 
            this.radiobtn_Medium.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.radiobtn_Medium.AutoSize = true;
            this.radiobtn_Medium.BackColor = System.Drawing.Color.Transparent;
            this.radiobtn_Medium.Checked = true;
            this.radiobtn_Medium.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.radiobtn_Medium.Location = new System.Drawing.Point(134, 11);
            this.radiobtn_Medium.Name = "radiobtn_Medium";
            this.radiobtn_Medium.Size = new System.Drawing.Size(97, 22);
            this.radiobtn_Medium.TabIndex = 2;
            this.radiobtn_Medium.TabStop = true;
            this.radiobtn_Medium.Text = "Trung Bình";
            this.radiobtn_Medium.UseVisualStyleBackColor = false;
            // 
            // radiobtn_Easy
            // 
            this.radiobtn_Easy.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.radiobtn_Easy.AutoSize = true;
            this.radiobtn_Easy.BackColor = System.Drawing.Color.Transparent;
            this.radiobtn_Easy.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.radiobtn_Easy.Location = new System.Drawing.Point(78, 11);
            this.radiobtn_Easy.Name = "radiobtn_Easy";
            this.radiobtn_Easy.Size = new System.Drawing.Size(45, 22);
            this.radiobtn_Easy.TabIndex = 1;
            this.radiobtn_Easy.TabStop = true;
            this.radiobtn_Easy.Text = "Dễ";
            this.radiobtn_Easy.UseVisualStyleBackColor = false;
            // 
            // lbl_Level
            // 
            this.lbl_Level.AutoSize = true;
            this.lbl_Level.BackColor = System.Drawing.Color.Transparent;
            // 
            // 
            // 
            this.lbl_Level.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.lbl_Level.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbl_Level.Location = new System.Drawing.Point(3, 12);
            this.lbl_Level.Name = "lbl_Level";
            this.lbl_Level.Size = new System.Drawing.Size(73, 21);
            this.lbl_Level.TabIndex = 0;
            this.lbl_Level.Text = "Độ Khó : ";
            // 
            // groupPanel3
            // 
            this.groupPanel3.CanvasColor = System.Drawing.SystemColors.Control;
            this.groupPanel3.ColorSchemeStyle = DevComponents.DotNetBar.eDotNetBarStyle.Office2007;
            this.groupPanel3.Controls.Add(this.radiobtn_Black);
            this.groupPanel3.Controls.Add(this.radiobtn_White);
            this.groupPanel3.Controls.Add(this.lbl_ChooseSide);
            this.groupPanel3.DisabledBackColor = System.Drawing.Color.Empty;
            this.groupPanel3.Location = new System.Drawing.Point(12, 273);
            this.groupPanel3.Name = "groupPanel3";
            this.groupPanel3.Size = new System.Drawing.Size(354, 58);
            // 
            // 
            // 
            this.groupPanel3.Style.BackColor2SchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBackground2;
            this.groupPanel3.Style.BackColorGradientAngle = 90;
            this.groupPanel3.Style.BackColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBackground;
            this.groupPanel3.Style.BorderBottom = DevComponents.DotNetBar.eStyleBorderType.Solid;
            this.groupPanel3.Style.BorderBottomWidth = 1;
            this.groupPanel3.Style.BorderColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBorder;
            this.groupPanel3.Style.BorderLeft = DevComponents.DotNetBar.eStyleBorderType.Solid;
            this.groupPanel3.Style.BorderLeftWidth = 1;
            this.groupPanel3.Style.BorderRight = DevComponents.DotNetBar.eStyleBorderType.Solid;
            this.groupPanel3.Style.BorderRightWidth = 1;
            this.groupPanel3.Style.BorderTop = DevComponents.DotNetBar.eStyleBorderType.Solid;
            this.groupPanel3.Style.BorderTopWidth = 1;
            this.groupPanel3.Style.CornerDiameter = 4;
            this.groupPanel3.Style.CornerType = DevComponents.DotNetBar.eCornerType.Rounded;
            this.groupPanel3.Style.TextAlignment = DevComponents.DotNetBar.eStyleTextAlignment.Center;
            this.groupPanel3.Style.TextColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelText;
            this.groupPanel3.Style.TextLineAlignment = DevComponents.DotNetBar.eStyleTextAlignment.Near;
            // 
            // 
            // 
            this.groupPanel3.StyleMouseDown.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            // 
            // 
            // 
            this.groupPanel3.StyleMouseOver.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.groupPanel3.TabIndex = 4;
            // 
            // radiobtn_Black
            // 
            this.radiobtn_Black.AutoSize = true;
            this.radiobtn_Black.BackColor = System.Drawing.Color.Transparent;
            this.radiobtn_Black.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.radiobtn_Black.Location = new System.Drawing.Point(292, 12);
            this.radiobtn_Black.Name = "radiobtn_Black";
            this.radiobtn_Black.Size = new System.Drawing.Size(53, 22);
            this.radiobtn_Black.TabIndex = 3;
            this.radiobtn_Black.Text = "Đen";
            this.radiobtn_Black.UseVisualStyleBackColor = false;
            // 
            // radiobtn_White
            // 
            this.radiobtn_White.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.radiobtn_White.AutoSize = true;
            this.radiobtn_White.BackColor = System.Drawing.Color.Transparent;
            this.radiobtn_White.Checked = true;
            this.radiobtn_White.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.radiobtn_White.Location = new System.Drawing.Point(143, 11);
            this.radiobtn_White.Name = "radiobtn_White";
            this.radiobtn_White.Size = new System.Drawing.Size(142, 22);
            this.radiobtn_White.TabIndex = 2;
            this.radiobtn_White.TabStop = true;
            this.radiobtn_White.Text = "Trắng ( Đi trước ) ";
            this.radiobtn_White.UseVisualStyleBackColor = false;
            // 
            // lbl_ChooseSide
            // 
            this.lbl_ChooseSide.AutoSize = true;
            this.lbl_ChooseSide.BackColor = System.Drawing.Color.Transparent;
            // 
            // 
            // 
            this.lbl_ChooseSide.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.lbl_ChooseSide.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbl_ChooseSide.Location = new System.Drawing.Point(3, 12);
            this.lbl_ChooseSide.Name = "lbl_ChooseSide";
            this.lbl_ChooseSide.Size = new System.Drawing.Size(134, 21);
            this.lbl_ChooseSide.TabIndex = 0;
            this.lbl_ChooseSide.Text = "Bạn Chọn Quân : ";
            // 
            // groupPanel4
            // 
            this.groupPanel4.CanvasColor = System.Drawing.SystemColors.Control;
            this.groupPanel4.ColorSchemeStyle = DevComponents.DotNetBar.eDotNetBarStyle.Office2007;
            this.groupPanel4.Controls.Add(this.integerInput_TimeBonus);
            this.groupPanel4.Controls.Add(this.integerInput_TimeLimit);
            this.groupPanel4.Controls.Add(this.lbl_Second);
            this.groupPanel4.Controls.Add(this.lbl_Minute);
            this.groupPanel4.Controls.Add(this.lbl_ExtraTime);
            this.groupPanel4.Controls.Add(this.lbl_TimeMax);
            this.groupPanel4.DisabledBackColor = System.Drawing.Color.Empty;
            this.groupPanel4.Location = new System.Drawing.Point(12, 348);
            this.groupPanel4.Name = "groupPanel4";
            this.groupPanel4.Size = new System.Drawing.Size(354, 97);
            // 
            // 
            // 
            this.groupPanel4.Style.BackColor2SchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBackground2;
            this.groupPanel4.Style.BackColorGradientAngle = 90;
            this.groupPanel4.Style.BackColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBackground;
            this.groupPanel4.Style.BorderBottom = DevComponents.DotNetBar.eStyleBorderType.Solid;
            this.groupPanel4.Style.BorderBottomWidth = 1;
            this.groupPanel4.Style.BorderColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBorder;
            this.groupPanel4.Style.BorderLeft = DevComponents.DotNetBar.eStyleBorderType.Solid;
            this.groupPanel4.Style.BorderLeftWidth = 1;
            this.groupPanel4.Style.BorderRight = DevComponents.DotNetBar.eStyleBorderType.Solid;
            this.groupPanel4.Style.BorderRightWidth = 1;
            this.groupPanel4.Style.BorderTop = DevComponents.DotNetBar.eStyleBorderType.Solid;
            this.groupPanel4.Style.BorderTopWidth = 1;
            this.groupPanel4.Style.CornerDiameter = 4;
            this.groupPanel4.Style.CornerType = DevComponents.DotNetBar.eCornerType.Rounded;
            this.groupPanel4.Style.TextAlignment = DevComponents.DotNetBar.eStyleTextAlignment.Center;
            this.groupPanel4.Style.TextColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelText;
            this.groupPanel4.Style.TextLineAlignment = DevComponents.DotNetBar.eStyleTextAlignment.Near;
            // 
            // 
            // 
            this.groupPanel4.StyleMouseDown.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            // 
            // 
            // 
            this.groupPanel4.StyleMouseOver.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.groupPanel4.TabIndex = 5;
            // 
            // integerInput_TimeBonus
            // 
            // 
            // 
            // 
            this.integerInput_TimeBonus.BackgroundStyle.Class = "DateTimeInputBackground";
            this.integerInput_TimeBonus.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.integerInput_TimeBonus.ButtonFreeText.Shortcut = DevComponents.DotNetBar.eShortcut.F2;
            this.integerInput_TimeBonus.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.integerInput_TimeBonus.Location = new System.Drawing.Point(184, 51);
            this.integerInput_TimeBonus.MaxValue = 30;
            this.integerInput_TimeBonus.MinValue = 0;
            this.integerInput_TimeBonus.Name = "integerInput_TimeBonus";
            this.integerInput_TimeBonus.ShowUpDown = true;
            this.integerInput_TimeBonus.Size = new System.Drawing.Size(80, 24);
            this.integerInput_TimeBonus.TabIndex = 5;
            this.integerInput_TimeBonus.Value = 5;
            // 
            // integerInput_TimeLimit
            // 
            // 
            // 
            // 
            this.integerInput_TimeLimit.BackgroundStyle.Class = "DateTimeInputBackground";
            this.integerInput_TimeLimit.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.integerInput_TimeLimit.ButtonFreeText.Shortcut = DevComponents.DotNetBar.eShortcut.F2;
            this.integerInput_TimeLimit.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.integerInput_TimeLimit.Location = new System.Drawing.Point(184, 12);
            this.integerInput_TimeLimit.MaxValue = 90;
            this.integerInput_TimeLimit.MinValue = 1;
            this.integerInput_TimeLimit.Name = "integerInput_TimeLimit";
            this.integerInput_TimeLimit.ShowUpDown = true;
            this.integerInput_TimeLimit.Size = new System.Drawing.Size(80, 24);
            this.integerInput_TimeLimit.TabIndex = 4;
            this.integerInput_TimeLimit.Value = 10;
            // 
            // lbl_Second
            // 
            this.lbl_Second.AutoSize = true;
            this.lbl_Second.BackColor = System.Drawing.Color.Transparent;
            // 
            // 
            // 
            this.lbl_Second.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.lbl_Second.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbl_Second.Location = new System.Drawing.Point(279, 51);
            this.lbl_Second.Name = "lbl_Second";
            this.lbl_Second.Size = new System.Drawing.Size(35, 21);
            this.lbl_Second.TabIndex = 3;
            this.lbl_Second.Text = "Giây";
            // 
            // lbl_Minute
            // 
            this.lbl_Minute.AutoSize = true;
            this.lbl_Minute.BackColor = System.Drawing.Color.Transparent;
            // 
            // 
            // 
            this.lbl_Minute.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.lbl_Minute.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbl_Minute.Location = new System.Drawing.Point(279, 12);
            this.lbl_Minute.Name = "lbl_Minute";
            this.lbl_Minute.Size = new System.Drawing.Size(35, 21);
            this.lbl_Minute.TabIndex = 2;
            this.lbl_Minute.Text = "Phút";
            // 
            // lbl_ExtraTime
            // 
            this.lbl_ExtraTime.AutoSize = true;
            this.lbl_ExtraTime.BackColor = System.Drawing.Color.Transparent;
            // 
            // 
            // 
            this.lbl_ExtraTime.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.lbl_ExtraTime.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbl_ExtraTime.Location = new System.Drawing.Point(3, 51);
            this.lbl_ExtraTime.Name = "lbl_ExtraTime";
            this.lbl_ExtraTime.Size = new System.Drawing.Size(177, 21);
            this.lbl_ExtraTime.TabIndex = 1;
            this.lbl_ExtraTime.Text = "Thời Gian Cộng Thêm : ";
            // 
            // lbl_TimeMax
            // 
            this.lbl_TimeMax.AutoSize = true;
            this.lbl_TimeMax.BackColor = System.Drawing.Color.Transparent;
            // 
            // 
            // 
            this.lbl_TimeMax.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.lbl_TimeMax.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbl_TimeMax.Location = new System.Drawing.Point(3, 12);
            this.lbl_TimeMax.Name = "lbl_TimeMax";
            this.lbl_TimeMax.Size = new System.Drawing.Size(141, 21);
            this.lbl_TimeMax.TabIndex = 0;
            this.lbl_TimeMax.Text = "Thời Gian Tối Đa : ";
            // 
            // btn_Start
            // 
            this.btn_Start.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
            this.btn_Start.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.btn_Start.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground;
            this.btn_Start.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.btn_Start.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_Start.Location = new System.Drawing.Point(93, 466);
            this.btn_Start.Name = "btn_Start";
            this.btn_Start.Size = new System.Drawing.Size(185, 37);
            this.btn_Start.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.btn_Start.TabIndex = 6;
            this.btn_Start.Text = "Bắt Đầu Chơi";
            this.btn_Start.TextColor = System.Drawing.Color.Red;
            this.btn_Start.Click += new System.EventHandler(this.btn_Start_Click);
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
            this.ribbonControl1.Size = new System.Drawing.Size(383, 47);
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
            this.ribbonControl1.TabIndex = 7;
            this.ribbonControl1.Text = "ribbonControl1";
            // 
            // styleManager1
            // 
            //this.styleManager1.ManagerStyle = DevComponents.DotNetBar.eStyle.Office2010Blue;
            //this.styleManager1.MetroColorParameters = new DevComponents.DotNetBar.Metro.ColorTables.MetroColorGeneratorParameters(System.Drawing.Color.White, System.Drawing.Color.FromArgb(((int)(((byte)(43)))), ((int)(((byte)(87)))), ((int)(((byte)(154))))));
            // 
            // Form_New_game
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(393, 556);
            this.Controls.Add(this.ribbonControl1);
            this.Controls.Add(this.btn_Start);
            this.Controls.Add(this.groupPanel4);
            this.Controls.Add(this.groupPanel3);
            this.Controls.Add(this.groupPanel2);
            this.Controls.Add(this.groupPanel1);
            this.Controls.Add(this.lbl_Form_Newgame);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.Name = "Form_New_game";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Ván cờ mới ";
            this.groupPanel1.ResumeLayout(false);
            this.groupPanel1.PerformLayout();
            this.groupPanel2.ResumeLayout(false);
            this.groupPanel2.PerformLayout();
            this.groupPanel3.ResumeLayout(false);
            this.groupPanel3.PerformLayout();
            this.groupPanel4.ResumeLayout(false);
            this.groupPanel4.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.integerInput_TimeBonus)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.integerInput_TimeLimit)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private DevComponents.DotNetBar.LabelX lbl_Form_Newgame;
        private DevComponents.DotNetBar.Controls.GroupPanel groupPanel1;
        private DevComponents.DotNetBar.Controls.ComboBoxEx combobox_Game_Mode;
        private DevComponents.Editors.ComboItem combobox_GameMode_itemvsCom;
        private DevComponents.Editors.ComboItem combobox_GameMode_itemvsPlayer;
        private DevComponents.DotNetBar.LabelX lbl_GameMode;
        private DevComponents.DotNetBar.Controls.GroupPanel groupPanel2;
        private System.Windows.Forms.RadioButton radiobtn_Hard;
        private System.Windows.Forms.RadioButton radiobtn_Medium;
        private System.Windows.Forms.RadioButton radiobtn_Easy;
        private DevComponents.DotNetBar.LabelX lbl_Level;
        private DevComponents.DotNetBar.Controls.GroupPanel groupPanel3;
        private System.Windows.Forms.RadioButton radiobtn_Black;
        private System.Windows.Forms.RadioButton radiobtn_White;
        private DevComponents.DotNetBar.LabelX lbl_ChooseSide;
        private DevComponents.DotNetBar.Controls.GroupPanel groupPanel4;
        private DevComponents.Editors.IntegerInput integerInput_TimeBonus;
        private DevComponents.Editors.IntegerInput integerInput_TimeLimit;
        private DevComponents.DotNetBar.LabelX lbl_Second;
        private DevComponents.DotNetBar.LabelX lbl_Minute;
        private DevComponents.DotNetBar.LabelX lbl_ExtraTime;
        private DevComponents.DotNetBar.LabelX lbl_TimeMax;
        private DevComponents.DotNetBar.ButtonX btn_Start;
        private DevComponents.DotNetBar.RibbonControl ribbonControl1;
        private DevComponents.DotNetBar.StyleManager styleManager1;
    }
}