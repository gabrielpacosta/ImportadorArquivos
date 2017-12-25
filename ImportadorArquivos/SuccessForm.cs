using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ImportadorArquivos
{
    public partial class SuccessForm : Form
    {
        public static string linhasProcessadas;
        public SuccessForm()
        {
            InitializeComponent();
        }

        private void SuccessForm_Load(object sender, EventArgs e)
        {
            System.Media.SystemSounds.Beep.Play();
            lblSuccess.Text = $"{linhasProcessadas} linhas processadas.";
        }

        private void btnOk_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
