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
    public partial class ABMArticulo : System.Web.UI.Page
    {
        public bool MostrarBotonEliminar { get; set; }
        public bool MostrarConfirmacion { get; set; }
        protected void Page_Load(object sender, EventArgs e)
        {
            try
            {
                MostrarBotonEliminar = false;
                MostrarConfirmacion = false;
                if (!IsPostBack)
                {
                    MarcaNegocio marcaNegocio = new MarcaNegocio();
                    CategoriaNegocio categoriaNegocio = new CategoriaNegocio();

                    ddlMarca.DataSource = marcaNegocio.listar();
                    ddlCategoria.DataSource = categoriaNegocio.listar();
                    ddlMarca.DataValueField = "Id";
                    ddlMarca.DataTextField = "Descripcion";
                    ddlCategoria.DataValueField = "Id";
                    ddlCategoria.DataTextField = "Descripcion";
                    ddlMarca.DataBind();
                    ddlCategoria.DataBind();

                    if (Request.QueryString["id"] != null)
                    {
                        ArticuloNegocio articuloNegocio = new ArticuloNegocio();
                        Articulo artFiltrado = (articuloNegocio.listar()).Find(x => x.Id == int.Parse(Request.QueryString["id"]));
                        Session.Add("ArticuloFiltrado", artFiltrado);

                        //Carga de campos
                        txtId.Text = artFiltrado.Id.ToString();
                        txtCodigo.Text = artFiltrado.Codigo;
                        txtNombre.Text = artFiltrado.Nombre;
                        txtDescripcion.Text = artFiltrado.Descripcion;
                        txtPrecio.Text = artFiltrado.Precio.ToString();
                        txtUrlImagen.Text = artFiltrado.UrlImagen;
                        cargarImagen(artFiltrado.UrlImagen);
                        ddlMarca.SelectedValue = artFiltrado.Marca.Id.ToString();
                        ddlCategoria.SelectedValue = artFiltrado.Categoria.Id.ToString();

                        MostrarBotonEliminar = true;

                    }
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        protected void txtUrlImagen_TextChanged(object sender, EventArgs e)
        {
            cargarImagen(txtUrlImagen.Text);
        }
        private void cargarImagen(string url)
        {
            try
            {
                imgArticulo.ImageUrl = url;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }


        protected void btnConfirmarEliminacion_Click(object sender, EventArgs e)
        {
            try
            {
                ArticuloNegocio articuloNegocio = new ArticuloNegocio();
                articuloNegocio.eliminar((Articulo)Session["ArticuloFiltrado"]);
                Session["ListaArticulos"] = articuloNegocio.listar();
                Response.Redirect("ListadoArticulos.aspx", false);
            }
            catch (Exception ex)
            {
                throw ex;
            }

        }

        protected void btnAceptar_Click(object sender, EventArgs e)
        {
            Articulo aux = new Articulo();
            aux.Codigo = txtCodigo.Text;
            aux.Descripcion = txtDescripcion.Text;
            aux.Nombre = txtNombre.Text;
            if (!(string.IsNullOrEmpty(txtPrecio.Text)))
                aux.Precio = decimal.Parse(txtPrecio.Text);
            else
                aux.Precio = 0;
            aux.UrlImagen = txtUrlImagen.Text;

            aux.Categoria = new Categoria();
            aux.Categoria.Id = int.Parse(ddlCategoria.SelectedValue);

            aux.Marca = new Marca();
            aux.Marca.Id = int.Parse(ddlMarca.SelectedValue);
            ArticuloNegocio articuloNegocio = new ArticuloNegocio();
            if (Request.QueryString["id"] != null)
            {
                aux.Id = int.Parse(txtId.Text);
                articuloNegocio.modificar(aux);
                lblAddMod.Text = "Modificado exitosamente!";
            }
            else
            {
                articuloNegocio.agregar(aux);
                lblAddMod.Text = "Agregado exitosamente!";
            }
            MostrarConfirmacion = true;

        }
    }
}