using MySqlConnector;
using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace DataBase
{
    internal class VillageStreet
    {
        public object id { get; set; }
        public object village { get; set; }
        public object street { get; set; }

        public VillageStreet() { }

        public VillageStreet(object _id, object _village, object _street )
        {
            id = _id;
            village = _village;
            street = _street; 
        }

        public VillageStreet(object _village)
        {
            village = _village;
        }

        private List<VillageStreet> data = new List<VillageStreet>();
        bool mess;
        public void ComboBoxVillageFill(ComboBox comboBox)
        {
            data.Clear();

            ConnectionClass _manager = new ConnectionClass();
            MySqlDataReader _reader;
            _manager.openConnection();

            string reader = "SELECT DISTINCT village FROM villagestreet";
            MySqlCommand _search = new MySqlCommand(reader, _manager.getConnection());
            _reader = _search.ExecuteReader();

            while (_reader.Read())
            {
                VillageStreet row = new VillageStreet(_reader["village"]);
                data.Add(row);

            }
            _reader.Close();

            for (int i = 0; i < data.Count; i++)
            {
                AddDataGrid(data[i], comboBox, r => r.village);
                mess = true;
            }
            if (mess == false)
            {
                MessageBox.Show("Таблиця населених пунктів і вулиць пуста, спочатку заповніть дані !");
            }
            _manager.closeConnection();
        }

        public void comboBoxStreetChoose(ComboBox comboBoxVillage, ComboBox comboBoxStreets)
        {

            comboBoxStreets.Items.Clear();

            string village = comboBoxVillage.Text;
            comboBoxStreets.Text = "Виберіть вулицю";

            bool mess = false;
            data.Clear();

            ConnectionClass _manager = new ConnectionClass();
            MySqlDataReader _reader;
            _manager.openConnection();

            string reader = "SELECT street FROM villagestreet WHERE `village` = '" + village + "'";
            MySqlCommand _search = new MySqlCommand(reader, _manager.getConnection());
            _reader = _search.ExecuteReader();

            while (_reader.Read())
            {
                VillageStreet row = new VillageStreet(_reader["street"]);
                data.Add(row);

            }
            _reader.Close();

            for (int i = 0; i < data.Count; i++)
            {
                AddDataGrid(data[i], comboBoxStreets, r => r.village);
                mess = true;
            }
            if (mess == false)
            {
                MessageBox.Show("Таблиця населених пунктів і вулиць пуста, спочатку заповніть дані !");
            }
            _manager.closeConnection();
        }

        private void AddDataGrid<T>(T row, ComboBox comboBox, Func<T, object> selector)
        {
            comboBox.Items.Add(selector(row));
        }

    }
}
