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
        internal Classes.Connect con;
        public main()
        {
            InitializeComponent();
        }

        private void btnConnect_Click(object sender, EventArgs e)
        {
            try
            {
                tssStatus.Text = "Connecting...";
                Console.WriteLine(txtDB.Text);
                this.con = new Classes.Connect(db: txtDB.Text, passwd: txtPW.Text);
                con.Refresh();
                tssStatus.Text = "Connected.";
            }
            catch (Exception ex)
            {
                tssStatus.Text = ex.Message;
            }
        }

        private void addControls()
        {
            groupBox1.Controls.Add(new AutoCompleteEditingControl());

        }

        private void btnExec_Click(object sender, EventArgs e)
        {
            try
            {
                string sql;
                if (rtbSQL.SelectionLength > 0)
                {
                    sql = rtbSQL.SelectedText;
                }
                else
                {
                    sql = rtbSQL.Text;
                }
                this.con.Refresh();
                DataTable tbl = this.con.Query(sql);
                dgvResult.DataSource = tbl;
            }
            catch(Exception ex)
            {
                tssStatus.Text = ex.Message;
            }
        }



    }
}
