using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Xml.Schema;
using System.Globalization;

namespace AccesoDatos
{
    public class Datos
    {
        private SqlConnection conexion;
        private SqlCommand comando;
        private SqlDataReader lector;
        public Datos()
        {
            conexion = new SqlConnection("server=.\\SQLEXPRESS; database=CATAGOLO_WEB_DB; integrated security=true");
            comando = new SqlCommand();
        }
        public SqlDataReader Lector
        {
            get { return lector; }
        }
        public void setearConsulta(string consutla)
        {
            comando.CommandType = System.Data.CommandType.Text;
            comando.CommandText = consutla;
        }
        public void ejecutarLector()
        {
            comando.Connection = conexion;
            try
            {
                conexion.Open();
                lector = comando.ExecuteReader();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public void ejecutarAccion()
        {
            try
            {
                comando.Connection = conexion;
                conexion.Open();
                comando.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public void setearParametro(string parametro, object valor)
        {
            comando.Parameters.AddWithValue(parametro, valor);
        }
        public void cerrarConexion()
        {
            if (lector != null)
                lector.Close();
            conexion.Close();
        }
    }
}
