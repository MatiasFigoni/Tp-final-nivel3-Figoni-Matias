using Dominio;
using System;
using System.Collections.Generic;
using System.Diagnostics.Tracing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Herramienta;

namespace Negocio
{
    public class UsuarioNegocio
    {
        public bool logIn(Usuario user)
        {
            AccesoDatos datos = new AccesoDatos();
            try
            {
                datos.setearConsulta("select Id,email,pass,nombre,apellido,urlImagenPerfil,admin from USERS where email = @email and pass = @pass");
                datos.setearParametro("@email", user.Email);
                datos.setearParametro("@pass", user.Pass);
                datos.ejecutarLector();
                while (datos.Lector.Read())
                {
                    user.Id = (int)datos.Lector["Id"];
                    if (!(datos.Lector["nombre"] is DBNull))
                        user.Nombre = (string)datos.Lector["nombre"];
                    if (!(datos.Lector["apellido"] is DBNull))
                        user.Apellido = (string)datos.Lector["apellido"];
                    if (!(datos.Lector["urlImagenPerfil"] is DBNull))
                        user.UrlImagen = (string)datos.Lector["urlImagenPerfil"];
                    user.Admin = (bool)datos.Lector["admin"];
                    return true;
                }
                return false;
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally { datos.cerrarConexion(); }

        }
        public void registrarse(Usuario user)
        {
            AccesoDatos datos = new AccesoDatos();
            try
            {
                datos.setearConsulta("insert into USERS (email,pass) values (@email,@pass)");
                datos.setearParametro("@email",user.Email);
                datos.setearParametro("@pass",user.Pass);
                datos.ejecutarAccion();
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally { datos.cerrarConexion(); }
        }
        public void modificarPerfil(Usuario user)
        {
            AccesoDatos datos = new AccesoDatos();
            try
            {
                datos.setearConsulta("update USERS set pass=@pass, Nombre = @nombre, Apellido=@apellido,UrlImagenPerfil=@img where Id = @id");
                datos.setearParametro("@pass", user.Pass);
                datos.setearParametro("@nombre", user.Nombre);
                datos.setearParametro("@apellido", user.Apellido);
                datos.setearParametro("@img", user.UrlImagen != null ? user.UrlImagen : "");
                datos.setearParametro("@id", user.Id);
                datos.ejecutarAccion();
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally { datos.cerrarConexion(); }
        }
    }
}
