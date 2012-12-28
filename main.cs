using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using SQLite.Designer.Editors;


namespace sqlite.cs
{
    public partial class main : Form
    {
        public main()
        {
            InitializeComponent();
            this.addControls();
        }

        private void btnConnect_Click(object sender, EventArgs e)
        {
            Console.WriteLine(txtDB.Text);
            Classes.Connect con = new Classes.Connect(db: txtDB.Text, passwd: txtPW.Text);
            Console.WriteLine(txtDB.Text);
            con.Refresh();
        }

        private void addControls()
        {
            groupBox1.Controls.Add(new AutoCompleteEditingControl());

        }

    }
}
