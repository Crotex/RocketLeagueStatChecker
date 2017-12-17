namespace RocketLeagueStatChecker
{
    partial class Main_Form
    {
        /// <summary>
        /// Erforderliche Designervariable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Verwendete Ressourcen bereinigen.
        /// </summary>
        /// <param name="disposing">True, wenn verwaltete Ressourcen gelöscht werden sollen; andernfalls False.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Vom Windows Form-Designer generierter Code

        /// <summary>
        /// Erforderliche Methode für die Designerunterstützung.
        /// Der Inhalt der Methode darf nicht mit dem Code-Editor geändert werden.
        /// </summary>
        private void InitializeComponent()
        {
            this.seasonBox = new System.Windows.Forms.ComboBox();
            this.test_DELETELATER = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // seasonBox
            // 
            this.seasonBox.BackColor = System.Drawing.Color.White;
            this.seasonBox.FormattingEnabled = true;
            this.seasonBox.Items.AddRange(new object[] {
            "Season 1",
            "Season 2",
            "Season 3",
            "Season 4",
            "Season 5",
            "Season 6"});
            this.seasonBox.Location = new System.Drawing.Point(12, 12);
            this.seasonBox.Name = "seasonBox";
            this.seasonBox.Size = new System.Drawing.Size(121, 21);
            this.seasonBox.TabIndex = 0;
            this.seasonBox.SelectionChangeCommitted += new System.EventHandler(this.seasonBox_ItemChanged);
            // 
            // test_DELETELATER
            // 
            this.test_DELETELATER.AutoSize = true;
            this.test_DELETELATER.Location = new System.Drawing.Point(550, 305);
            this.test_DELETELATER.Name = "test_DELETELATER";
            this.test_DELETELATER.Size = new System.Drawing.Size(35, 13);
            this.test_DELETELATER.TabIndex = 1;
            this.test_DELETELATER.Text = "label1";
            // 
            // Main_Form
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1264, 681);
            this.Controls.Add(this.test_DELETELATER);
            this.Controls.Add(this.seasonBox);
            this.Name = "Main_Form";
            this.Text = "Rocket League Stat Checker";
            this.Deactivate += new System.EventHandler(this.Main_Form_Deactivate);
            this.Load += new System.EventHandler(this.Main_Form_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ComboBox seasonBox;
        private System.Windows.Forms.Label test_DELETELATER;
    }
}

