using System;
using System.Data;
using System.Drawing;
using System.Drawing.Printing;
using System.Windows.Forms;
using Lev_Documents;
using Npgsql;

namespace Lev_Documents
{
    public partial class DocumentsForm : Form
    {
        private string loggedInUser;
        private string contractTemplatePath = "Contract.txt";
        private PostgresConnector postgresConnector;

        public DocumentsForm(string loggedInUser)
        {
            InitializeComponent();
            this.loggedInUser = loggedInUser;
            labelLoggedInUser.Text = $"Logged in as: {loggedInUser}";
            postgresConnector = new PostgresConnector();

            FillComboBoxPhysPer();
            FillComboBoxCource();

            comboBoxPhysPer.SelectedIndexChanged += comboBoxPhysPer_SelectedIndexChanged;
            comboBoxCourse.SelectedIndexChanged += comboBoxCourse_SelectedIndexChanged;
        }

        private void FillComboBoxPhysPer()
        {
            try
            {
                postgresConnector.openConnection();

                string query = "SELECT surname FROM listeners";
                NpgsqlDataAdapter adapter = new NpgsqlDataAdapter(query, postgresConnector.getConnection());
                DataTable dataTable = new DataTable();
                adapter.Fill(dataTable);

                foreach (DataRow row in dataTable.Rows)
                {
                    comboBoxPhysPer.Items.Add(row["surname"].ToString());
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error filling comboBoxPhysPer: " + ex.Message);
            }
            finally
            {
                postgresConnector.closeConnection();
            }
        }

        private void FillComboBoxCource()
        {
            try
            {
                postgresConnector.openConnection();

                string query = "SELECT name FROM cources";
                NpgsqlDataAdapter adapter = new NpgsqlDataAdapter(query, postgresConnector.getConnection());
                DataTable dataTable = new DataTable();
                adapter.Fill(dataTable);

                foreach (DataRow row in dataTable.Rows)
                {
                    comboBoxCourse.Items.Add(row["name"].ToString());
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error filling comboBoxCource: " + ex.Message);
            }
            finally
            {
                postgresConnector.closeConnection();
            }
        }

        private void comboBoxPhysPer_SelectedIndexChanged(object sender, EventArgs e)
        {
            string selectedPerson = comboBoxPhysPer.SelectedItem?.ToString();

            if (!string.IsNullOrEmpty(selectedPerson))
            {
                DataTable dataTable = GetPersonData(selectedPerson);

                if (dataTable != null && dataTable.Rows.Count > 0)
                {
                    DataRow row = dataTable.Rows[0];
                    string contractText = richTextBoxContract.Text;

                    contractText = contractText.Replace("Петров Алексей Анатольевич", $"{row["surname"]} {row["name"]} {row["patronymic"]}");
                    contractText = contractText.Replace("04.05.1980", row["date_of_birth"].ToString());
                    contractText = contractText.Replace("Тюменская область, город Тюмень, улица Бодрова, дом 336, квартира 743", row["place_of_residence"].ToString());
                    contractText = contractText.Replace("ХХХХ", row["passport_serial_number"].ToString());
                    contractText = contractText.Replace("+7 (907) 777-77-77", row["telephone_number"].ToString());

                    richTextBoxContract.Text = contractText;
                }
            }
        }

        private void comboBoxCourse_SelectedIndexChanged(object sender, EventArgs e)
        {
            string selectedCource = comboBoxCourse.SelectedItem?.ToString();

            if (!string.IsNullOrEmpty(selectedCource))
            {
                DataTable dataTable = GetCourceData(selectedCource);

                if (dataTable != null && dataTable.Rows.Count > 0)
                {
                    DataRow row = dataTable.Rows[0];
                    string contractText = richTextBoxContract.Text;
                    contractText = contractText.Replace("обучающий курс по музыкальному маркетингу", $"обучающий курс {row["number"]} по {row["name"]}");
                    contractText = contractText.Replace("курс лекций в режиме online, связанных с заявленной тематикой", $"курс лекций в режиме {row["type"]}, связанных с заявленной тематикой");

                    richTextBoxContract.Text = contractText;
                }
            }
        }

        private DataTable GetPersonData(string surname)
        {
            try
            {
                postgresConnector.openConnection();

                string query = $"SELECT * FROM listeners WHERE surname = '{surname}'";

                NpgsqlDataAdapter adapter = new NpgsqlDataAdapter(query, postgresConnector.getConnection());

                DataTable dataTable = new DataTable();
                adapter.Fill(dataTable);

                return dataTable;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error fetching person data from the database: " + ex.Message);
                return null;
            }
            finally
            {
                postgresConnector.closeConnection();
            }
        }

        private DataTable GetCourceData(string courceName)
        {
            try
            {
                postgresConnector.openConnection();

                string query = $"SELECT * FROM cources WHERE name = '{courceName}'";

                NpgsqlDataAdapter adapter = new NpgsqlDataAdapter(query, postgresConnector.getConnection());

                DataTable dataTable = new DataTable();
                adapter.Fill(dataTable);

                return dataTable;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error fetching cource data from the database: " + ex.Message);
                return null;
            }
            finally
            {
                postgresConnector.closeConnection();
            }
        }

        private void buttonAdd_Click(object sender, EventArgs e)
        {
            try
            {
                string contractText = System.IO.File.ReadAllText(contractTemplatePath);
                richTextBoxContract.Clear();
                richTextBoxContract.AppendText(contractText);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Ошибка при загрузке шаблона договора: " + ex.Message);
            }
        }

        private void buttonClean_Click(object sender, EventArgs e)
        {
            richTextBoxContract.Clear();
        }

        private void buttonPrint_Click(object sender, EventArgs e)
        {
            PrintDocument printDocument = new PrintDocument();
            PrintDialog printDialog = new PrintDialog();

            printDialog.Document = printDocument;

            printDocument.PrintPage += new PrintPageEventHandler(PrintDocument_PrintPage);

            DialogResult result = printDialog.ShowDialog();

            if (result == DialogResult.OK)
            {
                try
                {
                    printDocument.Print();
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Ошибка при печати: " + ex.Message);
                }
            }
        }

        private void PrintDocument_PrintPage(object sender, PrintPageEventArgs e)
        {
            string textToPrint = richTextBoxContract.Text;

            Font printFont = new Font("Times New Roman", 14);

            float yPos = 0;
            int count = 0;
            float leftMargin = e.MarginBounds.Left;
            float topMargin = e.MarginBounds.Top;

            e.Graphics.DrawString(textToPrint, printFont, Brushes.Black, leftMargin, yPos, new StringFormat());

            count++;

            if (count < 1)
                e.HasMorePages = true;
            else
                e.HasMorePages = false;
        }

        private void buttonSave_Click(object sender, EventArgs e)
        {
            SaveFileDialog saveFileDialog = new SaveFileDialog();
            saveFileDialog.Filter = "Text Documents|*.txt";

            if (saveFileDialog.ShowDialog() == DialogResult.OK)
            {
                string filePath = saveFileDialog.FileName;

                try
                {
                    System.IO.File.WriteAllText(filePath, richTextBoxContract.Text);
                    MessageBox.Show("Содержимое сохранено успешно.");
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Ошибка при сохранении файла: " + ex.Message);
                }
            }
        }

        private void DocumentsForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            Application.Exit();
        }
    }
}