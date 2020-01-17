using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.OleDb;
using System.Security.Cryptography;
using System.Data.SqlClient;

namespace WindowsFormsApplication2
{
    

    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
    public static class DBOperator
        {
            private const string CONNECT_STRING = "Data Source=Slava\\1111;Initial Catalog=TDB;Integrated Security=True";
            public static bool IsUserExists(string name, string password)
            {
                string selectCmd = string.Format("SELECT * FROM Qwerty WHERE login='{0}' AND Pass='{1}'",
                                                 name, password);
                using (SqlConnection cnn = new SqlConnection(CONNECT_STRING))
                {
                    cnn.Open();
                    using (SqlCommand cmd = new SqlCommand(selectCmd, cnn))
                    {
                        using (SqlDataReader reader = cmd.ExecuteReader())
                        {
                            return reader.HasRows;
                        }
                    }
                }
            }
        }
        public string GetMD5(string text)
        {
            MD5CryptoServiceProvider md5 = new MD5CryptoServiceProvider();
            md5.ComputeHash(ASCIIEncoding.ASCII.GetBytes(text));
            byte[] result = md5.Hash;
            StringBuilder str = new StringBuilder();
            for (int i = 0; i < result.Length; i++)
            {
                str.Append(result[i].ToString("x2"));
            }
            return str.ToString();
        }
        private void button1_Click(object sender, EventArgs e)
        {

            if (DBOperator.IsUserExists(textBox1.Text, GetMD5(textBox2.Text)))
            {
                new System.Threading.Thread(() => { Application.Run(new Form2()); }).Start();
                this.Close();
            }
            else
            {
                MessageBox.Show("Неверный логин или пароль!", "логин неправильный");
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
    }
}
