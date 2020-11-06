using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml;

namespace PhoneBook
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        

        private void button4_Click(object sender, EventArgs e)
        {
            try
            {
                panel1.Enabled  = true;
                data.PhoneBook .AddPhoneBookRow (data.PhoneBook .NewPhoneBookRow ());
                phoneBookBindingSource .MoveLast ();
                txtNumber .Focus ();
            }
            catch (Exception  ex)
            {
                MessageBox.Show(ex.Message , "message", MessageBoxButtons.OK , MessageBoxIcon.Error );
                data.PhoneBook .RejectChanges();
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            panel1.Enabled = true;
            txtNumber.Focus ();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            phoneBookBindingSource .ResetBindings(false);
            panel1.Enabled= false;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {


                phoneBookBindingSource.EndEdit();
                data.PhoneBook.AcceptChanges();
                data.PhoneBook.WriteXml(string.Format("{0}//data.dat", Application.StartupPath));
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Message", MessageBoxButtons.OK, MessageBoxIcon.Error);
                data.PhoneBook.RejectChanges();
            }
        }



        static DataSet1 db;
        protected static DataSet1 data
        {
            get
            {
                if (db == null)
                    db = new DataSet1();
                return db;
            }
        }
        private void Form1_Load(object sender, EventArgs e)
        {
            string fileName = string.Format("{0}//data.dat", Application.StartupPath);
            if (File.Exists(fileName))
            {
                data.PhoneBook.ReadXml(fileName);
                phoneBookBindingSource.DataSource = data.PhoneBook ;
                panel1.Enabled = false;

            }

        }

        private void dataGridView1_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Delete)
            {
                if (MessageBox.Show("Are you sure want to delete this record?", "Message", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                    phoneBookBindingSource.RemoveCurrent();
            }
        }

        private void txt_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)13)//Enter key
            {
                if (!string.IsNullOrEmpty(txtsearch .Text))
                {
                    //you can use linq to query data
                    var query = from o in data.PhoneBook 
                                where o.Number == txtsearch  .Text || o.Name.ToLowerInvariant().Contains(txtsearch.Text.ToLowerInvariant())
                                select o;
                    dataGridView1.DataSource = query.ToList();
                }
                else
                    dataGridView1.DataSource = phoneBookBindingSource;
            }
        }
    }
}
