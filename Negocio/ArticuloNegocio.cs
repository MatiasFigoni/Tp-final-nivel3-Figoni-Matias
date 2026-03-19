using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Dominio;
using AccesoDatos;

namespace Negocio
{
    public class ArticuloNegocio
    {
        public List<Articulo> listar()
        {
			List<Articulo> listaArticulo = new List<Articulo>();
			Datos datos = new Datos();
			try
			{
				datos.setearConsulta("select A.Id, A.Codigo, A.Descripcion, A.Nombre, A.Precio, A.ImagenUrl, C.Descripcion 'Categoria', M.Descripcion 'Marca' from ARTICULOS A, CATEGORIAS C, MARCAS M where A.IdCategoria = C.Id and A.IdMarca = M.Id");
				datos.ejecutarLector();
				while (datos.Lector.Read())
				{
					Articulo aux = new Articulo();
					aux.Id = (int)datos.Lector["Id"];
					aux.Codigo = (string)datos.Lector["Codigo"];
					aux.Nombre = (string)datos.Lector["Nombre"];
					aux.Descripcion = (string)datos.Lector["Descripcion"];
					if (!(datos.Lector["ImagenUrl"] is DBNull))
					{
						aux.UrlImagen = (string)datos.Lector["ImagenUrl"];
                    }
					aux.Precio = (decimal)datos.Lector["Precio"];

					aux.Categoria = new Categoria();
					aux.Categoria.Descripcion = (string)datos.Lector["Categoria"];

					aux.Marca = new Marca();
					aux.Marca.Descripcion = (string)datos.Lector["Marca"];

					listaArticulo.Add(aux);
				}
				return listaArticulo;
			}
			catch (Exception ex)
			{
				throw ex;
			}
			finally { datos.cerrarConexion(); }
        }
    }
}
