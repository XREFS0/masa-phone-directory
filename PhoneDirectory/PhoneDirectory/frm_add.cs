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
    public partial class frm_add : Form
    {
        public frm_add()
        {
            InitializeComponent();
        }

        private void saveData()
        {
            MySqlConnection connection = new MySqlConnection("server=localhost;user=root;database=phonedirectory;port=3306;password=;");
            connection.Open();
            MySqlCommand cmd = new MySqlCommand();
            cmd.Connection = connection;
            cmd.CommandText = "INSERT INTO directory(ID ,Name,Nickname, PhoneNumber,MobileNumber, EmailAddress,HomeAddress,Company,Position,GroupName,Website,FacebookAccount,Remarks) VALUES(@ID ,@Name,@Nickname, @PhoneNumber,@MobileNumber, @EmailAddress,@HomeAddress,@Company,@Position,@GroupName,@Website,@FacebookAccount,@Remarks)";
            cmd.Parameters.AddWithValue("@ID", null);
            cmd.Parameters.AddWithValue("@Name", textBox1.Text);
            cmd.Parameters.AddWithValue("@Nickname", textBox2.Text);
            cmd.Parameters.AddWithValue("@PhoneNumber", textBox3.Text);
            cmd.Parameters.AddWithValue("@MobileNumber", textBox4.Text);
            cmd.Parameters.AddWithValue("@EmailAddress", textBox5.Text);
            cmd.Parameters.AddWithValue("@HomeAddress", textBox6.Text);
            cmd.Parameters.AddWithValue("@Company", textBox7.Text);
            cmd.Parameters.AddWithValue("@Position", textBox8.Text);
            cmd.Parameters.AddWithValue("@GroupName", textBox9.Text);
            cmd.Parameters.AddWithValue("@Website", textBox10.Text);
            cmd.Parameters.AddWithValue("@FacebookAccount", textBox11.Text);
            cmd.Parameters.AddWithValue("@Remarks", "");
            cmd.ExecuteNonQuery();
            if (connection != null)
                connection.Close();
            MessageBox.Show("Successfully saved to directory", " System Notification");
        }
        private void frm_add_Load(object sender, EventArgs e)
        {
            
        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                saveData();
            }
            catch (Exception er)
            {
                MessageBox.Show(er.Message);
            }
        }
    }
}
