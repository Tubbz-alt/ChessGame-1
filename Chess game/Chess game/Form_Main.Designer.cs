namespace Chess_game
{
    partial class Form_Main
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form_Main));
            this.styleManager1 = new DevComponents.DotNetBar.StyleManager(this.components);
            this.ribbonControl1 = new DevComponents.DotNetBar.RibbonControl();
            this.ribbonPanel1 = new DevComponents.DotNetBar.RibbonPanel();
            this.ribbonBar10 = new DevComponents.DotNetBar.RibbonBar();
            this.btn_Exit = new DevComponents.DotNetBar.ButtonItem();
            this.ribbonBar6 = new DevComponents.DotNetBar.RibbonBar();
            this.btn_Options = new DevComponents.DotNetBar.ButtonItem();
            this.btn_Language = new DevComponents.DotNetBar.ButtonItem();
            this.ribbonBar5 = new DevComponents.DotNetBar.RibbonBar();
            this.btn_Hint = new DevComponents.DotNetBar.ButtonItem();
            this.ribbonBar4 = new DevComponents.DotNetBar.RibbonBar();
            this.btn_Undo = new DevComponents.DotNetBar.ButtonItem();
            this.btn_Redo = new DevComponents.DotNetBar.ButtonItem();
            this.ribbonBar3 = new DevComponents.DotNetBar.RibbonBar();
            this.btn_Savegame = new DevComponents.DotNetBar.ButtonItem();
            this.btn_Loadgame = new DevComponents.DotNetBar.ButtonItem();
            this.ribbonBar1 = new DevComponents.DotNetBar.RibbonBar();
            this.btn_Newgame = new DevComponents.DotNetBar.ButtonItem();
            this.ribbonPanel2 = new DevComponents.DotNetBar.RibbonPanel();
            this.ribbonBar7 = new DevComponents.DotNetBar.RibbonBar();
            this.btn_Savemoved = new DevComponents.DotNetBar.ButtonItem();
            this.ribbonBar2 = new DevComponents.DotNetBar.RibbonBar();
            this.btn_Capture = new DevComponents.DotNetBar.ButtonItem();
            this.ribbonPanel3 = new DevComponents.DotNetBar.RibbonPanel();
            this.ribbonBar9 = new DevComponents.DotNetBar.RibbonBar();
            this.btn_Author = new DevComponents.DotNetBar.ButtonItem();
            this.ribbonBar8 = new DevComponents.DotNetBar.RibbonBar();
            this.btn_Chessrule = new DevComponents.DotNetBar.ButtonItem();
            this.ribbonTabItem_Home = new DevComponents.DotNetBar.RibbonTabItem();
            this.ribbonTabItem_Auxiliaryfunction = new DevComponents.DotNetBar.RibbonTabItem();
            this.ribbonTabItem_Help = new DevComponents.DotNetBar.RibbonTabItem();
            this.buttonItem1 = new DevComponents.DotNetBar.ButtonItem();
            this.buttonItem2 = new DevComponents.DotNetBar.ButtonItem();
            this.buttonItem3 = new DevComponents.DotNetBar.ButtonItem();
            this.buttonItem4 = new DevComponents.DotNetBar.ButtonItem();
            this.buttonItem5 = new DevComponents.DotNetBar.ButtonItem();
            this.buttonItem6 = new DevComponents.DotNetBar.ButtonItem();
            this.buttonItem7 = new DevComponents.DotNetBar.ButtonItem();
            this.colorPickerDropDown1 = new DevComponents.DotNetBar.ColorPickerDropDown();
            this.qatCustomizeItem1 = new DevComponents.DotNetBar.QatCustomizeItem();
            this.panel1 = new System.Windows.Forms.Panel();
            this.pnlTimerLeft = new System.Windows.Forms.Panel();
            this.pnlTimerRight = new System.Windows.Forms.Panel();
            this.pnlChessPieceEated1 = new System.Windows.Forms.Panel();
            this.pnlChessPieceEated2 = new System.Windows.Forms.Panel();
            this.ribbonControl1.SuspendLayout();
            this.ribbonPanel1.SuspendLayout();
            this.ribbonPanel2.SuspendLayout();
            this.ribbonPanel3.SuspendLayout();
            this.SuspendLayout();
            // 
            // styleManager1
            // 
            this.styleManager1.ManagerStyle = DevComponents.DotNetBar.eStyle.Office2010Blue;
            this.styleManager1.MetroColorParameters = new DevComponents.DotNetBar.Metro.ColorTables.MetroColorGeneratorParameters(System.Drawing.Color.White, System.Drawing.Color.FromArgb(((int)(((byte)(43)))), ((int)(((byte)(87)))), ((int)(((byte)(154))))));
            // 
            // ribbonControl1
            // 
            // 
            // 
            // 
            this.ribbonControl1.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.ribbonControl1.CaptionVisible = true;
            this.ribbonControl1.Controls.Add(this.ribbonPanel1);
            this.ribbonControl1.Controls.Add(this.ribbonPanel2);
            this.ribbonControl1.Controls.Add(this.ribbonPanel3);
            this.ribbonControl1.Dock = System.Windows.Forms.DockStyle.Top;
            this.ribbonControl1.Items.AddRange(new DevComponents.DotNetBar.BaseItem[] {
            this.ribbonTabItem_Home,
            this.ribbonTabItem_Auxiliaryfunction,
            this.ribbonTabItem_Help});
            this.ribbonControl1.KeyTipsFont = new System.Drawing.Font("Tahoma", 7F);
            this.ribbonControl1.Location = new System.Drawing.Point(5, 1);
            this.ribbonControl1.Name = "ribbonControl1";
            this.ribbonControl1.Padding = new System.Windows.Forms.Padding(0, 0, 0, 3);
            this.ribbonControl1.QuickToolbarItems.AddRange(new DevComponents.DotNetBar.BaseItem[] {
            this.buttonItem1,
            this.qatCustomizeItem1});
            this.ribbonControl1.Size = new System.Drawing.Size(990, 154);
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
            this.ribbonControl1.TabIndex = 0;
            this.ribbonControl1.Text = "ribbonControl1";
            // 
            // ribbonPanel1
            // 
            this.ribbonPanel1.ColorSchemeStyle = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.ribbonPanel1.Controls.Add(this.ribbonBar10);
            this.ribbonPanel1.Controls.Add(this.ribbonBar6);
            this.ribbonPanel1.Controls.Add(this.ribbonBar5);
            this.ribbonPanel1.Controls.Add(this.ribbonBar4);
            this.ribbonPanel1.Controls.Add(this.ribbonBar3);
            this.ribbonPanel1.Controls.Add(this.ribbonBar1);
            this.ribbonPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.ribbonPanel1.Location = new System.Drawing.Point(0, 53);
            this.ribbonPanel1.Name = "ribbonPanel1";
            this.ribbonPanel1.Padding = new System.Windows.Forms.Padding(3, 0, 3, 3);
            this.ribbonPanel1.Size = new System.Drawing.Size(990, 98);
            // 
            // 
            // 
            this.ribbonPanel1.Style.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            // 
            // 
            // 
            this.ribbonPanel1.StyleMouseDown.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            // 
            // 
            // 
            this.ribbonPanel1.StyleMouseOver.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.ribbonPanel1.TabIndex = 1;
            // 
            // ribbonBar10
            // 
            this.ribbonBar10.AutoOverflowEnabled = true;
            // 
            // 
            // 
            this.ribbonBar10.BackgroundMouseOverStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            // 
            // 
            // 
            this.ribbonBar10.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.ribbonBar10.ContainerControlProcessDialogKey = true;
            this.ribbonBar10.Dock = System.Windows.Forms.DockStyle.Left;
            this.ribbonBar10.DragDropSupport = true;
            this.ribbonBar10.Items.AddRange(new DevComponents.DotNetBar.BaseItem[] {
            this.btn_Exit});
            this.ribbonBar10.LicenseKey = "F962CEC7-CD8F-4911-A9E9-CAB39962FC1F";
            this.ribbonBar10.Location = new System.Drawing.Point(638, 0);
            this.ribbonBar10.Name = "ribbonBar10";
            this.ribbonBar10.Size = new System.Drawing.Size(79, 95);
            this.ribbonBar10.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.ribbonBar10.TabIndex = 5;
            // 
            // 
            // 
            this.ribbonBar10.TitleStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            // 
            // 
            // 
            this.ribbonBar10.TitleStyleMouseOver.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            // 
            // btn_Exit
            // 
            this.btn_Exit.Image = global::Chess_game.Properties.Resources.power_icon;
            this.btn_Exit.ImagePosition = DevComponents.DotNetBar.eImagePosition.Top;
            this.btn_Exit.Name = "btn_Exit";
            this.btn_Exit.RibbonWordWrap = false;
            this.btn_Exit.SubItemsExpandWidth = 14;
            this.btn_Exit.Text = "Thoát";
            this.btn_Exit.Click += new System.EventHandler(this.btn_Exit_Click);
            // 
            // ribbonBar6
            // 
            this.ribbonBar6.AutoOverflowEnabled = true;
            // 
            // 
            // 
            this.ribbonBar6.BackgroundMouseOverStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            // 
            // 
            // 
            this.ribbonBar6.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.ribbonBar6.ContainerControlProcessDialogKey = true;
            this.ribbonBar6.Dock = System.Windows.Forms.DockStyle.Left;
            this.ribbonBar6.DragDropSupport = true;
            this.ribbonBar6.Items.AddRange(new DevComponents.DotNetBar.BaseItem[] {
            this.btn_Options,
            this.btn_Language});
            this.ribbonBar6.LicenseKey = "F962CEC7-CD8F-4911-A9E9-CAB39962FC1F";
            this.ribbonBar6.Location = new System.Drawing.Point(477, 0);
            this.ribbonBar6.Name = "ribbonBar6";
            this.ribbonBar6.Size = new System.Drawing.Size(161, 95);
            this.ribbonBar6.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.ribbonBar6.TabIndex = 4;
            // 
            // 
            // 
            this.ribbonBar6.TitleStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            // 
            // 
            // 
            this.ribbonBar6.TitleStyleMouseOver.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            // 
            // btn_Options
            // 
            this.btn_Options.Image = global::Chess_game.Properties.Resources.option_icon1;
            this.btn_Options.ImagePosition = DevComponents.DotNetBar.eImagePosition.Top;
            this.btn_Options.Name = "btn_Options";
            this.btn_Options.SubItemsExpandWidth = 14;
            this.btn_Options.Text = "Tùy chọn";
            this.btn_Options.Click += new System.EventHandler(this.btn_Options_Click);
            // 
            // btn_Language
            // 
            this.btn_Language.Image = global::Chess_game.Properties.Resources.Vietnam_icon;
            this.btn_Language.ImagePosition = DevComponents.DotNetBar.eImagePosition.Top;
            this.btn_Language.Name = "btn_Language";
            this.btn_Language.SubItemsExpandWidth = 14;
            this.btn_Language.Text = "Ngôn ngữ";
            this.btn_Language.Click += new System.EventHandler(this.btn_Language_Click);
            // 
            // ribbonBar5
            // 
            this.ribbonBar5.AutoOverflowEnabled = true;
            // 
            // 
            // 
            this.ribbonBar5.BackgroundMouseOverStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            // 
            // 
            // 
            this.ribbonBar5.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.ribbonBar5.ContainerControlProcessDialogKey = true;
            this.ribbonBar5.Dock = System.Windows.Forms.DockStyle.Left;
            this.ribbonBar5.DragDropSupport = true;
            this.ribbonBar5.Items.AddRange(new DevComponents.DotNetBar.BaseItem[] {
            this.btn_Hint});
            this.ribbonBar5.LicenseKey = "F962CEC7-CD8F-4911-A9E9-CAB39962FC1F";
            this.ribbonBar5.Location = new System.Drawing.Point(395, 0);
            this.ribbonBar5.Name = "ribbonBar5";
            this.ribbonBar5.Size = new System.Drawing.Size(82, 95);
            this.ribbonBar5.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.ribbonBar5.TabIndex = 3;
            // 
            // 
            // 
            this.ribbonBar5.TitleStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            // 
            // 
            // 
            this.ribbonBar5.TitleStyleMouseOver.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            // 
            // btn_Hint
            // 
            this.btn_Hint.Enabled = false;
            this.btn_Hint.Image = global::Chess_game.Properties.Resources.idea_icon_64;
            this.btn_Hint.ImagePosition = DevComponents.DotNetBar.eImagePosition.Top;
            this.btn_Hint.Name = "btn_Hint";
            this.btn_Hint.SubItemsExpandWidth = 14;
            this.btn_Hint.Text = "Gợi ý ";
            this.btn_Hint.Click += new System.EventHandler(this.btn_Hint_Click);
            // 
            // ribbonBar4
            // 
            this.ribbonBar4.AutoOverflowEnabled = true;
            // 
            // 
            // 
            this.ribbonBar4.BackgroundMouseOverStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            // 
            // 
            // 
            this.ribbonBar4.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.ribbonBar4.ContainerControlProcessDialogKey = true;
            this.ribbonBar4.Dock = System.Windows.Forms.DockStyle.Left;
            this.ribbonBar4.DragDropSupport = true;
            this.ribbonBar4.Items.AddRange(new DevComponents.DotNetBar.BaseItem[] {
            this.btn_Undo,
            this.btn_Redo});
            this.ribbonBar4.LicenseKey = "F962CEC7-CD8F-4911-A9E9-CAB39962FC1F";
            this.ribbonBar4.Location = new System.Drawing.Point(238, 0);
            this.ribbonBar4.Name = "ribbonBar4";
            this.ribbonBar4.Size = new System.Drawing.Size(157, 95);
            this.ribbonBar4.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.ribbonBar4.TabIndex = 2;
            // 
            // 
            // 
            this.ribbonBar4.TitleStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            // 
            // 
            // 
            this.ribbonBar4.TitleStyleMouseOver.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            // 
            // btn_Undo
            // 
            this.btn_Undo.Enabled = false;
            this.btn_Undo.Image = global::Chess_game.Properties.Resources.arrow_refresh_1_icon;
            this.btn_Undo.ImagePosition = DevComponents.DotNetBar.eImagePosition.Top;
            this.btn_Undo.Name = "btn_Undo";
            this.btn_Undo.SubItemsExpandWidth = 14;
            this.btn_Undo.Text = "Undo";
            this.btn_Undo.Click += new System.EventHandler(this.btn_Undo_Click);
            // 
            // btn_Redo
            // 
            this.btn_Redo.Enabled = false;
            this.btn_Redo.Image = global::Chess_game.Properties.Resources.arrow_refresh_2_icon;
            this.btn_Redo.ImagePosition = DevComponents.DotNetBar.eImagePosition.Top;
            this.btn_Redo.Name = "btn_Redo";
            this.btn_Redo.SubItemsExpandWidth = 14;
            this.btn_Redo.Text = "Redo";
            this.btn_Redo.Click += new System.EventHandler(this.btn_Redo_Click);
            // 
            // ribbonBar3
            // 
            this.ribbonBar3.AutoOverflowEnabled = true;
            // 
            // 
            // 
            this.ribbonBar3.BackgroundMouseOverStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            // 
            // 
            // 
            this.ribbonBar3.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.ribbonBar3.ContainerControlProcessDialogKey = true;
            this.ribbonBar3.Dock = System.Windows.Forms.DockStyle.Left;
            this.ribbonBar3.DragDropSupport = true;
            this.ribbonBar3.Items.AddRange(new DevComponents.DotNetBar.BaseItem[] {
            this.btn_Savegame,
            this.btn_Loadgame});
            this.ribbonBar3.LicenseKey = "F962CEC7-CD8F-4911-A9E9-CAB39962FC1F";
            this.ribbonBar3.Location = new System.Drawing.Point(82, 0);
            this.ribbonBar3.Name = "ribbonBar3";
            this.ribbonBar3.Size = new System.Drawing.Size(156, 95);
            this.ribbonBar3.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.ribbonBar3.TabIndex = 1;
            // 
            // 
            // 
            this.ribbonBar3.TitleStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            // 
            // 
            // 
            this.ribbonBar3.TitleStyleMouseOver.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            // 
            // btn_Savegame
            // 
            this.btn_Savegame.Enabled = false;
            this.btn_Savegame.Image = global::Chess_game.Properties.Resources._1477430905_floppy_disk;
            this.btn_Savegame.ImagePosition = DevComponents.DotNetBar.eImagePosition.Top;
            this.btn_Savegame.Name = "btn_Savegame";
            this.btn_Savegame.SubItemsExpandWidth = 14;
            this.btn_Savegame.Text = "Lưu trò chơi ";
            this.btn_Savegame.Click += new System.EventHandler(this.btn_Savegame_Click);
            // 
            // btn_Loadgame
            // 
            this.btn_Loadgame.Image = global::Chess_game.Properties.Resources.folder_icon;
            this.btn_Loadgame.ImagePosition = DevComponents.DotNetBar.eImagePosition.Top;
            this.btn_Loadgame.Name = "btn_Loadgame";
            this.btn_Loadgame.SubItemsExpandWidth = 14;
            this.btn_Loadgame.Text = "Nạp trò chơi ";
            this.btn_Loadgame.Click += new System.EventHandler(this.btn_Loadgame_Click);
            // 
            // ribbonBar1
            // 
            this.ribbonBar1.AutoOverflowEnabled = true;
            // 
            // 
            // 
            this.ribbonBar1.BackgroundMouseOverStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            // 
            // 
            // 
            this.ribbonBar1.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.ribbonBar1.ContainerControlProcessDialogKey = true;
            this.ribbonBar1.Dock = System.Windows.Forms.DockStyle.Left;
            this.ribbonBar1.DragDropSupport = true;
            this.ribbonBar1.Items.AddRange(new DevComponents.DotNetBar.BaseItem[] {
            this.btn_Newgame});
            this.ribbonBar1.LicenseKey = "F962CEC7-CD8F-4911-A9E9-CAB39962FC1F";
            this.ribbonBar1.Location = new System.Drawing.Point(3, 0);
            this.ribbonBar1.Name = "ribbonBar1";
            this.ribbonBar1.Size = new System.Drawing.Size(79, 95);
            this.ribbonBar1.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.ribbonBar1.TabIndex = 0;
            // 
            // 
            // 
            this.ribbonBar1.TitleStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            // 
            // 
            // 
            this.ribbonBar1.TitleStyleMouseOver.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            // 
            // btn_Newgame
            // 
            this.btn_Newgame.Image = global::Chess_game.Properties.Resources.Chessboard_icon;
            this.btn_Newgame.ImagePosition = DevComponents.DotNetBar.eImagePosition.Top;
            this.btn_Newgame.Name = "btn_Newgame";
            this.btn_Newgame.SubItemsExpandWidth = 14;
            this.btn_Newgame.Text = "Chơi mới ";
            this.btn_Newgame.Click += new System.EventHandler(this.btn_Newgame_Click);
            // 
            // ribbonPanel2
            // 
            this.ribbonPanel2.ColorSchemeStyle = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.ribbonPanel2.Controls.Add(this.ribbonBar7);
            this.ribbonPanel2.Controls.Add(this.ribbonBar2);
            this.ribbonPanel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.ribbonPanel2.Location = new System.Drawing.Point(0, 53);
            this.ribbonPanel2.Name = "ribbonPanel2";
            this.ribbonPanel2.Padding = new System.Windows.Forms.Padding(3, 0, 3, 3);
            this.ribbonPanel2.Size = new System.Drawing.Size(1090, 98);
            // 
            // 
            // 
            this.ribbonPanel2.Style.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            // 
            // 
            // 
            this.ribbonPanel2.StyleMouseDown.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            // 
            // 
            // 
            this.ribbonPanel2.StyleMouseOver.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.ribbonPanel2.TabIndex = 2;
            this.ribbonPanel2.Visible = false;
            // 
            // ribbonBar7
            // 
            this.ribbonBar7.AutoOverflowEnabled = true;
            // 
            // 
            // 
            this.ribbonBar7.BackgroundMouseOverStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            // 
            // 
            // 
            this.ribbonBar7.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.ribbonBar7.ContainerControlProcessDialogKey = true;
            this.ribbonBar7.Dock = System.Windows.Forms.DockStyle.Left;
            this.ribbonBar7.DragDropSupport = true;
            this.ribbonBar7.Items.AddRange(new DevComponents.DotNetBar.BaseItem[] {
            this.btn_Savemoved});
            this.ribbonBar7.LicenseKey = "F962CEC7-CD8F-4911-A9E9-CAB39962FC1F";
            this.ribbonBar7.Location = new System.Drawing.Point(114, 0);
            this.ribbonBar7.Name = "ribbonBar7";
            this.ribbonBar7.Size = new System.Drawing.Size(118, 95);
            this.ribbonBar7.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.ribbonBar7.TabIndex = 1;
            // 
            // 
            // 
            this.ribbonBar7.TitleStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            // 
            // 
            // 
            this.ribbonBar7.TitleStyleMouseOver.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            // 
            // btn_Savemoved
            // 
            this.btn_Savemoved.Enabled = false;
            this.btn_Savemoved.Image = global::Chess_game.Properties.Resources.Document_icon;
            this.btn_Savemoved.ImagePosition = DevComponents.DotNetBar.eImagePosition.Top;
            this.btn_Savemoved.Name = "btn_Savemoved";
            this.btn_Savemoved.RibbonWordWrap = false;
            this.btn_Savemoved.SubItemsExpandWidth = 14;
            this.btn_Savemoved.Text = "Lưu các nước đã đi";
            this.btn_Savemoved.Click += new System.EventHandler(this.btn_Savemoved_Click);
            // 
            // ribbonBar2
            // 
            this.ribbonBar2.AutoOverflowEnabled = true;
            // 
            // 
            // 
            this.ribbonBar2.BackgroundMouseOverStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            // 
            // 
            // 
            this.ribbonBar2.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.ribbonBar2.ContainerControlProcessDialogKey = true;
            this.ribbonBar2.Dock = System.Windows.Forms.DockStyle.Left;
            this.ribbonBar2.DragDropSupport = true;
            this.ribbonBar2.Items.AddRange(new DevComponents.DotNetBar.BaseItem[] {
            this.btn_Capture});
            this.ribbonBar2.LicenseKey = "F962CEC7-CD8F-4911-A9E9-CAB39962FC1F";
            this.ribbonBar2.Location = new System.Drawing.Point(3, 0);
            this.ribbonBar2.Name = "ribbonBar2";
            this.ribbonBar2.Size = new System.Drawing.Size(111, 95);
            this.ribbonBar2.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.ribbonBar2.TabIndex = 0;
            // 
            // 
            // 
            this.ribbonBar2.TitleStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            // 
            // 
            // 
            this.ribbonBar2.TitleStyleMouseOver.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            // 
            // btn_Capture
            // 
            this.btn_Capture.Image = global::Chess_game.Properties.Resources.Camera_icon;
            this.btn_Capture.ImagePosition = DevComponents.DotNetBar.eImagePosition.Top;
            this.btn_Capture.Name = "btn_Capture";
            this.btn_Capture.RibbonWordWrap = false;
            this.btn_Capture.SubItemsExpandWidth = 14;
            this.btn_Capture.Text = "Chụp ảnh màn hình ";
            this.btn_Capture.Click += new System.EventHandler(this.btn_Capture_Click);
            // 
            // ribbonPanel3
            // 
            this.ribbonPanel3.ColorSchemeStyle = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.ribbonPanel3.Controls.Add(this.ribbonBar9);
            this.ribbonPanel3.Controls.Add(this.ribbonBar8);
            this.ribbonPanel3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.ribbonPanel3.Location = new System.Drawing.Point(0, 53);
            this.ribbonPanel3.Name = "ribbonPanel3";
            this.ribbonPanel3.Padding = new System.Windows.Forms.Padding(3, 0, 3, 3);
            this.ribbonPanel3.Size = new System.Drawing.Size(1090, 98);
            // 
            // 
            // 
            this.ribbonPanel3.Style.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            // 
            // 
            // 
            this.ribbonPanel3.StyleMouseDown.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            // 
            // 
            // 
            this.ribbonPanel3.StyleMouseOver.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.ribbonPanel3.TabIndex = 3;
            this.ribbonPanel3.Visible = false;
            // 
            // ribbonBar9
            // 
            this.ribbonBar9.AutoOverflowEnabled = true;
            // 
            // 
            // 
            this.ribbonBar9.BackgroundMouseOverStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            // 
            // 
            // 
            this.ribbonBar9.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.ribbonBar9.ContainerControlProcessDialogKey = true;
            this.ribbonBar9.Dock = System.Windows.Forms.DockStyle.Left;
            this.ribbonBar9.DragDropSupport = true;
            this.ribbonBar9.Items.AddRange(new DevComponents.DotNetBar.BaseItem[] {
            this.btn_Author});
            this.ribbonBar9.LicenseKey = "F962CEC7-CD8F-4911-A9E9-CAB39962FC1F";
            this.ribbonBar9.Location = new System.Drawing.Point(90, 0);
            this.ribbonBar9.Name = "ribbonBar9";
            this.ribbonBar9.Size = new System.Drawing.Size(87, 95);
            this.ribbonBar9.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.ribbonBar9.TabIndex = 1;
            // 
            // 
            // 
            this.ribbonBar9.TitleStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            // 
            // 
            // 
            this.ribbonBar9.TitleStyleMouseOver.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            // 
            // btn_Author
            // 
            this.btn_Author.Image = global::Chess_game.Properties.Resources.contact_icon_64;
            this.btn_Author.ImagePosition = DevComponents.DotNetBar.eImagePosition.Top;
            this.btn_Author.Name = "btn_Author";
            this.btn_Author.SubItemsExpandWidth = 14;
            this.btn_Author.Text = "Tác giả";
            this.btn_Author.Click += new System.EventHandler(this.btn_Author_Click);
            // 
            // ribbonBar8
            // 
            this.ribbonBar8.AutoOverflowEnabled = true;
            // 
            // 
            // 
            this.ribbonBar8.BackgroundMouseOverStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            // 
            // 
            // 
            this.ribbonBar8.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.ribbonBar8.ContainerControlProcessDialogKey = true;
            this.ribbonBar8.Dock = System.Windows.Forms.DockStyle.Left;
            this.ribbonBar8.DragDropSupport = true;
            this.ribbonBar8.Items.AddRange(new DevComponents.DotNetBar.BaseItem[] {
            this.btn_Chessrule});
            this.ribbonBar8.LicenseKey = "F962CEC7-CD8F-4911-A9E9-CAB39962FC1F";
            this.ribbonBar8.Location = new System.Drawing.Point(3, 0);
            this.ribbonBar8.Name = "ribbonBar8";
            this.ribbonBar8.Size = new System.Drawing.Size(87, 95);
            this.ribbonBar8.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.ribbonBar8.TabIndex = 0;
            // 
            // 
            // 
            this.ribbonBar8.TitleStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            // 
            // 
            // 
            this.ribbonBar8.TitleStyleMouseOver.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            // 
            // btn_Chessrule
            // 
            this.btn_Chessrule.Image = global::Chess_game.Properties.Resources.book_icon;
            this.btn_Chessrule.ImagePosition = DevComponents.DotNetBar.eImagePosition.Top;
            this.btn_Chessrule.Name = "btn_Chessrule";
            this.btn_Chessrule.SubItemsExpandWidth = 14;
            this.btn_Chessrule.Text = "Luật cờ vua ";
            this.btn_Chessrule.Click += new System.EventHandler(this.btn_Chessrule_Click);
            // 
            // ribbonTabItem_Home
            // 
            this.ribbonTabItem_Home.Checked = true;
            this.ribbonTabItem_Home.Name = "ribbonTabItem_Home";
            this.ribbonTabItem_Home.Panel = this.ribbonPanel1;
            this.ribbonTabItem_Home.Text = "Trang chủ";
            // 
            // ribbonTabItem_Auxiliaryfunction
            // 
            this.ribbonTabItem_Auxiliaryfunction.Name = "ribbonTabItem_Auxiliaryfunction";
            this.ribbonTabItem_Auxiliaryfunction.Panel = this.ribbonPanel2;
            this.ribbonTabItem_Auxiliaryfunction.Text = "Chức năng phụ";
            // 
            // ribbonTabItem_Help
            // 
            this.ribbonTabItem_Help.Name = "ribbonTabItem_Help";
            this.ribbonTabItem_Help.Panel = this.ribbonPanel3;
            this.ribbonTabItem_Help.Text = "Trợ giúp";
            // 
            // buttonItem1
            // 
            this.buttonItem1.ForeColor = System.Drawing.Color.Red;
            this.buttonItem1.HotFontBold = true;
            this.buttonItem1.Name = "buttonItem1";
            this.buttonItem1.SubItems.AddRange(new DevComponents.DotNetBar.BaseItem[] {
            this.buttonItem2,
            this.buttonItem3,
            this.buttonItem4,
            this.buttonItem5,
            this.buttonItem6,
            this.buttonItem7,
            this.colorPickerDropDown1});
            this.buttonItem1.Text = "Giao diện";
            // 
            // buttonItem2
            // 
            this.buttonItem2.Name = "buttonItem2";
            this.buttonItem2.Text = "Office 2010 Blue";
            this.buttonItem2.Click += new System.EventHandler(this.buttonItem2_Click);
            // 
            // buttonItem3
            // 
            this.buttonItem3.Name = "buttonItem3";
            this.buttonItem3.Text = "Office 2010 Black";
            this.buttonItem3.Click += new System.EventHandler(this.buttonItem3_Click);
            // 
            // buttonItem4
            // 
            this.buttonItem4.Name = "buttonItem4";
            this.buttonItem4.Text = "Office 2010 Silver ";
            this.buttonItem4.Click += new System.EventHandler(this.buttonItem4_Click);
            // 
            // buttonItem5
            // 
            this.buttonItem5.Name = "buttonItem5";
            this.buttonItem5.Text = "Office 2007 Black";
            this.buttonItem5.Click += new System.EventHandler(this.buttonItem5_Click);
            // 
            // buttonItem6
            // 
            this.buttonItem6.Name = "buttonItem6";
            this.buttonItem6.Text = "Vista Glass";
            this.buttonItem6.Click += new System.EventHandler(this.buttonItem6_Click);
            // 
            // buttonItem7
            // 
            this.buttonItem7.Name = "buttonItem7";
            this.buttonItem7.Text = "Windows 7 Blue";
            this.buttonItem7.Click += new System.EventHandler(this.buttonItem7_Click);
            // 
            // colorPickerDropDown1
            // 
            this.colorPickerDropDown1.Name = "colorPickerDropDown1";
            this.colorPickerDropDown1.Text = "Chọn màu ";
            this.colorPickerDropDown1.SelectedColorChanged += new System.EventHandler(this.colorPickerDropDown1_SelectedColorChanged);
            this.colorPickerDropDown1.ColorPreview += new DevComponents.DotNetBar.ColorPreviewEventHandler(this.colorPickerDropDown1_ColorPreview);
            this.colorPickerDropDown1.ExpandChange += new System.EventHandler(this.colorPickerDropDown1_ExpandChange);
            // 
            // qatCustomizeItem1
            // 
            this.qatCustomizeItem1.Name = "qatCustomizeItem1";
            // 
            // panel1
            // 
            this.panel1.Location = new System.Drawing.Point(144, 161);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(679, 548);
            this.panel1.TabIndex = 1;
            // 
            // pnlTimerLeft
            // 
            this.pnlTimerLeft.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("pnlTimerLeft.BackgroundImage")));
            this.pnlTimerLeft.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.pnlTimerLeft.Location = new System.Drawing.Point(8, 161);
            this.pnlTimerLeft.Name = "pnlTimerLeft";
            this.pnlTimerLeft.Size = new System.Drawing.Size(130, 59);
            this.pnlTimerLeft.TabIndex = 2;
            this.pnlTimerLeft.Visible = false;
            // 
            // pnlTimerRight
            // 
            this.pnlTimerRight.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("pnlTimerRight.BackgroundImage")));
            this.pnlTimerRight.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.pnlTimerRight.Location = new System.Drawing.Point(829, 651);
            this.pnlTimerRight.Name = "pnlTimerRight";
            this.pnlTimerRight.Size = new System.Drawing.Size(130, 58);
            this.pnlTimerRight.TabIndex = 3;
            this.pnlTimerRight.Visible = false;
            // 
            // pnlChessPieceEated1
            // 
            this.pnlChessPieceEated1.BackColor = System.Drawing.Color.Gray;
            this.pnlChessPieceEated1.Location = new System.Drawing.Point(8, 227);
            this.pnlChessPieceEated1.Name = "pnlChessPieceEated1";
            this.pnlChessPieceEated1.Size = new System.Drawing.Size(109, 418);
            this.pnlChessPieceEated1.TabIndex = 4;
            this.pnlChessPieceEated1.Visible = false;
            // 
            // pnlChessPieceEated2
            // 
            this.pnlChessPieceEated2.BackColor = System.Drawing.Color.DimGray;
            this.pnlChessPieceEated2.Location = new System.Drawing.Point(842, 227);
            this.pnlChessPieceEated2.Name = "pnlChessPieceEated2";
            this.pnlChessPieceEated2.Size = new System.Drawing.Size(117, 418);
            this.pnlChessPieceEated2.TabIndex = 5;
            this.pnlChessPieceEated2.Visible = false;
            // 
            // Form_Main
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1000, 760);
            this.Controls.Add(this.pnlChessPieceEated2);
            this.Controls.Add(this.pnlChessPieceEated1);
            this.Controls.Add(this.pnlTimerRight);
            this.Controls.Add(this.pnlTimerLeft);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.ribbonControl1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MinimumSize = new System.Drawing.Size(1000, 760);
            this.Name = "Form_Main";
            this.Text = "Chess game - Nguyen Trong Hoang Viet";
            this.WindowState = System.Windows.Forms.FormWindowState.Minimized;
            this.ribbonControl1.ResumeLayout(false);
            this.ribbonControl1.PerformLayout();
            this.ribbonPanel1.ResumeLayout(false);
            this.ribbonPanel2.ResumeLayout(false);
            this.ribbonPanel3.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private DevComponents.DotNetBar.StyleManager styleManager1;
        private DevComponents.DotNetBar.RibbonControl ribbonControl1;
        private DevComponents.DotNetBar.RibbonPanel ribbonPanel2;
        private DevComponents.DotNetBar.RibbonBar ribbonBar2;
        private DevComponents.DotNetBar.RibbonPanel ribbonPanel1;
        private DevComponents.DotNetBar.RibbonBar ribbonBar3;
        private DevComponents.DotNetBar.RibbonBar ribbonBar1;
        private DevComponents.DotNetBar.RibbonTabItem ribbonTabItem_Home;
        private DevComponents.DotNetBar.RibbonTabItem ribbonTabItem_Auxiliaryfunction;
        private DevComponents.DotNetBar.ButtonItem buttonItem1;
        private DevComponents.DotNetBar.QatCustomizeItem qatCustomizeItem1;
        private DevComponents.DotNetBar.RibbonPanel ribbonPanel3;
        private DevComponents.DotNetBar.RibbonTabItem ribbonTabItem_Help;
        private DevComponents.DotNetBar.RibbonBar ribbonBar6;
        private DevComponents.DotNetBar.RibbonBar ribbonBar5;
        private DevComponents.DotNetBar.RibbonBar ribbonBar4;
        private DevComponents.DotNetBar.ButtonItem btn_Language;
        private DevComponents.DotNetBar.ButtonItem btn_Hint;
        private DevComponents.DotNetBar.ButtonItem btn_Undo;
        private DevComponents.DotNetBar.ButtonItem btn_Redo;
        private DevComponents.DotNetBar.ButtonItem btn_Savegame;
        private DevComponents.DotNetBar.ButtonItem btn_Loadgame;
        private DevComponents.DotNetBar.ButtonItem btn_Newgame;
        private DevComponents.DotNetBar.RibbonBar ribbonBar7;
        private DevComponents.DotNetBar.ButtonItem btn_Savemoved;
        private DevComponents.DotNetBar.ButtonItem btn_Capture;
        private DevComponents.DotNetBar.RibbonBar ribbonBar9;
        private DevComponents.DotNetBar.RibbonBar ribbonBar8;
        private DevComponents.DotNetBar.ButtonItem btn_Author;
        private DevComponents.DotNetBar.ButtonItem btn_Chessrule;
        private DevComponents.DotNetBar.ButtonItem buttonItem2;
        private DevComponents.DotNetBar.ButtonItem buttonItem3;
        private DevComponents.DotNetBar.ButtonItem buttonItem4;
        private DevComponents.DotNetBar.ButtonItem buttonItem5;
        private DevComponents.DotNetBar.ButtonItem buttonItem6;
        private DevComponents.DotNetBar.ButtonItem buttonItem7;
        private DevComponents.DotNetBar.ColorPickerDropDown colorPickerDropDown1;
        private System.Windows.Forms.Panel panel1;
        private DevComponents.DotNetBar.RibbonBar ribbonBar10;
        private DevComponents.DotNetBar.ButtonItem btn_Exit;
        private DevComponents.DotNetBar.ButtonItem btn_Options;
        private System.Windows.Forms.Panel pnlTimerLeft;
        private System.Windows.Forms.Panel pnlTimerRight;
        private System.Windows.Forms.Panel pnlChessPieceEated1;
        private System.Windows.Forms.Panel pnlChessPieceEated2;
    }
}

