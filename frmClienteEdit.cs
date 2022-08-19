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
            using (var conexion = new SqlConnection(cadenaConexion))
            {
                conexion.Open();
                var sql = "SELECT * FROM TipoCliente";
                var comando = new SqlCommand(sql, conexion);
                var lector = comando.ExecuteReader();
                if(lector != null && lector.HasRows)
                {
                    Dictionary<string, string> tipoClienteSource = new Dictionary<string, string>();
                    while (lector.Read())
                    {
                        tipoClienteSource.Add(lector[0].ToString(), lector[1].ToString());
                    }
                    cboTipo.DataSource = new BindingSource(tipoClienteSource, null);
                    cboTipo.DisplayMember = "Value";
                    cboTipo.ValueMember = "Key";
                }                
            }
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            var value = cboTipo.SelectedValue;
            MessageBox.Show(value.ToString());
        }
    }
}
