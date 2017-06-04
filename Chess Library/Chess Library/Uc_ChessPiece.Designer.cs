namespace Chess_Library
{
    partial class Uc_ChessPiece
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

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.SuspendLayout();
            // 
            // Uc_ChessPiece
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Name = "Uc_ChessPiece";
            this.Load += new System.EventHandler(this.Uc_ChessPiece_Load);
            this.Click += new System.EventHandler(this.Uc_ChessPiece_Click);
            this.Paint += new System.Windows.Forms.PaintEventHandler(this.Uc_ChessPiece_Paint);
            this.ResumeLayout(false);

        }

        #endregion
    }
}
