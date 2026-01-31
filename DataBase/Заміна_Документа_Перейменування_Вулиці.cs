using MySqlConnector;
using System;
using System.IO;
using System.Windows.Forms;

namespace DataBase
{
    public partial class Заміна_Документа_Перейменування_Вулиці : Form
    {
        private int _id;
        public Заміна_Документа_Перейменування_Вулиці(int id)
        {
            InitializeComponent();
            _id = id;
        }

        private void головнаToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Головна form = new Головна();
            Program.OpenForm(this, form);
        }

        private void повернутисьToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ПочатокРоботи form = new ПочатокРоботи();
            Program.OpenForm(this, form);
        }

        private void rjButtonChooseNewDoc_Click(object sender, EventArgs e)
        {
            using (OpenFileDialog openFileDialog = new OpenFileDialog())
            {
                openFileDialog.InitialDirectory = "C:\\";
                openFileDialog.Filter = "Документи (Word, PDF, скани)|*.doc;*.docx;*.pdf;*.jpg;*.jpeg;*.png;*.tif;*.tiff";
                openFileDialog.RestoreDirectory = true;

                if (openFileDialog.ShowDialog() == DialogResult.OK)
                {
                    textBoxNewDoc.Text = openFileDialog.FileName;
                }
            }
        }

        private void rjButton1_Click(object sender, EventArgs e)
        {
            string filePath = textBoxNewDoc.Text;

            if (string.IsNullOrEmpty(filePath) || !File.Exists(filePath))
            {
                MessageBox.Show("Оберіть файл для завантаження!");
                return;
            }
            else
            {
                ChangeDoc(filePath, _id);
            }

            ПочатокРоботи form = new ПочатокРоботи();
            Program.OpenForm(this, form);
        }
         
        public void ChangeDoc(string filePath, int id)
        {
            ConnectionClass con = new ConnectionClass();
            con.openConnection();

            var conn = con.getConnection();
            MySqlTransaction tran = null;
            // Зчитування файлу у байти
            byte[] fileBytes = File.ReadAllBytes(filePath);
            string fileName = Path.GetFileName(filePath);

            try
            {
                tran = conn.BeginTransaction();

                using (var cmd = new MySqlCommand(@"
                    UPDATE villagestreet
                    SET fileData = @fileData
                    WHERE id = @Id",
                                conn, tran))
                {
                    cmd.Parameters.Add("@fileData", MySqlDbType.Blob).Value = fileBytes;
                    cmd.Parameters.AddWithValue("@Id", id);
                    cmd.ExecuteNonQuery();
                    tran.Commit();

                    MessageBox.Show("Документ замінено успішно !");
                    
                }
            }
            catch(Exception ex) 
            {
                tran.Rollback();
                MessageBox.Show("Помилка: " + ex.Message);
                MessageBox.Show("Помилка роботи з базою даних !");
            }
            finally
            {
                con.closeConnection();
            }
        }
    }
}
