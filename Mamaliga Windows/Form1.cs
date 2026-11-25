using System;
using System.Windows.Forms;
using MySqlConnector;

namespace Mamaliga_Windows
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void btnLogin_Click(object sender, EventArgs e)
        {
            try
            {
                string? connectionString = Environment.GetEnvironmentVariable("ONLINE_STORE_CONNECTION");
                if (string.IsNullOrWhiteSpace(connectionString))
                {
                    MessageBox.Show("Укажите строку подключения в переменной ONLINE_STORE_CONNECTION.");
                    return;
                }

                using (var CON = new MySqlConnection(connectionString))
                {
                    CON.Open();

                    var cmd = new MySqlCommand("SELECT COUNT(*) FROM tbl_users WHERE Login=@I AND Password=@p", CON);

                    cmd.Parameters.AddWithValue("@I", txtLogin.Text);
                    cmd.Parameters.AddWithValue("@p", txtPassword.Text);

                    if (Convert.ToInt32(cmd.ExecuteScalar()) > 0)
                        MessageBox.Show("Вход выполнен!");
                    else
                        MessageBox.Show("Неверный логин или пароль!");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Ошибка: " + ex.Message);
            }
        }
    }
}
