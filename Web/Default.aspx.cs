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
        public bool ConfirAgregadoFav { get; set; }
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                ConfirAgregadoFav = false;
                ArticuloNegocio articuloNegocio = new ArticuloNegocio();
                Session.Add("ListaArticulos", articuloNegocio.listar());
                repArticulos.DataSource = (List<Articulo>)Session["ListaArticulos"];
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

        protected void bntAgregarFav_Click(object sender, EventArgs e)
        {
            //Captura el button enviado
            try
            {
                int idArticulo = int.Parse(((Button)sender).CommandArgument);

                FavoritoNegocio favoritoNegocio = new FavoritoNegocio();
                favoritoNegocio.agregarFavorito(idArticulo, ((Usuario)Session["Usuario"]).Id);
                ConfirAgregadoFav = true;
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