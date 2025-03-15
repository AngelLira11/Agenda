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
    public partial class frmInsertarcs : Form
    {
        public frmInsertarcs()
        {
            InitializeComponent();
        }

        private void btnAgregar_Click(object sender, EventArgs e)
        {
            Datos datos = new Datos();
            bool f = datos.comando("INSERT INTO USUARIOS (APATERNO, AMATERNO, NOMBRE, TELEFONO, CORREO) " +
               "VALUES ('" + txtAPat.Text + "', '" + txtAMaterno.Text + "', '" +
               txtNombre.Text + "', '" + txtTelefono.Text + "', '" + txtCorreo.Text + "')");
            if (f == true)
            {
                MessageBox.Show("Datos insertados", "Sistema",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);
                this.Close();
            }
            else
            {
                MessageBox.Show("Error al insertar", "Sistema",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void label4_Click(object sender, EventArgs e)
        {

        }
    }
}
