using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Net.NetworkInformation;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Agenda
{
    public partial class frmActualizar : Form
    {
        public frmActualizar(string id,string Apaterno, string Amaterno, string nombre, string telefono, string correo)
        {
            InitializeComponent();
            txtID.Text = id;
            txtAPat.Text = Apaterno;
            txtAMaterno.Text = Amaterno;
            txtNombre.Text = nombre;
            txtTelefono.Text = telefono;
            txtCorreo.Text = correo;
        }

        private void btnAgregar_Click(object sender, EventArgs e)
        {

            Datos datos = new Datos();
            bool f = datos.comando("UPDATE Usuarios SET " +
               "APATERNO = '" + txtAPat.Text + "', " +
               "AMATERNO = '" + txtAMaterno.Text + "', " +
               "NOMBRE = '" + txtNombre.Text + "', " +
               "TELEFONO = '" + txtTelefono.Text + "', " +
               "CORREO = '" + txtCorreo.Text + "' " +
               "WHERE ID = '" + txtID.Text + "'");
            if (f == true)
            {
                MessageBox.Show("Datos Actualizados", "Sistema",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);
                this.Close();
            }
            else
                MessageBox.Show("Error al actualizar", "Sistema",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
        }

        private void btnEliminar_Click(object sender, EventArgs e)
        {
            DialogResult r = MessageBox.Show("¿Estas seguro de eliminar el registro?", "Sistema", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (r == DialogResult.Yes)
            {
                Datos datos = new Datos();
                bool f = datos.comando("delete from Usuarios where ID = '" + txtID.Text + "'");
                if (f)
                {
                    MessageBox.Show("AUTOR ELIMINADO", "SISTEMA", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    this.Close();
                }
                else
                {
                    MessageBox.Show("Error De Sistema", "SISTEMA", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
        }
    }
}
