using System.Data.SqlClient;

namespace AdoNetCodingConectado
{
    public partial class frmCliente : Form
    {
        string cadenaConexion = "server=localhost; database=Financiera; Integrated Security = true;";
        public frmCliente()
        {
            InitializeComponent();
        }

        private void tsbAdd_Click(object sender, EventArgs e)
        {
            var frm = new frmClienteEdit();
            if(frm.ShowDialog() == DialogResult.OK)
            {
                var nombre = ((TextBox)frm.Controls["txtNombre"]).Text;
                var apellido = ((TextBox)frm.Controls["txtApellidos"]).Text;
                var tipoCliente = ((ComboBox)frm.Controls["cboTipo"]).SelectedValue.ToString();
                var tipoDocumento = ((ComboBox)frm.Controls["cboDocumento"]).SelectedValue.ToString();
                var direccion = ((TextBox)frm.Controls["txtDireccion"]).Text;
                var referencia = ((TextBox)frm.Controls["txtReferencia"]).Text;

                using(var conexion = new SqlConnection(cadenaConexion))
                {
                    conexion.Open();
                    var sql = "INSERT INTO Cliente (Nombres ,Apellidos, Direccion, " +
                        "Referencia, IdTipoCliente, IdTipoDocumento) " +
                        "VALUES(@nombre, @apellido, @direccion, @referencia, " +
                        "@tipoCliente, @tipoDocumento)";

                    using(var comando = new SqlCommand(sql, conexion))
                    {
                        comando.Parameters.AddWithValue("@nombre", nombre);
                        comando.Parameters.AddWithValue("@apellido", apellido);
                        comando.Parameters.AddWithValue("@direccion", direccion);
                        comando.Parameters.AddWithValue("@referencia", referencia);
                        comando.Parameters.AddWithValue("@tipoCliente", tipoCliente);
                        comando.Parameters.AddWithValue("@tipoDocumento", tipoDocumento);
                        int resultado = comando.ExecuteNonQuery();
                        if (resultado > 0)
                        {
                            MessageBox.Show("El cliente ha sido registrado", "Sistemas", 
                                MessageBoxButtons.OK, MessageBoxIcon.Information);
                        }
                        else
                        {
                            MessageBox.Show("El proceso de creación del cliente ha fallado.", "Sistemas",
                                MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                    }
                }
            }
        }
    }
}