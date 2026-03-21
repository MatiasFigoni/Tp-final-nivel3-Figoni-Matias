using Dominio;
using Negocio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Web
{
    public partial class ModPerfilUsuario : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            try
            {
                if (!IsPostBack)
                {
                    if (Session["Usuario"] != null)
                    {
                        Usuario user = (Usuario)Session["Usuario"];
                        txtEmail.Text = user.Email;
                        txtContrasenia.Text = user.Pass;
                        txtNombre.Text = user.Nombre == null ? "" : user.Nombre;
                        txtApellido.Text = user.Apellido == null ? "" : user.Apellido;
                        imgImagenPerfil.ImageUrl = user.UrlImagen == null ? "" : user.UrlImagen;
                    }
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        protected void btnGuardar_Click(object sender, EventArgs e)
        {
            Usuario usuario = (Usuario)Session["Usuario"];
            UsuarioNegocio usuarioNegocio = new UsuarioNegocio();
            try
            {
                //Cargar imagen si recibio algo
                if (fupImagenPerfil.PostedFile.FileName != "")
                {
                    string ruta = Server.MapPath("~/ImgUsers/");
                    fupImagenPerfil.PostedFile.SaveAs(ruta + "perfil-" + usuario.Id + ".jpg");
                    usuario.UrlImagen = "perfil-" + usuario.Id + ".jpg";
                }
                if (txtContrasenia.Text != usuario.Pass)
                {
                    //notificar con mail el cambio de contraseña
                }
                usuario.Pass = txtContrasenia.Text;
                usuario.Nombre = txtNombre.Text;
                usuario.Apellido = txtApellido.Text;

                //Guardar datos
                usuarioNegocio.modificarPerfil(usuario);
                Session.Add("Usuario", usuario);

                //Leer imagen
                //Image img = (Image)Master.FindControl("imgPerfilUser");
                //img.ImageUrl = "~/Images/" + usuario.UrlImagen;
                //imgImagenPerfil.ImageUrl = "~/Images/" + usuario.UrlImagen;
                //Response.Redirect("~/Default.aspx", false);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}