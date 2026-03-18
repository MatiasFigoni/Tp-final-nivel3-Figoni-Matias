using Dominio;
using Negocio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Policy;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Web
{
    public partial class Default : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void btnIngresar_Click(object sender, EventArgs e)
        {
            Usuario usuario = new Usuario();
            if (!(string.IsNullOrEmpty(txtEmail.Text) || string.IsNullOrEmpty(txtPass.Text)))
            {
                usuario.Email = txtEmail.Text;
                usuario.Pass = txtPass.Text;
                UsuarioNegocio usuarioNegocio = new UsuarioNegocio();
                if (usuarioNegocio.logIn(usuario))
                {
                    Session.Add("Usuario", usuario);
                    Response.Redirect("~/Default.aspx", false);
                }
                else
                {
                    //Enviar pagina de error de error con su usuario o contraseña
                }
            }
            camposVacios();
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
    }
}