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
            this.listBox1 = new System.Windows.Forms.ListBox();
            this.Carti = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.Imprumuta = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // Wishlist
            // 
            this.Wishlist.Location = new System.Drawing.Point(696, 31);
            this.Wishlist.Name = "Wishlist";
            this.Wishlist.Size = new System.Drawing.Size(142, 51);
            this.Wishlist.TabIndex = 0;
            this.Wishlist.Text = "Wishlist";
            this.Wishlist.UseVisualStyleBackColor = true;
            // 
            // Deconectare
            // 
            this.Deconectare.Location = new System.Drawing.Point(696, 451);
            this.Deconectare.Name = "Deconectare";
            this.Deconectare.Size = new System.Drawing.Size(142, 51);
            this.Deconectare.TabIndex = 1;
            this.Deconectare.Text = "Deconectare";
            this.Deconectare.UseVisualStyleBackColor = true;
            this.Deconectare.Click += new System.EventHandler(this.Deconectare_Click);
            // 
            // AddToWishlist
            // 
            this.AddToWishlist.Location = new System.Drawing.Point(696, 102);
            this.AddToWishlist.Name = "AddToWishlist";
            this.AddToWishlist.Size = new System.Drawing.Size(142, 51);
            this.AddToWishlist.TabIndex = 2;
            this.AddToWishlist.Text = "Add to Wishlist";
            this.AddToWishlist.UseVisualStyleBackColor = true;
            this.AddToWishlist.Click += new System.EventHandler(this.AddtoWishlist_Click);
            // 
            // listBox1
            // 
            this.listBox1.FormattingEnabled = true;
            this.listBox1.ItemHeight = 16;
            this.listBox1.Location = new System.Drawing.Point(106, 102);
            this.listBox1.Name = "listBox1";
            this.listBox1.Size = new System.Drawing.Size(467, 372);
            this.listBox1.TabIndex = 3;
            // 
            // Carti
            // 
            this.Carti.Location = new System.Drawing.Point(696, 181);
            this.Carti.Name = "Carti";
            this.Carti.Size = new System.Drawing.Size(142, 51);
            this.Carti.TabIndex = 4;
            this.Carti.Text = "Carti";
            this.Carti.UseVisualStyleBackColor = true;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 16.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(174, 31);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(185, 32);
            this.label1.TabIndex = 5;
            this.label1.Text = "Bine ai venit, ";
            // 
            // Imprumuta
            // 
            this.Imprumuta.Location = new System.Drawing.Point(696, 267);
            this.Imprumuta.Name = "Imprumuta";
            this.Imprumuta.Size = new System.Drawing.Size(142, 51);
            this.Imprumuta.TabIndex = 6;
            this.Imprumuta.Text = "Imprumuta";
            this.Imprumuta.UseVisualStyleBackColor = true;
            this.Imprumuta.Click += new System.EventHandler(this.button1_Click);
            // 
            // UtilizatorForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(876, 533);
            this.Controls.Add(this.Imprumuta);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.Carti);
            this.Controls.Add(this.listBox1);
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
        private System.Windows.Forms.ListBox listBox1;
        private System.Windows.Forms.Button Carti;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button Imprumuta;
    }
}