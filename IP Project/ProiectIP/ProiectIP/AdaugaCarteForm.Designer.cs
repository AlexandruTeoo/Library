namespace ProiectIP
{
    partial class AdaugaCarteForm
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
            this.label1 = new System.Windows.Forms.Label();
            this.textBoxCategorie = new System.Windows.Forms.TextBox();
            this.textBoxAutor = new System.Windows.Forms.TextBox();
            this.Categorie = new System.Windows.Forms.Label();
            this.Autor = new System.Windows.Forms.Label();
            this.Titlu = new System.Windows.Forms.Label();
            this.textBoxTitle = new System.Windows.Forms.TextBox();
            this.buttonAdaugaCartea = new System.Windows.Forms.Button();
            this.Inapoi = new System.Windows.Forms.Button();
            this.textBoxCartiAdaugate = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 16.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(120, 44);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(543, 32);
            this.label1.TabIndex = 1;
            this.label1.Text = "Introdu datele pe care dorești să le adaugi\r\n";
            // 
            // textBoxCategorie
            // 
            this.textBoxCategorie.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textBoxCategorie.Location = new System.Drawing.Point(326, 205);
            this.textBoxCategorie.Name = "textBoxCategorie";
            this.textBoxCategorie.Size = new System.Drawing.Size(176, 27);
            this.textBoxCategorie.TabIndex = 24;
            // 
            // textBoxAutor
            // 
            this.textBoxAutor.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textBoxAutor.Location = new System.Drawing.Point(326, 159);
            this.textBoxAutor.Name = "textBoxAutor";
            this.textBoxAutor.Size = new System.Drawing.Size(176, 27);
            this.textBoxAutor.TabIndex = 23;
            // 
            // Categorie
            // 
            this.Categorie.AutoSize = true;
            this.Categorie.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Categorie.Location = new System.Drawing.Point(217, 212);
            this.Categorie.Name = "Categorie";
            this.Categorie.Size = new System.Drawing.Size(81, 20);
            this.Categorie.TabIndex = 19;
            this.Categorie.Text = "Categorie";
            this.Categorie.TextAlign = System.Drawing.ContentAlignment.BottomRight;
            // 
            // Autor
            // 
            this.Autor.AutoSize = true;
            this.Autor.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Autor.Location = new System.Drawing.Point(244, 166);
            this.Autor.Name = "Autor";
            this.Autor.Size = new System.Drawing.Size(49, 20);
            this.Autor.TabIndex = 18;
            this.Autor.Text = "Autor";
            this.Autor.TextAlign = System.Drawing.ContentAlignment.BottomRight;
            // 
            // Titlu
            // 
            this.Titlu.AutoSize = true;
            this.Titlu.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Titlu.Location = new System.Drawing.Point(252, 117);
            this.Titlu.Name = "Titlu";
            this.Titlu.Size = new System.Drawing.Size(41, 20);
            this.Titlu.TabIndex = 17;
            this.Titlu.Text = "Titlu";
            this.Titlu.TextAlign = System.Drawing.ContentAlignment.BottomRight;
            // 
            // textBoxTitle
            // 
            this.textBoxTitle.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textBoxTitle.Location = new System.Drawing.Point(326, 117);
            this.textBoxTitle.Name = "textBoxTitle";
            this.textBoxTitle.Size = new System.Drawing.Size(176, 27);
            this.textBoxTitle.TabIndex = 16;
            // 
            // buttonAdaugaCartea
            // 
            this.buttonAdaugaCartea.Location = new System.Drawing.Point(126, 340);
            this.buttonAdaugaCartea.Name = "buttonAdaugaCartea";
            this.buttonAdaugaCartea.Size = new System.Drawing.Size(185, 57);
            this.buttonAdaugaCartea.TabIndex = 28;
            this.buttonAdaugaCartea.Text = "Adaugă Cartea";
            this.buttonAdaugaCartea.UseVisualStyleBackColor = true;
            this.buttonAdaugaCartea.Click += new System.EventHandler(this.buttonAdaugaCartea_click);
            // 
            // Inapoi
            // 
            this.Inapoi.Location = new System.Drawing.Point(524, 335);
            this.Inapoi.Name = "Inapoi";
            this.Inapoi.Size = new System.Drawing.Size(185, 62);
            this.Inapoi.TabIndex = 29;
            this.Inapoi.Text = "Înapoi la Pagina Administratorului";
            this.Inapoi.UseVisualStyleBackColor = true;
            this.Inapoi.Click += new System.EventHandler(this.buttonInapoi_click);
            // 
            // textBoxCartiAdaugate
            // 
            this.textBoxCartiAdaugate.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textBoxCartiAdaugate.Location = new System.Drawing.Point(326, 255);
            this.textBoxCartiAdaugate.Name = "textBoxCartiAdaugate";
            this.textBoxCartiAdaugate.Size = new System.Drawing.Size(176, 27);
            this.textBoxCartiAdaugate.TabIndex = 31;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(173, 262);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(120, 20);
            this.label2.TabIndex = 30;
            this.label2.Text = "Cărți Adăugate";
            this.label2.TextAlign = System.Drawing.ContentAlignment.BottomRight;
            // 
            // AdaugaCarteForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 409);
            this.Controls.Add(this.textBoxCartiAdaugate);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.Inapoi);
            this.Controls.Add(this.buttonAdaugaCartea);
            this.Controls.Add(this.textBoxCategorie);
            this.Controls.Add(this.textBoxAutor);
            this.Controls.Add(this.Categorie);
            this.Controls.Add(this.Autor);
            this.Controls.Add(this.Titlu);
            this.Controls.Add(this.textBoxTitle);
            this.Controls.Add(this.label1);
            this.Name = "AdaugaCarteForm";
            this.Text = "AdaugaCarte";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox textBoxCategorie;
        private System.Windows.Forms.TextBox textBoxAutor;
        private System.Windows.Forms.Label Categorie;
        private System.Windows.Forms.Label Autor;
        private System.Windows.Forms.Label Titlu;
        private System.Windows.Forms.TextBox textBoxTitle;
        private System.Windows.Forms.Button buttonAdaugaCartea;
        private System.Windows.Forms.Button Inapoi;
        private System.Windows.Forms.TextBox textBoxCartiAdaugate;
        private System.Windows.Forms.Label label2;
    }
}