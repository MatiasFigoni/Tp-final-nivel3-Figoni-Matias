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
		Datos datos;

		public List<Articulo> listar()
        {
			List<Articulo> listaArticulo = new List<Articulo>();
			datos = new Datos();
			try
			{
				datos.setearConsulta("select A.Id, A.Codigo, A.Descripcion, A.Nombre, A.Precio, A.ImagenUrl, C.Descripcion 'Categoria', M.Descripcion 'Marca', C.Id 'IdCategoria',M.Id 'IdMarca' from ARTICULOS A, CATEGORIAS C, MARCAS M where A.IdCategoria = C.Id and A.IdMarca = M.Id");
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
					aux.Categoria.Id = (int)datos.Lector["IdCategoria"];
					aux.Categoria.Descripcion = (string)datos.Lector["Categoria"];

					aux.Marca = new Marca();
					aux.Marca.Id = (int)datos.Lector["IdMarca"];
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
        public void agregar(Articulo articulo)
        {
            datos = new Datos();
            try
            {
                datos.setearConsulta("insert into ARTICULOS(Codigo,Nombre,Descripcion,IdMarca,IdCategoria,ImagenUrl,Precio) values (@cod,@nom,@desc,@idM,@idC,@img,@pre)");
                datos.setearParametro("@cod", articulo.Codigo);
                datos.setearParametro("@nom", articulo.Nombre);
                datos.setearParametro("@desc", articulo.Descripcion);
                datos.setearParametro("@idM", articulo.Marca.Id);
                datos.setearParametro("@idC", articulo.Categoria.Id);
                datos.setearParametro("@img", articulo.UrlImagen);
                datos.setearParametro("@pre", articulo.Precio);
                datos.ejecutarAccion();
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally { datos.cerrarConexion(); }
        }
        public void modificar(Articulo articulo)
        {
            datos = new Datos();
            try
            {
                datos.setearConsulta("update ARTICULOS set Codigo = @cod, Nombre = @nom, Descripcion = @desc,IdMarca = @idM,IdCategoria = @idC,ImagenUrl = @img,Precio = @precio where Id = @id");
                datos.setearParametro("@id", articulo.Id);
                datos.setearParametro("@cod", articulo.Codigo);
                datos.setearParametro("@nom", articulo.Nombre);
                datos.setearParametro("@desc", articulo.Descripcion);
                datos.setearParametro("@idM", articulo.Marca.Id);
                datos.setearParametro("@idC", articulo.Categoria.Id);
                datos.setearParametro("@img", articulo.UrlImagen);
                datos.setearParametro("@precio", articulo.Precio);
                datos.ejecutarAccion();
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally { datos.cerrarConexion(); }
        }
        public void eliminar(Articulo articulo)
        {
            datos = new Datos();
            try
            {
                datos.setearConsulta("delete from ARTICULOS where Id = @id");
                datos.setearParametro("@id", articulo.Id);
                datos.ejecutarAccion();
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally { datos.cerrarConexion(); }
        }
        public List<Articulo> filtrar(string campo, string criterio, string filtro)
        {
            List<Articulo> lista = new List<Articulo>();
            datos = new Datos();
            try
            {
                string consulta = "select A.Id,Codigo,Nombre,A.Descripcion,IdMarca,M.Descripcion \"Marca\",IdCategoria,C.Descripcion \"Categoria\",ImagenUrl,Precio from ARTICULOS A,MARCAS M,CATEGORIAS C where A.IdMarca = M.Id and A.IdCategoria = C.Id and ";
                switch (campo)
                {
                    case "Marca":
                        consulta += "M.Descripcion = '" + criterio + "'";
                        break;
                    case "Categoria":
                        consulta += "C.Descripcion = '" + criterio + "'";
                        break;
                    case "Precio":
                        switch (criterio)
                        {
                            case "Menor a":
                                consulta += "Precio < " + filtro;
                                break;
                            case "Mayor a":
                                consulta += "Precio > " + filtro;
                                break;
                            case "Igual a":
                                consulta += "Precio = " + filtro;
                                break;
                            default:
                                break;
                        }
                        break;
                    case "Nombre":
                        switch (criterio)
                        {
                            case "Comienza por":
                                consulta += "A.Nombre like '" + filtro + "%'";
                                break;
                            case "Termina por":
                                consulta += "A.Nombre like '%" + filtro + "'";
                                break;
                            case "Contiene":
                                consulta += "A.Nombre like '%" + filtro + "%'";
                                break;
                            default:
                                break;
                        }
                        break;
                    default:
                        break;
                }

                datos.setearConsulta(consulta);
                datos.ejecutarLector();
                while (datos.Lector.Read())
                {
                    Articulo aux = new Articulo();
                    aux.Id = (int)datos.Lector["Id"];
                    aux.Codigo = (string)datos.Lector["Codigo"];
                    aux.Nombre = (string)datos.Lector["Nombre"];
                    aux.Descripcion = (string)datos.Lector["Descripcion"];

                    aux.Marca = new Marca();
                    aux.Marca.Id = (int)datos.Lector["IdMarca"];
                    aux.Marca.Descripcion = (string)datos.Lector["Marca"];

                    aux.Categoria = new Categoria();
                    aux.Categoria.Id = (int)datos.Lector["IdCategoria"];
                    aux.Categoria.Descripcion = (string)datos.Lector["Categoria"];

                    if (!(datos.Lector["ImagenUrl"] is DBNull))
                        aux.UrlImagen = (string)datos.Lector["ImagenUrl"];
                    aux.Precio = (decimal)datos.Lector["Precio"];

                    lista.Add(aux);
                }
                return lista;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}