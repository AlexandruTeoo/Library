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
            this.label1 = new System.Windows.Forms.Label();
            this.buttonAcceptaImprumut = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // Modifica
            // 
            this.Modifica.Location = new System.Drawing.Point(1049, 85);
            this.Modifica.Name = "Modifica";
            this.Modifica.Size = new System.Drawing.Size(142, 51);
            this.Modifica.TabIndex = 1;
            this.Modifica.Text = "Modifică Carte";
            this.Modifica.UseVisualStyleBackColor = true;
            this.Modifica.Click += new System.EventHandler(this.buttonModifyDetailsBook_Click);
            // 
            // Sterge
            // 
            this.Sterge.Location = new System.Drawing.Point(1049, 199);
            this.Sterge.Name = "Sterge";
            this.Sterge.Size = new System.Drawing.Size(142, 51);
            this.Sterge.TabIndex = 2;
            this.Sterge.Text = "Șterge Carte";
            this.Sterge.UseVisualStyleBackColor = true;
            this.Sterge.Click += new System.EventHandler(this.buttonDeleteBook_click);
            // 
            // listBoxBibliotecarForm
            // 
            this.listBoxBibliotecarForm.FormattingEnabled = true;
            this.listBoxBibliotecarForm.ItemHeight = 16;
            this.listBoxBibliotecarForm.Location = new System.Drawing.Point(88, 116);
            this.listBoxBibliotecarForm.Name = "listBoxBibliotecarForm";
            this.listBoxBibliotecarForm.Size = new System.Drawing.Size(881, 372);
            this.listBoxBibliotecarForm.TabIndex = 4;
            // 
            // Carti
            // 
            this.Carti.Location = new System.Drawing.Point(1049, 28);
            this.Carti.Name = "Carti";
            this.Carti.Size = new System.Drawing.Size(142, 51);
            this.Carti.TabIndex = 5;
            this.Carti.Text = "Cărți";
            this.Carti.UseVisualStyleBackColor = true;
            this.Carti.Click += new System.EventHandler(this.buttonShowBooks_click);
            // 
            // Imprumuturi
            // 
            this.Imprumuturi.Location = new System.Drawing.Point(1049, 298);
            this.Imprumuturi.Name = "Imprumuturi";
            this.Imprumuturi.Size = new System.Drawing.Size(142, 51);
            this.Imprumuturi.TabIndex = 6;
            this.Imprumuturi.Text = "Cereri Împrumuturi";
            this.Imprumuturi.UseVisualStyleBackColor = true;
            this.Imprumuturi.Click += new System.EventHandler(this.Imprumuturi_Click);
            // 
            // adaugaCarte
            // 
            this.adaugaCarte.Location = new System.Drawing.Point(1049, 142);
            this.adaugaCarte.Name = "adaugaCarte";
            this.adaugaCarte.Size = new System.Drawing.Size(142, 51);
            this.adaugaCarte.TabIndex = 7;
            this.adaugaCarte.Text = "Adaugă Carte";
            this.adaugaCarte.UseVisualStyleBackColor = true;
            this.adaugaCarte.Click += new System.EventHandler(this.buttonAdaugaCarte_click);
            // 
            // Deconectare
            // 
            this.Deconectare.Location = new System.Drawing.Point(1049, 471);
            this.Deconectare.Name = "Deconectare";
            this.Deconectare.Size = new System.Drawing.Size(142, 51);
            this.Deconectare.TabIndex = 8;
            this.Deconectare.Text = "Deconectare";
            this.Deconectare.UseVisualStyleBackColor = true;
            this.Deconectare.Click += new System.EventHandler(this.buttonDeconectare_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 16.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(338, 47);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(185, 32);
            this.label1.TabIndex = 9;
            this.label1.Text = "Bine ai venit, ";
            // 
            // buttonAcceptaImprumut
            // 
            this.buttonAcceptaImprumut.Location = new System.Drawing.Point(1049, 355);
            this.buttonAcceptaImprumut.Name = "buttonAcceptaImprumut";
            this.buttonAcceptaImprumut.Size = new System.Drawing.Size(142, 51);
            this.buttonAcceptaImprumut.TabIndex = 10;
            this.buttonAcceptaImprumut.Text = "Acceptă Imprumut";
            this.buttonAcceptaImprumut.UseVisualStyleBackColor = true;
            this.buttonAcceptaImprumut.Click += new System.EventHandler(this.buttonAcceptaImprumut_Click);
            // 
            // BibliotecarForms
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1232, 553);
            this.Controls.Add(this.buttonAcceptaImprumut);
            this.Controls.Add(this.label1);
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
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button Modifica;
        private System.Windows.Forms.Button Sterge;
        private System.Windows.Forms.ListBox listBoxBibliotecarForm;
        private System.Windows.Forms.Button Carti;
        private System.Windows.Forms.Button Imprumuturi;
        private System.Windows.Forms.Button adaugaCarte;
        private System.Windows.Forms.Button Deconectare;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button buttonAcceptaImprumut;
    }
}