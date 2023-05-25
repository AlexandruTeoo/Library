namespace ProiectIP
{
    partial class ModificaCarte
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
            this.Categorie = new System.Windows.Forms.Label();
            this.Autor = new System.Windows.Forms.Label();
            this.Titlu = new System.Windows.Forms.Label();
            this.textBoxCategorie = new System.Windows.Forms.TextBox();
            this.textBoxAutor = new System.Windows.Forms.TextBox();
            this.textBoxTitle = new System.Windows.Forms.TextBox();
            this.Inapoi = new System.Windows.Forms.Button();
            this.buttonModifica = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 16.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(177, 57);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(161, 32);
            this.label1.TabIndex = 0;
            this.label1.Text = "Ati selectat ";
            // 
            // Categorie
            // 
            this.Categorie.AutoSize = true;
            this.Categorie.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Categorie.Location = new System.Drawing.Point(227, 249);
            this.Categorie.Name = "Categorie";
            this.Categorie.Size = new System.Drawing.Size(81, 20);
            this.Categorie.TabIndex = 22;
            this.Categorie.Text = "Categorie";
            this.Categorie.TextAlign = System.Drawing.ContentAlignment.BottomRight;
            // 
            // Autor
            // 
            this.Autor.AutoSize = true;
            this.Autor.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Autor.Location = new System.Drawing.Point(254, 203);
            this.Autor.Name = "Autor";
            this.Autor.Size = new System.Drawing.Size(49, 20);
            this.Autor.TabIndex = 21;
            this.Autor.Text = "Autor";
            this.Autor.TextAlign = System.Drawing.ContentAlignment.BottomRight;
            // 
            // Titlu
            // 
            this.Titlu.AutoSize = true;
            this.Titlu.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Titlu.Location = new System.Drawing.Point(262, 154);
            this.Titlu.Name = "Titlu";
            this.Titlu.Size = new System.Drawing.Size(41, 20);
            this.Titlu.TabIndex = 20;
            this.Titlu.Text = "Titlu";
            this.Titlu.TextAlign = System.Drawing.ContentAlignment.BottomRight;
            // 
            // textBoxCategorie
            // 
            this.textBoxCategorie.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textBoxCategorie.Location = new System.Drawing.Point(322, 242);
            this.textBoxCategorie.Name = "textBoxCategorie";
            this.textBoxCategorie.Size = new System.Drawing.Size(176, 27);
            this.textBoxCategorie.TabIndex = 27;
            // 
            // textBoxAutor
            // 
            this.textBoxAutor.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textBoxAutor.Location = new System.Drawing.Point(322, 196);
            this.textBoxAutor.Name = "textBoxAutor";
            this.textBoxAutor.Size = new System.Drawing.Size(176, 27);
            this.textBoxAutor.TabIndex = 26;
            // 
            // textBoxTitle
            // 
            this.textBoxTitle.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textBoxTitle.Location = new System.Drawing.Point(322, 154);
            this.textBoxTitle.Name = "textBoxTitle";
            this.textBoxTitle.Size = new System.Drawing.Size(176, 27);
            this.textBoxTitle.TabIndex = 25;
            // 
            // Inapoi
            // 
            this.Inapoi.Location = new System.Drawing.Point(579, 357);
            this.Inapoi.Name = "Inapoi";
            this.Inapoi.Size = new System.Drawing.Size(185, 62);
            this.Inapoi.TabIndex = 30;
            this.Inapoi.Text = "Inapoi la Pagina Administratorului";
            this.Inapoi.UseVisualStyleBackColor = true;
            this.Inapoi.Click += new System.EventHandler(this.Inapoi_Click);
            // 
            // buttonModifica
            // 
            this.buttonModifica.Location = new System.Drawing.Point(39, 357);
            this.buttonModifica.Name = "buttonModifica";
            this.buttonModifica.Size = new System.Drawing.Size(185, 62);
            this.buttonModifica.TabIndex = 31;
            this.buttonModifica.Text = "Modifica";
            this.buttonModifica.UseVisualStyleBackColor = true;
            this.buttonModifica.Click += new System.EventHandler(this.buttonModifica_Click);
            // 
            // ModificaCarte
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.buttonModifica);
            this.Controls.Add(this.Inapoi);
            this.Controls.Add(this.textBoxCategorie);
            this.Controls.Add(this.textBoxAutor);
            this.Controls.Add(this.textBoxTitle);
            this.Controls.Add(this.Categorie);
            this.Controls.Add(this.Autor);
            this.Controls.Add(this.Titlu);
            this.Controls.Add(this.label1);
            this.Name = "ModificaCarte";
            this.Text = "ModificaCarte";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label Categorie;
        private System.Windows.Forms.Label Autor;
        private System.Windows.Forms.Label Titlu;
        private System.Windows.Forms.TextBox textBoxCategorie;
        private System.Windows.Forms.TextBox textBoxAutor;
        private System.Windows.Forms.TextBox textBoxTitle;
        private System.Windows.Forms.Button Inapoi;
        private System.Windows.Forms.Button buttonModifica;
    }
}