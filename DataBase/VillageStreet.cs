using MySqlConnector;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;

namespace DataBase
{
    public class VillageStreet
    {
        public int id { get; set; }
        public int villageId { get; set; }
        public int streetId { get; set; }
        public bool isActive { get; set; }
        public DateTime? renameDate { get; set; }

        public VillageStreet() { }

        public VillageStreet(int _id, int _villageId, int _streetId )
        {
            id = _id;
            villageId = _villageId;
            streetId = _streetId; 
        }

        public VillageStreet(int _villageId)
        {
            villageId = _villageId;
        }

        private List<Village> dataVillage = new List<Village>();
        private List<Street> dataStreet = new List<Street>();
        bool mess;
        public void ComboBoxVillageFill(ComboBox comboBox)
        {
            dataVillage.Clear();

            ConnectionClass _manager = new ConnectionClass();
            MySqlDataReader _reader;
            _manager.openConnection();

            string reader = "SELECT * FROM villages";
            MySqlCommand _search = new MySqlCommand(reader, _manager.getConnection());
            _reader = _search.ExecuteReader();

            while (_reader.Read())
            {
                Village row = new Village(_reader["name"].ToString());
                dataVillage.Add(row);

            }
            _reader.Close();

            for (int i = 0; i < dataVillage.Count; i++)
            {
                AddDataGrid(dataVillage[i], comboBox, r => r.Name);
                mess = true;
            }
            if (mess == false)
            {
                MessageBox.Show("Таблиця населених пунктів і вулиць пуста, спочатку заповніть дані !");
            }
            _manager.closeConnection();

            var autoSourse = new AutoCompleteStringCollection();
            autoSourse.AddRange(dataVillage.Select(d => d.Name.ToString()).ToArray());
            comboBox.AutoCompleteCustomSource = autoSourse;
        }

        public void ComboBoxStreetChoose(ComboBox comboBoxVillage, ComboBox comboBoxStreets)
        {

            comboBoxStreets.Items.Clear();

            string village = comboBoxVillage.Text;
            comboBoxStreets.Text = "Виберіть вулицю";

            bool mess = false;
            dataStreet.Clear();

            ConnectionClass _manager = new ConnectionClass();
            MySqlDataReader _reader;
            _manager.openConnection();

            string reader = "SELECT s.id, s.name FROM streets s JOIN villagestreet ss ON ss.streetId = s.id" +
                " JOIN villages st ON st.id = villageId WHERE st.name = '" + village + "' AND ss.isActive = 1 ORDER BY s.name";
            MySqlCommand _search = new MySqlCommand(reader, _manager.getConnection());
            _reader = _search.ExecuteReader();

            while (_reader.Read())
            {
                Street row = new Street(_reader["name"].ToString());
                dataStreet.Add(row);

            }
            _reader.Close();

            for (int i = 0; i < dataStreet.Count; i++)
            {
                AddDataGrid(dataStreet[i], comboBoxStreets, r => r.Name);
                mess = true;
            }
            if (mess == false)
            {
                MessageBox.Show("Таблиця населених пунктів і вулиць пуста, спочатку заповніть дані !");
            }
            _manager.closeConnection();

            var autoSourse = new AutoCompleteStringCollection();
            autoSourse.AddRange(dataStreet.Select(d => d.Name.ToString()).ToArray());
            comboBoxStreets.AutoCompleteCustomSource = autoSourse;
            comboBoxStreets.AutoCompleteMode = AutoCompleteMode.SuggestAppend;
            comboBoxStreets.AutoCompleteSource = AutoCompleteSource.CustomSource;
        }

        private void AddDataGrid<T>(T row, ComboBox comboBox, Func<T, object> selector)
        {
            comboBox.Items.Add(selector(row));
        }

    }
}
