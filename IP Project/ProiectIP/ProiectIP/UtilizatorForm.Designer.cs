namespace ProiectIP
{
    partial class UtilizatorForm
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
            this.Wishlist = new System.Windows.Forms.Button();
            this.Deconectare = new System.Windows.Forms.Button();
            this.AddToWishlist = new System.Windows.Forms.Button();
            this.listBoxUtilizatorForm = new System.Windows.Forms.ListBox();
            this.Carti = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.Imprumuta = new System.Windows.Forms.Button();
            this.removeWishlist = new System.Windows.Forms.Button();
            this.showLoans = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // Wishlist
            // 
            this.Wishlist.Location = new System.Drawing.Point(1047, 31);
            this.Wishlist.Name = "Wishlist";
            this.Wishlist.Size = new System.Drawing.Size(142, 51);
            this.Wishlist.TabIndex = 0;
            this.Wishlist.Text = "Wishlist";
            this.Wishlist.UseVisualStyleBackColor = true;
            this.Wishlist.Click += new System.EventHandler(this.buttonShowWishlist_click);
            // 
            // Deconectare
            // 
            this.Deconectare.Location = new System.Drawing.Point(1047, 467);
            this.Deconectare.Name = "Deconectare";
            this.Deconectare.Size = new System.Drawing.Size(142, 51);
            this.Deconectare.TabIndex = 1;
            this.Deconectare.Text = "Deconectare";
            this.Deconectare.UseVisualStyleBackColor = true;
            this.Deconectare.Click += new System.EventHandler(this.buttonDeconectare_Click);
            // 
            // AddToWishlist
            // 
            this.AddToWishlist.Location = new System.Drawing.Point(1047, 88);
            this.AddToWishlist.Name = "AddToWishlist";
            this.AddToWishlist.Size = new System.Drawing.Size(142, 51);
            this.AddToWishlist.TabIndex = 2;
            this.AddToWishlist.Text = "Adaugă in Wishlist";
            this.AddToWishlist.UseVisualStyleBackColor = true;
            this.AddToWishlist.Click += new System.EventHandler(this.AddtoWishlist_Click);
            // 
            // listBoxUtilizatorForm
            // 
            this.listBoxUtilizatorForm.FormattingEnabled = true;
            this.listBoxUtilizatorForm.ItemHeight = 16;
            this.listBoxUtilizatorForm.Location = new System.Drawing.Point(85, 102);
            this.listBoxUtilizatorForm.Name = "listBoxUtilizatorForm";
            this.listBoxUtilizatorForm.Size = new System.Drawing.Size(886, 372);
            this.listBoxUtilizatorForm.TabIndex = 3;
            // 
            // Carti
            // 
            this.Carti.Location = new System.Drawing.Point(1047, 202);
            this.Carti.Name = "Carti";
            this.Carti.Size = new System.Drawing.Size(142, 51);
            this.Carti.TabIndex = 4;
            this.Carti.Text = "Cărți";
            this.Carti.UseVisualStyleBackColor = true;
            this.Carti.Click += new System.EventHandler(this.buttonShowBooks_click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 16.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(385, 31);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(185, 32);
            this.label1.TabIndex = 5;
            this.label1.Text = "Bine ai venit, ";
            // 
            // Imprumuta
            // 
            this.Imprumuta.Location = new System.Drawing.Point(1047, 316);
            this.Imprumuta.Name = "Imprumuta";
            this.Imprumuta.Size = new System.Drawing.Size(142, 51);
            this.Imprumuta.TabIndex = 6;
            this.Imprumuta.Text = "Împrumută";
            this.Imprumuta.UseVisualStyleBackColor = true;
            this.Imprumuta.Click += new System.EventHandler(this.buttonImprumuta_Click);
            // 
            // removeWishlist
            // 
            this.removeWishlist.Location = new System.Drawing.Point(1047, 145);
            this.removeWishlist.Name = "removeWishlist";
            this.removeWishlist.Size = new System.Drawing.Size(142, 51);
            this.removeWishlist.TabIndex = 7;
            this.removeWishlist.Text = "Șterge din Wishlist";
            this.removeWishlist.UseVisualStyleBackColor = true;
            this.removeWishlist.Click += new System.EventHandler(this.removeWishlist_Click);
            // 
            // showLoans
            // 
            this.showLoans.Location = new System.Drawing.Point(1047, 259);
            this.showLoans.Name = "showLoans";
            this.showLoans.Size = new System.Drawing.Size(142, 51);
            this.showLoans.TabIndex = 8;
            this.showLoans.Text = "Arată Împrumuturile";
            this.showLoans.UseVisualStyleBackColor = true;
            this.showLoans.Click += new System.EventHandler(this.showLoans_Click);
            // 
            // UtilizatorForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1232, 553);
            this.Controls.Add(this.showLoans);
            this.Controls.Add(this.removeWishlist);
            this.Controls.Add(this.Imprumuta);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.Carti);
            this.Controls.Add(this.listBoxUtilizatorForm);
            this.Controls.Add(this.AddToWishlist);
            this.Controls.Add(this.Deconectare);
            this.Controls.Add(this.Wishlist);
            this.Name = "UtilizatorForm";
            this.Text = "UtizilatorForm";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button Wishlist;
        private System.Windows.Forms.Button Deconectare;
        private System.Windows.Forms.Button AddToWishlist;
        private System.Windows.Forms.ListBox listBoxUtilizatorForm;
        private System.Windows.Forms.Button Carti;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button Imprumuta;
        private System.Windows.Forms.Button removeWishlist;
        private System.Windows.Forms.Button showLoans;
    }
}