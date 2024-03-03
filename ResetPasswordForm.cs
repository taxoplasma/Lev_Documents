using Npgsql;
using System;
using System.Text.RegularExpressions;
using System.Windows.Forms;

namespace Lev_Documents
{
    public partial class ResetPasswordForm : Form
    {
        private PostgresConnector bd = new PostgresConnector();
        private string login;

        public ResetPasswordForm(string userLogin)
        {
            InitializeComponent();
            login = userLogin;
        }

        public string Login
        {
            get { return login; }
        }

        private void buttonReset_Click(object sender, EventArgs e)
        {
            string newPassword = textBoxNewPassword.Text;

            if (!IsPasswordValid(newPassword))
            {
                MessageBox.Show("Пароль не удовлетворяет требованиям:\n- Должно быть не менее 5 букв,\n- Не менее 3 цифр,\n- И содержать один из символов: @#%)(.<");
                return;
            }

            if (textBoxNewPassword.Text != textBoxConfirmPassword.Text)
            {
                MessageBox.Show("Пароли не совпадают. Пожалуйста, повторите ввод.");
                return;
            }

            using (NpgsqlConnection connection = bd.getConnection())
            {
                connection.Open();

                using (NpgsqlCommand cmd_update = new NpgsqlCommand("UPDATE users SET password = @password WHERE login = @login", connection))
                {
                    cmd_update.Parameters.AddWithValue("@login", login);
                    cmd_update.Parameters.AddWithValue("@password", newPassword);
                    cmd_update.ExecuteNonQuery();
                }
            }
            MessageBox.Show($"Пароль для пользователя {login} был успешно обновлен.");

            DialogResult = DialogResult.OK;
            this.Close();
        }

        private bool IsPasswordValid(string password)
        {
            if (password.Length < 5)
                return false;

            int digitCount = Regex.Matches(password, @"\d").Count;
            if (digitCount < 3)
                return false;

            if (!Regex.IsMatch(password, @"[@#%)(.<]"))
                return false;

            return true;
        }
    }
}