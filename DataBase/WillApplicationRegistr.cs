using Microsoft.Office.Interop.Word;
using System;
using System.Collections.Generic;
using System.Diagnostics;
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
            if (textBoxFullName.Text =="" && textBoxIdKod.Text == "" && textBoxDateOfBirth.Text =="" &&
                textBoxVillage.Text == "" && textBoxStreet.Text == "" && textBoxHouseNumb.Text == "" &&
                textBoxBirthPlace.Text == "" && textBoxPostId.Text == "" && textBoxWillNumber.Text == "" &&
                textBoxDateOfCreate.Text == "")
            {
                MessageBox.Show("Не всі поля заповнено");
                return;
            }
            else
            {
                string idKod = textBoxIdKod.Text.ToString().Trim();
                string i_1 = idKod.Substring(0, 1);
                string i_2 = idKod.Substring(1, 1);
                string i_3 = idKod.Substring(2, 1);
                string i_4 = idKod.Substring(3, 1);
                string i_5 = idKod.Substring(4, 1);
                string i_6 = idKod.Substring(5, 1);
                string i_7 = idKod.Substring(6, 1);
                string i_8 = idKod.Substring(7, 1);
                string i_9 = idKod.Substring(8, 1);
                string i_0 = idKod.Substring(9, 1);
                string fullname = textBoxFullName.Text;
                string birthDate = textBoxDateOfBirth.Text.ToString().Trim();
                string dayB = birthDate.Substring(0, 2);
                string mB = birthDate.Substring(3, 2);
                string yearB = birthDate.Substring(6, 4);
                string placeOfBitrh = textBoxBirthPlace.Text;
                string postId = textBoxPostId.Text;
                string village = textBoxVillage.Text;
                string street = textBoxStreet.Text;
                string house = textBoxHouseNumb.Text;
                string registrNumber = textBoxWillNumber.Text;
                string posId = textBoxPostId.Text;

                string dateRegistr = textBoxDateOfCreate.Text.ToString().Trim();
                string dayP = dateRegistr.Substring(0, 2);
                string mP = dateRegistr.Substring(3, 2);
                string yearP = dateRegistr.Substring(6, 4);


                Microsoft.Office.Interop.Word.Application wordApp = new Microsoft.Office.Interop.Word.Application();


                string currentDirectory = Directory.GetCurrentDirectory();

                string temlatePath = Path.Combine(currentDirectory, "DocTemplates", "Шаблон_заява_заповіт.docx");

                Document document = wordApp.Documents.Open(temlatePath);

                //Заміна слова у всьому документі
                Dictionary<string, string> replacements = new Dictionary<string, string>();

                replacements.Add("i-1", i_1);
                replacements.Add("i-2", i_2);
                replacements.Add("i-3", i_3);
                replacements.Add("i-4", i_4);
                replacements.Add("i-5", i_5);
                replacements.Add("i-6", i_6);
                replacements.Add("i-7", i_7);
                replacements.Add("i-8", i_8);
                replacements.Add("i-9", i_9);
                replacements.Add("i-0", i_0);
                replacements.Add("fullname", fullname);
                replacements.Add("dB", dayB);
                replacements.Add("mB", mB);
                replacements.Add("yB", yearB);
                replacements.Add("Village", village);
                replacements.Add("Street", street);
                replacements.Add("house", house);
                replacements.Add("place", placeOfBitrh);
                replacements.Add("i", postId);
                replacements.Add("reg", registrNumber);
                replacements.Add("dR", dayP);
                replacements.Add("mR", mP);
                replacements.Add("yR", yearP);

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
                string tempFolderPath = @"C:\Заяви_Заповіти";
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

                MessageBox.Show("Заяву на реєстрацію заповіту на " + fullname + " збережено на диску C в папці - Заяви_Заповіти");
            }
        }
    }
}
