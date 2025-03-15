using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Agenda
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            frmActualizar actualiza = new frmActualizar(dgvUsuarios[0, e.RowIndex].Value.ToString(),
                dgvUsuarios[1, e.RowIndex].Value.ToString(),
                dgvUsuarios[2, e.RowIndex].Value.ToString(),
                dgvUsuarios[3, e.RowIndex].Value.ToString(),
                dgvUsuarios[4, e.RowIndex].Value.ToString(),
                dgvUsuarios[5, e.RowIndex].Value.ToString());
            actualiza.Show();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            DiseñarTabla();
            Datos obj = new Datos();
            DataSet ds = obj.Consulta("SELECT * FROM Usuarios");
            if (ds != null)
            {
                dgvUsuarios.DataSource = ds.Tables[0];

            }
        }

        public void ActualizaGrid()
        {
            Datos obj = new Datos();
            DataSet ds = obj.Consulta("SELECT ID AS ID, APATERNO AS [APELLIDO PATERNO], AMATERNO AS [APELLIDO MATERNO], NOMBRE AS [NOMBRE COMPLETO], TELEFONO AS TELEFONO, CORREO AS [E-MAIL]\r\nFROM Usuarios");

            if (ds != null)
            {
                dgvUsuarios.DataSource = ds.Tables[0];
            }

        }

        private void Form1_Activated(object sender, EventArgs e)
        {
            ActualizaGrid();
        }

        private void btnInsertar_Click(object sender, EventArgs e)
        {
            frmInsertarcs insertar = new frmInsertarcs();
            insertar.ShowDialog();
        }

        private void dgvUsuarios_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
        private void DiseñarTabla()
        {
            // Color de fondo de la tabla
            dgvUsuarios.BackgroundColor = Color.Gray;

            // Alternar color de filas
            dgvUsuarios.AlternatingRowsDefaultCellStyle.BackColor = Color.LightGray;

            // Encabezado de la tabla
            dgvUsuarios.ColumnHeadersDefaultCellStyle.BackColor = Color.DarkSlateGray;
            dgvUsuarios.ColumnHeadersDefaultCellStyle.ForeColor = Color.White;
            dgvUsuarios.ColumnHeadersDefaultCellStyle.Font = new Font("Arial", 10, FontStyle.Bold);

            // Color de la selección
            dgvUsuarios.DefaultCellStyle.SelectionBackColor = Color.SteelBlue;
            dgvUsuarios.DefaultCellStyle.SelectionForeColor = Color.White;

            // Bordes de la celda
            dgvUsuarios.CellBorderStyle = DataGridViewCellBorderStyle.Single;
            dgvUsuarios.GridColor = Color.Black;

            // Alineación de texto en celdas
            dgvUsuarios.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;

            // Autoajuste del tamaño de las columnas
            dgvUsuarios.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
        }

        // Llamar a la función en el constructor o en el evento Load
       

    }
}
