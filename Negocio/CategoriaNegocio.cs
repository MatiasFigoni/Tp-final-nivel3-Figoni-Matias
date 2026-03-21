using Herramienta;
using Dominio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Negocio
{
    public class CategoriaNegocio
    {
        private AccesoDatos datos;
        public List<Categoria> listar()
        {
            List<Categoria> lista = new List<Categoria>();
            datos = new AccesoDatos();
            try
            {
                datos.setearConsulta("select Id,Descripcion from CATEGORIAS");
                datos.ejecutarLector();
                while (datos.Lector.Read())
                {
                    Categoria aux = new Categoria();
                    aux.Id = (int)datos.Lector["Id"];
                    aux.Descripcion = (string)datos.Lector["Descripcion"];
                    lista.Add(aux);
                }
                return lista;
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally { datos.cerrarConexion(); }
        }
    }
}
