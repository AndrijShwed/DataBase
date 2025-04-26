using Microsoft.Office.Interop.Word;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Windows.Forms;

namespace DataBase
{
    public partial class WillApplicationRegistr : Form
    {
        private int _id = 0;
        private RowOfData data_1 = new RowOfData();
        private RowOfData data = new RowOfData();
        public WillApplicationRegistr(int id)
        {
            InitializeComponent();
            _id = id;
            data = data_1.GetValueFromDB(id);

            textBoxFullName.Text = data.lastname.ToString() + " " + data.name.ToString() + " " + data.surname.ToString();
            textBoxIdKod.Text = data.id_kod.ToString();
            textBoxDateOfBirth.Text = data.date_of_birth.ToString();
            textBoxVillage.Text = data.village.ToString();
            textBoxStreet.Text = data.street.ToString();
            textBoxHouseNumb.Text = data.numb_of_house.ToString();
        }

        private void rjButton1_Click(object sender, EventArgs e)
        {
           
            if (textBoxFullName.Text =="" || textBoxIdKod.Text == "" || textBoxDateOfBirth.Text =="" ||
                textBoxVillage.Text == "" || textBoxStreet.Text == "" || textBoxHouseNumb.Text == "" ||
                textBoxBirthPlace.Text == "" || textBoxPostId.Text == "" || textBoxWillNumber.Text == "" ||
                textBoxDateOfCreate.Text == "")
            {
                MessageBox.Show("Не всі поля заповнено");
                return;
            }
            else
            {
                Microsoft.Office.Interop.Word.Application wordApp = null;
                Document document = null;

                try
                {
                    wordApp = new Microsoft.Office.Interop.Word.Application();
                    string currentDirectory = Directory.GetCurrentDirectory();
                    string temlatePath = Path.Combine(currentDirectory, "DocTemplates", "Шаблон_заява_заповіт.docx");
                    document = wordApp.Documents.Open(temlatePath);
                    string i_1 = null;
                    string i_2 = null;
                    string i_3 = null;
                    string i_4 = null;
                    string i_5 = null;
                    string i_6 = null;
                    string i_7 = null;
                    string i_8 = null;
                    string i_9 = null;
                    string i_0 = null;

                    string idKod = textBoxIdKod.Text.ToString().Trim();
                    if (idKod.Length < 10)
                    {
                        MessageBox.Show("Неправильно введений ідентифікаційний код");
                        return;
                    }
                    else
                    {
                        i_1 = idKod.Substring(0, 1);
                        i_2 = idKod.Substring(1, 1);
                        i_1 = idKod.Substring(2, 1);
                        i_1 = idKod.Substring(3, 1);
                        i_1 = idKod.Substring(4, 1);
                        i_1 = idKod.Substring(5, 1);
                        i_1 = idKod.Substring(6, 1);
                        i_1 = idKod.Substring(7, 1);
                        i_1 = idKod.Substring(8, 1);
                        i_1 = idKod.Substring(9, 1);
                    }
                    string fullname = textBoxFullName.Text;
                    string birthDate = textBoxDateOfBirth.Text.ToString().Trim();
                    string dayBirth = birthDate.Substring(0, 2);
                    string mBirth = birthDate.Substring(3, 2);
                    string yearBirth = birthDate.Substring(6, 4);
                    string placeOfBitrh = textBoxBirthPlace.Text;
                    string postId = textBoxPostId.Text;
                    string village = textBoxVillage.Text;
                    string street = textBoxStreet.Text;
                    string house = textBoxHouseNumb.Text;
                    string registrNumber = textBoxWillNumber.Text;
                    string p1 = null;
                    string p2 = null;
                    string p3 = null;
                    string p4 = null;
                    string p5 = null;

                    string posId = textBoxPostId.Text.ToString().Trim();
                    if (posId.Length < 5)
                    {
                        MessageBox.Show("Неправильно введено поштовий індекс");
                        return;
                    }
                    else
                    {
                        p1 = postId.Substring(0, 1);
                        p2 = postId.Substring(1, 1);
                        p3 = postId.Substring(2, 1);
                        p4 = postId.Substring(3, 1);
                        p5 = postId.Substring(4, 1);
                    }

                    string dateRegistr = textBoxDateOfCreate.Text.ToString().Trim();
                    string dayRegistr = dateRegistr.Substring(0, 2);
                    string monthRegistr = dateRegistr.Substring(3, 2);
                    string yearRegistr = dateRegistr.Substring(6, 4);

                    //Заміна слова у всьому документі
                    Dictionary<string, string> replacements = new Dictionary<string, string>
                    {
                        { "i-1", i_1 },
                        { "i-2", i_2 },
                        { "i-3", i_3 },
                        { "i-4", i_4 },
                        { "i-5", i_5 },
                        { "i-6", i_6 },
                        { "i-7", i_7 },
                        { "i-8", i_8 },
                        { "i-9", i_9 },
                        { "i-0", i_0 },
                        { "fullname", fullname },
                        { "dB", dayBirth },
                        { "mB", mBirth },
                        { "yB", yearBirth },
                        { "Village", village },
                        { "Street", street },
                        { "house", house },
                        { "place", placeOfBitrh },
                        { "a", p1 },
                        { "c", p2 },
                        { "h", p3 },
                        { "f", p4 },
                        { "j", p5 },
                        { "reg", registrNumber },
                        { "dR", dayRegistr },
                        { "mR", monthRegistr },
                        { "yR", yearRegistr }
                    };

                    foreach (var replacement in replacements)
                    {
                        // Визначаємо об'єкт для пошуку
                        Find find = wordApp.Selection.Find;

                        // Налаштовуємо параметри пошуку
                        find.ClearFormatting();
                        find.Text = replacement.Key; // Текст для пошуку
                        find.Replacement.ClearFormatting();
                        find.Replacement.Text = replacement.Value; // Текст для заміни

                        // Виконуємо заміну у всьому документі
                        find.Execute(Replace: WdReplace.wdReplaceAll);
                    }

                    // Визначення шляху до тимчасової папки
                    string tempFolderPath = @"C:\Users\berez\OneDrive\Заяви заповіти\Заяви заповіти\" + fullname + @"\";
                    string tempFilePath = Path.Combine(tempFolderPath, fullname + ".docx");

                    // Створення папки, якщо її немає
                    if (!Directory.Exists(tempFolderPath))
                    {
                        Directory.CreateDirectory(tempFolderPath);
                    }

                    // Зберігаємо зміни в тимчасовий файл
                    document.SaveAs(tempFilePath);
                    wordApp.ActiveDocument.Close();
                    wordApp.Quit();

                    Process.Start(new ProcessStartInfo
                    {
                        FileName = tempFilePath,
                        UseShellExecute = true
                    });

                    MessageBox.Show("Заяву на реєстрацію заповіту на " + fullname + " збережено на дискуC:Users/berez/OneDrive/Заяви заповіти/Заяви заповіти/" + fullname + @"\");
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Сталася помилка: {ex.Message}", "Помилка");
                }
                finally
                {
                    // FINALLY блокуємо — закриваємо об'єкти, якщо вони створені
                    if (document != null)
                    {
                        try
                        {
                            document.Close(false);
                        }
                        catch { }
                    }

                    if (wordApp != null)
                    {
                        try
                        {
                            wordApp.Quit();
                        }
                        catch { }
                    }
                }
            }
        }

        private void textBoxIdKod_KeyPress(object sender, KeyPressEventArgs e)
        {
            // Перевіряємо, чи є введений символ цифрою
            if (!char.IsDigit(e.KeyChar) && e.KeyChar != (char)8) // 8 - код для Backspace
            {
                e.Handled = true; // Блокуємо введення, якщо символ не є цифрою
            }
        }

        private void textBoxIdKod_TextChanged(object sender, EventArgs e)
        {
            // Перевірка, чи довжина тексту більше 10
            if (textBoxIdKod.Text.Length > 10)
            {
                textBoxIdKod.ForeColor = Color.Red;
                textBoxIdKod.Text = textBoxIdKod.Text.Substring(0, 10); // Обрізаємо текст до 10 символів
                textBoxIdKod.SelectionStart = textBoxIdKod.Text.Length; // Переміщаємо курсор в кінець тексту
            }
            else if (textBoxIdKod.Text.Length == 10)
            {
                // Якщо довжина тексту дорівнює 10, блокуємо можливість введення
                textBoxIdKod.ForeColor = Color.Black;
            }
            else
            {
                // Відновлюємо можливість введення, якщо довжина тексту менша за 10
                textBoxIdKod.ForeColor = Color.Red;
            }
        }

        private void textBoxPostId_TextChanged(object sender, EventArgs e)
        {
            // Перевірка, чи довжина тексту більше 5
            if (textBoxPostId.Text.Length > 5)
            {
                textBoxPostId.ForeColor = Color.Red;
                textBoxPostId.Text = textBoxPostId.Text.Substring(0, 5); // Обрізаємо текст до 5 символів
                textBoxPostId.SelectionStart = textBoxPostId.Text.Length; // Переміщаємо курсор в кінець тексту
            }
            else if (textBoxPostId.Text.Length == 5)
            {
                // Якщо довжина тексту дорівнює 5, змінюємо колір на чорний
                textBoxPostId.ForeColor = Color.Black;
            }
            else
            {
                textBoxPostId.ForeColor = Color.Red;
            }
        }

        private void textBoxPostId_KeyPress(object sender, KeyPressEventArgs e)
        {
            // Перевіряємо, чи є введений символ цифрою
            if (!char.IsDigit(e.KeyChar) && e.KeyChar != (char)8) // 8 - код для Backspace
            {
                e.Handled = true; // Блокуємо введення, якщо символ не є цифрою
            }
        }
    }
}
