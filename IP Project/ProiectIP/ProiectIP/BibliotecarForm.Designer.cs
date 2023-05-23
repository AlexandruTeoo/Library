namespace ProiectIP
{
    partial class BibliotecarForms
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
            this.Modifica = new System.Windows.Forms.Button();
            this.Sterge = new System.Windows.Forms.Button();
            this.listBox1 = new System.Windows.Forms.ListBox();
            this.Carti = new System.Windows.Forms.Button();
            this.Imprumuturi = new System.Windows.Forms.Button();
            this.Conturi = new System.Windows.Forms.Button();
            this.Deconectare = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // Modifica
            // 
            this.Modifica.Location = new System.Drawing.Point(644, 35);
            this.Modifica.Name = "Modifica";
            this.Modifica.Size = new System.Drawing.Size(142, 51);
            this.Modifica.TabIndex = 1;
            this.Modifica.Text = "Modifica";
            this.Modifica.UseVisualStyleBackColor = true;
            this.Modifica.Click += new System.EventHandler(this.buttonModifyDetailsBook_Click);
            // 
            // Sterge
            // 
            this.Sterge.Location = new System.Drawing.Point(644, 123);
            this.Sterge.Name = "Sterge";
            this.Sterge.Size = new System.Drawing.Size(142, 51);
            this.Sterge.TabIndex = 2;
            this.Sterge.Text = "Sterge";
            this.Sterge.UseVisualStyleBackColor = true;
            this.Sterge.Click += new System.EventHandler(this.buttonDeleteBook_click);
            // 
            // listBox1
            // 
            this.listBox1.FormattingEnabled = true;
            this.listBox1.ItemHeight = 16;
            this.listBox1.Location = new System.Drawing.Point(81, 71);
            this.listBox1.Name = "listBox1";
            this.listBox1.Size = new System.Drawing.Size(467, 372);
            this.listBox1.TabIndex = 4;
            // 
            // Carti
            // 
            this.Carti.Location = new System.Drawing.Point(644, 209);
            this.Carti.Name = "Carti";
            this.Carti.Size = new System.Drawing.Size(142, 51);
            this.Carti.TabIndex = 5;
            this.Carti.Text = "Carti";
            this.Carti.UseVisualStyleBackColor = true;
            this.Carti.Click += new System.EventHandler(this.buttonShowBooks_click);
            // 
            // Imprumuturi
            // 
            this.Imprumuturi.Location = new System.Drawing.Point(644, 301);
            this.Imprumuturi.Name = "Imprumuturi";
            this.Imprumuturi.Size = new System.Drawing.Size(142, 51);
            this.Imprumuturi.TabIndex = 6;
            this.Imprumuturi.Text = "Imprumuturi";
            this.Imprumuturi.UseVisualStyleBackColor = true;
            // 
            // Conturi
            // 
            this.Conturi.Location = new System.Drawing.Point(644, 392);
            this.Conturi.Name = "Conturi";
            this.Conturi.Size = new System.Drawing.Size(142, 51);
            this.Conturi.TabIndex = 7;
            this.Conturi.Text = "Conturi";
            this.Conturi.UseVisualStyleBackColor = true;
            this.Conturi.Click += new System.EventHandler(this.buttonShowAllAccounts_click);
            // 
            // Deconectare
            // 
            this.Deconectare.Location = new System.Drawing.Point(644, 478);
            this.Deconectare.Name = "Deconectare";
            this.Deconectare.Size = new System.Drawing.Size(142, 51);
            this.Deconectare.TabIndex = 8;
            this.Deconectare.Text = "Deconectare";
            this.Deconectare.UseVisualStyleBackColor = true;
            this.Deconectare.Click += new System.EventHandler(this.buttonDeconectare_Click);
            // 
            // v
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(826, 548);
            this.Controls.Add(this.Deconectare);
            this.Controls.Add(this.Conturi);
            this.Controls.Add(this.Imprumuturi);
            this.Controls.Add(this.Carti);
            this.Controls.Add(this.listBox1);
            this.Controls.Add(this.Sterge);
            this.Controls.Add(this.Modifica);
            this.Name = "v";
            this.Text = "BibliotecarForm";
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button Modifica;
        private System.Windows.Forms.Button Sterge;
        private System.Windows.Forms.ListBox listBox1;
        private System.Windows.Forms.Button Carti;
        private System.Windows.Forms.Button Imprumuturi;
        private System.Windows.Forms.Button Conturi;
        private System.Windows.Forms.Button Deconectare;
    }
}