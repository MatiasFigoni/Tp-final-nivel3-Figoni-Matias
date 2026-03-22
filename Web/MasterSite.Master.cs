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
    public partial class MasterSite : System.Web.UI.MasterPage
    {
        protected void Page_Load(object sender, EventArgs e)
        {

            if (!IsPostBack)
            {
                if (Seguridad.sessionActiva(Session["Usuario"]))
                {
                    Usuario user = (Usuario)Session["Usuario"];
                    lblEmailUser.Text = user.Email;
                    if (!string.IsNullOrEmpty(user.UrlImagen))
                        imgUser.ImageUrl = "~/ImgUsers/" + user.UrlImagen;
                    else
                        imgUser.ImageUrl = "~/ImgUsers/SinFotoPerfil.jpg";
                }
            }
        }

        protected void btnCerrarSesion_Click(object sender, EventArgs e)
        {
            Session.Remove("Usuario");
            Response.Redirect("Default.aspx", false);
        }
    }
}