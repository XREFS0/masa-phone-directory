using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.IO;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Data.SqlClient;
using System.Data.Sql;
using System.Data.SqlTypes;
using MySql.Data.MySqlClient;
using MySql.Data.Entity;
using MySql.Data.Types;
using MySql.Data;

namespace PhoneDirectory
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        static string name;
        private void Form1_Load(object sender, EventArgs e)
        {
            loadData();
        }
        private void loadData()
        {
            using (MySqlConnection conn = new MySqlConnection("server=localhost;user=root;database=phonedirectory;port=3306;password=;"))
            {
                using (MySqlDataAdapter adapter = new MySqlDataAdapter("SELECT Name,Nickname,PhoneNumber,MobileNumber,EmailAddress,HomeAddress,Company,Position,GroupName,Website,FacebookAccount From directory Where Remarks=''", conn))
                {
                    DataSet ds = new DataSet();
                    adapter.Fill(ds);
                    dataGridView1.DataSource = ds.Tables[0];
                }
            }
        }

        private void loadData(string searcher, string field)
        {
             name = searcher;
            if (comboBox1.Text == "")
            {
                try
                {
                    using (MySqlConnection conn = new MySqlConnection("server=localhost;user=root;database=phonedirectory;port=3306;password=;"))
                    {
                        using (MySqlDataAdapter adapter = new MySqlDataAdapter("SELECT Name,Nickname,PhoneNumber,MobileNumber,EmailAddress,HomeAddress,Company,Position,GroupName,Website,FacebookAccount  From directory WHERE Name LIKE '%" + name +
                            "%' or Nickname LIKE '%"+name+
                            "%' or PhoneNumber LIKE '%" + name +
                            "%' or MobileNumber LIKE '%" + name +
                            "%' or EmailAddress LIKE '%" + name +
                            "%' or HomeAddress LIKE '%" + name +
                            "%' or Company LIKE '%" + name +
                            "%' or Position LIKE '%" + name +
                            "%' or GroupName LIKE '%" + name +
                            "%' or Website LIKE '%" + name +
                            "%' or FacebookAccount LIKE '%" + name + "%'", conn))
                        {
                            DataSet ds = new DataSet();
                            adapter.Fill(ds);
                            dataGridView1.DataSource = ds.Tables[0];

                            
                        }
                    }
                }
                catch (Exception er)
                {
                }
            }
            else
            {
                try
                {
                    using (MySqlConnection conn = new MySqlConnection("server=localhost;user=root;database=phonedirectory;port=3306;password=;"))
                    {
                        using (MySqlDataAdapter adapter = new MySqlDataAdapter("SELECT Name,Nickname,PhoneNumber,MobileNumber,EmailAddress,HomeAddress,Company,Position,GroupName,Website,FacebookAccount  From directory WHERE " + field + " LIKE '%" + textBox1.Text + "%'", conn))
                        {
                            DataSet ds = new DataSet();
                            adapter.Fill(ds);
                            dataGridView1.DataSource = ds.Tables[0];
                        }
                    }
                }
                catch (Exception er)
                {
                }
            }

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            loadData();
            textBox1.Text= "";
            comboBox1.Text = "";
        }

        private void toolStripMenuItem1_Click(object sender, EventArgs e)
        {
            frm_dev a = new frm_dev();
            a.ShowDialog();
        }

        private void textBox1_TextChanged_1(object sender, EventArgs e)
        {
            loadData(textBox1.Text, comboBox1.Text);
        }

        static string Name1;
        static string Nickname;
        static string PhoneNumber;
        static string MobileNumber;
        static string EmailAddress;
        static string HomeAddress;
        static string Company;
        static string Position;
        static string GroupName;
        static string Website;
        static string FacebookAccount;

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                int index = e.RowIndex;
                DataGridViewRow selectedRow = dataGridView1.Rows[index];
                Name1 = selectedRow.Cells[0].Value.ToString();
                Nickname = selectedRow.Cells[1].Value.ToString();
                PhoneNumber = selectedRow.Cells[2].Value.ToString();
                MobileNumber = selectedRow.Cells[3].Value.ToString();
                EmailAddress = selectedRow.Cells[4].Value.ToString();
                HomeAddress = selectedRow.Cells[5].Value.ToString();
                Company = selectedRow.Cells[6].Value.ToString();
                Position = selectedRow.Cells[7].Value.ToString();
                GroupName = selectedRow.Cells[8].Value.ToString();
                Website = selectedRow.Cells[9].Value.ToString();
                FacebookAccount = selectedRow.Cells[10].Value.ToString();

                frm_prev a = new frm_prev(Name1,Nickname,PhoneNumber,MobileNumber,EmailAddress,HomeAddress,Company,Position,GroupName,Website,FacebookAccount);
                a.ShowDialog();
                loadData();

            }
            catch (Exception er)
            { 
            }
        }

        private void toolStripMenuItem2_Click(object sender, EventArgs e)
        {
             
        }

        private void toolStripMenuItem3_Click(object sender, EventArgs e)
        {
            frm_add a = new frm_add();
            a.ShowDialog();
            loadData();
        }

        private void toolStripMenuItem1_Click_1(object sender, EventArgs e)
        {
            frm_dev a = new frm_dev();
            a.ShowDialog();
        }

        private void dataGridView1_CellValidated(object sender, DataGridViewCellEventArgs e)
        {
            
        }

        private void dataGridView1_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
           
        }
    }
}
