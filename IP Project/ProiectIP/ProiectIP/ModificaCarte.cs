using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Security.Principal;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ProiectIP
{
    public partial class ModificaCarte : Form
    {
        public Book _selectedBook;
        public Account _account;
        public ModificaCarte(Account account, Book book)
        {
            _account = account;
            _selectedBook = book;
            InitializeComponent();
            label1.Text = label1.Text + _selectedBook._title;
        }

        private void Inapoi_Click(object sender, EventArgs e)
        {
            BibliotecarForms bibliotecarForms = new BibliotecarForms(_account);
            bibliotecarForms.Show();
            this.Hide();
        }
    }
}
