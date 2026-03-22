using Dominio;
using Herramienta;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Negocio
{
    public class FavoritoNegocio
    {
        public void agregarFavorito(int idArticulo, int idUser)
        {
            AccesoDatos datos = new AccesoDatos();
            try
            {
                datos.setearConsulta("insert into FAVORITOS values (@idUser,@idArticulo)");
                datos.setearParametro("@idUser", idUser);
                datos.setearParametro("idArticulo", idArticulo);
                datos.ejecutarAccion();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public void eliminarFavorito(int idArticulo, int idUser)
        {
            AccesoDatos datos = new AccesoDatos();
            try
            {
                datos.setearConsulta("delete from FAVORITOS where IdArticulo = @idArticulo and IdUser = @idUser");
                datos.setearParametro("@idUser", idUser);
                datos.setearParametro("idArticulo", idArticulo);
                datos.ejecutarAccion();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public List<Articulo> listarFavoritos(int idUser)
        {
            List<Articulo> listaArticulo = new List<Articulo>();
            AccesoDatos datos = new AccesoDatos();
            try
            {
                datos.setearConsulta("select A.Id, A.Codigo, A.Descripcion, A.Nombre, A.Precio, A.ImagenUrl, C.Descripcion 'Categoria', M.Descripcion 'Marca', C.Id 'IdCategoria',M.Id 'IdMarca' from ARTICULOS A, CATEGORIAS C, MARCAS M where A.IdCategoria = C.Id and A.IdMarca = M.Id and a.Id in (select IdArticulo from FAVORITOS where IdUser = @idUser)");
                datos.setearParametro("@idUser",idUser);
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
    }
}
