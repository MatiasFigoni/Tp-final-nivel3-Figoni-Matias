using Dominio;
using Herramienta;
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
                    if (Seguridad.sessionActiva(Session["Usuario"]))
                    {
                        Usuario user = (Usuario)Session["Usuario"];
                        if (string.IsNullOrEmpty(user.UrlImagen))
                            imgImagenPerfil.ImageUrl = "~/ImgUsers/SinFotoPerfil.jpg";
                        else
                            imgImagenPerfil.ImageUrl = "~/ImgUsers/" + user.UrlImagen;

                        txtEmail.Text = user.Email;
                        txtContrasenia.Text = user.Pass;
                        txtNombre.Text = user.Nombre == null ? "" : user.Nombre;
                        txtApellido.Text = user.Apellido == null ? "" : user.Apellido;
                    }
                }
            }
            catch (Exception ex)
            {
                cargarError(ex);
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
                    EmailService emailService = new EmailService();
                    emailService.armarCorreo(
                        usuario.Email,
                        "Cambio de contraseña", 
                        usuario.Nombre + " se ha detectado un cambio de contraseña de su cuenta: " + usuario.Email + ", si no fue usted contactese con el mail de soporte...");
                    emailService.enviarEmail();
                }
                usuario.Pass = txtContrasenia.Text;
                usuario.Nombre = txtNombre.Text;
                usuario.Apellido = txtApellido.Text;

                //Guardar datos
                usuarioNegocio.modificarPerfil(usuario);
                Session.Add("Usuario", usuario);

                //Leer imagen
                Image img = (Image)Master.FindControl("imgUser");
                img.ImageUrl = "~/ImgUSers/" + usuario.UrlImagen;
                imgImagenPerfil.ImageUrl = "~/ImgUsers/" + usuario.UrlImagen;
                Response.Redirect("~/Default.aspx", false);
            }
            catch (Exception ex)
            {
                cargarError(ex);
            }
        }
        private void cargarError(Exception ex)
        {
            Session.Add("Error", ex.ToString());
            Response.Redirect("~/Error.aspx", false);
        }
    }
}