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
    public partial class DescripcionArticulo : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Request.QueryString["id"] == null)
            {
                Response.Redirect("Default.aspx", false);
            }
            else
            {
                int id = int.Parse(Request.QueryString["id"].ToString());
                ArticuloNegocio articuloNegocio = new ArticuloNegocio();
                Articulo artFiltrado = articuloNegocio.listar().Find(x => x.Id == id);
                lblNombre.Text = artFiltrado.Nombre;
                imgArticulo.ImageUrl = artFiltrado.UrlImagen;
                lblCodigo.Text ="Codigo: " + artFiltrado.Codigo;
                lblDescripcion.Text = artFiltrado.Descripcion;
                lblMarca.Text ="Marca: " + artFiltrado.Marca.Descripcion;
                lblCategoria.Text ="Categoria: " + artFiltrado.Categoria.Descripcion;
                lblPrecio.Text ="Precio: " + artFiltrado.Precio.ToString();
            }
        }
    }
}