using supermercadoEcommerce.br.unitins.supercommerce.application;
using supermercadoEcommerce.br.unitins.supercommerce.models;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace supermercadoEcommerce.br.unitins.supercommerce.dao
{
    abstract class Dao<T> : Crud<T>
    {

        private static SqlConnection _con = new SqlConnection();
        public Dao()
        {
            _con.ConnectionString = @"Data Source=DESKTOP-ML5GQ10;Initial Catalog=Prova_A1;Integrated Security=True";
        }

        public static SqlConnection Connect()
        {
            if (_con.State == System.Data.ConnectionState.Closed)
            {
                _con.Open();
            }
            return _con;
        }

        public SqlConnection Con
        {
            get => _con;
            set => _con = value;
        }
        public static SqlConnection Disconnect()
        {
            if (_con.State == System.Data.ConnectionState.Open)
            {
                _con.Close();
            }
            return _con;

        }

        public abstract void Create(T param);

        public abstract void Destroy(T param);

        public abstract void Edit(T param);

        public abstract List<T> Index();

        public abstract T Show(int id);

       
    }
}
