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
    public partial class Default1 : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                ArticuloNegocio articuloNegocio = new ArticuloNegocio();
                repArticulos.DataSource = articuloNegocio.listar();
                repArticulos.DataBind();
            }
            if (Session["Usuario"] != null)
            {
                Usuario usuario = (Usuario)Session["Usuario"];
                lblBienvenida.Text = "Bienvenido " + usuario.Nombre + "!";
            }
            else
            {
                lblBienvenida.Text = "Bienvenido!";
            }
        }
    }
}