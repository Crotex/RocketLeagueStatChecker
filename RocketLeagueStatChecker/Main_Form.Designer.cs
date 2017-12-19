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
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.tableLayoutPanel2 = new System.Windows.Forms.TableLayoutPanel();
            this.DoublesRankIcon = new System.Windows.Forms.PictureBox();
            this.SoloStandardRankIcon = new System.Windows.Forms.PictureBox();
            this.StandardRankIcon = new System.Windows.Forms.PictureBox();
            this.DuelRankIcon = new System.Windows.Forms.PictureBox();
            this.tableLayoutPanel1.SuspendLayout();
            this.tableLayoutPanel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.DoublesRankIcon)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.SoloStandardRankIcon)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.StandardRankIcon)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.DuelRankIcon)).BeginInit();
            this.SuspendLayout();
            // 
            // seasonBox
            // 
            this.seasonBox.BackColor = System.Drawing.Color.White;
            this.seasonBox.FormattingEnabled = true;
            this.seasonBox.Items.AddRange(new object[] {
            "Season 2",
            "Season 3",
            "Season 4",
            "Season 5",
            "Season 6"});
            this.seasonBox.Location = new System.Drawing.Point(3, 3);
            this.seasonBox.Name = "seasonBox";
            this.seasonBox.Size = new System.Drawing.Size(121, 21);
            this.seasonBox.TabIndex = 0;
            this.seasonBox.SelectionChangeCommitted += new System.EventHandler(this.seasonBox_ItemChanged);
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.ColumnCount = 1;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.tableLayoutPanel1.Controls.Add(this.seasonBox, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this.tableLayoutPanel2, 0, 1);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 2;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel1.Size = new System.Drawing.Size(1264, 681);
            this.tableLayoutPanel1.TabIndex = 1;
            // 
            // tableLayoutPanel2
            // 
            this.tableLayoutPanel2.ColumnCount = 4;
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 25F));
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 25F));
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 25F));
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 25F));
            this.tableLayoutPanel2.Controls.Add(this.DoublesRankIcon, 1, 1);
            this.tableLayoutPanel2.Controls.Add(this.SoloStandardRankIcon, 2, 1);
            this.tableLayoutPanel2.Controls.Add(this.StandardRankIcon, 3, 1);
            this.tableLayoutPanel2.Controls.Add(this.DuelRankIcon, 0, 1);
            this.tableLayoutPanel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel2.Location = new System.Drawing.Point(0, 27);
            this.tableLayoutPanel2.Margin = new System.Windows.Forms.Padding(0);
            this.tableLayoutPanel2.Name = "tableLayoutPanel2";
            this.tableLayoutPanel2.RowCount = 3;
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 100F));
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 100F));
            this.tableLayoutPanel2.Size = new System.Drawing.Size(1264, 654);
            this.tableLayoutPanel2.TabIndex = 1;
            // 
            // DoublesRankIcon
            // 
            this.DoublesRankIcon.Dock = System.Windows.Forms.DockStyle.Fill;
            this.DoublesRankIcon.Location = new System.Drawing.Point(316, 100);
            this.DoublesRankIcon.Margin = new System.Windows.Forms.Padding(0);
            this.DoublesRankIcon.Name = "DoublesRankIcon";
            this.DoublesRankIcon.Size = new System.Drawing.Size(316, 454);
            this.DoublesRankIcon.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.DoublesRankIcon.TabIndex = 1;
            this.DoublesRankIcon.TabStop = false;
            // 
            // SoloStandardRankIcon
            // 
            this.SoloStandardRankIcon.Dock = System.Windows.Forms.DockStyle.Fill;
            this.SoloStandardRankIcon.Location = new System.Drawing.Point(632, 100);
            this.SoloStandardRankIcon.Margin = new System.Windows.Forms.Padding(0);
            this.SoloStandardRankIcon.Name = "SoloStandardRankIcon";
            this.SoloStandardRankIcon.Size = new System.Drawing.Size(316, 454);
            this.SoloStandardRankIcon.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.SoloStandardRankIcon.TabIndex = 2;
            this.SoloStandardRankIcon.TabStop = false;
            // 
            // StandardRankIcon
            // 
            this.StandardRankIcon.Dock = System.Windows.Forms.DockStyle.Fill;
            this.StandardRankIcon.Location = new System.Drawing.Point(948, 100);
            this.StandardRankIcon.Margin = new System.Windows.Forms.Padding(0);
            this.StandardRankIcon.Name = "StandardRankIcon";
            this.StandardRankIcon.Size = new System.Drawing.Size(316, 454);
            this.StandardRankIcon.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.StandardRankIcon.TabIndex = 3;
            this.StandardRankIcon.TabStop = false;
            // 
            // DuelRankIcon
            // 
            this.DuelRankIcon.Dock = System.Windows.Forms.DockStyle.Fill;
            this.DuelRankIcon.Location = new System.Drawing.Point(0, 100);
            this.DuelRankIcon.Margin = new System.Windows.Forms.Padding(0);
            this.DuelRankIcon.Name = "DuelRankIcon";
            this.DuelRankIcon.Size = new System.Drawing.Size(316, 454);
            this.DuelRankIcon.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.DuelRankIcon.TabIndex = 0;
            this.DuelRankIcon.TabStop = false;
            // 
            // Main_Form
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1264, 681);
            this.Controls.Add(this.tableLayoutPanel1);
            this.Name = "Main_Form";
            this.Text = "Rocket League Stat Checker";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.Main_Form_FormClosed);
            this.tableLayoutPanel1.ResumeLayout(false);
            this.tableLayoutPanel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.DoublesRankIcon)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.SoloStandardRankIcon)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.StandardRankIcon)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.DuelRankIcon)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.ComboBox seasonBox;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel2;
        private System.Windows.Forms.PictureBox DoublesRankIcon;
        private System.Windows.Forms.PictureBox SoloStandardRankIcon;
        private System.Windows.Forms.PictureBox StandardRankIcon;
        private System.Windows.Forms.PictureBox DuelRankIcon;
    }
}

