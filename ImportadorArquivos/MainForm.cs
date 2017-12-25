using System;
using System.Windows.Forms;
using ImportadorArquivos.Controller;
using ImportadorArquivos.Model;

namespace ImportadorArquivos
{
    public partial class Main : Form
    {
        string arquivoCA, arquivoRec;

        public Main()
        {
            InitializeComponent();
        }

        private void btnImportarCA_Click(object sender, EventArgs e)
        {
            if ((txbDirArquivoCA.Text == null) || (txbDirArquivoRec.Text == null))
            {
                MessageBox.Show("Preencha todos os campos obrigatórios.", "Erro!", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            {
                CarteiraAtual.Data_Arquivo = dateTimePickerCA.Value;
                Action action = () => CarteiraAtualController.UploadCarteiraAtual(arquivoCA);
                using (LoadingForm form = new LoadingForm(action))
                {
                    form.ShowDialog(this);
                }
            }
        }

        private void btnProcurarCA_Click(object sender, EventArgs e)
        {
            if (openFileDialogCA.ShowDialog() == DialogResult.OK)
            {
                txbDirArquivoCA.Text = openFileDialogCA.FileName;
                arquivoCA = openFileDialogCA.FileName;
            }
        }

        private void btnProcurarRec_Click(object sender, EventArgs e)
        {
            if (openFileDialogRec.ShowDialog() == DialogResult.OK)
            {
                txbDirArquivoRec.Text = openFileDialogRec.FileName;
                arquivoRec = openFileDialogRec.FileName;
            }
        }

        private void btnProcurarConn_Click(object sender, EventArgs e)
        {
            if (openFileDialogConn.ShowDialog() == DialogResult.OK)
            {
                txbConn.Text = openFileDialogConn.FileName;
                _Global.ConnectionString = System.IO.File.ReadAllLines(txbConn.Text)[0];
            }
        }

        private void btnImportarRec_Click(object sender, EventArgs e)
        {
            if ((txbDirArquivoRec.Text == null) || (txbDirArquivoRec.Text == null))
            {
                MessageBox.Show("Preencha todos os campos obrigatórios.", "Erro!", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            {
                Action action = () => RecAssController.UploadRecAss(arquivoRec);
                using (LoadingForm form = new LoadingForm(action))
                {
                    form.ShowDialog(this);
                }
           }
        }
    }
}
