namespace WindowsFormsApp2
{
    partial class Form1
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

        #region Kod generowany przez Projektanta formularzy systemu Windows

        /// <summary>
        /// Metoda wymagana do obsługi projektanta — nie należy modyfikować
        /// jej zawartości w edytorze kodu.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            this.button1 = new System.Windows.Forms.Button();
            this.toolStrip1 = new System.Windows.Forms.ToolStrip();
            this.DodajWierzcholek = new System.Windows.Forms.ToolStripButton();
            this.LaczymyWierzcholki = new System.Windows.Forms.ToolStripButton();
            this.UsuwanieWierzcholka = new System.Windows.Forms.ToolStripButton();
            this.Czyszczenie = new System.Windows.Forms.ToolStripButton();
            this.toolStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(12, 28);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(75, 23);
            this.button1.TabIndex = 0;
            this.button1.Text = "Sprawdź";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // toolStrip1
            // 
            this.toolStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.DodajWierzcholek,
            this.LaczymyWierzcholki,
            this.UsuwanieWierzcholka,
            this.Czyszczenie});
            this.toolStrip1.Location = new System.Drawing.Point(0, 0);
            this.toolStrip1.Name = "toolStrip1";
            this.toolStrip1.Size = new System.Drawing.Size(800, 25);
            this.toolStrip1.TabIndex = 1;
            this.toolStrip1.Text = "toolStrip1";
            // 
            // DodajWierzcholek
            // 
            this.DodajWierzcholek.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.DodajWierzcholek.Image = ((System.Drawing.Image)(resources.GetObject("DodajWierzcholek.Image")));
            this.DodajWierzcholek.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.DodajWierzcholek.Name = "DodajWierzcholek";
            this.DodajWierzcholek.Size = new System.Drawing.Size(23, 22);
            this.DodajWierzcholek.Text = "Dodaj wierzchołek";
            this.DodajWierzcholek.Click += new System.EventHandler(this.DodajWierzcholek_Click);
            // 
            // LaczymyWierzcholki
            // 
            this.LaczymyWierzcholki.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.LaczymyWierzcholki.Image = ((System.Drawing.Image)(resources.GetObject("LaczymyWierzcholki.Image")));
            this.LaczymyWierzcholki.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.LaczymyWierzcholki.Name = "LaczymyWierzcholki";
            this.LaczymyWierzcholki.Size = new System.Drawing.Size(23, 22);
            this.LaczymyWierzcholki.Text = "Dodaj krawędź";
            this.LaczymyWierzcholki.Click += new System.EventHandler(this.LaczymyWierzcholki_Click);
            // 
            // UsuwanieWierzcholka
            // 
            this.UsuwanieWierzcholka.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.UsuwanieWierzcholka.Image = ((System.Drawing.Image)(resources.GetObject("UsuwanieWierzcholka.Image")));
            this.UsuwanieWierzcholka.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.UsuwanieWierzcholka.Name = "UsuwanieWierzcholka";
            this.UsuwanieWierzcholka.Size = new System.Drawing.Size(23, 22);
            this.UsuwanieWierzcholka.Text = "Usuń wierzchołek";
            this.UsuwanieWierzcholka.Click += new System.EventHandler(this.UsuwanieWierzcholka_Click);
            // 
            // Czyszczenie
            // 
            this.Czyszczenie.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.Czyszczenie.Image = ((System.Drawing.Image)(resources.GetObject("Czyszczenie.Image")));
            this.Czyszczenie.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.Czyszczenie.Name = "Czyszczenie";
            this.Czyszczenie.Size = new System.Drawing.Size(23, 22);
            this.Czyszczenie.Text = "Wyczyść";
            this.Czyszczenie.Click += new System.EventHandler(this.toolStripButton1_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.toolStrip1);
            this.Controls.Add(this.button1);
            this.Name = "Form1";
            this.Text = "Graf Dwudzielny";
            this.Paint += new System.Windows.Forms.PaintEventHandler(this.Form1_Paint);
            this.MouseUp += new System.Windows.Forms.MouseEventHandler(this.Form1_MouseUp);
            this.toolStrip1.ResumeLayout(false);
            this.toolStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.ToolStrip toolStrip1;
        private System.Windows.Forms.ToolStripButton DodajWierzcholek;
        private System.Windows.Forms.ToolStripButton LaczymyWierzcholki;
        private System.Windows.Forms.ToolStripButton UsuwanieWierzcholka;
        private System.Windows.Forms.ToolStripButton Czyszczenie;
    }
}

