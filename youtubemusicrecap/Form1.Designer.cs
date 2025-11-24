namespace youtubemusicrecap
{
    partial class Form1
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
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
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            top_songs = new Panel();
            top_authors = new Panel();
            SuspendLayout();
            // 
            // top_songs
            // 
            top_songs.AutoScroll = true;
            top_songs.Location = new Point(12, 12);
            top_songs.Name = "top_songs";
            top_songs.Size = new Size(421, 430);
            top_songs.TabIndex = 0;
            // 
            // top_authors
            // 
            top_authors.AutoScroll = true;
            top_authors.Location = new Point(455, 12);
            top_authors.Name = "top_authors";
            top_authors.Size = new Size(421, 430);
            top_authors.TabIndex = 1;
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(892, 450);
            Controls.Add(top_authors);
            Controls.Add(top_songs);
            Name = "Form1";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Form1";
            Load += Form1_Load;
            ResumeLayout(false);
        }

        #endregion

        private Panel top_songs;
        private Panel top_authors;
    }
}
