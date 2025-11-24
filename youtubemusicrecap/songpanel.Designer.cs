namespace youtubemusicrecap
{
    partial class songpanel
    {
        /// <summary> 
        /// Wymagana zmienna projektanta.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary> 
        /// Wyczyść wszystkie używane zasoby.
        /// </summary>
        /// <param name="disposing">prawda, jeżeli zarządzane zasoby powinny zostać zlikwidowane; Fałsz w przeciwnym wypadku.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Kod wygenerowany przez Projektanta składników

        /// <summary> 
        /// Metoda wymagana do obsługi projektanta — nie należy modyfikować 
        /// jej zawartości w edytorze kodu.
        /// </summary>
        private void InitializeComponent()
        {
            name_song = new Label();
            pictureBox1 = new PictureBox();
            view_count = new Label();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).BeginInit();
            SuspendLayout();
            // 
            // name_song
            // 
            name_song.AutoSize = true;
            name_song.Location = new Point(178, 3);
            name_song.Name = "name_song";
            name_song.Size = new Size(38, 15);
            name_song.TabIndex = 0;
            name_song.Text = "label1";
            // 
            // pictureBox1
            // 
            pictureBox1.Location = new Point(5, 3);
            pictureBox1.Name = "pictureBox1";
            pictureBox1.Size = new Size(167, 94);
            pictureBox1.SizeMode = PictureBoxSizeMode.Zoom;
            pictureBox1.TabIndex = 1;
            pictureBox1.TabStop = false;
            // 
            // view_count
            // 
            view_count.AutoSize = true;
            view_count.Location = new Point(178, 28);
            view_count.Name = "view_count";
            view_count.Size = new Size(38, 15);
            view_count.TabIndex = 2;
            view_count.Text = "label1";
            // 
            // songpanel
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.FromArgb(224, 224, 224);
            Controls.Add(view_count);
            Controls.Add(pictureBox1);
            Controls.Add(name_song);
            Name = "songpanel";
            Size = new Size(400, 100);
            Load += songpanel_Load;
            ((System.ComponentModel.ISupportInitialize)pictureBox1).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        public Label name_song;
        private PictureBox pictureBox1;
        public Label view_count;
        private Label label1;
    }
}
