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
    public partial class ArticulosFavoritosUser : System.Web.UI.Page
    {
        public bool ConfirEliminarFav { get; set; }
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                ConfirEliminarFav = false;
                if (Seguridad.sessionActiva(Session["Usuario"]) && Request.QueryString["id"] != null)
                {
                    cargarRepetidor();
                }
            }
        }
        private void cargarRepetidor()
        {
            FavoritoNegocio favoritoNegocio = new FavoritoNegocio();
            repArticulos.DataSource = favoritoNegocio.listarFavoritos(int.Parse(Request.QueryString["id"]));
            repArticulos.DataBind();
        }
        protected void btnQuitarFav_Click(object sender, EventArgs e)
        {
            try
            {
                int idArticulo = int.Parse(((Button)sender).CommandArgument);
                FavoritoNegocio favoritoNegocio = new FavoritoNegocio();
                favoritoNegocio.eliminarFavorito(idArticulo, ((Usuario)Session["Usuario"]).Id);
                ConfirEliminarFav = true;
                cargarRepetidor();
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