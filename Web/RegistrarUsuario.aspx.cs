using Dominio;
using Negocio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Net.Mail;

namespace Web
{
    public partial class RegistrarUsuario : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void btnRegistrarse_Click(object sender, EventArgs e)
        {
            Usuario usuario = new Usuario();
            UsuarioNegocio usuarioNegocio = new UsuarioNegocio();
            try
            {
                if (!(string.IsNullOrEmpty(txtEmail.Text) || string.IsNullOrEmpty(txtPass.Text)) && isEmail(txtEmail.Text))
                {
                    usuario.Email = txtEmail.Text;
                    usuario.Pass = txtPass.Text;
                    usuarioNegocio.registrarse(usuario);
                    Session.Add("Usuario", usuario);
                    Response.Redirect("~/Default.aspx", false);
                }
                camposVacios();

            }
            catch (Exception ex)
            {
                cargarError(ex);
            }
        }
        private bool isEmail(string email)
        {
            if (string.IsNullOrEmpty(email))
                return false;
            try
            {
                //Usa el try para detectar si puede crear una instancia del MailAddress.
                //En caso de coincidir con la estructura deja crear la instancia.
                var validacion = new MailAddress(email);
                return true;
            }
            catch
            {
                return false;
            }
        }
        private void camposVacios()
        {
            if (string.IsNullOrEmpty(txtEmail.Text))
                txtEmail.CssClass = "form-control is-invalid";
            else
                txtEmail.CssClass = "form-control";

            if (string.IsNullOrEmpty(txtPass.Text))
                txtPass.CssClass = "form-control is-invalid";
            else
                txtPass.CssClass = "form-control";
        }
        private void cargarError(Exception ex)
        {
            Session.Add("Error", ex.ToString());
            Response.Redirect("~/Error.aspx", false);
        }
    }
}