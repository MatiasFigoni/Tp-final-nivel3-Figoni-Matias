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
    public partial class ListadoArticulos : System.Web.UI.Page
    {
        public bool FiltroAvanzado { get; set; }
        protected void Page_Load(object sender, EventArgs e)
        {
            FiltroAvanzado = cbxActivarFiltroAvanzado.Checked;
            if (!IsPostBack)
            {
                //Por defecto al apretar Enter acciona el boton "Salir" de la MasterPage,
                //aca le decimos que la prioridad del Enter sea el btnFiltroAvanzado
                this.Form.DefaultButton = btnFiltroAvanzado.UniqueID;
                try
                {
                    ArticuloNegocio articuloNegocio = new ArticuloNegocio();
                    Session.Add("ListaArticulos", articuloNegocio.listar());
                    dgvArticulos.DataSource = (List<Articulo>)Session["ListaArticulos"];
                    dgvArticulos.DataBind();
                }
                catch (Exception ex)
                {
                    cargarError(ex);
                }
            }
        }

        protected void dgvArticulos_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            dgvArticulos.PageIndex = e.NewPageIndex;
            dgvArticulos.DataSource = (List<Articulo>)Session["ListaArticulos"];
            dgvArticulos.DataBind();
        }

        protected void dgvArticulos_SelectedIndexChanged(object sender, EventArgs e)
        {
            string id = dgvArticulos.SelectedDataKey.Value.ToString();
            Response.Redirect("ABMArticulo.aspx?id=" + id, false);
        }

        private bool onlyNumbers(string cadena)
        {
            //Intentar que acepte decimales
            char a;
            foreach (char c in cadena)
            {
                if (!char.IsNumber(c))
                {
                    return false;
                }
            }
            return true;
        }
        protected void btnFiltroAvanzado_Click(object sender, EventArgs e)
        {
            ArticuloNegocio negocio = new ArticuloNegocio();
            if (ddlCampo.Text == "Precio" && (!(onlyNumbers(txtFiltroAvanzado.Text)) || txtFiltroAvanzado.Text == ""))
            {
                txtFiltroAvanzado.CssClass = "form-control is-invalid";
                return;
            }
            else
            {
                txtFiltroAvanzado.CssClass = "form-control";
            }
            Session["ListaArticulos"] = negocio.filtrar(ddlCampo.Text, ddlCriterio.Text, txtFiltroAvanzado.Text);
            dgvArticulos.DataSource = (List<Articulo>)Session["ListaArticulos"];
            dgvArticulos.DataBind();
        }
        protected void ddlCampo_SelectedIndexChanged(object sender, EventArgs e)
        {
            ddlCriterio.Items.Clear();
            switch (ddlCampo.Text)
            {
                case "Precio":
                    ddlCriterio.Items.Add("Menor a");
                    ddlCriterio.Items.Add("Mayor a");
                    ddlCriterio.Items.Add("Igual a");
                    break;
                case "Marca":
                    MarcaNegocio marcaNegocio = new MarcaNegocio();
                    foreach (var item in marcaNegocio.listar())
                        ddlCriterio.Items.Add(item.Descripcion);
                    break;
                case "Categoria":
                    CategoriaNegocio categoriaNegocio = new CategoriaNegocio();
                    foreach (var item in categoriaNegocio.listar())
                        ddlCriterio.Items.Add(item.Descripcion);
                    break;
                case "Nombre":
                    ddlCriterio.Items.Add("Comienza por");
                    ddlCriterio.Items.Add("Termina por");
                    ddlCriterio.Items.Add("Contiene");
                    break;
                default:
                    break;
            }

        }
        protected void txtFiltro_TextChanged(object sender, EventArgs e)
        {
            try
            {
                List<Articulo> listaFiltrada = ((List<Articulo>)Session["ListaArticulos"]).FindAll(x => x.Nombre.ToUpper().Contains(txtFiltro.Text.ToUpper()));
                dgvArticulos.DataSource = listaFiltrada;
                dgvArticulos.DataBind();

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