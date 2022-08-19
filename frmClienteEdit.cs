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
                
                // CARGAR DATOS DE TIPO DE CLIENTE
                var sql = "SELECT * FROM TipoCliente";
                using(var comando = new SqlCommand(sql, conexion))
                {
                    using(var lector = comando.ExecuteReader())
                    {
                        if (lector != null && lector.HasRows)
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

                // CARGAR DATOS DE TIPO DE DOCUMENTO
                sql = "SELECT * FROM TipoDocumento";
                using(var comando = new SqlCommand(sql, conexion))
                {
                    using(var lector = comando.ExecuteReader())
                    {
                        if (lector != null && lector.HasRows)
                        {
                            Dictionary<string, string> tipoDocumentoSource = new Dictionary<string, string>();
                            while (lector.Read())
                            {
                                tipoDocumentoSource.Add(lector[0].ToString(), lector[1].ToString());
                            }
                            cboDocumento.DataSource = new BindingSource(tipoDocumentoSource, null);
                            cboDocumento.DisplayMember = "Value";
                            cboDocumento.ValueMember = "Key";
                        }
                    }                    
                }
            }
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.OK;
        }
    }
}
