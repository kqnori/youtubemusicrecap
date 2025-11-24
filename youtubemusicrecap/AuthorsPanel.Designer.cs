namespace youtubemusicrecap
{
    partial class AuthorsPanel
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
            label1 = new Label();
            Duration = new Label();
            SuspendLayout();
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(79, 13);
            label1.Name = "label1";
            label1.Size = new Size(38, 15);
            label1.TabIndex = 0;
            label1.Text = "label1";
            // 
            // Duration
            // 
            Duration.AutoSize = true;
            Duration.Location = new Point(79, 39);
            Duration.Name = "Duration";
            Duration.Size = new Size(38, 15);
            Duration.TabIndex = 1;
            Duration.Text = "label2";
            // 
            // AuthorsPanel
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.FromArgb(224, 224, 224);
            Controls.Add(Duration);
            Controls.Add(label1);
            Name = "AuthorsPanel";
            Size = new Size(400, 100);
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        public Label label1;
        public Label Duration;
    }
}
