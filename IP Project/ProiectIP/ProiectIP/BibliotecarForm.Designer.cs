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
            this.listBoxBibliotecarForm = new System.Windows.Forms.ListBox();
            this.Carti = new System.Windows.Forms.Button();
            this.Imprumuturi = new System.Windows.Forms.Button();
            this.adaugaCarte = new System.Windows.Forms.Button();
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
            this.Sterge.Text = "Sterge Carte";
            this.Sterge.UseVisualStyleBackColor = true;
            this.Sterge.Click += new System.EventHandler(this.buttonDeleteBook_click);
            // 
            // listBoxBibliotecarForm
            // 
            this.listBoxBibliotecarForm.FormattingEnabled = true;
            this.listBoxBibliotecarForm.ItemHeight = 16;
            this.listBoxBibliotecarForm.Location = new System.Drawing.Point(81, 71);
            this.listBoxBibliotecarForm.Name = "listBoxBibliotecarForm";
            this.listBoxBibliotecarForm.Size = new System.Drawing.Size(467, 372);
            this.listBoxBibliotecarForm.TabIndex = 4;
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
            // adaugaCarte
            // 
            this.adaugaCarte.Location = new System.Drawing.Point(644, 392);
            this.adaugaCarte.Name = "adaugaCarte";
            this.adaugaCarte.Size = new System.Drawing.Size(142, 51);
            this.adaugaCarte.TabIndex = 7;
            this.adaugaCarte.Text = "Adauga Carte";
            this.adaugaCarte.UseVisualStyleBackColor = true;
            this.adaugaCarte.Click += new System.EventHandler(this.buttonAdaugaCarte_click);
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
            // BibliotecarForms
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(826, 548);
            this.Controls.Add(this.Deconectare);
            this.Controls.Add(this.adaugaCarte);
            this.Controls.Add(this.Imprumuturi);
            this.Controls.Add(this.Carti);
            this.Controls.Add(this.listBoxBibliotecarForm);
            this.Controls.Add(this.Sterge);
            this.Controls.Add(this.Modifica);
            this.Name = "BibliotecarForms";
            this.Text = "BibliotecarForm";
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button Modifica;
        private System.Windows.Forms.Button Sterge;
        private System.Windows.Forms.ListBox listBoxBibliotecarForm;
        private System.Windows.Forms.Button Carti;
        private System.Windows.Forms.Button Imprumuturi;
        private System.Windows.Forms.Button adaugaCarte;
        private System.Windows.Forms.Button Deconectare;
    }
}