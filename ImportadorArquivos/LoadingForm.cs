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
    public partial class LoadingForm : Form
    {
        public Action Worker { get; set; }

        public LoadingForm(Action wrkr)
        {
            InitializeComponent();
            if (wrkr == null)
               throw new ArgumentNullException();
            Worker = wrkr;
        }

        private void LoadingForm_Load(object sender, EventArgs e)
        {
            Task.Factory.StartNew(Worker).ContinueWith(t =>
            {
                this.Close();

                using (SuccessForm form = new SuccessForm())
                {
                    form.ShowDialog(this);
                }
            }, TaskScheduler.FromCurrentSynchronizationContext());
        }
    }
}
