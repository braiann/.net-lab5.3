using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Negocio;

namespace Lab5._3
{
    public partial class ListaUsuarios : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void grdUsuarios_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            if (e.CommandName.ToLower() == "Insertar")
            {
                TextBox cajaTexto;
                string textoActual;
                Usuario usuarioNuevo = new Usuario();

                cajaTexto = (TextBox)grdUsuarios.FooterRow.FindControl("txtNombre");
                textoActual = cajaTexto.Text;
                usuarioNuevo.Nombre = textoActual;

                cajaTexto = (TextBox)grdUsuarios.FooterRow.FindControl("txtApellido");
                textoActual = cajaTexto.Text;
                usuarioNuevo.Apellido = textoActual;

                cajaTexto = (TextBox)grdUsuarios.FooterRow.FindControl("txtTipoDoc");
                textoActual = cajaTexto.Text;
                usuarioNuevo.TipoDoc = Convert.ToInt32(textoActual);

                cajaTexto = (TextBox)grdUsuarios.FooterRow.FindControl("txtNroDoc");
                textoActual = cajaTexto.Text;
                usuarioNuevo.NroDoc = Convert.ToInt32(textoActual);

                cajaTexto = (TextBox)grdUsuarios.FooterRow.FindControl("txtFechaNac");
                textoActual = cajaTexto.Text;
                usuarioNuevo.FechaNac = textoActual;

                cajaTexto = (TextBox)grdUsuarios.FooterRow.FindControl("txtDireccion");
                textoActual = cajaTexto.Text;
                usuarioNuevo.Direccion = textoActual;

                cajaTexto = (TextBox)grdUsuarios.FooterRow.FindControl("txtTelefono");
                textoActual = cajaTexto.Text;
                usuarioNuevo.Telefono = textoActual;

                cajaTexto = (TextBox)grdUsuarios.FooterRow.FindControl("txtEmail");
                textoActual = cajaTexto.Text;
                usuarioNuevo.Email = textoActual;

                cajaTexto = (TextBox)grdUsuarios.FooterRow.FindControl("txtCelular");
                textoActual = cajaTexto.Text;
                usuarioNuevo.Celular = textoActual;

                cajaTexto = (TextBox)grdUsuarios.FooterRow.FindControl("txtNombreUsuario");
                textoActual = cajaTexto.Text;
                usuarioNuevo.NombreUsuario = textoActual;

                cajaTexto = (TextBox)grdUsuarios.FooterRow.FindControl("txtClave");
                textoActual = cajaTexto.Text;
                usuarioNuevo.Clave = textoActual;

                ManagerUsuarios manager = new ManagerUsuarios();

                manager.AgregarUsuario(usuarioNuevo);

                grdUsuarios.DataBind();
            }
        }
    }
}