using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace AdoNetCodingConectado
{
    public partial class frmClienteEdit : Form
    {
        //string cadenaConexion = "server=localhost; database=Financiera; uid=[nombre_usuario]; password=[password_bd]";
        string cadenaConexion = "server=localhost; database=Financiera; Integrated Security=true";
        public frmClienteEdit()
        {
            InitializeComponent();
        }

        private void frmClienteEdit_Load(object sender, EventArgs e)
        {
            cargarDatos();
        }

        private void cargarDatos()
        {
            var conexion = new SqlConnection(cadenaConexion);
            conexion.Open();
            var sql = "SELECT * FROM TipoCliente";
            var command = new SqlCommand(sql, conexion);
            var lector = command.ExecuteReader();
            while (lector.Read())
            {
                cboTipo.Items.Add(lector[1].ToString());
            }
            conexion.Close();
        }
    }
}
