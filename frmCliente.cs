namespace AdoNetCodingConectado
{
    public partial class frmCliente : Form
    {
        public frmCliente()
        {
            InitializeComponent();
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            var frm = new frmClienteEdit();
            frm.ShowDialog();
        }
    }
}